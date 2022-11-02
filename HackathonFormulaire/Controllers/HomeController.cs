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
                return View("Form");
            }
            return View("CodeEmail");
        }
        #endregion CodeEmail

        public IActionResult Form()
        {
            return View("Form");
        }

        public IActionResult ValidateForm(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TelError = false;
                return View("Form");
            }
            ViewBag.TelError = true;
            return View("Form");
        }
    }
}
