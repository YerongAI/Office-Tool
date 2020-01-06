using OfficeTool.List;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace OfficeTool
{
    // Copyright © 2020 蓝点网 | By Yerong | https://otp.landian.vip/
    // For more information please visit: https://docs.microsoft.com/en-us/DeployOffice/configuration-options-for-the-office-2016-deployment-tool

    class CreateXML
    {
        private static readonly List<InstallConfig> ProductConfigList = new List<InstallConfig>();
        private static readonly List<Property> PropertyList = new List<Property>();

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
            internal bool? OfficeMgmtCOM = null;
            internal bool ForceUpgrade = false;
            internal bool AllowCdnFallback = false;
            internal bool MigrateArch = false;
            // Display Element
            internal bool DisplayLevel = false;
            internal bool AcceptEULA = false;
            // Logging Element
            internal bool? LoggingLevel = null;
            internal string LoggingPath = "%temp%";
            // Updates Element
            internal bool? UpdateEnabled = null;
            internal string UpdatePath = string.Empty;
            internal string TargetVersion = string.Empty;
            internal string Deadline = string.Empty;
            internal string UpdateChannel = string.Empty;
            // RemoveMSI Element
            internal bool RemoveMSI = false;
            internal List<string> IgnoreProduct = new List<string>();
            // Remove Element
            private bool RemoveOffice;

            /// <summary>
            /// 构建安装文件配置
            /// </summary>
            public InstallArguments(){ }

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
                }
            }

            /// <summary>
            /// 添加新的产品
            /// </summary>
            /// <param name="ProductID">产品 ID</param>
            /// <param name="LanguageID">产品的语言</param>
            public void AddProduct(string ProductID, List<string> LanguageID)
            {
                InstallConfig arguments = new InstallConfig(ProductID, "", LanguageID, new List<string>());
                ProductConfigList.Add(arguments);
            }

            /// <summary>
            /// 添加新的产品
            /// </summary>
            /// <param name="ProductID">产品 ID</param>
            /// <param name="LanguageID">产品的语言</param>
            /// <param name="ExcludeApps">指定要排除的应用程序 ID</param>
            public void AddProduct(string ProductID, string MAK, List<string> LanguageID, List<string> ExcludeApps)
            {
                InstallConfig arguments = new InstallConfig(ProductID, MAK, LanguageID, ExcludeApps);
                ProductConfigList.Add(arguments);
            }

            /// <summary>
            /// 设置产品的多次激活密钥 (MAK)
            /// </summary>
            /// <param name="ProductID">产品 ID</param>
            /// <param name="MAK">多次激活密钥 (MAK)</param>
            public void SetMAK(string ProductID, string MAK)
            {
                foreach (InstallConfig config in ProductConfigList)
                {
                    if (config.ProductID == ProductID)
                    {
                        config.MAK = MAK;
                        break;
                    }
                }
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
            /// Get all information of products
            /// </summary>
            /// <returns>Return products list</returns>
            public List<InstallConfig> GetProductsList()
            {
                return ProductConfigList;
            }

            public List<Property> GetProperties()
            {
                return PropertyList;
            }

            /// <summary>
            /// Get the count of Product List
            /// </summary>
            public int Length()
            {
                return ProductConfigList.Count;
            }

            /// <summary>
            /// Create XML File
            /// </summary>
            /// <param name="FilePath">Save path</param>
            /// <param name="FileName">File name</param>
            public void CreateXMLFile(string FilePath, string FileName)
            {
                try
                {
                    if (!Directory.Exists(FilePath))
                        Directory.CreateDirectory(FilePath);
                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        Encoding = new System.Text.UTF8Encoding(true),
                        Indent = true,
                        OmitXmlDeclaration = true
                    };
                    // Create XML
                    XmlWriter xw = XmlWriter.Create(FilePath + FileName, settings);
                    XElement RootElement = new XElement("Configuration");
                    if (RemoveOffice != true)
                    {
                        if (Description != string.Empty)
                        {
                            XElement description = new XElement("Info", new XAttribute("Description", Description));
                            RootElement.Add(description);
                        }
                        // Add Element Attributes
                        XElement AddElementTemp = new XElement("Add",
                                           new XAttribute("OfficeClientEdition", OfficeClientEdition),
                                           new XAttribute("Channel", Channel),
                                           new XAttribute("SourcePath", SourcePath),
                                           new XAttribute("DownloadPath", DownloadPath),
                                           new XAttribute("Version", Version),
                                           new XAttribute("ForceUpgrade", ForceUpgrade.ToString().Replace("False", "").ToUpper()),
                                           new XAttribute("MigrateArch", MigrateArch.ToString().Replace("False", "").Replace("True", "TRUE")),
                                           new XAttribute("AllowCdnFallback", AllowCdnFallback.ToString().Replace("False", "")),
                                           new XAttribute("OfficeMgmtCOM", OfficeMgmtCOM.ToString().Replace("null", "")));
                        // Add [Add Element Attributes] to [Add Element]
                        XElement AddElement = new XElement("Add",
                                            from el in AddElementTemp.Attributes()
                                            where (string)el != string.Empty
                                            select el);
                        // Foreach products in list and add to [Add Element]
                        for (int i = 0; i < ProductConfigList.Count; i++)
                        {
                            XElement LangElemtnt = new XElement("Product");
                            foreach (string LangID in ProductConfigList[i].LanguageID)
                            {
                                // Language
                                if (LangID != null)
                                {
                                    XElement LanguageElemtnt = new XElement("Language",
                                                               new XAttribute("ID", LangID));
                                    LangElemtnt.Add(LanguageElemtnt);
                                }
                            }
                            // Product ID
                            XElement ProductElemtnt = new XElement("Product",
                                                  new XAttribute("ID", ProductConfigList[i].ProductID),
                                                  from el in LangElemtnt.Elements()
                                                  select el);
                            // Product Exclude Apps
                            foreach (string appid in ProductConfigList[i].ExcludeApps)
                            {
                                if (appid != null)
                                {
                                    XElement AppElemtnt = new XElement("ExcludeApp",
                                                          new XAttribute("ID", appid));
                                    ProductElemtnt.Add(AppElemtnt);
                                }
                            }
                            // Product MAK
                            if (ProductConfigList[i].MAK.Length == 29 && ProductConfigList[i].ProductID.Contains("Volume"))
                                ProductElemtnt.SetAttributeValue("PIDKEY", ProductConfigList[i].MAK);
                            AddElement.Add(ProductElemtnt);
                        }
                        if (AddElement.HasAttributes || AddElement.HasElements)
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
                              new XAttribute("Channel", UpdateChannel),
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
                            if (IgnoreProduct.Count == 0)
                            {
                                XElement TempElemtnt = new XElement("RemoveMSI");
                                RootElement.Add(TempElemtnt);
                            }
                            else
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
                                        XElement LanguageElemtnt = new XElement("Language",
                                                                   new XAttribute("ID", LangID));
                                        LangElemtnt.Add(LanguageElemtnt);
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
                    throw;
                }
            }

            /// <summary>
            /// Load and read XML file
            /// </summary>
            /// <param name="filePath">File path</param>
            public void LoadXMLFile(string filePath)
            {
                XElement loadxml = XElement.Load(filePath);
                IEnumerable<XElement> MatchElements = from el in loadxml.Elements("Add")
                                                      select el;
                // Read Add Element
                foreach (XElement ele in MatchElements)
                {
                    foreach (XAttribute attribute in ele.Attributes())
                    {
                        if (attribute.Name == "OfficeClientEdition")
                        {
                            OfficeClientEdition = attribute.Value;
                        }
                        else if (attribute.Name == "Channel")
                        {
                            Channel = attribute.Value;
                        }
                        else if (attribute.Name == "SourcePath")
                        {
                            SourcePath = attribute.Value;
                        }
                        else if (attribute.Name == "DownloadPath")
                        {
                            DownloadPath = attribute.Value;
                        }
                        else if (attribute.Name == "Version")
                        {
                            Version = attribute.Value;
                        }
                        else if (attribute.Name == "ForceUpgrade")
                        {
                            ForceUpgrade = (bool)attribute;
                        }
                        else if (attribute.Name == "MigrateArch")
                        {
                            MigrateArch = (bool)attribute;
                        }
                        else if (attribute.Name == "AllowCdnFallback")
                        {
                            AllowCdnFallback = (bool)attribute;
                        }
                        else if (attribute.Name == "OfficeMgmtCOM")
                        {
                            OfficeMgmtCOM = (bool)attribute;
                        }
                    }
                    // Read Product Element
                    foreach (XElement xElement in ele.Elements("Product"))
                    {
                        string productID = xElement.Attribute("ID").Value;
                        List<string> languageID = new List<string>();
                        List<string> excludeApps = new List<string>();
                        foreach (XElement temp in xElement.Elements())
                        {
                            if (temp.Name == "Language")
                            {
                                languageID.Add(temp.Attribute("ID").Value);
                            }
                            else if (temp.Name == "ExcludeApp")
                            {
                                excludeApps.Add(temp.Attribute("ID").Value);
                            }
                        }
                        if (xElement.Attribute("PIDKEY") != null)
                        {
                            AddProduct(productID, xElement.Attribute("PIDKEY").Value, languageID, excludeApps);
                        }
                        else
                        {
                            AddProduct(productID, "", languageID, excludeApps);
                        }
                    }
                }

                MatchElements = from el in loadxml.Elements("Display")
                                select el;
                // Read Display Element
                foreach (XElement ele in MatchElements)
                {
                    if (ele.Attribute("Level") != null)
                    {
                        if (ele.Attribute("Level").Value == "None")
                            DisplayLevel = true;
                    }
                    if (ele.Attribute("AcceptEULA") != null)
                    {
                        AcceptEULA = (bool)ele.Attribute("AcceptEULA");
                    }
                }

                MatchElements = from el in loadxml.Elements("Logging")
                                select el;
                // Read Logging Element
                foreach (XElement ele in MatchElements)
                {
                    if (ele.Attribute("Level").Value == "Standard")
                    {
                        LoggingLevel = true;
                        LoggingPath = ele.Attribute("Path").Value;
                    }
                }

                MatchElements = from el in loadxml.Elements("Property")
                                select el;
                // Read Property Element
                foreach (XElement ele in MatchElements)
                {
                    AddProperty(ele.Attribute("Name").Value, ele.Attribute("Value").Value);
                }

                MatchElements = from el in loadxml.Elements("Updates")
                                select el;
                // Read Updates Element
                foreach (XElement ele in MatchElements)
                {
                    foreach (XAttribute attribute in ele.Attributes())
                    {
                        if (attribute.Name == "Enabled")
                        {
                            UpdateEnabled = (bool)attribute;
                        }
                        else if (attribute.Name == "UpdatePath")
                        {
                            UpdatePath = attribute.Value;
                        }
                        else if (attribute.Name == "UpdateChannel")
                        {
                            UpdateChannel = attribute.Value;
                        }
                        else if (attribute.Name == "TargetVersion")
                        {
                            TargetVersion = attribute.Value;
                        }
                        else if (attribute.Name == "DeadLine")
                        {
                            Deadline = attribute.Value;
                        }
                    }
                }

                MatchElements = from el in loadxml.Elements("Info")
                                select el;
                // Read Info Element
                foreach (XElement ele in MatchElements)
                {
                    Description = ele.Attribute("Description").Value;
                }

                MatchElements = from el in loadxml.Elements("RemoveMSI")
                                select el;
                // Read RemoveMSI Element
                foreach (XElement ele in MatchElements)
                {
                    RemoveMSI = true;
                    foreach (XElement element in ele.Elements())
                    {
                        if (element.Name == "IgnoreProduct" && element.Attribute("ID") != null)
                        {
                            IgnoreProduct.Add(element.Attribute("ID").Value);
                        }
                    }
                }

                MatchElements = from el in loadxml.Elements("AppSettings")
                                select el;
                // Read AppSettings Element
                foreach (XElement ele in MatchElements)
                {
                    foreach (XElement element in ele.Elements())
                    {
                        if (element.Name == "Setup" && element.Attribute("Name") != null && element.Attribute("Value") != null)
                        {
                            CompanyName = element.Attribute("Value").Value;
                        }
                    }
                }
            }
        }

        public class InstallConfig
        {
            public InstallConfig(string ProductID, string MAK, List<string> LanguageID, List<string> ExcludeApps)
            {
                this.ProductID = ProductID;
                this.MAK = MAK;
                this.LanguageID = LanguageID;
                this.ExcludeApps = ExcludeApps;
            }

            public string ProductID { get; set; }
            public string MAK { get; set; }
            public List<string> LanguageID { get; set; }
            public List<string> ExcludeApps { get; set; }
        }

        public class Property
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