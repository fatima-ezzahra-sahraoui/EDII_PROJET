using EDI_prjct.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDI_prjct.Models
{
    public class Fichier_EDI
    {
        [Key] public int Id_ficierEDI { get; set; }
        public String Title { get; set; }
        public String Formaat { get; set; }
        public EDI_prjct.Models.Contribuable Envoyeur { get; set; }
        public  DateTime Date_Recap { get; set; }
        public  DateTime Date_Traitement { get; set; }
        public String Etat { get; set; }
    }
}