using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GesNaturaMVC.DAL;
using GesNaturaMVC.Models;

namespace GesNaturaMVC.Controllers
{
    public class PercursosCriadosController : Controller
    {
        private GesNaturaDbContext db = new GesNaturaDbContext();

        // GET: PercursosCriados
        public async Task<ActionResult> Index()
        {
            return View(await db.PercursosCriados.ToListAsync());
        }

        // GET: PercursosCriados/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercursosCriados percursosCriados = await db.PercursosCriados.FindAsync(id);
            if (percursosCriados == null)
            {
                return HttpNotFound();
            }
            return View(percursosCriados);
        }

        // GET: PercursosCriados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PercursosCriados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ClientID,PercursoID")] PercursosCriados percursosCriados)
        {
            if (ModelState.IsValid)
            {
                db.PercursosCriados.Add(percursosCriados);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(percursosCriados);
        }

        // GET: PercursosCriados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercursosCriados percursosCriados = await db.PercursosCriados.FindAsync(id);
            if (percursosCriados == null)
            {
                return HttpNotFound();
            }
            return View(percursosCriados);
        }

        // POST: PercursosCriados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ClientID,PercursoID")] PercursosCriados percursosCriados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(percursosCriados).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(percursosCriados);
        }

        // GET: PercursosCriados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercursosCriados percursosCriados = await db.PercursosCriados.FindAsync(id);
            if (percursosCriados == null)
            {
                return HttpNotFound();
            }
            return View(percursosCriados);
        }

        // POST: PercursosCriados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PercursosCriados percursosCriados = await db.PercursosCriados.FindAsync(id);
            db.PercursosCriados.Remove(percursosCriados);
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
