using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonFormulaire.Models
{
    public class FormViewModel
    {
        #region Name
        //[Required(ErrorMessage = "Le champ est obligatoire.")]
        //[MinLength(6, ErrorMessage = "Le champ doit être composé d'au moins 6 caractères.")]
        public string Name { get; set; }
        #endregion Name

        #region Birthday

        //[Required(ErrorMessage = "Le champ est requis !")]

        public int Minute { get; set; }

        //[Required(ErrorMessage = "Le champ est requis !")]
        public int Hour { get; set; }

        //[Required(ErrorMessage = "Le champ est requis !")]
        public int NameDay { get; set; }

        //[Required(ErrorMessage = "Le champ est requis !")]
        public int Day1 { get; set; }

        //[Required(ErrorMessage = "Le champ est requis !")]
        public int Day2 { get; set; }

        //[Required(ErrorMessage = "Le mois est requis !")]
        public string Month { get; set; }

        //[Required(ErrorMessage = "L'année est requis !")]
        public int? Year { get; set; }
        #endregion Birthday

        #region Tel
        //[Required(ErrorMessage = "Le numéro 3 est vide :'(")]
        public string? Tel1 { get; set; }

        //[Required(ErrorMessage = "Le numéro 7 est vide ^^'")]
        public string? Tel2 { get; set; }

        //[Required(ErrorMessage = "Le numéro 5 est vide :-/")]
        public string? Tel3 { get; set; }

        //[Required(ErrorMessage = "Le numéro 10 est vide ^o^")]
        public string? Tel4 { get; set; }

        //[Required(ErrorMessage = "Le numéro 1 est vide o_O")]
        public string? Tel5 { get; set; }

        //[Required(ErrorMessage = "Le numéro 9 est vide o.O")]
        public string? Tel6 { get; set; }

        //[Required(ErrorMessage = "Le numéro 6 est vide :/")]
        public string? Tel7 { get; set; }

        //[Required(ErrorMessage = "Le numéro 4 est vide :-(")]
        public string? Tel8 { get; set; }

        //[Required(ErrorMessage = "Le numéro 2 est vide :O")]
        public string? Tel9 { get; set; }

        //[Required(ErrorMessage = "Le numéro 8 est vide o_o")]
        public string? Tel10 { get; set; }
        #endregion Tel

        #region Email
        //[Required(ErrorMessage = "Obligatoire.")]
        public string? Email1 { get; set; }

        public string? Separator1 { get; set; }

        public string? Email2 { get; set; }

        //[Required(ErrorMessage = "Obligatoire.")]
        //[Compare("ArobaseConst", ErrorMessage = "Mauvaise valeur.")]
        public string? Symbol { get; set; }

        //[Required(ErrorMessage = "Obligatoire.")]
        public string? Email3 { get; set; }

        //[Required(ErrorMessage = "Obligatoire.")]
        //[Compare("PointConst", ErrorMessage = "Mauvaise valeur.")]
        public string? Separator2 { get; set; }

        //[Required(ErrorMessage = "Obligatoire.")]
        public string? Email4 { get; set; }

        public string PointConst { get { return "."; } }
        public string ArobaseConst { get { return "@"; } }
        #endregion Email

        #region Password

        //[Required(ErrorMessage = "Mot de passe obligatoire")]
        public string FirstPassword { get; set; }

        //[Required(ErrorMessage = "Mot de passe obligatoire")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirmation du mot de passe obligatoire")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Les mots de passe ne sont pas identique")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Confirmation du mot de passe obligatoire")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Les mots de passe ne sont pas identique")]
        public string ConfirmPassword2 { get; set; }

        #endregion Password

    }
}
