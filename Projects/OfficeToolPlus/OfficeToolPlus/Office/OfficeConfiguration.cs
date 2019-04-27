using Microsoft.Win32;
using System.Collections.Generic;

namespace OTP
{
	//Copyright © 2019 Landiannews |By Yerong | https://otp.landian.vip/
    class OfficeConfiguration
    {
        internal bool HasOffice;
        internal string ClickToRunLanguage;
        internal string ProductOwner;
        internal bool UpdateEnabled;
        internal string UpdateChannel;
        internal bool ChannelChanged;

        public OfficeConfiguration()
        {
            InstalledProductName = new List<string>();
            try
            {
                RegistryKey localKey;
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration");
                if (subKey == null)
                {
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration");
                    if (subKey == null)
                    {
                        HasOffice = false;
                        return;
                    }
                }
                HasOffice = true;
                object h = subKey.GetValue("InstallationPath");//安装路径
                if (h != null)
                {
                    InstallPath = h.ToString();
                }
                h = subKey.GetValue("VersionToReport");//当前通道版本号
                if (h != null)
                {
                    OfficeVersion = h.ToString();
                }
                h = subKey.GetValue("ClientVersionToReport");//Client版本号
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
                h = subKey.GetValue("ProductReleaseIds");//已安装产品
                if (h != null)
                {
                    string registData = h.ToString();
                    InstalledProduct = registData.Split(',');
                    foreach (string id in InstalledProduct)
                    {
                        RegistryKey registryKey;
                        if (OfficePlatform == "x32")
                        {
                            registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                        }
                        else
                        {
                            registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                        }
                        RegistryKey keys = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                        foreach (string s in keys.GetSubKeyNames())
                        {
                            if (s.Contains(id))
                            {
                                RegistryKey key = keys.OpenSubKey(s);
                                if ((h = key.GetValue("DisplayName")) != null)
                                {
                                    InstalledProductName.Add(h.ToString() + " - " + id);
                                }
                            }
                        }
                    }
                }
                h = subKey.GetValue("Platform");//体系架构
                if (h != null)
                {
                    OfficePlatform = h.ToString();
                }
                h = subKey.GetValue("ClientCulture");
                if (h != null)
                {
                    ClickToRunLanguage = h.ToString();
                }
                h = subKey.GetValue("ClientFolder");//Client所在目录
                if (h != null)
                {
                    ClickToRunPath = h.ToString();
                }
                foreach (string item in InstalledProduct)
                {
                    h = subKey.GetValue(item + ".EmailAddress");//拥有者
                    if (h != null)
                    {
                        ProductOwner = h.ToString();
                    }
                }
                h = subKey.GetValue("UpdatesEnabled");//是否自动更新
                if (h != null)
                {
                    if (h.ToString() == "True")
                    {
                        UpdateEnabled = true;
                    }
                    else
                    {
                        UpdateEnabled = false;
                    }
                }
                h = subKey.GetValue("UpdateChannel");//更新通道
                if (h != null)
                {
                    string registData = h.ToString().ToLower();
                    UpdateChannel = registData;
                }
                subKey.Close();
            }
            catch
            {
                throw;
            }
        }

        public bool Save()
        {
            try
            {
                RegistryKey localKey;
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
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
                    subKey.SetValue("UpdateChannel", UpdateChannel);
                    subKey.SetValue("CDNBaseUrl", UpdateChannel);
                    //subKey.SetValue("AudienceId", UpdateChannel.Replace(CDNLink, ""));
                }
                foreach (string item in InstalledProduct)
                {
                    subKey.SetValue(item + ".EmailAddress", ProductOwner);
                }
                subKey.SetValue("UpdatesEnabled", UpdateEnabled.ToString());
                subKey.SetValue("UpdateChannelChanged", ChannelChanged.ToString());
                return true;
            }
            catch
            {
                throw;
            }
        }

        public List<string> InstalledProductName { get; }
        public string[] InstalledProduct { get; }
        public string OfficeVersion { get; }
        public string OfficePlatform { get; }
        public string InstallPath { get; }
        public string ClickToRunVersion { get; }
        public string ClickToRunPath { get; }
    }
}