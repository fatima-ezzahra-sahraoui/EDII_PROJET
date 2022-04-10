using EDI_prjct.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EDI_prjct.Models
{
    public class RDbContext : DbContext
    {
        
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public System.Data.Entity.DbSet<EDI_prjct.Models.Employe> Employes { get; set; }

        public System.Data.Entity.DbSet<EDI_prjct.Models.Contribuable> Contribuables { get; set; }

        public System.Data.Entity.DbSet<EDI_prjct.Models.Fichier_EDI> Fichier_EDI { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<EDI_prjct.Models.Register> Registers { get; set; }

        public System.Data.Entity.DbSet<EDI_prjct.Models.Login> Logins { get; set; }
    }
}