using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GesNaturaMVC.DAL;
using GesNaturaMVC.Models;
using GesNaturaMVC.ViewModels;
using Microsoft.AspNet.Identity;

namespace GesNaturaMVC.Controllers
{
    public class UtilizadoresController : Controller
    {
        private GesNaturaDbContext db = new GesNaturaDbContext();

        // GET: Utilizadores
        public ActionResult Index()
        {
            return View(db.Utilizadors.ToList());
        }
        public ActionResult Estatisticas()
        {
            string client = User.Identity.GetUserId();
            return RedirectToAction("Dados", new { clientID = client });
            
        }
        public ActionResult Dados(string clientID)
        {
            PercursoVM percVM = new PercursoVM();

            percVM.ListaPercurosPercorridosVM = new List<PercursoPercorridoVM>();
            percVM.ListaPercursosCriadosVM = new List<PercursoCriadoVM>();
            percVM.ListaComentarios = new List<PercursoComentarioVM>();


            var listaPercursos = db.PercursosPercorridos.Where(pr => pr.ClientID == clientID).ToList();
            var listaPercursosCriados = db.PercursosCriados.Where(pc => pc.IDCliente == clientID).ToList();
            var listaComentarios = db.PercursoComentarios.Where(c => c.ClientID == clientID).ToList();

            float contaKms=0;
            float contaHoras = 0;
            float media = 0;
            foreach (var item in listaPercursos)
            {
                PercursoPercorridoVM ppercVM = new PercursoPercorridoVM();
                ppercVM.Nome = item.Nome;
                ppercVM.ID = item.PercursoID;
                ppercVM.ClientID = item.ClientID;
                ppercVM.Distancia = item.Distancia;
                ppercVM.KmsPercorridos += item.Distancia;
                contaKms += item.Distancia;
                ViewBag.TotalKms = contaKms.ToString();
                contaHoras += item.Duracao;
                ViewBag.TotalHoras = contaHoras.ToString();
                media = contaKms/contaHoras;
                ViewBag.Media = media.ToString();
                percVM.ListaPercurosPercorridosVM.Add(ppercVM);
            }
            var maior = 0;
            foreach (var item in listaComentarios)
            {
                PercursoComentarioVM pComentVM = new PercursoComentarioVM();

                pComentVM.PercursoID = item.PercursoID;
                pComentVM.Classificacao = item.Classificacao;
                pComentVM.Comentario = item.Comentario;
                if (item.Classificacao > maior)
                {
                    maior = item.Classificacao;
                    ViewBag.Maior = maior.ToString();
                }
                percVM.ListaComentarios.Add(pComentVM);
            }

            foreach (var item in listaPercursosCriados)
            {
                PercursoCriadoVM pCriadoVM = new PercursoCriadoVM();
                pCriadoVM.IDCliente = item.IDCliente;
                pCriadoVM.NomeCliente = item.NomeCliente;
                pCriadoVM.PercursoID = item.PercursoID;
                pCriadoVM.NomePercurso = item.NomePercurso;

                percVM.ListaPercursosCriadosVM.Add(pCriadoVM);
            }



            return View(percVM);
        }

        // GET: Utilizadores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientID,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Utilizadors.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientID,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Utilizador utilizador = db.Utilizadors.Find(id);
            db.Utilizadors.Remove(utilizador);
            db.SaveChanges();
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
