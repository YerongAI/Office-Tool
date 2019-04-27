using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
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

namespace OfficeToolPlus
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

        private void InstallNetFramework()
        {
            var Result = MessageBox.Show(Find("MsgNetFrameworkError"), Find("MsgError"), MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Process.Start("http://go.microsoft.com/fwlink/?LinkId=780601");
            }
            Application.Current.Shutdown();
        }

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

        private void MaxApp_Click(object sender, RoutedEventArgs e)
        {
            Width = 780;
            Height = 620;
        }

        private void MiniApp_Click(object sender, RoutedEventArgs e)
        {
            Width = 450;
            Height = 550;
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
        #endregion

        private void OfficeInstallation_DoWork(object sender, DoWorkEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "files\\setup.exe";
            process.StartInfo.Arguments = e.Argument + " " + a + "Configuration.xml";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            e.Result = process.ExitCode.ToString();
        }

        private void InstallLicenses_DoWork(object sender, DoWorkEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cscript";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            string[] ar = (string[])e.Argument;
            if (ar[0] == "2")
            {
                XElement loadxml = XElement.Load(OfficeInstallPath + "\\root\\Licenses16\\c2rpridslicensefiles_auto.xml");
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
                                    if (File.Exists("files\\activate\\ospp_" + Find("Culture") + ".vbs"))
                                    {
                                        p.StartInfo.Arguments = "//Nologo files\\activate\\ospp_" + Find("Culture") + ".vbs /inslic:\"" + OfficeInstallPath + "\\root\\Licenses16\\" + element.Attribute("name").Value + "\"";
                                    }
                                    else
                                    {
                                        p.StartInfo.Arguments = "//Nologo files\\activate\\ospp.vbs /inslic:\"" + OfficeInstallPath + "\\root\\Licenses16\\" + element.Attribute("name").Value + "\"";
                                    }
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
            else if (ar[0] == "0")
            {
                try //删除多余文件，避免出错
                {
                    DirectoryInfo di = new DirectoryInfo(a + "licenses\\");
                    di.Delete(true);
                }
                catch
                { }
                ZipFile.ExtractToDirectory("files\\activate\\licenses.data", a);
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

                    if (File.Exists("files\\activate\\ospp_" + Find("Culture") + ".vbs"))
                    {
                        p.StartInfo.Arguments = "//Nologo files\\activate\\ospp_" + Find("Culture") + ".vbs /inslic:\"" + ar[3] + "\\" + fi.Name + "\"";
                    }
                    else
                    {
                        p.StartInfo.Arguments = "//Nologo files\\activate\\ospp.vbs /inslic:\"" + ar[3] + "\\" + fi.Name + "\"";
                    }
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

                if (File.Exists("files\\activate\\ospp_" + Find("Culture") + ".vbs"))
                {
                    p.StartInfo.Arguments = "//Nologo files\\activate\\ospp_" + Find("Culture") + ".vbs /inslic:\"" + ar[1] + "\\" + fi.Name + "\"";
                }
                else
                {
                    p.StartInfo.Arguments = "//Nologo files\\activate\\ospp.vbs /inslic:\"" + ar[1] + "\\" + fi.Name + "\"";
                }
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
                    if (File.Exists("files\\activate\\ospp_" + Find("Culture") + ".vbs"))
                    {
                        p.StartInfo.Arguments = "//Nologo files\\activate\\ospp_" + Find("Culture") + ".vbs /inpkey:" + ar[2];
                    }
                    else
                    {
                        p.StartInfo.Arguments = "//Nologo files\\activate\\ospp.vbs /inpkey:" + ar[2];
                    }
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
            if (e.Error != null)
            {
                CMessageBox.Show(e.Error.Message, CMessageBoxImage.Error);
            }
            else if (e.Result != null)
            {
                
            }
            else
            {
                
            }
            try //删除多余文件，避免出错
            {
                DirectoryInfo di = new DirectoryInfo(a + "licenses\\");
                di.Delete(true);
            }
            catch
            { }
            InstallLicenses.Dispose();
        }

        private void BackgroundDoWork(string FileName, string Arguments)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = FileName;
                if (Arguments != null)
                {
                    if (FileName == string.Empty)
                    {
                        p.StartInfo.FileName = "cscript";
                        if (File.Exists("files\\activate\\ospp_" + Find("Culture") + ".vbs"))
                        {
                            p.StartInfo.Arguments = "//Nologo files\\activate\\ospp_" + Find("Culture") + ".vbs /" + Arguments;
                        }
                        else
                        {
                            p.StartInfo.Arguments = "//Nologo files\\activate\\ospp.vbs /" + Arguments;
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
        #endregion

        #region 激活 Office 页面
        private void ILicenses_Click(object sender, RoutedEventArgs e)
        {
            if (InstallLicenses.IsBusy)
            {
                return;
            }
            if (CMessageBox.Show(Find("MsgInstallLicenses"), Find("MsgNormalTitle"), CMessageBoxButton.YesNO, CMessageBoxImage.Question) == CMessageBoxResult.Yes)
            {
                string Licenses_Dir;
                string Key;
                if (ConversionSelected.SelectedIndex == 0)
                {
                    Licenses_Dir = a + "licenses\\VOL\\ProPlus16";
                    Key = "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99";
                }
                else if (ConversionSelected.SelectedIndex == 1)
                {
                    Licenses_Dir = a + "licenses\\VOL\\Mondo16";
                    Key = "HFTND-W9MK4-8B7MJ-B6C4G-XQBR2";
                }
                else if (ConversionSelected.SelectedIndex == 2)
                {
                    Licenses_Dir = a + "licenses\\VOL\\Project16";
                    Key = "WGT24-HCNMF-FQ7XH-6M8K7-DRTW9";
                }
                else if (ConversionSelected.SelectedIndex == 3)
                {
                    Licenses_Dir = a + "licenses\\VOL\\Visio16";
                    Key = "69WXN-MBYV6-22PQG-3WGHK-RM6XC";
                }
                else if (ConversionSelected.SelectedIndex == 4)
                {
                    Licenses_Dir = a + "licenses\\VOL\\ProPlus17";
                    Key = "NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP";
                }
                else if (ConversionSelected.SelectedIndex == 5)
                {
                    Licenses_Dir = a + "licenses\\VOL\\Project17";
                    Key = "B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B";
                }
                else if (ConversionSelected.SelectedIndex == 6)
                {
                    Licenses_Dir = a + "licenses\\VOL\\Visio17";
                    Key = "9BGNQ-K37YR-RQHF2-38RQ3-7VCBB";
                }
                else
                {
                    string[] arg = new string[] { "2", "CommonLicenseFiles," + ConversionSelected.Text };
                    InstallLicenses.RunWorkerAsync(arg);
                    return;
                }
                // 0 内置证书，1 证书路径，2 Office 文件夹
                string[] ar = { "0", Licenses_Dir, Key, a + "licenses\\Common" };
                InstallLicenses.RunWorkerAsync(ar);
            }
        }

        private void InstallLicensesByPath_Click(object sender, RoutedEventArgs e)
        {
            if (InstallLicenses.IsBusy)
            {

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

        private void UAllLicenses_Click(object sender, RoutedEventArgs e)
        {
            if (CMessageBox.Show(Find("MsgClearLicenses"), Find("MsgWarning"), CMessageBoxButton.YesNO, CMessageBoxImage.Warning) == CMessageBoxResult.Yes)
            {
                if (Environment.Is64BitOperatingSystem == true)
                {
                    BackgroundDoWork("files\\clean\\x64\\cleanospp.exe", "-Licenses");
                }
                else
                {
                    BackgroundDoWork("files\\clean\\x86\\cleanospp.exe", "-Licenses");
                }
            }
        }

        private void ResetLicensingStatus_Click(object sender, RoutedEventArgs e)
        {
            if (CMessageBox.Show(Find("MsgResetLicensingStatus"), Find("MsgWarning"), CMessageBoxButton.YesNO, CMessageBoxImage.Question) == CMessageBoxResult.Yes)
            {
                BackgroundDoWork("files\\activate\\OSPPREARM.EXE", string.Empty);
            }
        }

        private void ClearActivation_Click(object sender, RoutedEventArgs e)
        {
            if (CMessageBox.Show(Find("MsgClearActivation"), Find("MsgWarning"), CMessageBoxButton.YesNO, CMessageBoxImage.Warning) == CMessageBoxResult.Yes)
            {
                if (Environment.Is64BitOperatingSystem == true)
                {
                    BackgroundDoWork("files\\clean\\x64\\cleanospp.exe", string.Empty);
                }
                else
                {
                    BackgroundDoWork("files\\clean\\x86\\cleanospp.exe", string.Empty);
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
                Message(Find("ToastInputError"), Find("MsgError"));
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
                Message(Find("ToastInputError"), Find("MsgError"));
            }
        }

        private void ClearKeys_Click(object sender, RoutedEventArgs e)
        {
            if (CMessageBox.Show(Find("MsgClearKeys"), Find("MsgWarning"), CMessageBoxButton.YesNO, CMessageBoxImage.Question) == CMessageBoxResult.Yes)
            {
                if (Environment.Is64BitOperatingSystem == true)
                {
                    BackgroundDoWork("files\\clean\\x64\\cleanospp.exe", "-PKey");
                }
                else
                {
                    BackgroundDoWork("files\\clean\\x86\\cleanospp.exe", "-PKey");
                }
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
                Message(Find("ToastInputError"), Find("MsgError"));
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

        private void CheckKMS_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < KMSAddress.Text.Length; i++)
            {
                if (KMSAddress.Text[i] > 127)
                {
                    KMSAddress.Text = KMSAddress.Text.Remove(i, 1);
                }
            }
            if (KMSAddress.Text.Length != 0)
            {
                if (KMSPort.Text.Replace(" ", "").Length != 0)
                {
                    BackgroundDoWork("files\\activate\\vlmcs.exe", KMSAddress.Text + ":" + KMSPort.Text.Replace(" ", ""));
                }
                else
                {
                    BackgroundDoWork("files\\activate\\vlmcs.exe", KMSAddress.Text);
                }
            }
            else
            {
                Message(Find("ToastInputError"), Find("MsgError"));
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
                Message(Find("ToastInputError"), Find("MsgError"));
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
                Message(Find("ToastInputError"), Find("MsgError"));
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
        private void PowerControl(string flag)
        {
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");

            //"0" 注销 "1" 关机, "2" 重启 "8" 关闭计算机电源
            //"0" Log out "1" Shutdown, "2" Reboot "8" Shutdown power
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