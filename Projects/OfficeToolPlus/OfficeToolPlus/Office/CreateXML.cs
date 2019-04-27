using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace OTP
{
    class CreateXML
    {
        private static readonly List<InstallConfig> ProductConfigList = new List<InstallConfig>(2);
        private static readonly List<Property> PropertyList = new List<Property>(1);

        public class InstallArguments
        {
            // Info Element
            internal string Description = string.Empty;
            // CompanyName Element
            internal string CompanyName = string.Empty;
            // Add Element
            internal string SourcePath = string.Empty;
            internal string Version;
            internal string OfficeClientEdition;
            internal string Channel;
            internal string DownloadPath;
            internal bool? OfficeMgmtCOM;
            internal bool ForceUpgrade;
            internal bool AllowCdnFallback;
            // Display Element
            internal bool DisplayLevel;
            internal bool AcceptEULA;
            // Logging Element
            internal bool? LoggingLevel;
            internal string LoggingPath;
            // Updates Element
            internal bool? UpdateEnabled;
            internal string UpdatePath = string.Empty;
            internal string TargetVersion = string.Empty;
            internal string Deadline = string.Empty;
            internal string UpdateChannel = string.Empty;
            // RemoveMSI Element
            internal bool RemoveMSI;
            internal string[] IgnoreProduct;
            // Remove Element
            private bool RemoveOffice;

            /// <summary>
            /// 构建安装文件配置
            /// </summary>
            public InstallArguments()
            {
                //ProductConfigList.Clear();
                //PropertyList.Clear();
                OfficeMgmtCOM = null;
                ForceUpgrade = false;
                AllowCdnFallback = false;
                DisplayLevel = false;
                AcceptEULA = false;
                LoggingLevel = null;
                UpdateEnabled = null;
                RemoveMSI = false;
                LoggingPath = "%temp%";
            }

            /// <summary>
            /// 构建安装文件配置
            /// </summary>
            /// <param name="rebuild">是否重建元素</param>
            public InstallArguments(bool rebuild)
            {
                if (rebuild)
                {
                    ProductConfigList.Clear();
                    PropertyList.Clear();
                    OfficeMgmtCOM = null;
                    ForceUpgrade = false;
                    AllowCdnFallback = false;
                    DisplayLevel = false;
                    AcceptEULA = false;
                    LoggingLevel = null;
                    UpdateEnabled = null;
                    RemoveMSI = false;
                    LoggingPath = "%temp%";
                }
            }

            /// <summary>
            /// 添加新的产品
            /// </summary>
            /// <param name="ProductID">产品 ID</param>
            /// <param name="LanguageID">产品的语言</param>
            public void AddProduct(string ProductID, string[] LanguageID)
            {
                InstallConfig arguments = new InstallConfig(ProductID, "", LanguageID, "", null);
                ProductConfigList.Add(arguments);
            }

            /// <summary>
            /// 添加新的产品
            /// </summary>
            /// <param name="ProductID">产品 ID</param>
            /// <param name="LanguageID">产品的语言</param>
            /// <param name="ExcludeApps">指定要排除的应用程序 ID</param>
            public void AddProduct(string ProductID, string MAK, string[] LanguageID, string[] ExcludeApps)
            {
                InstallConfig arguments = new InstallConfig(ProductID, MAK, LanguageID, "", ExcludeApps);
                ProductConfigList.Add(arguments);
            }

            /// <summary>
            /// 添加新的产品
            /// </summary>
            /// <param name="ProductID">产品 ID</param>
            /// <param name="LanguageID">产品的语言</param>
            /// <param name="ExcludeApps">指定要排除的应用程序 ID</param>
            public void AddProduct(string ProductID, string MAK, string[] LanguageID, string FallbackLanguage, string[] ExcludeApps)
            {
                InstallConfig arguments = new InstallConfig(ProductID, MAK, LanguageID, FallbackLanguage, ExcludeApps);
                ProductConfigList.Add(arguments);
            }

            /// <summary>
            /// 添加 Property 元素
            /// </summary>
            /// <param name="Name">需要定义的属性</param>
            /// <param name="Value">属性的值</param>
            public void AddProperty(string Name, string Value)
            {
                Property property = new Property(Name, Value);
                PropertyList.Add(property);
            }

            /// <summary>
            /// 设置此配置文件是否用于 Remove Office，如果需要移除特定的产品，请使用 AddProduct 指定
            /// </summary>
            /// <param name="removeOffice">定义是否将 Office 产品移除</param>
            public void SetRemoveOffice(bool removeOffice)
            {
                RemoveOffice = removeOffice;
            }

            /// <summary>
            /// 获取指定元素的产品 ID，index 指定元素下标
            /// </summary>
            public string GetProduct(int index)
            {
                if (index >= ProductConfigList.Count)
                    throw new Exception("Index out of list length!");
                else
                    return ProductConfigList[index].ProductID;
            }

            /// <summary>
            /// 获取指定元素的MAK，index 指定元素下标
            /// </summary>
            public string GetMAK(int index)
            {
                if (index >= ProductConfigList.Count)
                    throw new Exception("Index out of list length!");
                else if (GetProduct(index).Contains("Volume"))
                    return ProductConfigList[index].MAK;
                else
                    return string.Empty;
            }

            /// <summary>
            /// 获取指定元素的语言 ID，index 指定元素下标
            /// </summary>
            public string[] GetLanguage(int index)
            {
                if (index >= ProductConfigList.Count)
                    throw new Exception("Index out of list length!");
                else
                    return ProductConfigList[index].LanguageID;
            }

            /// <summary>
            /// 获取指定元素的排除的应用程序，index 指定元素下标
            /// </summary>
            public string[] GetExcludeApp(int index)
            {
                if (index >= ProductConfigList.Count)
                    throw new Exception("Index out of list length!");
                else
                    return ProductConfigList[index].ExcludeApps;
            }

            /// <summary>
            /// 获取列表的元素数量
            /// </summary>
            public int Length()
            {
                return ProductConfigList.Count;
            }

            /// <summary>
            /// 清空所有的元素
            /// </summary>
            public void Clear()
            {
                ProductConfigList.Clear();
            }

            /// <summary>
            /// 建立 XML 文件
            /// </summary>
            /// <param name="FilePath">文件保存路径</param>
            /// <param name="FileName">文件名</param>
            public void CreateXMLFile(string FilePath, string FileName)
            {
                try
                {
                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        Encoding = new System.Text.UTF8Encoding(true),
                        Indent = true,
                        OmitXmlDeclaration = true
                    };
                    XmlWriter xw = XmlWriter.Create(FilePath + FileName, settings);
                    XElement RootElement = new XElement("Configuration");
                    if (RemoveOffice != true)
                    {
                        if (Description != string.Empty)
                        {
                            XElement description = new XElement("Info", new XAttribute("Description", Description));
                            RootElement.Add(description);
                        }
                        //Add 内容
                        XElement AddElementTemp = new XElement("Add",
                                           new XAttribute("OfficeClientEdition", OfficeClientEdition),//指定体系架构
                                           new XAttribute("Channel", Channel),//指定更新通道
                                           new XAttribute("SourcePath", SourcePath),//指定安装文件位置
                                           new XAttribute("DownloadPath", DownloadPath),//指定下载位置
                                           new XAttribute("Version", Version),//指定要安装的版本
                                           new XAttribute("ForceUpgrade", ForceUpgrade.ToString().Replace("False", "").ToUpper()),
                                           new XAttribute("AllowCdnFallback", AllowCdnFallback.ToString().Replace("False", "")),
                                           new XAttribute("OfficeMgmtCOM", OfficeMgmtCOM.ToString().Replace("null", "")));//指定是否使用配置管理器管理更新

                        XElement AddElement = new XElement("Add",
                                            from el in AddElementTemp.Attributes()
                                            where (string)el != string.Empty
                                            select el);

                        for (int i = 0; i < ProductConfigList.Count; i++)
                        {
                            XElement LangElemtnt = new XElement("Product");
                            foreach (string LangID in ProductConfigList[i].LanguageID)
                            {
                                if (LangID != null)
                                {
                                    if (ProductConfigList[i].FallbackLanguage != string.Empty)
                                    {
                                        XElement LanguageElemtnt = new XElement("Language",
                                                                   new XAttribute("ID", LangID),
                                                                   new XAttribute("Fallback", ProductConfigList[i].FallbackLanguage));
                                        LangElemtnt.Add(LanguageElemtnt);
                                    }
                                    else
                                    {
                                        XElement LanguageElemtnt = new XElement("Language",
                                                                   new XAttribute("ID", LangID));
                                        LangElemtnt.Add(LanguageElemtnt);
                                    }
                                }
                            }
                            XElement ProductElemtnt = new XElement("Product",
                                                  new XAttribute("ID", ProductConfigList[i].ProductID),
                                                  from el in LangElemtnt.Elements()
                                                  select el);//指定产品 ID

                            foreach (string appid in ProductConfigList[i].ExcludeApps)
                            {
                                if (appid != null)
                                {
                                    XElement AppElemtnt = new XElement("ExcludeApp",
                                                          new XAttribute("ID", appid));//指定要排除的应用程序
                                    ProductElemtnt.Add(AppElemtnt);
                                }
                            }
                            if (ProductConfigList[i].MAK.Length == 29 && ProductConfigList[i].ProductID.Contains("Volume"))
                                ProductElemtnt.SetAttributeValue("PIDKEY", ProductConfigList[i].MAK);
                            AddElement.Add(ProductElemtnt);
                        }
                        RootElement.Add(AddElement);

                        if (DisplayLevel == true || AcceptEULA == true)
                        {
                            XElement TempElemtnt = new XElement("Display",
                                                  new XAttribute("Level", DisplayLevel.ToString().Replace("False", "").Replace("True", "None")),
                                                  new XAttribute("AcceptEULA", AcceptEULA.ToString().Replace("False", "").ToUpper()));
                            XElement DisplayElemtnt = new XElement("Display",
                                                from el in TempElemtnt.Attributes()
                                                where (string)el != string.Empty
                                                select el);
                            if (DisplayElemtnt.HasAttributes)
                            {
                                RootElement.Add(DisplayElemtnt);
                            }
                        }
                        if (LoggingLevel == true)
                        {
                            XElement TempElemtnt = new XElement("Logging",
                                                   new XAttribute("Level", "Standard"),
                                                   new XAttribute("Path", LoggingPath));
                            RootElement.Add(TempElemtnt);
                        }
                        else if (LoggingLevel == false)
                        {
                            XElement TempElemtnt = new XElement("Logging",
                                                   new XAttribute("Level", "Off"));
                            RootElement.Add(TempElemtnt);
                        }

                        for (int i = 0; i < PropertyList.Count; i++)
                        {
                            XElement TempElemtnt = new XElement("Property",
                                       new XAttribute("Name", PropertyList[i].Name),
                                       new XAttribute("Value", PropertyList[i].Value));
                            RootElement.Add(TempElemtnt);
                        }

                        XElement UpdateTempElemtnt = new XElement("Updates",
                              new XAttribute("Enabled", UpdateEnabled.ToString().Replace("True", "FALSE").Replace("False", "TRUE").Replace("null", "")),
                              new XAttribute("UpdatePath", UpdatePath),
                              new XAttribute("UpdateChannel", UpdateChannel),
                              new XAttribute("TargetVersion", TargetVersion),
                              new XAttribute("DeadLine", Deadline));
                        XElement UpdateElemtnt = new XElement("Updates",
                                            from el in UpdateTempElemtnt.Attributes()
                                            where (string)el != string.Empty
                                            select el);
                        if (UpdateElemtnt.HasAttributes)
                        {
                            RootElement.Add(UpdateElemtnt);
                        }
                        if (RemoveMSI == true)
                        {
                            if (IgnoreProduct == null)
                            {
                                XElement TempElemtnt = new XElement("RemoveMSI");
                                RootElement.Add(TempElemtnt);
                            }
                            else if (IgnoreProduct.Length > 0)
                            {
                                XElement TempElemtnt = new XElement("RemoveMSI");
                                foreach (string id in IgnoreProduct)
                                {
                                    XElement TempElemtnt1 = new XElement("IgnoreProduct",
                                                            new XAttribute("ID", id));
                                    TempElemtnt.Add(TempElemtnt1);
                                }
                                RootElement.Add(TempElemtnt);
                            }
                        }
                        XElement AppSettingsElemtnt = new XElement("AppSettings");
                        if (CompanyName != string.Empty)
                        {
                            XElement TempElemtnt = new XElement("Setup",
                                                         new XAttribute("Name", "Company"),
                                                         new XAttribute("Value", CompanyName));
                            AppSettingsElemtnt.Add(TempElemtnt);
                        }
                        if (AppSettingsElemtnt.HasElements)
                        {
                            RootElement.Add(AppSettingsElemtnt);
                        }
                    }
                    else
                    {
                        if (ProductConfigList.Count == 0)
                        {
                            XElement RemoveElement = new XElement("Remove", new XAttribute("All", "TRUE"));
                            RootElement.Add(RemoveElement);
                        }
                        else
                        {
                            XElement RemoveElement = new XElement("Remove", new XAttribute("All", "FALSE"));
                            for (int i = 0; i < ProductConfigList.Count; i++)
                            {
                                XElement LangElemtnt = new XElement("Product");
                                foreach (string LangID in ProductConfigList[i].LanguageID)
                                {
                                    if (LangID != null)
                                    {
                                        if (ProductConfigList[i].FallbackLanguage != string.Empty)
                                        {
                                            XElement LanguageElemtnt = new XElement("Language",
                                                                       new XAttribute("ID", LangID),
                                                                       new XAttribute("Fallback", ProductConfigList[i].FallbackLanguage));
                                            LangElemtnt.Add(LanguageElemtnt);
                                        }
                                        else
                                        {
                                            XElement LanguageElemtnt = new XElement("Language",
                                                                       new XAttribute("ID", LangID));
                                            LangElemtnt.Add(LanguageElemtnt);
                                        }
                                    }
                                }
                                XElement ProductElemtnt = new XElement("Product",
                                                      new XAttribute("ID", ProductConfigList[i].ProductID),
                                                      from el in LangElemtnt.Elements()
                                                      select el);
                                RemoveElement.Add(ProductElemtnt);
                            }
                            RootElement.Add(RemoveElement);
                        }
                    }
                    RootElement.Save(xw);
                    xw.Flush();
                    xw.Close();
                }
                catch
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(FilePath);
                    }
                    catch { }
                    throw;
                }
            }
        }

        class InstallConfig//安装配置信息构造
        {
            public InstallConfig(string ProductID, string MAK, string[] LanguageID, string FallbackLanguage, string[] ExcludeApps)
            {
                this.ProductID = ProductID;
                this.MAK = MAK;
                this.LanguageID = LanguageID;
                this.FallbackLanguage = FallbackLanguage;
                this.ExcludeApps = ExcludeApps;
            }

            public string ProductID { get; set; }
            public string MAK { get; set; }
            public string[] LanguageID { get; set; }
            public string FallbackLanguage { get; set; }
            public string[] ExcludeApps { get; set; }
        }

        class Property
        {
            public Property(string Name, string Value)
            {
                this.Name = Name;
                this.Value = Value;
            }

            public string Name { get; }
            public string Value { get; }
        }
    }
}