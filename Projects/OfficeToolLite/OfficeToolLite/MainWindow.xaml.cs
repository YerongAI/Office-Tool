using Microsoft.Win32;
using OTP.Export;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shell;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;
using Zmy.Wpf.CMessageBox;

namespace OfficeToolLite
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();//初始化所有组件
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Find("MsgError"));
                InstallNetFramework();//初始化失败，触发Net安装
            }
        }

        #region 属性
        public bool AdminButtonIsEnabled
        {
            get;
            set;
        }
        #endregion

        #region 各种执行函数
        private void InstallNetFramework()
        {
            var Result = MessageBox.Show(Find("MsgNetFrameworkError"), Find("MsgError"), MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Process.Start("http://go.microsoft.com/fwlink/?LinkId=780601");
            }
            Application.Current.Shutdown();
        }

        private string ConvertSize(double size)
        {
            if (size > 1073741824)
            {
                return (size / 1073741824).ToString("#0.00 GB");
            }
            else if (size > 1048576)
            {
                return (size / 1048576).ToString("#0.00 MB");
            }
            else if (size > 1024)
            {
                return (size / 1024).ToString("#0.00 KB");
            }
            else
            {
                return size.ToString("#0.00 B");
            }
        }

        private void ReadXMLFile(string FilePath, bool IsStartup)
        {
            OTP.CreateXML.InstallArguments arguments = new OTP.CreateXML.InstallArguments();
            arguments.ReadXMLFile(FilePath);

            XElement loadxml = XElement.Load(FilePath);
            IEnumerable<XElement> MatchElements = from el in loadxml.Elements("OTLConfig") select el;
            foreach (XElement element in MatchElements.Elements())
            {
                if (element.Name == "KMS")
                {
                    KMSAddress.Text = element.Attribute("Address").Value;
                }
                else if (element.Name == "AfterInstallation")
                {
                    SettingsAI.SelectedIndex = (int)element.Attribute("Index");
                }
                else if (element.Name == "Notification")
                {
                    EnableNotify.IsChecked = (bool?)element.Attribute("Enabled");
                }
            }

            if (IsStartup)
            {
                if (Directory.Exists("Office\\Data\\"))
                {
                    OTP.InstallationFile installation = new OTP.InstallationFile(StartPath);
                    for (int i = 0; i < installation.Count(); i++)
                    {
                        if (installation.HasError(i) == false && installation.GetLanguage(i).Count > 0)
                        {
                            IPlatform.IsEnabled = false;
                            arguments.Version = InstallVersion.Text = installation.GetVersion(i);
                            arguments.SourcePath = SourcePath.Text = InstallationPath;
                        }
                    }
                    if (installation.MultiplePlatform)
                    {
                        IPlatform.IsEnabled = true;
                    }
                }
            }
            StartInstallation(false, arguments);
        }
        #endregion

        #region 标题栏按钮点击事件
        private void Path_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;

            var point = WindowState == WindowState.Maximized ? new Point(0, element.ActualHeight)
                : new Point(Left + BorderThickness.Left, element.ActualHeight + Top + BorderThickness.Top);
            point = element.TransformToAncestor(this).Transform(point);
            SystemCommands.ShowSystemMenu(this, point);
        }

        private void MinApp_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
        #endregion

        #region 窗口改变相关事件
        private void Window_Activated(object sender, EventArgs e)
        {
            Binding binding = new Binding
            {
                Source = LayoutRoot,
                Path = new PropertyPath(BackgroundProperty)
            };
            HeaderTitle.SetBinding(ForegroundProperty, binding);
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            HeaderTitle.Foreground = new SolidColorBrush(Colors.DarkGray);
        }
        #endregion

        #region TabControl SelectionChanged
        private void LeftTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.OriginalSource is TabControl)
            {
                var color = new ColorConverter();
                SolidColorBrush brush = new SolidColorBrush();
                var ColorChange = new ColorAnimation
                {
                    From = (Color)color.ConvertFrom(LayoutRoot.Background.ToString()),
                    Duration = TimeSpan.FromMilliseconds(350)
                };
                if (HomeTab.SelectedIndex == 0 || HomeTab.SelectedIndex == 6 || HomeTab.SelectedIndex == -1)
                {
                    ColorChange.To = (Color)color.ConvertFrom("#EB3C00"); //Office Color
                }
                else if (HomeTab.SelectedIndex == 1)
                {
                    ColorChange.To = (Color)color.ConvertFrom("#2B579A"); //Word Color
                }
                else if (HomeTab.SelectedIndex == 2)
                {
                    ColorChange.To = (Color)color.ConvertFrom("#D24726"); //PowerPoint Color
                }
                else if (HomeTab.SelectedIndex == 3)
                {
                    ColorChange.To = (Color)color.ConvertFrom("#217346"); //Excel Color
                }
                else if (HomeTab.SelectedIndex == 4)
                {
                    ColorChange.To = (Color)color.ConvertFrom("#0078D7"); //Outlook Color
                }
                else if (HomeTab.SelectedIndex == 5)
                {
                    ColorChange.To = (Color)color.ConvertFrom("#672B7A"); //OneNote Color
                }
                else
                {
                    return;
                }
                if (SystemParameters.ClientAreaAnimation)
                {
                    brush.BeginAnimation(SolidColorBrush.ColorProperty, ColorChange);
                    LayoutRoot.Background = brush;
                }
                else
                {
                    LayoutRoot.Background = new SolidColorBrush((Color)ColorChange.To);
                }
            }
        }
        #endregion

        #region 所有后台相关事件
        private void CleanOffice_DoWork(object sender, DoWorkEventArgs e)
        {
            //停止和 Office 有关的进程
            Dispatcher.BeginInvoke(new Action(delegate
            {
                //CleanOfficeResultBox.Clear();
                //CleanOfficeResultBox.Visibility = Visibility.Visible;
                TaskProgressBar.ProgressState = TaskbarItemProgressState.Indeterminate;
                //CleanOfficeResultBox.AppendText("----- Microsoft Office Cleaner (Beta) Powered by Yerong -----");
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.AppendText("End proccess");
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
            })).Wait();
            List<string> ProcessName = new List<string>(15)
            {
                "MSACCESS",
                "EXCEL",
                "ONENOTE",
                "OUTLOOK",
                "POWERPNT",
                "WINPROJ",
                "MSPUB",
                "lync",
                "VISIO",
                "WINWORD",
                "OfficeC2RClient",
                "OfficeClickToRun",
                "AppVShNotify"
            };
            for (int n = 0; n < ProcessName.Count; n++)
            {
                Process[] p = Process.GetProcessesByName(ProcessName[n]);
                foreach (Process pro in p)
                {
                    if (pro.HasExited == false)
                    {
                        pro.Kill();
                    }
                }
            }
            //删除服务和 Office 计划任务
            Dispatcher.BeginInvoke(new Action(delegate
            {
                //CleanOfficeResultBox.AppendText("Delete Services and Tasks");
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
            })).Wait();
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "sc";
            proc.StartInfo.Arguments = "delete Clicktorunsvc";
            proc.Start();
            string Output = proc.StandardOutput.ReadToEnd();
            Dispatcher.BeginInvoke(new Action(delegate
            {
                //CleanOfficeResultBox.AppendText(Output);
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.ScrollToEnd();
            })).Wait();
            List<string> arguments = new List<string>(15)
            {
                @"""\Microsoft\Office\Office Automatic Updates""",
                @"""\Microsoft\Office\Office Subscription Maintenance""",
                @"""\Microsoft\Office\Office ClickToRun Service Monitor""",
                @"""\Microsoft\Office\OfficeTelemetryAgentLogOn2016""",
                @"""\Microsoft\Office\OfficeTelemetryAgentFallBack2016"""
            };
            for (int n = 0; n < arguments.Count; n++)
            {
                proc.StartInfo.FileName = "schtasks.exe";
                proc.StartInfo.Arguments = "/delete /F /TN " + arguments[n];
                proc.Start();
                Output = proc.StandardOutput.ReadToEnd();
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    if (Output != string.Empty)
                    {
                        //CleanOfficeResultBox.AppendText(Output);
                        //CleanOfficeResultBox.AppendText(Environment.NewLine);
                        //CleanOfficeResultBox.ScrollToEnd();
                    }
                })).Wait();
            }
            //卸载有关组件
            Dispatcher.BeginInvoke(new Action(delegate
            {
                //CleanOfficeResultBox.AppendText("Uninstall components");
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.ScrollToEnd();
            })).Wait();
            arguments = new List<string>(5)
            {
                "{90160000-008F-0000-1000-0000000FF1CE}",
                "{90160000-008C-0000-0000-0000000FF1CE}",
                "{90160000-008C-0409-0000-0000000FF1CE}",
                "{90160000-007E-0000-0000-0000000FF1CE}",
                "{90160000-008C-0804-1000-0000000FF1CE}"
            };
            for (int n = 0; n < arguments.Count; n++)
            {
                proc.StartInfo.FileName = "MsiExec.exe";
                proc.StartInfo.Arguments = "/quiet /X" + arguments[n];
                proc.Start();
                proc.WaitForExit();
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    //CleanOfficeResultBox.AppendText("Exit Code: " + proc.ExitCode.ToString());
                    //CleanOfficeResultBox.AppendText(Environment.NewLine);
                    //CleanOfficeResultBox.ScrollToEnd();
                })).Wait();
            }
            //删除注册表项
            Dispatcher.BeginInvoke(new Action(delegate
            {
                //CleanOfficeResultBox.AppendText("Clean regedit");
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.ScrollToEnd();
            })).Wait();
            RegistryKey localKey;
            localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            foreach (string s in subKey.GetSubKeyNames())
            {
                Dispatcher.BeginInvoke(new Action(() => {
                    foreach (ComboBoxItem item in Suites.Items.OfType<ComboBoxItem>())
                    {
                        if (s.Contains(item.Content.ToString()))
                        {
                            subKey.DeleteSubKey(s, false);
                        }
                    }
                    foreach (ComboBoxItem item in VisioProduct.Items.OfType<ComboBoxItem>())
                    {
                        if (s.Contains(item.Content.ToString()))
                        {
                            subKey.DeleteSubKey(s, false);
                        }
                    }
                    foreach (ComboBoxItem item in ProjectProduct.Items.OfType<ComboBoxItem>())
                    {
                        if (s.Contains(item.Content.ToString()))
                        {
                            subKey.DeleteSubKey(s, false);
                        }
                    }
                    foreach (CheckBox item in AdditionalProducts.Items.OfType<CheckBox>())
                    {
                        if (s.Contains(item.Content.ToString()))
                        {
                            subKey.DeleteSubKey(s, false);
                        }
                    }
                })).Wait();
            }
            subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            subKey.DeleteSubKeyTree(@"Office\ClickToRun\", false);
            subKey.DeleteSubKeyTree(@"AppVISV\", false);
            localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            subKey = localKey.OpenSubKey(@"Software\Microsoft\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            subKey.DeleteSubKeyTree(@"Office\", false);

            localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            foreach (string s in subKey.GetSubKeyNames())
            {
                Dispatcher.BeginInvoke(new Action(() => {
                    foreach (ComboBoxItem item in Suites.Items.OfType<ComboBoxItem>())
                    {
                        if (s.Contains(item.Content.ToString()))
                        {
                            subKey.DeleteSubKey(s, false);
                        }
                    }
                    foreach (ComboBoxItem item in VisioProduct.Items.OfType<ComboBoxItem>())
                    {
                        if (s.Contains(item.Content.ToString()))
                        {
                            subKey.DeleteSubKey(s, false);
                        }
                    }
                    foreach (ComboBoxItem item in ProjectProduct.Items.OfType<ComboBoxItem>())
                    {
                        if (s.Contains(item.Content.ToString()))
                        {
                            subKey.DeleteSubKey(s, false);
                        }
                    }
                    foreach (CheckBox item in AdditionalProducts.Items.OfType<CheckBox>())
                    {
                        if (s.Contains(item.Content.ToString()))
                        {
                            subKey.DeleteSubKey(s, false);
                        }
                    }
                })).Wait();
            }
            subKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            subKey.DeleteSubKeyTree(@"Office\ClickToRun\", false);
            subKey.DeleteSubKeyTree(@"AppVISV\", false);
            localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
            subKey = localKey.OpenSubKey(@"Software\Microsoft", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            subKey.DeleteSubKeyTree(@"Office\", false);
            //删除文件以及快捷方式
            Dispatcher.BeginInvoke(new Action(delegate
            {
                //CleanOfficeResultBox.AppendText("End Explorer");
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.AppendText("Delete files and shortcuts");
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.ScrollToEnd();
            })).Wait();
            Process[] process = Process.GetProcessesByName("explorer");
            foreach (Process pro in process)
            {
                pro.Kill();
            }
            DirectoryInfo ProgramData = new DirectoryInfo(Environment.GetEnvironmentVariable("ALLUSERSPROFILE"));//获取ProgramData路径
            DirectoryInfo Program64 = new DirectoryInfo(Environment.GetEnvironmentVariable("ProgramW6432"));//获取ProgramFiles路径
            DirectoryInfo Program86 = new DirectoryInfo(Environment.GetEnvironmentVariable("ProgramFiles(x86)"));//获取ProgramFiles(x86)路径
            DirectoryInfo CommonFiles = new DirectoryInfo(Environment.GetEnvironmentVariable("CommonProgramW6432"));//获取Common Files路径
            List<string> directory = new List<string>(5)
            {
                Program64.FullName + "\\Microsoft Office 16\\",
                Program64.FullName + "\\Microsoft Office 15\\",
                Program64.FullName + "\\Microsoft Office\\",
                Program86.FullName + "\\Microsoft Office\\",
                ProgramData.FullName + "\\Microsoft\\ClickToRun\\",
                ProgramData.FullName + "\\Microsoft\\Office\\",
                CommonFiles.FullName + "\\microsoft shared\\ClickToRun\\"
            };
            for (int n = 0; n < directory.Count; n++)
            {
                if (Directory.Exists(directory[n]))
                {
                    Directory.Delete(directory[n], true);
                }
            }
            foreach (string s in Directory.GetDirectories(ProgramData.FullName + "\\Microsoft\\Windows\\Start Menu\\Programs\\"))
            {
                if (s.Contains("Microsoft Office"))
                {
                    Directory.Delete(s, true);
                }
            }
            foreach (string s in Directory.GetFiles(ProgramData.FullName + "\\Microsoft\\Windows\\Start Menu\\Programs\\"))
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    foreach (StackPanel items in AppsList.Children)
                    {
                        foreach (CheckBox item in items.Children)
                        {
                            if (s.Contains(item.Content.ToString()))
                            {
                                File.Delete(s);
                            }
                        }
                    }
                })).Wait();
            }
            Dispatcher.BeginInvoke(new Action(delegate
            {
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.AppendText("Completed!");
                //CleanOfficeResultBox.ScrollToEnd();
            })).Wait();
        }

        private void CleanOffice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TaskProgressBar.ProgressState = TaskbarItemProgressState.None;
            if (e.Error != null)
            {
                //CleanOfficeResultBox.AppendText("Error: " + e.Error.Message);
                //CleanOfficeResultBox.AppendText(Environment.NewLine);
                //CleanOfficeResultBox.ScrollToEnd();
            }
        }

        private void InstallLicenses_DoWork(object sender, DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                Tab4Process.IsIndeterminate = true;
                TaskProgressBar.ProgressState = TaskbarItemProgressState.Indeterminate;
            })).Wait();
            OTP.OfficeConfiguration office = new OTP.OfficeConfiguration();
            Process p = new Process();
            p.StartInfo.FileName = "cscript";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            string[] ar = (string[])e.Argument;
            if (ar[0] == "2")
            {
                XElement loadxml = XElement.Load(office.InstallPath + "\\root\\Licenses16\\c2rpridslicensefiles_auto.xml");
                IEnumerable<XElement> MatchElements = from el in loadxml.Elements("ProductReleaseId")
                                                      select el;

                char[] separator = { ',' };
                string[] Licenses = ar[1].Split(separator);
                foreach (string id in Licenses)
                {
                    foreach (XElement ele in MatchElements)
                    {
                        if (ele.Attribute("id").Value == id)
                        {
                            foreach (XElement elements in ele.Elements())
                            {
                                foreach (XElement element in elements.Element("Files").Elements())
                                {
                                    p.StartInfo.Arguments = "//Nologo \"" + office.InstallPath + "\\Office16\\ospp.vbs\" /inslic:\"" + office.InstallPath + "\\root\\Licenses16\\" + element.Attribute("name").Value + "\"";
                                    p.Start();
                                    string sOutput = p.StandardOutput.ReadToEnd();
                                    Dispatcher.BeginInvoke(new Action(delegate
                                    {
                                        ResultBox.AppendText(sOutput);
                                        ResultBox.ScrollToEnd();
                                    }));
                                }
                            }
                        }
                    }
                }
                return;
            }
            string[] files = Directory.GetFiles(ar[1], "*.xrm-ms");//获取指定路径的证书文件
            if (files.Length == 0)
            {
                e.Result = Find("ToastLicensesInstallError");
                return;
            }
            if (ar[0] == "0")//是否指定 common 证书
            {
                string[] commonfiles = Directory.GetFiles(ar[3], "*.xrm-ms");
                foreach (string s in commonfiles)
                {
                    FileInfo fi = new FileInfo(s);
                    p.StartInfo.Arguments = "//Nologo \"" + office.InstallPath + "\\Office16\\ospp.vbs\" /inslic:\"" + ar[3] + "\\" + fi.Name + "\"";
                    p.Start();
                    string sOutput = p.StandardOutput.ReadToEnd();
                    Dispatcher.BeginInvoke(new Action(delegate
                    {
                        ResultBox.AppendText(sOutput);
                        ResultBox.ScrollToEnd();
                    }));
                }
            }
            foreach (string s in files)//安装指定路径的证书文件
            {
                FileInfo fi = new FileInfo(s);
                p.StartInfo.Arguments = "//Nologo \"" + office.InstallPath + "\\Office16\\ospp.vbs\" /inslic:\"" + ar[1] + "\\" + fi.Name + "\"";
                p.Start();
                string sOutput = p.StandardOutput.ReadToEnd();
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    ResultBox.AppendText(sOutput);
                    ResultBox.ScrollToEnd();
                }));
            }
            if (ar[0] == "0")//安装 Key
            {
                if (ar[2] != string.Empty)
                {
                    p.StartInfo.Arguments = "//Nologo \"" + office.InstallPath + "\\Office16\\ospp.vbs\" /inpkey:" + ar[2];
                    p.Start();
                    string Output = p.StandardOutput.ReadToEnd();
                    Dispatcher.BeginInvoke(new Action(delegate
                    {
                        ResultBox.AppendText(Output);
                        ResultBox.AppendText(Environment.NewLine);
                        ResultBox.ScrollToEnd();
                    })).Wait();
                }
            }
        }

        private void InstallLicenses_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TaskProgressBar.ProgressState = TaskbarItemProgressState.None;
            Tab4Process.IsIndeterminate = false;
            if (e.Error != null)
            {
                CMessageBox.Show(e.Error.Message, Find("MsgError"), CMessageBoxImage.Error);
            }
            else if (e.Result != null)
            {
                ToastMessage(e.Result.ToString(), string.Empty);
            }
            else
            {
                ToastMessage(Find("ToastLicensesInstallSuccess"), string.Empty);
            }
            try //删除多余文件，避免出错
            {
                DirectoryInfo di = new DirectoryInfo(TempInfo.FullName + "licenses\\");
                di.Delete(true);
            }
            catch
            { }
            InstallLicenses.Dispose();
        }

        private void BackgroundDoWork(string FileName, string Arguments)
        {
            TaskProgressBar.ProgressState = TaskbarItemProgressState.Indeterminate;
            Tab4Process.IsIndeterminate = true;

            try
            {
                Process p = new Process();
                p.StartInfo.FileName = FileName;
                if (Arguments != null)
                {
                    if (FileName == string.Empty)
                    {
                        OTP.OfficeConfiguration office = new OTP.OfficeConfiguration();
                        if (office.HasOffice)
                        {
                            p.StartInfo.FileName = "cscript";
                            p.StartInfo.Arguments = "//Nologo \"" + office.InstallPath + "\\Office16\\ospp.vbs\" /" + Arguments;
                        }
                        else
                        {
                            TaskProgressBar.ProgressState = TaskbarItemProgressState.None;
                            Tab4Process.IsIndeterminate = false;
                            CMessageBox.Show(Find("ToastLoadOSPPError"), Find("MsgError"), CMessageBoxImage.Error);
                            return;
                        }
                    }
                    else
                    {
                        p.StartInfo.Arguments = Arguments;
                    }
                }
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.EnableRaisingEvents = true;
                p.OutputDataReceived += new DataReceivedEventHandler(Process_OutputDataReceived);
                p.Exited += Process_Exited;
                p.Start();
                p.BeginOutputReadLine();
            }
            catch (Exception ex)
            {
                TaskProgressBar.ProgressState = TaskbarItemProgressState.None;
                Tab4Process.IsIndeterminate = false;
                CMessageBox.Show(ex.Message, CMessageBoxImage.Error);
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                ResultBox.AppendText(e.Data);
                ResultBox.AppendText(Environment.NewLine);
                ResultBox.ScrollToEnd();
            }));
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                TaskProgressBar.ProgressState = TaskbarItemProgressState.None;
                Tab4Process.IsIndeterminate = false;
            }));
        }
        #endregion

        #region 激活 Office 页面
        private void ConversionSelected_CheckBox_Click(object sender, RoutedEventArgs e)
        {
            string id = string.Empty;
            foreach (CheckBox item in ConversionSelected.Items.OfType<CheckBox>())
            {
                if (item.IsChecked == true)
                {
                    id += item.Content.ToString() + ",";
                }
            }
            if (id.Length == 0)
            {
                ConversionSelected.SelectedIndex = 0;
            }
            else
            {
                ConversionSelected.Text = id.Remove(id.Length - 1);
            }
        }

        private void ILicenses_Click(object sender, RoutedEventArgs e)
        {
            if (InstallLicenses.IsBusy)
            {
                ToastMessage(Find("ToastWorkerIsBusy"), Find("MsgNormalTitle"));
                return;
            }
            if (CMessageBox.Show(Find("MsgInstallLicenses"), Find("MsgNormalTitle"), CMessageBoxButton.YesNO, CMessageBoxImage.Question) == CMessageBoxResult.Yes)
            {
                string Licenses_Dir;
                string Key;
                if (ConversionSelected.SelectedIndex == 0)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\ProPlus16";
                    Key = "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99";
                }
                else if (ConversionSelected.SelectedIndex == 1)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Mondo16";
                    Key = "HFTND-W9MK4-8B7MJ-B6C4G-XQBR2";
                }
                else if (ConversionSelected.SelectedIndex == 2)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Project16";
                    Key = "WGT24-HCNMF-FQ7XH-6M8K7-DRTW9";
                }
                else if (ConversionSelected.SelectedIndex == 3)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Visio16";
                    Key = "69WXN-MBYV6-22PQG-3WGHK-RM6XC";
                }
                else if (ConversionSelected.SelectedIndex == 4)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\ProPlus17";
                    Key = "NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP";
                }
                else if (ConversionSelected.SelectedIndex == 5)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Project17";
                    Key = "B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B";
                }
                else if (ConversionSelected.SelectedIndex == 6)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Visio17";
                    Key = "9BGNQ-K37YR-RQHF2-38RQ3-7VCBB";
                }
                else
                {
                    string[] arg = new string[] { "2", "CommonLicenseFiles," + ConversionSelected.Text };
                    InstallLicenses.RunWorkerAsync(arg);
                    return;
                }
                // 0 内置证书，1 证书路径，2 Office 文件夹
                string[] ar = { "0", Licenses_Dir, Key, TempInfo.FullName + "licenses\\Common" };
                InstallLicenses.RunWorkerAsync(ar);
            }
        }

        private void InstallLicensesByPath_Click(object sender, RoutedEventArgs e)
        {
            if (InstallLicenses.IsBusy)
            {
                ToastMessage(Find("ToastWorkerIsBusy"), Find("MsgNormalTitle"));
            }
            else
            {
                System.Windows.Forms.FolderBrowserDialog m_Dialog = new System.Windows.Forms.FolderBrowserDialog
                {
                    Description = Find("MsgSelectLicensesPath")
                };
                System.Windows.Forms.DialogResult result = m_Dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string[] ar = new string[] { "1", m_Dialog.SelectedPath.Trim() };
                    InstallLicenses.RunWorkerAsync(ar);
                }
            }
        }

        private void ResetLicensingStatus_Click(object sender, RoutedEventArgs e)
        {
            if (CMessageBox.Show(Find("MsgResetLicensingStatus"), Find("MsgWarning"), CMessageBoxButton.YesNO, CMessageBoxImage.Question) == CMessageBoxResult.Yes)
            {
                OTP.OfficeConfiguration office = new OTP.OfficeConfiguration();
                if (office.HasOffice)
                {
                    BackgroundDoWork(office.InstallPath + "\\Office16\\OSPPREARM.EXE", string.Empty);
                }
                else
                {
                    CMessageBox.Show(Find("ToastLoadOSPPError"), Find("MsgError"), CMessageBoxImage.Error);
                    return;
                }
            }
        }

        private void InstallKey_Click(object sender, RoutedEventArgs e)
        {
            string key = KeyValue.Text.Replace(" ", "");
            if (key.Length == 29)
            {
                BackgroundDoWork(string.Empty, "inpkey:" + key);
            }
            else
            {
                ToastMessage(Find("ToastInputError"), Find("MsgError"));
            }
        }

        private void UninstallKey_Click(object sender, RoutedEventArgs e)
        {
            string key;
            key = KeyValue.Text.Replace(" ", "");
            if (key.Length == 5)
            {
                BackgroundDoWork(string.Empty, "unpkey:" + key);
            }
            else
            {
                ToastMessage(Find("ToastInputError"), Find("MsgError"));
            }
        }

        private void ViewIID_Click(object sender, RoutedEventArgs e)
        {
            BackgroundDoWork(string.Empty, "dinstid");
        }

        private void InstallCID_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < KeyValue.Text.Length; i++)
            {
                if (KeyValue.Text[i] > 57 || KeyValue.Text[i] < 48)
                {
                    KeyValue.Text = KeyValue.Text.Remove(i, 1);
                    i--;
                }
            }
            if (KeyValue.Text != string.Empty)
            {
                BackgroundDoWork(string.Empty, "actcid:" + KeyValue.Text);
            }
            else
            {
                ToastMessage(Find("ToastInputError"), Find("MsgError"));
            }
        }

        private void KeyValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (KeyValue.Text.Length < 10)
                {
                    UninstallKey_Click(sender, e);
                }
                else if (KeyValue.Text.Length < 30)
                {
                    InstallKey_Click(sender, e);
                }
                else
                {
                    InstallCID_Click(sender, e);
                }
            }
        }

        private void SetKMS_Click(object sender, RoutedEventArgs e)
        {
            for (int i = KMSAddress.Text.Length - 1; i >= 0; i--)
            {
                if (KMSAddress.Text[i] > 127)
                {
                    KMSAddress.Text = KMSAddress.Text.Remove(i, 1);
                }
            }
            if (KMSAddress.Text.Replace(" ", "").Length != 0)
            {
                BackgroundDoWork(string.Empty, "sethst:" + KMSAddress.Text.Replace(" ", ""));
                if (KMSPort.Text.Replace(" ", "").Length != 0)
                {
                    BackgroundDoWork(string.Empty, "setprt:" + KMSPort.Text.Replace(" ", ""));
                }
            }
            else
            {
                ToastMessage(Find("ToastInputError"), Find("MsgError"));
            }
        }

        private void KMSAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SetKMS_Click(sender, e);
            }
        }

        private void SetKMSPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SetKMSPort_Click(sender, e);
            }
        }

        private void SetKMSPort_Click(object sender, RoutedEventArgs e)
        {
            if (KMSPort.Text.Replace(" ", "").Length != 0)
            {
                BackgroundDoWork(string.Empty, "setprt:" + KMSPort.Text.Replace(" ", ""));
            }
            else
            {
                ToastMessage(Find("ToastInputError"), Find("MsgError"));
            }
        }

        private void CleanKMS_Click(object sender, RoutedEventArgs e)
        {
            BackgroundDoWork(string.Empty, "remhst");
        }

        private void ActiviteOffice_Click(object sender, RoutedEventArgs e)
        {
            BackgroundDoWork(string.Empty, "act");
        }

        private void CheckActivation_Click(object sender, RoutedEventArgs e)
        {
            BackgroundDoWork(string.Empty, "dstatus");
        }

        private void ViewLicenses_Click(object sender, RoutedEventArgs e)
        {
            BackgroundDoWork(string.Empty, "dstatusall");
        }

        private void ViewAFH_Click(object sender, RoutedEventArgs e)
        {
            BackgroundDoWork(string.Empty, "dhistoryacterr");
        }

        private void ViewKMSCAH_Click(object sender, RoutedEventArgs e)
        {
            BackgroundDoWork(string.Empty, "dhistorykms");
        }
        #endregion

        #region 设置页面
        private void ADItem_Activate()
        {
            PowerControlSet(SettingsAD.SelectedIndex);
        }

        private void AIItem_Activate()
        {
            if (SettingsAI.SelectedIndex != 0)
            {
                PowerControlSet(SettingsAI.SelectedIndex + 1);
            }
        }

        private void PowerControlSet(int n)
        {
            if (n == 1)
            {
                if (CreateXMLFile(false, false))
                {
                    StartInstallation(false, null);
                    if (EnableNotify.IsChecked == true)
                    {
                        notifyIcon.BalloonTipTitle = Find("MsgDownloadSuccessful");
                        notifyIcon.BalloonTipText = Find("ToastAutomicStartedSetup");
                        notifyIcon.ShowBalloonTip(8000);
                    }
                    else
                    {
                        ToastMessage(Find("ToastAutomicStartedSetup"), Find("MsgDownloadSuccessful"));
                    }
                }
            }
            else if (n == 2)
            {
                Thread.Sleep(1000);
                SystemCommands.CloseWindow(this);
            }
            else if (n == 3)
            {
                Thread.Sleep(1000);
                PowerControl("0");
                SystemCommands.CloseWindow(this);
            }
            else if (n == 4)
            {
                Countdown = 0;
                ADIItemsAuto.Start();
                if (CMessageBox.Show(Find("MsgADIQuestion"), Find("MsgWarning"), CMessageBoxButton.OKCancel, CMessageBoxImage.Warning) == CMessageBoxResult.OK)
                {
                    Countdown = 59;
                }
                else
                {
                    ADIItemsAuto.Stop();
                    Countdown = 0;
                }
            }
            else if (n == 5)
            {
                Countdown = 0;
                ADIItemsAuto.Start();
                if (CMessageBox.Show(Find("MsgADIQuestion"), Find("MsgWarning"), CMessageBoxButton.OKCancel, CMessageBoxImage.Warning) == CMessageBoxResult.OK)
                {
                    Countdown = 59;
                }
                else
                {
                    ADIItemsAuto.Stop();
                    Countdown = 0;
                }
            }
        }

        private void ADIItemsAuto_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                Countdown += 1;
                if (Countdown == 60)
                {
                    if (SettingsAD.SelectedIndex == 4 || SettingsAI.SelectedIndex == 3)
                    {
                        PowerControl("1");
                    }
                    else if (SettingsAD.SelectedIndex == 5 || SettingsAI.SelectedIndex == 4)
                    {
                        PowerControl("2");
                    }
                    SystemCommands.CloseWindow(this);
                }
            }));
        }

        private void PowerControl(string flag)
        {
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");

            //"0" 注销 "1" 关机, "2" 重启 "8" 关闭计算机电源
            mboShutdownParams["Flags"] = flag;
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                ManagementBaseObject mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
            }
        }
        #endregion
    }
}