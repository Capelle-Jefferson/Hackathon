using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonFormulaire.Models
{
    public class CodeEmailFormViewModel
    {
        [Required(ErrorMessage = "Le champ est obligatoire.")]
        [Compare("CodeConf", ErrorMessage = "Le code est incorrect !")]
        public int? Code { get; set; }

        public int CodeConf { get { return 20032017; } }
    }
}
