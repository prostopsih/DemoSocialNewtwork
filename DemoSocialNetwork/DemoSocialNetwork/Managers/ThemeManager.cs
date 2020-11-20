using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoSocialNetwork.Managers
{
    class ThemeManager
    {
        public ThemeManager()
        {
            LoadTheme();
        }
        public string PathToLocaleFile { get; set; } = "Theme.txt";
        private string themeName;
        public string ThemeName
        {
            get => themeName;
            set
            {
                themeName = value;
                var theme = new ResourceDictionary();
                theme.Source = new Uri($"{Environment.CurrentDirectory}\\..\\..\\Themes\\{themeName}Theme.xaml");
                Application.Current.MainWindow.Resources = theme;
                SaveTheme();
            }
        }
        private void SaveTheme()
        {
            File.WriteAllText(PathToLocaleFile, ThemeName);
        }
        public void LoadTheme()
        {
            try
            {
                ThemeName = File.ReadAllText(PathToLocaleFile);
            }
            catch
            {
                ThemeName = "light";
            }
        }
    }
}
