using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace EDI_prjct.Models
{
    public class Initialiser : CreateDatabaseIfNotExists<RDbContext>
    {


    }
}