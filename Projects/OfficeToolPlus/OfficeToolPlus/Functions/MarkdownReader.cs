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
    // Markdown Reader by Yerong | https://otp.landian.vip/
    // Only supported title, image, line and highlight.
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
                    AddTitle(line.Substring(2), 22, FontWeights.Normal);
                }
                else if (line.StartsWith("## "))
                {
                    AddTitle(line.Substring(3), 18, FontWeights.Normal);
                }
                else if (line.StartsWith("### "))
                {
                    AddTitle(line.Substring(4), 15, FontWeights.Normal);
                }
                else if (line.StartsWith("#### "))
                {
                    AddTitle(line.Substring(5), 12, FontWeights.Bold);
                }
                else if (line.StartsWith("##### "))
                {
                    AddTitle(line.Substring(6), 10, FontWeights.Bold);
                }
                else if (line.StartsWith("###### "))
                {
                    AddTitle(line.Substring(7), 8, FontWeights.Bold);
                }
                else if (line.Contains("---") && line.Replace("-", "").Length == 0)
                {
                    AddLine();
                    AddText("\n");
                }
                else
                {
                    string text = string.Empty;
                    string content = string.Empty;
                    string link;
                    string target = string.Empty;
                    Queue queue = new Queue();
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (queue.Count > 0)
                        {
                            if (line[i] == ']' && queue.Peek().ToString().Contains("["))
                            {
                                target = queue.Dequeue().ToString();
                                content = string.Empty;
                                while (queue.Count > 0)
                                    content += queue.Dequeue().ToString();
                            }
                            else if (line[i] == ')' && queue.Peek().ToString() == "(")
                            {
                                queue.Dequeue();
                                link = string.Empty;
                                while (queue.Count > 0)
                                    link += queue.Dequeue().ToString();
                                if (content != string.Empty)
                                {
                                    if (target == "![")
                                        AddImage(link, content);
                                    else
                                        AddLink(content, link);
                                    content = string.Empty;
                                }
                                else
                                {
                                    AddText("(" + link + ")");
                                }
                            }
                            else if (line[i] == '`' && queue.Peek().ToString() == "`")
                            {
                                queue.Dequeue();
                                string temp = string.Empty;
                                while (queue.Count > 0)
                                    temp += queue.Dequeue().ToString();
                                AddText(temp, Colors.Red);
                            }
                            else
                            {
                                queue.Enqueue(line[i]);
                            }
                            continue;
                        }
                        if (line[i] != '[' && line[i] != '(' && line[i] != '`')
                            text += line[i];
                        else
                        {
                            if (text != string.Empty)
                            {
                                AddText(text);
                                text = string.Empty;
                            }
                            if (i > 0 && line[i - 1] == '!' && line[i] == '[')
                                queue.Enqueue(line[i - 1] + line[i]);
                            else
                                queue.Enqueue(line[i]);
                        }
                    }
                    if (text != string.Empty)
                    {
                        AddText(text);
                    }
                    AddText("\n");
                }
            }
        }

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

        private void AddText(string text)
        {
            Run run = new Run
            {
                Text = text
            };
            paragraph.Inlines.Add(run);
        }

        private void AddText(string text, FontWeight weights)
        {
            Run run = new Run
            {
                Text = text,
                FontWeight = weights
            };
            paragraph.Inlines.Add(run);
        }

        private void AddText(string text, FontStyle style)
        {
            Run run = new Run
            {
                Text = text,
                FontStyle = style
            };
            paragraph.Inlines.Add(run);
        }

        private void AddText(string text, Color color)
        {
            Run run = new Run
            {
                Text = text,
                Foreground = new SolidColorBrush(color),
            };
            paragraph.Inlines.Add(run);
        }

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
                X2 = 4000,
                Width = 4000,
                Stroke = brush
            };
            InlineUIContainer container = new InlineUIContainer
            {
                Child = line
            };
            paragraph.Inlines.Add(container);
        }

        private void AddImage(string link, string toolTip)
        {
            BitmapImage bmp = new BitmapImage(new Uri(link));
            Image img = new Image
            {
                Source = bmp,
                ToolTip = toolTip,
                Stretch = Stretch.None
            };
            InlineUIContainer container = new InlineUIContainer
            {
                Child = img
            };
            paragraph.Inlines.Add(container);
        }

        public Paragraph GetParagraph()
        {
            return paragraph;
        }
    }
}
