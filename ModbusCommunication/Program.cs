using System;
using System.Windows.Forms;
using ModbusCommunication.Forms;
using ModbusCommunication.Repositories;
using ModbusCommunication.Utils;

namespace ModbusCommunication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                var testConnectionRepository = new TestConnectionRepository();
                Configuration.Instance.LoadConfiguration("configuration.xml");
                if(testConnectionRepository.TestConnectionToDatabase())
                    Application.Run(new MainForm());
                else
                    throw new Exception("Nie można połączyć się z bazą danych.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(text: ex.Message, caption: @"Błąd programu", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }
    }
}
