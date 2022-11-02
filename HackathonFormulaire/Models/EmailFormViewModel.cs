using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonFormulaire.Models
{
    public class EmailFormViewModel
    {
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "L'email est incorrect.")]
        public string Email { get; set; }

        [Compare("Email", ErrorMessage = "Les adresses ne sont pas identiques")]
        public string ConfEmail { get; set; }

        [Compare("Email", ErrorMessage = "Les adresses ne sont pas identiques")]
        public string ConfEmail2 { get; set; }
    }
}
