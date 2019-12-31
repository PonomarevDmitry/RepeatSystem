using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepeatSystem.DataBase;

namespace RepeatSystemForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Загружаем конфиг-файл.
            ProgramConfiguraton.LoadDefaultXmlConfig();

            Config.Session = new Session();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new FormMain());
            }
            finally
            {
                // Сохраняем конфигурационный файл.
                ProgramConfiguraton.SaveDefaultXmlConfig();
            }
        }
    }
}
