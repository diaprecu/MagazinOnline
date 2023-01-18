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
    public class ProduseController : Controller
    {

        private MagazinOnlineEntities db = new MagazinOnlineEntities();

        // GET: Produse
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Vizualizați stocul magazinului dumneavoastră";
            var produs = db.Produs.Include(p => p.Categorie).Include(p => p.Furnizor);
            return View(await produs.ToListAsync());
        }

        // GET: Produse/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = await db.Produs.FindAsync(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            return View(produs);
        }

        // GET: Produse/Create
        public ActionResult Create()
        {
            ViewBag.ID_Categorie = new SelectList(db.Categorie, "ID", "Denumire");
            ViewBag.ID_Furnizor = new SelectList(db.Furnizor, "ID", "Denumire");
            return View();
        }

        // POST: Produse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Denumire,Descriere,Pret,Stoc,ID_Furnizor,ID_Categorie")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                db.Produs.Add(produs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Categorie = new SelectList(db.Categorie, "ID", "Denumire", produs.ID_Categorie);
            ViewBag.ID_Furnizor = new SelectList(db.Furnizor, "ID", "Denumire", produs.ID_Furnizor);
            return View(produs);
        }

        // GET: Produse/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = await db.Produs.FindAsync(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Categorie = new SelectList(db.Categorie, "ID", "Denumire", produs.ID_Categorie);
            ViewBag.ID_Furnizor = new SelectList(db.Furnizor, "ID", "Denumire", produs.ID_Furnizor);
            return View(produs);
        }

        // POST: Produse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Denumire,Descriere,Pret,Stoc,ID_Furnizor,ID_Categorie")] Produs produs)
        {
            produs.Denumire = produs.Denumire?.Trim();
            produs.Descriere = produs.Descriere?.Trim();

            if (ModelState.IsValid)
            {
                db.Entry(produs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Categorie = new SelectList(db.Categorie, "ID", "Denumire", produs.ID_Categorie);
            ViewBag.ID_Furnizor = new SelectList(db.Furnizor, "ID", "Denumire", produs.ID_Furnizor);
            return View(produs);
        }

        // GET: Produse/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = await db.Produs.FindAsync(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            return View(produs);
        }

        // POST: Produse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Produs produs = await db.Produs.FindAsync(id);
            db.Produs.Remove(produs);
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
