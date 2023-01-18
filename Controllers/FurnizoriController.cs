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
    public class FurnizoriController : Controller
    {
        private MagazinOnlineEntities db = new MagazinOnlineEntities();

        // GET: Furnizors
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Administrare Furnizori de produse";
            return View(await db.Furnizor.ToListAsync());
        }

        // GET: Furnizors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furnizor furnizor = await db.Furnizor.FindAsync(id);
            if (furnizor == null)
            {
                return HttpNotFound();
            }
            return View(furnizor);
        }

        // GET: Furnizors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Furnizors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Denumire,Email,Telefon")] Furnizor furnizor)
        {
            if (ModelState.IsValid)
            {
                db.Furnizor.Add(furnizor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(furnizor);
        }

        // GET: Furnizors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furnizor furnizor = await db.Furnizor.FindAsync(id);
            if (furnizor == null)
            {
                return HttpNotFound();
            }
            return View(furnizor);
        }

        // POST: Furnizors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Denumire,Email,Telefon")] Furnizor furnizor)
        {
            furnizor.Denumire = furnizor.Denumire?.Trim();
            furnizor.Email = furnizor.Email?.Trim();
            furnizor.Telefon = furnizor.Telefon?.Trim();

            if (ModelState.IsValid)
            {
                db.Entry(furnizor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(furnizor);
        }

        // GET: Furnizors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furnizor furnizor = await db.Furnizor.FindAsync(id);
            if (furnizor == null)
            {
                return HttpNotFound();
            }
            return View(furnizor);
        }

        // POST: Furnizors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Furnizor furnizor = await db.Furnizor.FindAsync(id);
            db.Furnizor.Remove(furnizor);
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
