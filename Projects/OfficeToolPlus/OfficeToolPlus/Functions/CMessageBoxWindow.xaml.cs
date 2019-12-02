using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Zmy.Wpf.CMessageBox
{
    /// <summary>
    /// 消息对话框按钮样式
    /// </summary>
    public enum ButtonStyle
    {
        NormalButtonStyle = 0,
        NotNormalButtonStyle = 1
    }

    /// <summary>
    /// CMessageBoxWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CMessageBoxWindow : Window
    {
        #region 成员
        private readonly Style normalButtonStyle;

        private readonly Style notNormalButtonStyle;
        #endregion

        #region 属性
        public string MessageBoxTitle
        {
            get;
            set;
        }

        public string MessageBoxText
        {
            get;
            set;
        }

        public System.Windows.Documents.Paragraph ParagraphContent
        {
            get;
            set;
        }

        public Visibility OKButtonVisibility
        {
            get;
            set;
        }

        public Visibility CancelButtonVisibility
        {
            get;
            set;
        }

        public Visibility YesButtonVisibility
        {
            get;
            set;
        }

        public Visibility NoButtonVisibility
        {
            get;
            set;
        }

        public Visibility ApplyToAllVisibility
        {
            get;
            set;
        }

        public ButtonStyle OKButtonStyle
        {
            set
            {
                if (value == ButtonStyle.NormalButtonStyle)
                {
                    OKButton.Style = normalButtonStyle;
                }
                else if (value == ButtonStyle.NotNormalButtonStyle)
                {
                    OKButton.Style = notNormalButtonStyle;
                }
            }
        }

        public ButtonStyle CancelButtonStyle
        {
            set
            {
                if (value == ButtonStyle.NormalButtonStyle)
                {
                    CancelButton.Style = normalButtonStyle;
                }
                else if (value == ButtonStyle.NotNormalButtonStyle)
                {
                    CancelButton.Style = notNormalButtonStyle;
                }
            }
        }

        public ButtonStyle YesButtonStyle
        {
            set
            {
                if (value == ButtonStyle.NormalButtonStyle)
                {
                    YesButton.Style = normalButtonStyle;
                }
                else if (value == ButtonStyle.NotNormalButtonStyle)
                {
                    YesButton.Style = notNormalButtonStyle;
                }
            }
        }

        public ButtonStyle NoButtonStyle
        {
            set
            {
                if (value == ButtonStyle.NormalButtonStyle)
                {
                    NoButton.Style = normalButtonStyle;
                }
                else if (value == ButtonStyle.NotNormalButtonStyle)
                {
                    NoButton.Style = notNormalButtonStyle;
                }
            }
        }

        public CMessageBoxResult Result;
        #endregion

        #region 构造函数
        public CMessageBoxWindow()
        {
            Owner = Application.Current.Windows[0];
            InitializeComponent();
            DataContext = this;

            MessageBoxTitle = Application.Current.FindResource("MsgNormalTitle").ToString();
            ApplyToAllVisibility = OKButtonVisibility = CancelButtonVisibility = YesButtonVisibility = NoButtonVisibility = Visibility.Collapsed;
            normalButtonStyle = FindResource("NormalButtonStyle") as Style;
            notNormalButtonStyle = FindResource("NotNormalButtonStyle") as Style;

            Result = CMessageBoxResult.None;
        }
        #endregion

        private void OKButton_Click(object sender, EventArgs e)
        {
            Result = CMessageBoxResult.OK;
            Close();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            if (ApplyToAll.IsChecked == true)
            {
                Result = CMessageBoxResult.AllYes;
            }
            else
            {
                Result = CMessageBoxResult.Yes;
            }
            Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            if (ApplyToAll.IsChecked == true)
            {
                Result = CMessageBoxResult.AllNo;
            }
            else
            {
                Result = CMessageBoxResult.No;
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Result = CMessageBoxResult.Cancel;
            Close();
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CMessageBoxResult.None;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (SystemParameters.DropShadow == false)
            {
                Thickness thickness = new Thickness(1);
                BorderThickness = thickness;
            }
            Background = Application.Current.Windows[0].Background;
            Foreground = Application.Current.Windows[0].Foreground;
            BorderBrush = Application.Current.Windows[0].BorderBrush;
            Opacity = Application.Current.Windows[0].Opacity;
            Topmost = Application.Current.Windows[0].Topmost;
            FontSize = Application.Current.Windows[0].FontSize;
            FlowDirection = Application.Current.Windows[0].FlowDirection;

            if (ParagraphContent != null)
            {
                richTextBox.Visibility = Visibility.Visible;
                richTextBox.Document.Blocks.Clear();
                richTextBox.Document.Blocks.Add(ParagraphContent);
            }
            if (string.IsNullOrEmpty(MessageBoxTitle))
            {
                IconPath.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Binding binding = new Binding
            {
                Source = Window,
                Path = new PropertyPath(BorderBrushProperty)
            };
            WindowTitle.SetBinding(ForegroundProperty, binding);
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            WindowTitle.Foreground = new SolidColorBrush(Colors.DarkGray);
        }
    }
}