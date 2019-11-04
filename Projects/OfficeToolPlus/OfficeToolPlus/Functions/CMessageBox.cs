using System;
using System.Media;
using System.Windows;
using System.Windows.Media;

namespace Zmy.Wpf.CMessageBox
{
    /// <summary>
    /// CMessageBox显示的按钮类型
    /// </summary>
    public enum CMessageBoxButton
    {
        OK = 0,
        OKCancel = 1,
        YesNO = 2,
        YesNoCancel = 3,
        AllYesAllNo = 4
    }

    /// <summary>
    /// CMessageBox显示的图标类型
    /// </summary>
    public enum CMessageBoxImage
    {
        None = 0,
        Error = 1,
        Question = 2,
        Warning = 3,
        Info = 4
    }

    /// <summary>
    /// 消息的重点显示按钮
    /// </summary>
    public enum CMessageBoxDefaultButton
    {
        None = 0,
        OK = 1,
        Cancel = 2,
        Yes = 3,
        No = 4
    }

    /// <summary>
    /// 消息框的返回值
    /// </summary>
    public enum CMessageBoxResult
    {
        //用户直接关闭了消息窗口
        None = 0,
        //用户点击确定按钮
        OK = 1,
        //用户点击取消按钮
        Cancel = 2,
        //用户点击是按钮
        Yes = 3,
        //用户点击否按钮
        No = 4,
        AllYes = 5,
        AllNo = 6
    }

