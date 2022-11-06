using HackathonFormulaire.Models;
using HackathonFormulaire.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Net.Mail;
using System.Threading.Tasks;


namespace HackathonFormulaire.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // Formulaire 1 adresse mail 
        #region Etape1Email
        public IActionResult FirstEmail()
        {
            return View("FirstEmail");
        }

        public IActionResult FirstEmailValidate(EmailFormViewModel form)
        {
            if (ModelState.IsValid)
            {
                Email email = new Email();
                email.Send(form.Email);
                return View("CodeEmail");
            }
            return View("FirstEmail");
        }

        #endregion Etape1Email

        #region CodeEmail
        public IActionResult CodeEmailValidate(CodeEmailFormViewModel form)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TelError = false;
                return View("Form");
            }
            return View("CodeEmail");
        }
        #endregion CodeEmail

        public IActionResult Form()
        {
            ViewBag.TelError = false;
            return View("Form");
        }

        public IActionResult ValidateForm(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TelError = false;

                // Verif date de naissance
                if (!IsBirthdayValid(form))
                {
                    return View("Form");
                }

                // Page suivante
                ViewBag.Form = form;
                return View("NameConf", form);
            }
            ViewBag.TelError = true;
            return View("Form");
        }

        #region VerifDate
        private bool IsBirthdayValid(FormViewModel form)
        {
            int month = IsMonthValid(form.Month);

            // Mois incorrect
            if (month == 0)
            {
                ViewBag.Errors = "Le mois est inconnu.";
                return false;
            }

            // Création d'un datetime, si exception return false 
            int day = form.Day1 * 10 + form.Day2;
            int year = 2000 + form.Year.Value;
            DateTime d;
            try
            {
                d = new DateTime(year, month, day);
            }
            catch
            {
                ViewBag.Errors = "Le jour n'est pas valide.";
                return false;
            }

            if((int)d.DayOfWeek != form.NameDay)
            {
                ViewBag.Errors = "Le nom du jour est incorrect !";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Retourne 0 si erreur ou 1 pour janvier ...
        /// </summary>
        /// <param name="form">FormViewModel</param>
        /// <returns>int</returns>
        private int IsMonthValid(string month)
        {
            switch (month.ToLower())
            {
                case "janvier":
                    return 1;
                case "février":
                    return 2;
                case "fevrier":
                    return 2;
                case "mars":
                    return 3;
                case "avril":
                    return 4;
                case "mai":
                    return 5;
                case "juin":
                    return 6;
                case "juillet":
                    return 7;
                case "août":
                    return 8;
                case "aout":
                    return 8;
                case "septembre":
                    return 9;
                case "octobre":
                    return 10;
                case "novembre":
                    return 11;
                case "décembre":
                    return 12;
                case "decembre":
                    return 12;

                default:
                    return 0;

            }
        }
        #endregion VerifDate


        public IActionResult ConfDate(FormViewModel form)
        {
            ViewBag.Form = form;
            ViewBag.Day = form.Day1 * 10 + form.Day2;
            ViewBag.Year = 2000 + form.Year;
            if (form.NameDay == 1)
                ViewBag.NameDay = "Lundi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Mardi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Mercredi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Jeudi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Vendredi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Samedi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Dimanche";
            return View("DateConf");
        }

        public IActionResult EmailConf(FormViewModel form)
        {
            ViewBag.Form = form;
            ViewBag.Email = string.Concat(form.Email1, form.Separator1, form.Email2, form.Symbol, form.Email3, form.Separator2, form.Email4);
            return View("EmailConf");
        }

        public IActionResult TelConf(FormViewModel form)
        {
            ViewBag.Form = form;
            ViewBag.Tel = string.Concat(form.Tel1, form.Tel2, " ", form.Tel3, form.Tel4, " ", form.Tel5, form.Tel6, " ", form.Tel7, form.Tel8, " ", form.Tel9, form.Tel10);
            return View("TelConf");
        }

        public IActionResult PasswordConf(FormViewModel form)
        {
            ViewBag.Form = form;
            return View("PasswordConf");
        }

        public IActionResult PageConf(FormViewModel form)
        {
            ViewBag.Form = form;
            ViewBag.Email = string.Concat(form.Email1, form.Separator1, form.Email2, form.Symbol, form.Email3, form.Separator2, form.Email4);
            ViewBag.Tel = string.Concat(form.Tel1, form.Tel2, " ", form.Tel3, form.Tel4, " ", form.Tel5, form.Tel6, " ", form.Tel7, form.Tel8, " ", form.Tel9, form.Tel10);
            ViewBag.Day = form.Day1 * 10 + form.Day2;
            ViewBag.Year = 2000 + form.Year;
            if (form.NameDay == 1)
                ViewBag.NameDay = "Lundi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Mardi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Mercredi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Jeudi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Vendredi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Samedi";
            else if (form.NameDay == 2)
                ViewBag.NameDay = "Dimanche";
            return View("PageConf");
        }

        public IActionResult Conf(FormViewModel form)
        {
            return View("Conf");
        }
    }
}
