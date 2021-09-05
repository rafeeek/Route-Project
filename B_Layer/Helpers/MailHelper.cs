using B_Layer.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Helpers
{
    public static class MailHelper
    {
        public static string SendMail(MailVM model)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential("rnfeee@gmail.com", "1q2w3eCXZ@");
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage("rnfeee@gmail.com" , model.MailTo, model.Title , model.Message);
                smtpClient.Send(mail);
                return "Done !  Mail Sent Successfully";
            }
            catch (Exception ex)
            {
                return "Faild To Send";
            }
        }
    }
}
