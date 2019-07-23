using System;
using System.Collections;
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
    // Markdown Reader by Yerong | https://otp.landian.vip/ | 2019/07/23
    // Only supported title, image, line, text color and text style.
    // Only used in Office Tool Plus.

    class MarkdownReader
    {
        private readonly Paragraph paragraph = new Paragraph();

        public MarkdownReader(string originText)
        {
            StringReader reader = new StringReader(originText);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("# "))
                {
                    // 一级标题
                    AddTitle(line.Substring(2), 22, FontWeights.Normal);
                }
                else if (line.StartsWith("## "))
                {
                    // 二级标题
                    AddTitle(line.Substring(3), 18, FontWeights.Normal);
                }
                else if (line.StartsWith("### "))
                {
                    // 三级标题
                    AddTitle(line.Substring(4), 15, FontWeights.Normal);
                }
                else if (line.StartsWith("#### "))
                {
                    // 四级标题
                    AddTitle(line.Substring(5), 12, FontWeights.Bold);
                }
                else if (line.StartsWith("##### "))
                {
                    // 五级标题
                    AddTitle(line.Substring(6), 10, FontWeights.Bold);
                }
                else if (line.StartsWith("###### "))
                {
                    // 六级标题
                    AddTitle(line.Substring(7), 8, FontWeights.Bold);
                }
                else if ((line.Contains("---") && line.Replace("-", "").Length == 0) || (line.Contains("***") && line.Replace("*", "").Length == 0))
                {
                    // 横线
                    AddLine();
                    AddText("\n");
                }
                else if (line.Contains("```") && line.Replace("`", "").Length == 0)
                {
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
                    string content = string.Empty;
                    Queue queue = new Queue();
                    TextType type = TextType.Unknown;
                    for (int i = 0; i <= line.Length; i++)
                    {
                        if (i == line.Length)
                        {
                            if (queue.Count > 0)
                                AddText(GetText(queue));
                            break;
                        }
                        if (line[i] == '[' || line[i] == '!' || line[i] == '(' || line[i] == '`' || line[i] == '*' || line[i] == '~')
                        {
                            if (i < line.Length - 1)
                                if (line[i] == '!' && line[i + 1] == '[')
                                    continue;
                            if (queue.Count > 0 && type == TextType.Unknown)
                            {
                                AddText(GetText(queue));
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
                                                queue.Enqueue(line[i - 1]);
                                        }
                                        break;
                                    case '(':
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
                                                type++;
                                        }
                                        break;
                                    case '~':
                                        type = TextType.Strikethrough;
                                        break;
                                }
                                queue.Enqueue(line[i]);
                                continue;
                            }
                        }
                        queue.Enqueue(line[i]);
                        if (type != TextType.Unknown)
                        {
                            if (line[i] == ']' && type == TextType.HyperLinkText)
                            {
                                string temp = GetText(queue);
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
                                if (content.Length > 0)
                                {
                                    queue.Dequeue();
                                    string temp = GetText(queue);
                                    if (content[0] == '!')
                                        AddImage(content.Remove(content.Length - 1).Remove(0, 2), temp.Remove(temp.Length - 1));
                                    else
                                        AddLink(content.Remove(content.Length - 1).Remove(0, 1), temp.Remove(temp.Length - 1));
                                }
                                else
                                {
                                    AddText(GetText(queue));
                                }
                                type = TextType.Unknown;
                            }
                            else if (line[i] == '`' && type == TextType.Code)
                            {
                                queue.Dequeue();
                                string temp = GetText(queue);
                                AddText(temp.Remove(temp.Length - 1), Colors.Red);
                                type = TextType.Unknown;
                            }
                            else if (line[i] == '~' && type == TextType.Strikethrough && queue.Count > 2)
                            {
                                queue.Dequeue();
                                if (queue.Peek().ToString() == "~")
                                    continue;
                                string temp = GetText(queue);
                                AddText(temp.Remove(temp.Length - 2), type);
                                type = TextType.Unknown;
                            }
                            else if (line[i] == '*')
                            {
                                if (queue.Peek().ToString() == "*")
                                {
                                    queue.Dequeue();
                                    continue;
                                }
                                string temp = GetText(queue);
                                AddText(temp.Remove(temp.IndexOf('*')), type);
                                type = TextType.Unknown;
                            }
                        }
                        else
                        {
                            AddText(GetText(queue));
                            type = TextType.Unknown;
                        }
                    }
                    AddText("\n");
                }
            }
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
                Text = text
            };
            paragraph.Inlines.Add(run);
            if (fontSize == 22)
            {
                AddText("\n");
                AddLine();
            }
            AddText("\n");
        }

        /// <summary>
        /// 添加常规文本，无任何特殊格式
        /// </summary>
        /// <param name="text">文本内容</param>
        private void AddText(string text)
        {
            Run run = new Run
            {
                Text = text
            };
            paragraph.Inlines.Add(run);
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
            Hyperlink hyperlink = new Hyperlink();
            hyperlink.Inlines.Add(run);
            hyperlink.IsEnabled = true;
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
                X2 = 2000,
                Width = 2000,
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

        private string GetText(Queue queue)
        {
            string temp = string.Empty;
            while (queue.Count > 0)
                temp += queue.Dequeue().ToString();
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

        private enum TextType
        {
            Oblique = 0,
            Bold = 1,
            Italic = 2,
            Strikethrough = 3,
            HyperLinkText = 4,
            HyperLink = 5,
            Code = 6,
            Unknown = 7
        }
    }
}