    public class CMessageBox
    {
        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        public static CMessageBoxResult Show(string cmessageBoxText)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));
            window.MessageBoxText = cmessageBoxText;
            window.OKButtonVisibility = Visibility.Visible;
            Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    window.ShowDialog();
                }));
            return window.Result;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        /// <param name="CMessageBoxImage">消息框图标</param>
        public static CMessageBoxResult Show(string cmessageBoxText, CMessageBoxImage CMessageBoxImage)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));
            window.MessageBoxText = cmessageBoxText;
            window.OKButtonVisibility = Visibility.Visible;
            SwitchIcon(CMessageBoxImage, window);
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window.ShowDialog();
            }));
            return window.Result;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        /// <param name="caption">消息标题</param>
        public static CMessageBoxResult Show(string cmessageBoxText, string caption)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));
            window.MessageBoxText = cmessageBoxText;
            window.MessageBoxTitle = caption;
            window.OKButtonVisibility = Visibility.Visible;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window.ShowDialog();
            }));
            return window.Result;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        /// <param name="caption">消息标题</param>
        /// <param name="CMessageBoxImage">消息框图标</param>
        public static CMessageBoxResult Show(string cmessageBoxText, string caption, CMessageBoxImage CMessageBoxImage)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));
            window.MessageBoxText = cmessageBoxText;
            window.MessageBoxTitle = caption;
            window.OKButtonVisibility = Visibility.Visible;
            SwitchIcon(CMessageBoxImage, window);
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window.ShowDialog();
            }));
            return window.Result;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        /// <param name="caption">消息标题</param>
        /// <param name="CMessageBoxImage">消息框图标</param>
        public static CMessageBoxResult Show(System.Windows.Documents.Paragraph cmessageBoxContent, string caption, CMessageBoxButton CMessageBoxButton, CMessageBoxImage CMessageBoxImage, CMessageBoxDefaultButton CMessageBoxDefaultButton)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));
            window.ParagraphContent = cmessageBoxContent;
            window.MessageBoxTitle = caption;
            SwitchDefaultButton(CMessageBoxDefaultButton, window);
            SwitchBoxButton(CMessageBoxButton, window);
            SwitchIcon(CMessageBoxImage, window);
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window.ShowDialog();
            }));
            return window.Result;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        /// <param name="CMessageBoxButton">消息框按钮</param>
        public static CMessageBoxResult Show(string cmessageBoxText, CMessageBoxButton CMessageBoxButton)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));
            window.MessageBoxText = cmessageBoxText;
            SwitchBoxButton(CMessageBoxButton, window);
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window.ShowDialog();
            }));
            return window.Result;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        /// <param name="caption">消息标题</param>
        /// <param name="CMessageBoxButton">消息框按钮</param>
        public static CMessageBoxResult Show(string cmessageBoxText, string caption, CMessageBoxButton CMessageBoxButton)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));
            window.MessageBoxText = cmessageBoxText;
            window.MessageBoxTitle = caption;
            SwitchBoxButton(CMessageBoxButton, window);
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window.ShowDialog();
            }));
            return window.Result;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        /// <param name="caption">消息标题</param>
        /// <param name="CMessageBoxButton">消息框按钮</param>
        /// <param name="CMessageBoxImage">消息框图标</param>
        /// <returns></returns>
        public static CMessageBoxResult Show(string cmessageBoxText, string caption, CMessageBoxButton CMessageBoxButton, CMessageBoxImage CMessageBoxImage)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));

            window.MessageBoxText = cmessageBoxText;
            window.MessageBoxTitle = caption;
            SwitchBoxButton(CMessageBoxButton, window);
            SwitchIcon(CMessageBoxImage, window);
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window.ShowDialog();
            }));
            return window.Result;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="cmessageBoxText">消息内容</param>
        /// <param name="caption">消息标题</param>
        /// <param name="CMessageBoxButton">消息框按钮</param>
        /// <param name="CMessageBoxImage">消息框图标</param>
        /// <param name="CMessageBoxDefaultButton">消息框默认按钮</param>
        /// <returns></returns>
        public static CMessageBoxResult Show(string cmessageBoxText, string caption, CMessageBoxButton CMessageBoxButton, CMessageBoxImage CMessageBoxImage, CMessageBoxDefaultButton CMessageBoxDefaultButton)
        {
            CMessageBoxWindow window = null;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window = new CMessageBoxWindow();
            }));
            window.MessageBoxText = cmessageBoxText;
            window.MessageBoxTitle = caption;

            SwitchBoxButton(CMessageBoxButton, window);
            SwitchDefaultButton(CMessageBoxDefaultButton, window);
            SwitchIcon(CMessageBoxImage, window);
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                window.ShowDialog();
            }));
            return window.Result;
        }

        private static void SwitchDefaultButton(CMessageBoxDefaultButton CMessageBoxDefaultButton, CMessageBoxWindow window)
        {
            switch (CMessageBoxDefaultButton)
            {
                case CMessageBoxDefaultButton.OK:
                    {
                        window.OKButtonStyle = ButtonStyle.NormalButtonStyle;
                        window.CancelButtonStyle = window.YesButtonStyle = window.NoButtonStyle = ButtonStyle.NotNormalButtonStyle;
                        break;
                    }
                case CMessageBoxDefaultButton.Cancel:
                    {
                        window.OKButtonStyle = ButtonStyle.NotNormalButtonStyle;
                        window.CancelButtonStyle = ButtonStyle.NormalButtonStyle;
                        window.YesButtonStyle = ButtonStyle.NotNormalButtonStyle;
                        window.NoButtonStyle = ButtonStyle.NotNormalButtonStyle;
                        break;
                    }
                case CMessageBoxDefaultButton.Yes:
                    {
                        window.OKButtonStyle = ButtonStyle.NotNormalButtonStyle;
                        window.CancelButtonStyle = ButtonStyle.NotNormalButtonStyle;
                        window.YesButtonStyle = ButtonStyle.NormalButtonStyle;
                        window.NoButtonStyle = ButtonStyle.NotNormalButtonStyle;
                        break;
                    }
                case CMessageBoxDefaultButton.No:
                    {
                        window.OKButtonStyle = window.CancelButtonStyle = window.YesButtonStyle = ButtonStyle.NotNormalButtonStyle;
                        window.NoButtonStyle = ButtonStyle.NormalButtonStyle;
                        break;
                    }
                case CMessageBoxDefaultButton.None:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private static void SwitchBoxButton(CMessageBoxButton CMessageBoxButton, CMessageBoxWindow window)
        {
            switch (CMessageBoxButton)
            {
                case CMessageBoxButton.OK:
                    {
                        window.OKButtonVisibility = Visibility.Visible;
                        break;
                    }
                case CMessageBoxButton.OKCancel:
                    {
                        window.OKButtonVisibility = Visibility.Visible;
                        window.CancelButtonVisibility = Visibility.Visible;
                        break;
                    }
                case CMessageBoxButton.YesNO:
                    {
                        window.YesButtonVisibility = Visibility.Visible;
                        window.NoButtonVisibility = Visibility.Visible;
                        break;
                    }
                case CMessageBoxButton.AllYesAllNo:
                    {
                        window.YesButtonVisibility = Visibility.Visible;
                        window.NoButtonVisibility = Visibility.Visible;
                        window.ApplyToAllVisibility = Visibility.Visible;
                        break;
                    }
                case CMessageBoxButton.YesNoCancel:
                    {
                        window.YesButtonVisibility = Visibility.Visible;
                        window.NoButtonVisibility = Visibility.Visible;
                        window.CancelButtonVisibility = Visibility.Visible;
                        break;
                    }
                default:
                    {
                        window.OKButtonVisibility = Visibility.Visible;
                        break;
                    }
            }
        }

        private static void SwitchIcon(CMessageBoxImage CMessageBoxImage, CMessageBoxWindow window)
        {
            var fc = new BrushConverter();
            switch (CMessageBoxImage)
            {
                case CMessageBoxImage.Error:
                    {
                        window.IconPath.Data = Geometry.Parse("M1024,512c0,282.8-229.2,512-512,512S0,794.8,0,512S229.2,0,512,0S1024,229.2,1024,512z M752.1,679.5L682,749L512.7,578.3L342.5,749l-70-70.5l170.7-168.4L272.4,339.9l68.7-70l171.6,170.7   l171.2-170.7l67.3,72.4L581.8,510.1L752.1,679.5z");
                        window.IconPath.Fill = (Brush)fc.ConvertFrom("#FFFF0000");
                        SystemSounds.Hand.Play();
                        break;
                    }
                case CMessageBoxImage.Question:
                    {
                        window.IconPath.Data = Geometry.Parse("M1024,512c0,282.8-229.2,512-512,512S0,794.8,0,512S229.2,0,512,0S1024,229.2,1024,512z M544,660.4H429.3v-40.8c0-31,5.6-57.4,16.9-79.3c11.3-21.9,30.3-43.8,56.9-65.8c30.7-25.2,51.1-45.8,61.3-61.9   c10.1-16.1,15.2-33.4,15.2-51.9c0-21.4-7.5-38.5-22.6-51.3c-15.1-12.7-36.7-19.1-64.8-19.1c-54.5,0-105.2,20.3-152.1,60.8V217.1   c51.9-29,107.3-43.5,166.4-43.5c66.3,0,117.9,15.2,154.7,45.6c36.8,30.4,55.2,71.6,55.2,123.4c0,33.3-7.5,64-22.6,92.1   c-15.1,28.1-41,57.1-77.8,86.9c-31,24.6-50.8,44-59.3,58c-8.5,14.1-12.8,30.9-12.8,50.6V660.4z M487.1,723.8   c22,0,40.8,7.1,56.5,21.3c15.6,14.2,23.5,31.4,23.5,51.7c0,19.7-7.8,36.7-23.5,50.8S509.1,869,487.1,869   c-22.3,0-41.1-7.2-56.5-21.5c-15.4-14.3-23-31.2-23-50.6c0-20,7.7-37.2,23-51.5C446,731,464.8,723.8,487.1,723.8z");
                        window.IconPath.Fill = (Brush)fc.ConvertFrom("#FF008CFF");
                        break;
                    }
                case CMessageBoxImage.Warning:
                    {
                        window.IconPath.Fill = (Brush)fc.ConvertFrom("#FFFFE100");
                        SystemSounds.Exclamation.Play();
                        break;
                    }
                case CMessageBoxImage.Info:
                    {
                        window.IconPath.Fill = (Brush)fc.ConvertFrom("#FF008CFF");
                        SystemSounds.Asterisk.Play();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (CMessageBoxImage != CMessageBoxImage.None)
                window.IconPath.Visibility = Visibility.Visible;
        }
    }
}
