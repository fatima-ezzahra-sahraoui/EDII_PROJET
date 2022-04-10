using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EDI_prjct.Models;
using Syncfusion.XlsIO;
using System.IO;
using System.Xml.Linq;

namespace EDI_prjct.Controllers
{
    public class Fichier_EDIController : Controller
    {
        private RDbContext db = new RDbContext();

        // GET: Fichier_EDI
        public async Task<ActionResult> Index()
        {
            return View(await db.Fichier_EDI.ToListAsync());
        }

        // GET: Fichier_EDI/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichier_EDI fichier_EDI = await db.Fichier_EDI.FindAsync(id);
            if (fichier_EDI == null)
            {
                return HttpNotFound();
            }
            return View(fichier_EDI);
        }
        //
        public void GenerateXml()
        {
            var infoList = (from item in db.Employes
                            select item).ToList();
            var count = 1;
            var doc = new XElement("Utilisateurs");
            foreach (var item in infoList)
            {
                doc.Add(new XElement("EMPLOYEE_INFO",
                            new XElement("num", count),
                            new XElement("NAME", item.FirstName),
                new XElement("lastname", item.LastName),
                            new XElement("EMAIL", item.Email),
                            new XElement("Poste", item.Poste)
                        )
                    );
                count += 1;
            }
            string fileName = "C#_EmployeeInfo_" +
                               string.Format("{0:yyyy_MM_dd}", DateTime.Now) + ".xml";
            Response.ContentType = "text/xml";
            Response.AddHeader("content-disposition", "attachment ; filename = \"" + fileName + "\"");
            Response.Write(doc);
            Response.End();
        }


        // GET: Fichier_EDI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fichier_EDI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_ficierEDI,Title,Formaat,Date_Recap,Date_Traitement,Etat")] Fichier_EDI fichier_EDI)
        {
            if (ModelState.IsValid)
            {
                db.Fichier_EDI.Add(fichier_EDI);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fichier_EDI);
        }

        // GET: Fichier_EDI/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichier_EDI fichier_EDI = await db.Fichier_EDI.FindAsync(id);
            if (fichier_EDI == null)
            {
                return HttpNotFound();
            }
            return View(fichier_EDI);
        }

        // POST: Fichier_EDI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_ficierEDI,Title,Formaat,Date_Recap,Date_Traitement,Etat")] Fichier_EDI fichier_EDI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichier_EDI).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fichier_EDI);
        }

        // GET: Fichier_EDI/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichier_EDI fichier_EDI = await db.Fichier_EDI.FindAsync(id);
            if (fichier_EDI == null)
            {
                return HttpNotFound();
            }
            return View(fichier_EDI);
        }

        // POST: Fichier_EDI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fichier_EDI fichier_EDI = await db.Fichier_EDI.FindAsync(id);
            db.Fichier_EDI.Remove(fichier_EDI);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
