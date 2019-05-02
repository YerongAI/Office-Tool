using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace OTP
{
    //Copyright © 2019 Landiannews | By Yerong | https://otp.landian.vip/
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
            List.LanguageList languageList = new List.LanguageList();
            foreach (DirectoryInfo var in ds)
            {
                if (File.Exists(InstallationPath + "\\Office\\Data\\v64.cab") && File.Exists(InstallationPath + "\\Office\\Data\\v64_" + var.Name + ".cab")) //64位文件检测
                {
                    bit64 = true;
                    file.Clear();
                    file.Add("\\Office\\Data\\v64_" + var.Name + ".cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\i640.cab");
                    file.Add("\\Office\\Data\\" + var.Name + "\\s640.cab");
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
                        if (File.Exists(InstallationPath + "\\Office\\Data\\" + var.Name + "\\stream.x64.x-none.dat") == true)
                        {
                            InstallationFileList item = new InstallationFileList(var.Name, false, null, false, "");
                            lists.Add(item);
                        }
                        else
                        {
                            InstallationFileList item = new InstallationFileList(var.Name, false, false, false, "");
                            lists.Add(item);
                        }
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
                        if (File.Exists(InstallationPath + "\\Office\\Data\\" + var.Name + "\\stream.x86.x-none.dat") == true)
                        {
                            InstallationFileList item = new InstallationFileList(var.Name, true, null, false, "");
                            lists.Add(item);
                        }
                        else
                        {
                            InstallationFileList item = new InstallationFileList(var.Name, true, false, false, "");
                            lists.Add(item);
                        }
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
                lists[i].Language = new List<string>(10);
                foreach (string id in languageList.GetIDs())
                {
                    string num = languageList.GetInfByID(id, List.LanguageType.Num).ToString();
                    string type = languageList.GetInfByID(id, List.LanguageType.Type).ToString();
                    if (lists[i].Is32Platform)
                    {
                        if (File.Exists(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\" + "stream.x86." + id + ".dat"))//检测对应的安装文件是否存在
                        {
                            lists[i].Language.Add(id);
                            file.Clear();
                            if (type == "Full")
                            {
                                if (lists[i].IsFullPack == null)
                                    lists[i].IsFullPack = true;
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i32" + num + ".cab");
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i64" + num + ".cab");
                            }
                            else if (lists[i].IsFullPack == null)
                                lists[i].IsFullPack = false;
                            file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\s32" + num + ".cab");
                            for (int n = 0; n < file.Count; n++)
                            {
                                if (File.Exists(file[n].ToString()) == false)//文件检测
                                {
                                    lists[i].HasError = true;
                                }
                            }
                            if (lists[i].HasError == false)
                            {
                                string path = Environment.GetEnvironmentVariable("temp");
                                try
                                {
                                    Process process = new Process();
                                    process.StartInfo.FileName = "expand";
                                    process.StartInfo.Arguments = "-F:*.xml \"" + InstallationPath + "\\Office\\Data\\" + "v32_" + lists[i].Version + ".cab\" " + path;
                                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                    process.Start();
                                    process.WaitForExit(30000);
                                    XElement loadxml = XElement.Load(path + "\\VersionDescriptor.xml");
                                    XElement xml = loadxml.Element("DeliveryMechanism");
                                    lists[i].FFN = xml.Attribute("FFNRoot").Value;
                                    File.Delete(path + "\\VersionDescriptor.xml");
                                }
                                catch { }
                            }
                        }
                    }
                    else
                    {
                        if (File.Exists(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\" + "stream.x64." + id + ".dat"))//检测对应的安装文件是否存在
                        {
                            lists[i].Language.Add(id);
                            file.Clear();
                            if (type == "Full")
                            {
                                if (lists[i].IsFullPack == null)
                                    lists[i].IsFullPack = true;
                                file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\i64" + num + ".cab");
                            }
                            else if (lists[i].IsFullPack == null)
                                lists[i].IsFullPack = false;
                            file.Add(InstallationPath + "\\Office\\Data\\" + lists[i].Version + "\\s64" + num + ".cab");
                            for (int n = 0; n < file.Count; n++)
                            {
                                if (File.Exists(file[n].ToString()) == false)//文件检测
                                {
                                    lists[i].HasError = true;
                                }
                            }
                            if (lists[i].HasError == false)
                            {
                                string path = Environment.GetEnvironmentVariable("temp");
                                try
                                {
                                    Process process = new Process();
                                    process.StartInfo.FileName = "expand";
                                    process.StartInfo.Arguments = "-F:*.xml \"" + InstallationPath + "\\Office\\Data\\" + "v64_" + lists[i].Version + ".cab\" " + path;
                                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                    process.Start();
                                    process.WaitForExit(30000);
                                    XElement loadxml = XElement.Load(path + "\\VersionDescriptor.xml");
                                    XElement xml = loadxml.Element("DeliveryMechanism");
                                    lists[i].FFN = xml.Attribute("FFNRoot").Value;
                                    File.Delete(path + "\\VersionDescriptor.xml");
                                }
                                catch { }
                            }
                        }
                    }
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
                ver += lists[i].Version + " - " + lists[i].Is32Platform.ToString().Replace("True", "x86").Replace("False", "x64") + ",";
            }
            return ver.Remove(ver.Length - 1);
        }

        public string GetVersion(int index)
        {
            return lists[index].Version;
        }

        public List<string> GetLanguage(int index)
        {
            return lists[index].Language;
        }

        public bool Is32Platform(int index)
        {
            return lists[index].Is32Platform;
        }

        public bool? IsFullPack(int index)
        {
            return lists[index].IsFullPack;
        }

        public bool HasError(int index)
        {
            return lists[index].HasError;
        }

        public string GetFFN(int index)
        {
            return lists[index].FFN;
        }

        public int Count()
        {
            return lists.Count;
        }
    }

    class InstallationFileList
    {
        public InstallationFileList(string Version, bool Is32Platform, bool? IsFullPack, bool HasError, string FFN)
        {
            this.Version = Version;
            this.Is32Platform = Is32Platform;
            this.IsFullPack = IsFullPack;
            this.HasError = HasError;
            this.FFN = FFN;
        }

        public string Version { get; }
        public List<string> Language { get; set; }
        public bool Is32Platform { get; }
        public bool? IsFullPack { get; set; }
        public bool HasError { get; set; }
        public string FFN { get; set; }
    }
}