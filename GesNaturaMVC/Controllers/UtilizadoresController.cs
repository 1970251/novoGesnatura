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
using GesPhloraClassLibrary.Models;
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


            var listaPercursos = db.PercursosPercorridos.Include(p => p.Percurso).Where(pr => pr.ClientID == clientID).ToList();
            var listaPercursosCriados = db.PercursosCriados.Include(p=>p.Percurso).Where(pc => pc.IDCliente == clientID).ToList();
            var listaComentarios = db.PercursoComentarios.Include(p=>p.Percurso).Where(c => c.CriadorPercurso == clientID).ToList();
            

            float contaKms=0;
            float contaHoras = 0;
            float media = 0;
            int nmrComentariosPorPercurso = 0;
            double numeroPercursosCriados = 0;
            int maiorNmrComentarios = 0;
            foreach (var item in listaPercursos)
            {
                PercursoPercorridoVM ppercVM = new PercursoPercorridoVM();
                ppercVM.Nome = item.Percurso.Nome;
                ppercVM.ID = item.PercursoID;
                ppercVM.ClientID = item.ClientID;
                ppercVM.Distancia = item.Percurso.Distancia;
                ppercVM.KmsPercorridos += percVM.Distancia;
                contaKms += item.Percurso.Distancia;
                ViewBag.TotalKms = contaKms.ToString();
                contaHoras += item.Percurso.DuracaoAproximada;
                ViewBag.TotalHoras = contaHoras.ToString();
                media = contaKms/contaHoras;
                ViewBag.Media = media.ToString();
                
                percVM.ListaPercurosPercorridosVM.Add(ppercVM);
            }
            var maior = 0;
            double numeroComentarios = 0;
            
            foreach (var item in listaComentarios)
            {
                PercursoComentarioVM pComentVM = new PercursoComentarioVM();
                
                pComentVM.PercursoID = item.PercursoID;
                ViewBag.ID = pComentVM.PercursoID;
                pComentVM.NomePercurso = item.Percurso?.Nome??"Sem Correspondencia";
                pComentVM.Classificacao = item.Classificacao;
                pComentVM.Comentario = item.Comentario;
             
                var listaComentPorPercurso = listaComentarios.Where(p => p.PercursoID == item.PercursoID).ToList();
                
                if(listaComentPorPercurso.Count > 1 && numeroComentarios < listaComentarios.Count)
                {
                    
                    
                    int somaPerc = 0;
                    foreach(var perc in listaComentPorPercurso)
                    {
                        somaPerc += perc.Classificacao;
                        nmrComentariosPorPercurso++;
                        int classPerc = somaPerc / nmrComentariosPorPercurso;
                        pComentVM.Classificacao = classPerc;
                        
                        if (nmrComentariosPorPercurso > maiorNmrComentarios)
                        {
                            maiorNmrComentarios = nmrComentariosPorPercurso;
                            ViewBag.MaisComentarios = perc.Percurso.Nome;
                        }
                        
                        
                    }
                    nmrComentariosPorPercurso = 0;
                    numeroComentarios = nmrComentariosPorPercurso - 1;
                }
                numeroComentarios++;
                if (pComentVM.Classificacao > maior)
                {
                    maior = pComentVM.Classificacao;
                    ViewBag.Maior = maior.ToString();
                    ViewBag.Nome = pComentVM.NomePercurso;
                }
                
               if(numeroComentarios > listaComentarios.Count)
                {
                    numeroComentarios--;
                }

                percVM.ListaComentarios.Add(pComentVM);
                
            }

            foreach (var item in listaPercursosCriados)
            {
                PercursoCriadoVM pCriadoVM = new PercursoCriadoVM();
                pCriadoVM.IDCliente = item.IDCliente;
                pCriadoVM.NomeCliente = item.NomeCliente;
                pCriadoVM.PercursoID = item.PercursoID;
                pCriadoVM.NomePercurso = item.Percurso.Nome;
                numeroPercursosCriados++;
                percVM.ListaPercursosCriadosVM.Add(pCriadoVM);
            }

            
            double percentagem = (listaComentarios.Count/numeroPercursosCriados)*100;

            ViewBag.Percentagem = percentagem.ToString();

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
