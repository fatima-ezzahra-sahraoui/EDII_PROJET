using EDI_prjct.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace EDI_prjct.Models
{
    public class RH : Utilisateur
    {
        
      public   String fonction_Rh { get; set; }
       public  String Disponibillité_Rh { get; set; }
    }
}