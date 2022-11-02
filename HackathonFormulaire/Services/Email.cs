using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HackathonFormulaire.Services
{
    public class Email
    {
        private const string from = "jefferson.capelle@gmail.com";
        private const string subject = "Code de confidentialité";
        private const string username = "jefferson.capelle@gmail.com";
        private const string password = "hosbrzysqlnlllpk";
        private const string host = "smtp.gmail.com";
        private const int port = 587;

        private const string body = "Bonjour, \n\n " +
            "Votre code de confidentialité est le : \n " +
            "20032017 / 3 = a \n" +
            "a / 6677339 = b \n" +
            "b * 11837167 = c \n" +
            "c * 3 = d \n" +
            "d * 2 = e \n" +
            "Inverser l'ordre des chiffres de e = Code de confidentialité\n\n" +
            " Bien cordialement, \n\n" +
            " Le bot du développeur.";

        private SmtpClient Client { get; set; }

        public Email()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            Client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
        }

        public void Send(string to)
        {
            Client.Send(from, to, subject, body) ;
        }

    }
}
