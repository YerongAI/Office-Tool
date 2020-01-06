using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace OfficeTool
{
    // Copyright © 2020 蓝点网 | By Yerong | https://otp.landian.vip/
    class OfficeConfiguration
    {
        internal List<InstalledProducts> InstalledProductsList { get; set; } = new List<InstalledProducts>(3);
        internal bool HasOffice { get; set; } = false;
        internal string ClickToRunLanguage { get; set; }
        internal string UpdateChannel { get; set; }
        internal bool ChannelChanged { get; set; }
        internal string ProductOwner { get; set; }

        /// <summary>
        /// Load Office Configuration information
        /// </summary>
        public OfficeConfiguration()
        {
            RegistryKey localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            try
            {
                RegistryKey subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration");
                if (subKey == null)
                {
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration");
                    if (subKey == null)
                    {
                        return;
                    }
                }
                object h = subKey.GetValue("InstallationPath");
                if (h != null)
                {
                    InstallPath = h.ToString();
                }
                h = subKey.GetValue("ClientVersionToReport");
                if (h != null)
                {
                    string registData = h.ToString();
                    ClickToRunVersion = registData;
                }
                h = subKey.GetValue("UpdateChannelChanged");
                if (h != null)
                {
                    if (h.ToString() == "True")
                    {
                        ChannelChanged = true;
                    }
                    else
                    {
                        ChannelChanged = false;
                    }
                }
                else
                {
                    ChannelChanged = false;
                }
                h = subKey.GetValue("Platform");
                if (h != null)
                {
                    OfficePlatform = h.ToString();
                }
                h = subKey.GetValue("ClientCulture");
                if (h != null)
                {
                    ClickToRunLanguage = h.ToString();
                    Languages = new List<string>
                    {
                        ClickToRunLanguage
                    };
                }
                h = subKey.GetValue("ClientFolder");
                if (h != null)
                {
                    ClickToRunPath = h.ToString();
                }
                h = subKey.GetValue("UpdateChannel");
                if (h != null)
                {
                    string registData = h.ToString().ToLower();
                    UpdateChannel = registData;
                }
                h = subKey.GetValue("ProductReleaseIds");
                if (h != null)
                {
                    // Get the all installed products
                    string registData = h.ToString();
                    subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration");

                    RegistryKey tempKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\ProductReleaseIDs");
                    string path = tempKey.GetValue("ActiveConfiguration").ToString();
                    tempKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\ProductReleaseIDs\" + path);
                    // Foreach all installed products information
                    foreach (string id in registData.Split(','))
                    {
                        string excludeApps = string.Empty;
                        string owner = string.Empty;
                        string version = string.Empty;

                        h = subKey.GetValue(id + ".ExcludedApps");
                        if (h != null)
                            excludeApps = h.ToString();
                        h = subKey.GetValue(id + ".EmailAddress");
                        if (h != null)
                            owner = h.ToString();

                        foreach (string s in tempKey.GetSubKeyNames())
                        {
                            if (s.Contains(id))
                            {
                                RegistryKey temp = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\ProductReleaseIDs\" + path + @"\" + s);
                                foreach (string lang in temp.GetSubKeyNames())
                                {
                                    if (!lang.Contains("x-none"))
                                    {
                                        if (!Languages.Contains(lang))
                                            Languages.Add(lang);
                                    }
                                    else if (lang.Contains("x-none"))
                                    {
                                        temp = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\ProductReleaseIDs\" + path + @"\" + s + @"\" + lang);
                                        if ((h = temp.GetValue("Version")) != null)
                                        {
                                            version = h.ToString();
                                        }
                                    }
                                }
                            }
                        }

                        InstalledProducts products = new InstalledProducts(id, excludeApps, owner, version);
                        InstalledProductsList.Add(products);
                        HasOffice = true;
                    }
                }
                subKey.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                localKey.Close();
            }
        }

        public bool Save()
        {
            RegistryKey localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            try
            {
                RegistryKey subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration", true);
                if (subKey == null)
                {
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration", true);
                    if (subKey == null)
                    {
                        return false;
                    }
                }
                if (ClickToRunLanguage != null)
                {
                    subKey.SetValue("ClientCulture", ClickToRunLanguage);
                }
                if (UpdateChannel != null)
                {
                    object h = subKey.GetValue("UpdateChannel");
                    if (h != null)
                    {
                        string registData = h.ToString().ToLower();
                        if (registData != UpdateChannel)
                        {
                            RegistryKey tempSubKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration", true);
                            tempSubKey.DeleteValue("UpdateUrl", false);
                            tempSubKey.DeleteValue("UpdateToVersion", false);
                            tempSubKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Updates", true);
                            tempSubKey.DeleteValue("UpdateToVersion", false);
                        }
                    }
                    subKey.SetValue("UpdateChannel", UpdateChannel);
                    subKey.SetValue("CDNBaseUrl", UpdateChannel);
                }
                foreach (InstalledProducts item in InstalledProductsList)
                {
                    subKey.SetValue(item.ProductID + ".EmailAddress", ProductOwner);
                }
                subKey.SetValue("UpdateChannelChanged", ChannelChanged.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                localKey.Close();
            }
        }

        public class InstalledProducts
        {
            public InstalledProducts(string productID, string excludeApps, string owner, string version)
            {
                ProductID = productID;
                ExcludeApps = excludeApps;
                Owner = owner;
                Version = version;
            }

            public string ProductID { get; set; }
            public string ExcludeApps { get; set; }
            public string Owner { get; set; }
            public string Version { get; set; }
        }

        public string OfficePlatform { get; }
        public string InstallPath { get; }
        public string ClickToRunVersion { get; }
        public string ClickToRunPath { get; }
        public List<string> Languages { get; set; }
    }
}