using System;
using System.Globalization;
using System.Windows;

namespace OfficeToolPlus
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;
            ResourceDictionary langRd = null;
            try
            {
                langRd =
                    LoadComponent(
                             new Uri(@"Language\" + currentCultureInfo.Name.Replace("zh-hk", "zh-tw") + ".xaml", UriKind.Relative))
                    as ResourceDictionary;
            }
            catch
            { }
            if (langRd != null)
            {
                if (Resources.MergedDictionaries.Count > 0)
                {
                    Resources.MergedDictionaries.Clear();
                }
                Resources.MergedDictionaries.Add(langRd);
            }
        }
    }
}