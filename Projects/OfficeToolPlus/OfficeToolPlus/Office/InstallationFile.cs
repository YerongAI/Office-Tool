using OfficeTool.List;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace OfficeTool
{
    // Copyright © 2020 蓝点网 | By Yerong | https://otp.landian.vip/
    /// <summary>
    /// Check Office Installation
    /// </summary>
    class InstallationFile
    {
        private readonly List<InstallationFileList> lists = new List<InstallationFileList>();

        private readonly bool FileExists = true;
        internal readonly bool HasOtherChar = false;
        internal readonly bool MultiplePlatform = false;

        /// <summary>
        /// Check Office Installation
        /// </summary>
        /// <param name="InstallationPath">Office Installation Path (Don't include "\Office\Data\").</param>
        public InstallationFile(string InstallationPath)
        {
            DirectoryInfo d = new DirectoryInfo(InstallationPath + "\\Office\\Data\\");
            if (d.Exists == false)
            {
                // If directory is empty, return.
                return;
            }
            DirectoryInfo[] ds = d.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            if (ds.Length == 0)
            {
                // If directory is empty, return.
                return;
            }
            bool bit64 = false;
            bool bit86 = false;
            List<string> file = new List<string>(10);
            LanguageList languageList = new LanguageList();
            // Check all versions of Office installation
            foreach (DirectoryInfo var in ds)
            {
                // Check 64 bit of installation
                if (File.Exists(InstallationPath + "\\Office\\Data\\v64.cab") && File.Exists(InstallationPath + "\\Office\\Data\\v64_" + var.Name + ".cab"))
                {
                    bit64 = true;
                    file.Clear();
                    file.Add("\\Office\\Data\\v64_" + var.Name + ".cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\i640.cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\s640.cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\stream.x64.x-none.dat");
                    for (int n = 0; n < file.Count - 1; n++)
                    {
                        if (File.Exists(InstallationPath + file[n].ToString()) == false)
                        {
                            FileExists = false;
                            bit64 = false;
                        }
                    }
                    if (FileExists)
                    {
                        InstallationFileList item = new InstallationFileList(var.Name, false, false, "");
                        lists.Add(item);
                    }
                }
                // Check 32 bit of installation
                if (File.Exists(InstallationPath + "\\Office\\Data\\v32.cab") && File.Exists(InstallationPath + "\\Office\\Data\\v32_" + var.Name + ".cab"))
                {
                    bit86 = true;
                    file.Clear();
                    file.Add("\\Office\\Data\\v32_" + var.Name + ".cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\i320.cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\i640.cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\s320.cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\stream.x86.x-none.dat");
                    for (int n = 0; n < file.Count - 1; n++)
                    {
                        if (File.Exists(InstallationPath + file[n].ToString()) == false)
                        {
                            FileExists = false;
                            bit86 = false;
                        }
                    }
                    if (FileExists)
                    {
                        InstallationFileList item = new InstallationFileList(var.Name, true, false, "");
                        lists.Add(item);
                    }
                }
            }
            if (bit86 == bit64 && bit86 == true)
            {
                MultiplePlatform = true;
            }
            else if (bit86 == bit64)
            {
                FileExists = false;
                return;
            }
            for (int i = 0; i < lists.Count; i++)
            {
                // Check all language packs of each installation.
                string platform = "v32_";
                lists[i].Language = new List<string>(10);
                foreach (LangInfo lang in languageList.GetList())
                {
                    if (lists[i].Is32Platform == true)
                    {
                        // Check dat file.
                        if (File.Exists(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\" + "stream.x86." + lang.ID + ".dat"))
                        {
                            lists[i].Language.Add(lang.ID);
                            file.Clear();
                            if (lang.Type == LanguageType.Full)
                            {
                                // If language type is Full, this files should be included.
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i32" + lang.Num + ".cab");
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i64" + lang.Num + ".cab");
                            }
                            file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\s32" + lang.Num + ".cab");
                            // Check all required files
                            for (int n = 0; n < file.Count; n++)
                            {
                                if (File.Exists(file[n].ToString()) == false)
                                {
                                    lists[i].HasError = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        platform = "v64_";
                        // Check dat file.
                        if (File.Exists(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\" + "stream.x64." + lang.ID + ".dat"))
                        {
                            lists[i].Language.Add(lang.ID);
                            file.Clear();
                            if (lang.Type == LanguageType.Full)
                            {
                                // If language type is Full, the file should be included.
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i64" + lang.Num + ".cab");
                            }
                            file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\s64" + lang.Num + ".cab");
                            // Check all required files
                            for (int n = 0; n < file.Count; n++)
                            {
                                if (File.Exists(file[n].ToString()) == false)
                                {
                                    lists[i].HasError = true;
                                }
                            }
                        }
                    }
                }
                if (lists[i].HasError == false)
                {
                    // Check installtion Channel information if no errors.
                    string path = Environment.GetEnvironmentVariable("temp");
                    Process process = new Process();
                    try
                    {
                        process.StartInfo.FileName = "expand";
                        process.StartInfo.Arguments = "-F:*.xml \"" + InstallationPath + "\\Office\\Data\\" + platform + lists[i].Version + ".cab\" " + path;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.Start();
                        process.WaitForExit(30000);
                        if (File.Exists(path + "\\VersionDescriptor.xml"))
                        {
                            XElement loadxml = XElement.Load(path + "\\VersionDescriptor.xml");
                            XElement xml = loadxml.Element("DeliveryMechanism");
                            lists[i].FFN = xml.Attribute("FFNRoot").Value;
                            File.Delete(path + "\\VersionDescriptor.xml");
                        }
                    }
                    catch { }
                    finally
                    {
                        process.Dispose();
                    }
                }
            }
            for (int i = lists.Count - 1; i > 0; i--)
            {
                // If the same version of Office exists, set the platform to all, means include 32 bit and 64 bit.
                if (lists[i].Version == lists[i - 1].Version && lists[i].HasError == lists[i - 1].HasError)
                {
                    lists[i - 1].Is32Platform = null;
                    lists.RemoveAt(i);
                }
            }
            for (int i = 0; i < InstallationPath.Length; i++)
            {
                // Check the installation path if include non-English char or not.
                if (InstallationPath[i] > 127)
                {
                    HasOtherChar = true;
                }
            }
        }

        /// <summary>
        /// Get all installations version
        /// </summary>
        /// <returns>Return the string of all version.</returns>
        public string GetAllVersionList()
        {
            string ver = string.Empty;
            for (int i = 0; i < lists.Count; i++)
            {
                ver += lists[i].Version + ",";
            }
            return ver.Remove(ver.Length - 1);
        }

        public List<InstallationFileList> GetInstallations()
        {
            return lists;
        }

        public int Count()
        {
            return lists.Count;
        }
    }

    class InstallationFileList
    {
        public InstallationFileList(string Version, bool? Is32Platform, bool HasError, string FFN)
        {
            this.Version = Version;
            this.Is32Platform = Is32Platform;
            this.HasError = HasError;
            this.FFN = FFN;
        }

        public string Version { get; }
        public List<string> Language { get; set; }
        public bool? Is32Platform { get; set; }
        public bool HasError { get; set; }
        public string FFN { get; set; }
    }
}