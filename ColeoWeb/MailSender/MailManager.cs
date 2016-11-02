using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class MailManager
    {
        public static bool SendMail(Email email)
        {
            bool result = true;

            SmtpClient client = new SmtpClient();
            client.Port = MailSettings.Default.Port;
            client.Host = MailSettings.Default.Host;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(MailSettings.Default.User, MailSettings.Default.Password);

            MailMessage message = new MailMessage(MailSettings.Default.User, email.To, email.Subject, email.Body);
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            try
            {
                client.Send(message);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
