using System;
using System.Windows.Forms;
using ModbusCommon.Utils;
using ModbusCommunication.Forms;

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
                Configuration.Instance.LoadConfiguration("configuration.xml");
                Application.Run(new MainForm());
            }
            catch(Exception ex)
            {
                MessageBox.Show(text: ex.Message, caption: @"Błąd programu", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }
    }
}
