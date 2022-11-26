using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Utils
{
    public static class EmailUtil
    {
        public async static Task SendEmailAsync(string email, string subject, string path, Dictionary<string, string> replaces)
        {
            string body = String.Empty;
            using (StreamReader streamReader = System.IO.File.OpenText(path))
            {
                body = streamReader.ReadToEnd();
            }

            foreach (var replace in replaces)
            {
                body = body.Replace(replace.Key, replace.Value);
            }


            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(Constant.EmailAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(Constant.EmailAddress, Constant.Password);
            smtp.EnableSsl = true;
            try
            {
                await smtp.SendMailAsync(mail);
            }
            catch (Exception)
            {
                throw new Exception("Mail can not sent");
            }
        }
    }
}
