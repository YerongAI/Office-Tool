using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OfficeTool.Functions
{
    // Markdown Reader by Yerong | https://otp.landian.vip/ | 2019/07/25
    // Only supported title, image, line, text color and text style.
    // Only used in Office Tool Plus.
    /*
     Supported format (支持的格式)
     Title (标题): 1, 2, 3, 4, 5, 6 (#, ##, ###, ####, #####, ######)
     Red color text (红色文本): `some text`
     Oblique (斜体): *some text*
     Bold (粗体): *some text*
     Italic and bold (斜体加粗): ***some text***
     Highlight text (高亮文本): ==some text==
     Line (横线): Three * or - or more.
     Hyper link (超链接): [Text](Link)
     Image (图片): [Image Tooltip](Link)
     Code block (No highlight and grammar check, don't support type of codes):
     ```
     some text
     ```
     */

    /// <summary>
    /// 读取 Markdown 格式的文本，并以 Paragraph 类返回，用于 RichTextBox 中
    /// </summary>
    class MarkdownReader
    {
        private readonly Paragraph paragraph = new Paragraph();

        public MarkdownReader(string originText)
        {
            StringReader reader = new StringReader(originText);
            string line;
            List<char> list = new List<char>();
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("# "))
                {
                    AddText(GetText(list));
                    // 一级标题
                    AddTitle(line.Substring(2), 26, FontWeights.Normal);
                    AddLine();
                    AddText("\n");
                }
                else if (line.StartsWith("## "))
                {
                    AddText(GetText(list));
                    // 二级标题
                    AddTitle(line.Substring(3), 22, FontWeights.Normal);
                }
                else if (line.StartsWith("### "))
                {
                    AddText(GetText(list));
                    // 三级标题
                    AddTitle(line.Substring(4), 18, FontWeights.Normal);
                }
                else if (line.StartsWith("#### "))
                {
                    AddText(GetText(list));
                    // 四级标题
                    AddTitle(line.Substring(5), 15, FontWeights.Bold);
                }
                else if (line.StartsWith("##### "))
                {
                    AddText(GetText(list));
                    // 五级标题
                    AddTitle(line.Substring(6), 13, FontWeights.Bold);
                }
                else if (line.StartsWith("###### "))
                {
                    AddText(GetText(list));
                    // 六级标题
                    AddTitle(line.Substring(7), 11, FontWeights.Bold);
                }
                else if ((line.Contains("---") && line.Replace("-", "").Length == 0) || (line.Contains("***") && line.Replace("*", "").Length == 0))
                {
                    AddText(GetText(list));
                    // 横线
                    AddLine();
                    AddText("\n");
                }
                else if (line.Contains("```") && line.Replace("`", "").Length == 0)
                {
                    AddText(GetText(list));
                    // 代码块（伪，无语法高亮，且只能单独复制）
                    string temp = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("```") && line.Replace("`", "").Length == 0)
                            break;
                        temp += line + "\n";
                    }
                    TextBox textBox = new TextBox
                    {
                        Text = temp.Remove(temp.Length - 1),
                        Background = new SolidColorBrush(Colors.Gainsboro),
                        BorderThickness = new Thickness(0),
                        Padding = new Thickness(15),
                        IsReadOnly = true,
                        TextWrapping = TextWrapping.Wrap,
                    };
                    paragraph.Inlines.Add(textBox);
                    AddText("\n");
                }
                else
                {
                    line += "\n";
                    string content = string.Empty;
                    TextType type = TextType.Unknown;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '[' || line[i] == '!' || line[i] == '(' || line[i] == '`' || line[i] == '*' || line[i] == '~' || line[i] == '=')
                        {
                            if (i < line.Length - 1)
                                if (line[i] == '!' && line[i + 1] == '[')
                                    continue;
                            if (list.Count > 0 && type == TextType.Unknown)
                            {
                                AddText(GetText(list));
                            }
                            if (type == TextType.Unknown)
                            {
                                switch (line[i])
                                {
                                    case '[':
                                        type = TextType.HyperLinkText;
                                        if (i > 0)
                                        {
                                            if (line[i - 1] == '!')
                                                list.Insert(0, line[i - 1]);
                                        }
                                        break;
                                    case '(':
                                        if (content != string.Empty)
                                            type = TextType.HyperLink;
                                        break;
                                    case '`':
                                        type = TextType.Code;
                                        break;
                                    case '*':
                                        if (type == TextType.Unknown)
                                        {
                                            type = TextType.Oblique;
                                            while (line[++i] == '*')
                                            {
                                                list.Add(line[i]);
                                                type++;
                                            }
                                        }
                                        break;
                                    case '~':
                                        type = TextType.Strikethrough;
                                        break;
                                    case '=':
                                        type = TextType.Highlight;
                                        break;
                                }
                                list.Add(line[i]);
                                continue;
                            }
                        }
                        list.Add(line[i]);
                        if (type != TextType.Unknown)
                        {
                            if (line[i] == ']' && type == TextType.HyperLinkText)
                            {
                                string temp = GetText(list);
                                if (i < line.Length - 1)
                                    if (line[i + 1] == '(')
                                    {
                                        content = temp;
                                        type = TextType.Unknown;
                                        continue;
                                    }
                                content = string.Empty;
                                AddText(temp);
                                type = TextType.Unknown;
                            }
                            else if (line[i] == ')' && type == TextType.HyperLink)
                            {
                                List<char> head = list.FindAll(delegate (char s) {
                                    return s == '(';
                                });
                                List<char> tail = list.FindAll(delegate (char s) {
                                    return s == ')';
                                });
                                if (head.Count != tail.Count)
                                    continue;
                                if (content.Length > 0)
                                {
                                    list.RemoveAt(0);
                                    list.RemoveAt(list.Count - 1);
                                    string temp = GetText(list);
                                    if (content[0] == '!')
                                        AddImage(content.Remove(content.Length - 1).Remove(0, 2), temp);
                                    else
                                        AddLink(content.Remove(content.Length - 1).Remove(0, 1), temp);
                                }
                                else
                                {
                                    AddText(GetText(list));
                                }
                                type = TextType.Unknown;
                            }
                            else if (line[i] == '`' && type == TextType.Code)
                            {
                                list.RemoveAt(0);
                                string temp = GetText(list);
                                AddText(temp.Remove(temp.Length - 1), Colors.Red);
                                type = TextType.Unknown;
                            }
                            else if (line[i] == '~' && type == TextType.Strikethrough && list.Count > 2)
                            {
                                list.RemoveAt(0);
                                if (list[0] == '~')
                                    continue;
                                list.RemoveRange(list.Count - 2, 2);
                                string temp = GetText(list);
                                AddText(temp, type);
                                type = TextType.Unknown;
                            }
                            else if (line[i] == '*')
                            {
                                if (list[0] == '*')
                                {
                                    list.RemoveAt(0);
                                    continue;
                                }
                                string temp = GetText(list);
                                AddText(temp.Remove(temp.IndexOf('*')), type);
                                type = TextType.Unknown;
                            }
                            else if (line[i] == '=' && type == TextType.Highlight)
                            {
                                if (list[0] == '=')
                                {
                                    list.RemoveAt(0);
                                    continue;
                                }
                                string temp = GetText(list);
                                AddTextWithBackground(temp.Remove(temp.IndexOf('=')), Colors.Yellow);
                                type = TextType.Unknown;
                            }
                        }
                    }
                }
            }
            AddText(GetText(list));
        }

        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="text">标题文本</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="weights">字体样式</param>
        private void AddTitle(string text, int fontSize, FontWeight weights)
        {
            Run run = new Run
            {
                FontSize = fontSize,
                FontWeight = weights,
                Text = text + "\n"
            };
            paragraph.Inlines.Add(run);
        }

        /// <summary>
        /// 添加常规文本，无任何特殊格式
        /// </summary>
        /// <param name="text">文本内容</param>
        private void AddText(string text)
        {
            if (text.Length > 0)
            {
                Run run = new Run
                {
                    Text = text
                };
                paragraph.Inlines.Add(run);
            }
        }

        /// <summary>
        /// 以指定的颜色添加文本
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="color">文本颜色</param>
        private void AddText(string text, Color color)
        {
            Run run = new Run
            {
                Text = text,
                Foreground = new SolidColorBrush(color),
            };
            paragraph.Inlines.Add(run);
        }

        /// <summary>
        /// 添加具有特定背景色的文本
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="color">背景色</param>
        private void AddTextWithBackground(string text, Color color)
        {
            Run run = new Run
            {
                Text = text,
                Background = new SolidColorBrush(color),
            };
            paragraph.Inlines.Add(run);
        }

        /// <summary>
        /// 添加具有特定格式的文本
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="type">文本类型</param>
        private void AddText(string text, TextType type)
        {
            Run run = new Run
            {
                Text = text,
            };
            if (type == TextType.Strikethrough)
                run.TextDecorations = TextDecorations.Strikethrough;
            else if (type == TextType.Bold)
                run.FontWeight = FontWeights.Bold;
            else if (type == TextType.Oblique)
                run.FontStyle = FontStyles.Oblique;
            else if (type == TextType.Italic)
            {
                run.FontWeight = FontWeights.Bold;
                run.FontStyle = FontStyles.Italic;
            }
            paragraph.Inlines.Add(run);
        }

        /// <summary>
        /// 添加超链接
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="link">链接</param>
        private void AddLink(string text, string link)
        {
            Run run = new Run(text);
            Hyperlink hyperlink = new Hyperlink
            {
                ToolTip = link
            };
            hyperlink.Inlines.Add(run);
            if (link != string.Empty)
            {
                hyperlink.NavigateUri = new Uri(link);
                hyperlink.RequestNavigate += (sender, args) => Process.Start(args.Uri.ToString());
            }
            paragraph.Inlines.Add(hyperlink);
        }

        /// <summary>
        /// 添加一条横线
        /// </summary>
        private void AddLine()
        {
            SolidColorBrush brush = new SolidColorBrush
            {
                Color = Colors.Gray
            };
            Line line = new Line
            {
                Y1 = 5,
                Y2 = 5,
                X2 = 4200,
                Width = 4200,
                Stroke = brush
            };
            InlineUIContainer container = new InlineUIContainer
            {
                Child = line
            };
            paragraph.Inlines.Add(container);
        }

        /// <summary>
        /// 添加一个图片
        /// </summary>
        /// <param name="toolTip">提示内容</param>
        /// <param name="link">图片链接</param>
        private void AddImage(string toolTip, string link)
        {
            BitmapImage bmp = new BitmapImage(new Uri(link));
            Image img = new Image
            {
                Source = bmp,
                ToolTip = toolTip,
                Stretch = Stretch.Uniform,
                StretchDirection = StretchDirection.DownOnly
            };
            InlineUIContainer container = new InlineUIContainer
            {
                Child = img
            };
            paragraph.Inlines.Add(container);
        }

        /// <summary>
        /// 返回列表中所有的文字，列表中的文字会被清空
        /// </summary>
        /// <param name="list">源列表</param>
        /// <returns></returns>
        private string GetText(List<char> list)
        {
            string temp = string.Empty;
            foreach (char ch in list)
            {
                temp += ch;
            }
            list.Clear();
            return temp;
        }

        /// <summary>
        /// 以 Paragraph 类返回 Markdown 内容
        /// </summary>
        /// <returns></returns>
        public Paragraph GetParagraph()
        {
            return paragraph;
        }

        /// <summary>
        /// 文本的类型
        /// </summary>
        private enum TextType
        {
            Oblique = 0,
            Bold = 1,
            Italic = 2,
            Strikethrough = 3,
            Highlight = 4,
            HyperLinkText = 5,
            HyperLink = 6,
            Code = 7,
            Unknown = 8
        }
    }
}