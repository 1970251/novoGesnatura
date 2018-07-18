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
using Microsoft.AspNet.Identity;

namespace GesNaturaMVC.Controllers
{
    public class PercursosPercorridosController : Controller
    {
        private GesNaturaDbContext db = new GesNaturaDbContext();

        // GET: PercursosPercorridos
        public async Task<ActionResult> Index()
        {
            return View(await db.PercursosPercorridos.ToListAsync());
        }

        // GET: PercursosPercorridos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercursosPercorridos percursosPercorridos = await db.PercursosPercorridos.FindAsync(id);
            if (percursosPercorridos == null)
            {
                return HttpNotFound();
            }
            return View(percursosPercorridos);
        }

        // GET: PercursosPercorridos/Create
        public async Task<ActionResult> Create(int id, string nome, float distancia, float duracao)
        {
            PercursosPercorridos pperc = new PercursosPercorridos();
            pperc.PercursoID = id;
            pperc.ClientID = User.Identity.GetUserId();
            pperc.Nome = nome;
            pperc.Distancia = distancia;
            pperc.Duracao = duracao;
            db.PercursosPercorridos.Add(pperc);
            await db.SaveChangesAsync();
            return RedirectToAction("Dados","Utilizadores",new { clientID = pperc.ClientID});
            
        }

        // POST: PercursosPercorridos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ClientID,PercursoID")] PercursosPercorridos percursosPercorridos)
        {
            if (ModelState.IsValid)
            {
                db.PercursosPercorridos.Add(percursosPercorridos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(percursosPercorridos);
        }

        // GET: PercursosPercorridos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercursosPercorridos percursosPercorridos = await db.PercursosPercorridos.FindAsync(id);
            if (percursosPercorridos == null)
            {
                return HttpNotFound();
            }
            return View(percursosPercorridos);
        }

        // POST: PercursosPercorridos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID")] PercursosPercorridos percursosPercorridos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(percursosPercorridos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(percursosPercorridos);
        }

        // GET: PercursosPercorridos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercursosPercorridos percursosPercorridos = await db.PercursosPercorridos.FindAsync(id);
            if (percursosPercorridos == null)
            {
                return HttpNotFound();
            }
            return View(percursosPercorridos);
        }

        // POST: PercursosPercorridos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PercursosPercorridos percursosPercorridos = await db.PercursosPercorridos.FindAsync(id);
            db.PercursosPercorridos.Remove(percursosPercorridos);
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
