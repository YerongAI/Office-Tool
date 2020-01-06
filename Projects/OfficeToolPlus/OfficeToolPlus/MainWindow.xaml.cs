using Microsoft.Win32;
using OfficeTool.Export;
using OfficeTool.Functions;
using OfficeTool.List;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Shell;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;
using Zmy.Wpf.CMessageBox;
using static OfficeTool.CreateXML;
using static OfficeTool.OfficeConfiguration;

namespace OfficeTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OfficeToolPlus : Window
    {
        public OfficeToolPlus()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Find("MsgError"));
                InstallNetFramework();
            }
        }

        /// <summary>
        /// 弹出询问安装 Net Framework 的窗口
        /// </summary>
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
            SystemCommands.MaximizeWindow(this);
        }

        private void ResApp_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
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
                    id += item.Name + ",";
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
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Mondo16";
                    Key = "HFTND-W9MK4-8B7MJ-B6C4G-XQBR2";
                }
                else if (ConversionSelected.SelectedIndex == 1)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\ProPlus17";
                    Key = "NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP";
                }
                else if (ConversionSelected.SelectedIndex == 2)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Project17";
                    Key = "B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B";
                }
                else if (ConversionSelected.SelectedIndex == 3)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Visio17";
                    Key = "9BGNQ-K37YR-RQHF2-38RQ3-7VCBB";
                }
                else if (ConversionSelected.SelectedIndex == 4)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\ProPlus16";
                    Key = "XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99";
                }
                else if (ConversionSelected.SelectedIndex == 5)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Project16";
                    Key = "WGT24-HCNMF-FQ7XH-6M8K7-DRTW9";
                }
                else if (ConversionSelected.SelectedIndex == 6)
                {
                    Licenses_Dir = TempInfo.FullName + "licenses\\VOL\\Visio16";
                    Key = "69WXN-MBYV6-22PQG-3WGHK-RM6XC";
                }
                else if (ConversionSelected.SelectedIndex == -1)
                {
                    string[] arg = new string[] { "2", "CommonLicenseFiles," + ConversionSelected.Text };
                    InstallLicenses.RunWorkerAsync(arg);
                    return;
                }
                else
                {
                    CheckBox item = ConversionSelected.SelectedItem as CheckBox;
                    string[] arg = new string[] { "2", "CommonLicenseFiles," + item.Name };
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
                m_Dialog.Dispose();
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
                if (File.Exists("files\\activate\\OSPPREARM.EXE"))
                    BackgroundDoWork("files\\activate\\OSPPREARM.EXE", string.Empty);
                else
                {
                    OfficeConfiguration office = new OfficeConfiguration();
                    if (office.HasOffice)
                    {
                        BackgroundDoWork(office.InstallPath + "\\Office16\\OSPPREARM.EXE", string.Empty);
                    }
                }
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
                ToastMessage(Find("ToastInputError"), Find("MsgError"));
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
    }
}

		//Copyright © 2020 Landiannews |By Yerong | https://otp.landian.vip/