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
using System.Data.Entity.Validation;

namespace MagazinOnline.Controllers
{
    public class CategoriiController : Controller
    {
        
        private MagazinOnlineEntities db = new MagazinOnlineEntities();

        // GET: Categorii
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Administrare Categorii de produse";
            return View(await db.Categorie.ToListAsync());
        }

        // GET: Categorii/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = await db.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // GET: Categorii/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Denumire")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Categorie.Add(categorie);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categorie);
        }

        // GET: Categorii/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = await db.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categorii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Denumire")] Categorie categorie)
        {
            categorie.Denumire = categorie.Denumire?.Trim();
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Categorii/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = await db.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categorii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Categorie categorie = await db.Categorie.FindAsync(id);
            db.Categorie.Remove(categorie);
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
