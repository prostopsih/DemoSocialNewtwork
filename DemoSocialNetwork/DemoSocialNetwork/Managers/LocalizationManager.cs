using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSocialNetwork.Managers
{
    class LocalizationManager
    {
        public LocalizationManager()
        {
            LoadLocale();
        }
        public string PathToLocaleFile { get; set; } = "Locale.txt";
        private string locale;
        public string Locale 
        {
            get => locale;
            set
            {
                locale = value;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Locale);
                SaveLocale();
            }
        }
        private void SaveLocale()
        {
            File.WriteAllText(PathToLocaleFile, Locale);
        }
        public void LoadLocale()
        {
            try
            {
                Locale = File.ReadAllText(PathToLocaleFile);
            }
            catch
            {

            }
        }
    }
}
