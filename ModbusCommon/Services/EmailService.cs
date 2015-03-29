using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using ModbusCommon.Utils;

namespace ModbusCommon.Services
{
    public class EmailService
    {
        public void SendEmail(string subject, string body)
        {
            try
            {
                var senderAddress = GetSenderEmailAddress();
                var receiverAddress = GetReceiverEmailAddress();
                var password = Configuration.Instance.GetValue("SenderEmailPassword");

                var smtpClient = GetSmtpClient(senderAddress, password);

                using (var message = new MailMessage(senderAddress, receiverAddress))
                {
                    message.Subject = subject;
                    message.Body = body;

                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(text: ex.Message, caption: @"Błąd podczas wysyłania maila", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            
        }

        private static MailAddress GetSenderEmailAddress()
        {
            var senderEmailAddres = Configuration.Instance.GetValue("SenderEmailAddress");
            var senderName = Configuration.Instance.GetValue("SenderEmailName");
            var senderAddress = new MailAddress(senderEmailAddres, senderName);
            return senderAddress;
        }

        private static MailAddress GetReceiverEmailAddress()
        {
            var receiverEmailAddres = Configuration.Instance.GetValue("ReceiverEmailAddress");
            var receiverName = Configuration.Instance.GetValue("ReceiverEmailName");
            var receiverAddress = new MailAddress(receiverEmailAddres, receiverName);
            return receiverAddress;
        }

        private static SmtpClient GetSmtpClient(MailAddress senderAddress, string password)
        {
            var smtpClient = new SmtpClient
            {
                Host = Configuration.Instance.GetValue("EmailHost"),
                Port = Convert.ToInt32(Configuration.Instance.GetValue("EmailPort")),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderAddress.Address, password),
                Timeout = 20000
            };
            return smtpClient;
        }
    }
}
