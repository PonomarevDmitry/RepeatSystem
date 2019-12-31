using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using RepeatSystem.DataBase;

namespace RepeatSystemForms
{
    public static class Config
    {
        public static Session Session { get; set; }

        public static readonly Color ColorValueSelected = Color.FromArgb(210, 255, 210);

        private static InputLanguage inputLanguageRussian;
        public static InputLanguage InputLanguageRussian
        {
            get
            {
                if (inputLanguageRussian == null)
                {
                    inputLanguageRussian = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
                }

                return inputLanguageRussian;
            }
        }

        private static InputLanguage inputLanguageEnglish;
        public static InputLanguage InputLanguageEnglish
        {
            get
            {
                if (inputLanguageEnglish == null)
                {
                    inputLanguageEnglish = InputLanguage.FromCulture(new CultureInfo("en-US"));
                }

                return inputLanguageEnglish;
            }
        }
    }
}
