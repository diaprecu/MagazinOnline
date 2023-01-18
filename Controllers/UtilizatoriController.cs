using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagazinOnline.Models.DatabaseModels;

namespace MagazinOnline.Controllers
{
    public class UtilizatoriController : Controller
    {
        private MagazinOnlineEntities db = new MagazinOnlineEntities();

        // GET: Utilizatori
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Administrare Utilizatori";
            return View(await db.Utilizator.ToListAsync());
        }

        // GET: Utilizatori/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizator utilizator = await db.Utilizator.FindAsync(id);
            if (utilizator == null)
            {
                return HttpNotFound();
            }
            return View(utilizator);
        }

        // GET: Utilizatori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilizatori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nume,Prenume,Username,Parola")] Utilizator utilizator)
        {
            if (ModelState.IsValid)
            {
                db.Utilizator.Add(utilizator);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(utilizator);
        }

        // GET: Utilizatori/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizator utilizator = await db.Utilizator.FindAsync(id);
            if (utilizator == null)
            {
                return HttpNotFound();
            }
            return View(utilizator);
        }

        // POST: Utilizatori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nume,Prenume,Username,Parola")] Utilizator utilizator)
        {
            utilizator.Nume = utilizator.Nume?.Trim();
            utilizator.Prenume = utilizator.Prenume?.Trim();
            utilizator.Username = utilizator.Username?.Trim();
            utilizator.Parola = utilizator.Parola?.Trim();

            if (ModelState.IsValid)
            {
                db.Entry(utilizator).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(utilizator);
        }

        // GET: Utilizatori/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizator utilizator = await db.Utilizator.FindAsync(id);
            if (utilizator == null)
            {
                return HttpNotFound();
            }
            return View(utilizator);
        }

        // POST: Utilizatori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Utilizator utilizator = await db.Utilizator.FindAsync(id);
            db.Utilizator.Remove(utilizator);
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
