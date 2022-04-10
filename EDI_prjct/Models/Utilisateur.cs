using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDI_prjct.Models
{
    public class Utilisateur
    {

        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Vous devez saisir votre prenom")]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vous devez saisir votre nom")]
        [DisplayName("Nom")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Vous devez saisir un E-mail valide")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vous devez saisir un pseudo valable ")]
        [DisplayName("Pseudo")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [DisplayName("Mot de Passe")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please Confirm your Password ")]
        [DataType(DataType.Password)]
        [DisplayName("Cofirmez votre Mot de passe")]
        public string ConfirmPassword { get; set; }
    }
}