using System;
using System.Windows.Forms;
using ModbusCommon.Repositories;
using ModbusCommunication.Forms;
using ModbusCommon.Utils;

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
                //var registerService = new RegisterService();
                //var dateTimeNow = DateTime.Now;

                //if (registerService.GetValue("TestValue") == null)
                //    registerService.SetValue("TestValue", DateTimeToUnixTimestamp(dateTimeNow));

                //var registerValueTimeStamp = Convert.ToDouble(registerService.GetValue("TestValue"));
                //var registerValue = UnixTimestampToDateTime(registerValueTimeStamp);
                //if (registerValue.AddDays(31) <= dateTimeNow)
                //    throw new Exception("Zakończyła się wersja trial. Proszę o kontakt z programistą.");

                var testConnectionRepository = new TestConnectionRepository();
                Configuration.Instance.LoadConfiguration("configuration.xml");
                if (testConnectionRepository.TestConnectionToDatabase())
                    Application.Run(new MainForm());
                else
                    throw new Exception("Nie można połączyć się z bazą danych.");

            }
            catch(Exception ex)
            {
                if (ex.Message.Equals("Nie można połączyć się z bazą danych."))
                {
                    //var emailService = new EmailService();
                    //emailService.SendEmail("Błąd programu", ex.Message);
                }
                MessageBox.Show(text: ex.Message, caption: @"Błąd programu", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }
    }
}
