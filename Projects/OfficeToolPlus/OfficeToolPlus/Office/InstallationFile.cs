using OTP.List;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace OTP
{
    // Copyright © 2019 Landiannews | By Yerong | https://otp.landian.vip/
    class InstallationFile
    {
        private readonly List<InstallationFileList> lists = new List<InstallationFileList>();

        private readonly bool FileExists = true;
        internal readonly bool HasOtherChar = false;
        internal readonly bool MultiplePlatform = false;
        public InstallationFile(string InstallationPath)
        {
            DirectoryInfo d = new DirectoryInfo(InstallationPath + "\\Office\\Data\\");
            if (d.Exists == false)
            {
                return;
            }
            DirectoryInfo[] ds = d.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            if (ds.Length == 0)
            {
                return;
            }
            bool bit64 = false;
            bool bit86 = false;
            List<string> file = new List<string>(10);
            LanguageList languageList = new LanguageList();
            foreach (DirectoryInfo var in ds)
            {
                if (File.Exists(InstallationPath + "\\Office\\Data\\v64.cab") && File.Exists(InstallationPath + "\\Office\\Data\\v64_" + var.Name + ".cab")) //64位文件检测
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
                if (File.Exists(InstallationPath + "\\Office\\Data\\v32.cab") && File.Exists(InstallationPath + "\\Office\\Data\\v32_" + var.Name + ".cab"))//32位文件检测
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
                string platform = "v32_";
                lists[i].Language = new List<string>(10);
                foreach (LangInfo lang in languageList.GetList())
                {
                    if (lists[i].Is32Platform == true)
                    {
                        if (File.Exists(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\" + "stream.x86." + lang.ID + ".dat"))//检测对应的安装文件是否存在
                        {
                            lists[i].Language.Add(lang.ID);
                            file.Clear();
                            if (lang.Type == LanguageType.Full)
                            {
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i32" + lang.Num + ".cab");
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i64" + lang.Num + ".cab");
                            }
                            file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\s32" + lang.Num + ".cab");
                            for (int n = 0; n < file.Count; n++)
                            {
                                if (File.Exists(file[n].ToString()) == false)//文件检测
                                {
                                    lists[i].HasError = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        platform = "v64_";
                        if (File.Exists(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\" + "stream.x64." + lang.ID + ".dat"))//检测对应的安装文件是否存在
                        {
                            lists[i].Language.Add(lang.ID);
                            file.Clear();
                            if (lang.Type == LanguageType.Full)
                            {
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i64" + lang.Num + ".cab");
                            }
                            file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\s64" + lang.Num + ".cab");
                            for (int n = 0; n < file.Count; n++)
                            {
                                if (File.Exists(file[n].ToString()) == false)//文件检测
                                {
                                    lists[i].HasError = true;
                                }
                            }
                        }
                    }
                }
                if (lists[i].HasError == false)
                {
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
                if (lists[i].Version == lists[i - 1].Version && lists[i].HasError == lists[i - 1].HasError)
                {
                    lists[i - 1].Is32Platform = null;
                    lists.RemoveAt(i);
                }
            }
            for (int i = 0; i < InstallationPath.Length; i++)
            {
                if (InstallationPath[i] > 127)
                {
                    HasOtherChar = true;
                }
            }
        }

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