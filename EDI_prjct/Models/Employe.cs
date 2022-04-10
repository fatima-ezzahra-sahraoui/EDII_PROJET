using EDI_prjct.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDI_prjct.Models
{
    public class Employe :Utilisateur
    {
        [Required(ErrorMessage = "Vous devez saisir date emb")]
        [DisplayName("date embauche")]
        public  DateTime Date_Embauche { get; set; }
        [Required(ErrorMessage = "Vous devez saisir votre poste")]
        [DisplayName("poste")]
        public String Poste { get; set; }
        [Required(ErrorMessage = "Vous devez saisir votre echelle")]
        [DisplayName("echelle")]
        public  String Echelle { get; set; }
        [Required(ErrorMessage = "Vous devez saisir votre salaire")]
        [DisplayName("salaire")]
        public  Double Salaire { get; set; }
    }
}