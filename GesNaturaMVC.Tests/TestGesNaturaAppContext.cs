using GesNaturaMVC.DAL;
using GesNaturaMVC.Models;
using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestGesNaturaAppContext : IGesNaturaContext
    {
        public TestGesNaturaAppContext()
        {
            this.Reinoes = new TestReinoDbSet();
            this.Classes = new TestClasseDbSet();
            this.Especies = new TestEspecieDbSet();
            this.Generoes = new TestGeneroDbSet();
            this.Percursos = new TestPercursoDbSet();
            this.POIs = new TestPOIDbSet();
            this.Familias = new TestFamiliaDbSet();
            this.Ordems = new TestOrdemDBSet();
            this.PercursoComentarios = new TestPercursoComentarioDbSet();
            this.PercursosCriados = new TestPercursoCriadoDbSet();
            this.PercursosPercorridos = new TestPercursosPercorridosDbSet();

        }
        public DbSet<Reino> Reinoes { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Genero> Generoes { get; set; }
        public DbSet<Percurso> Percursos { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Ordem> Ordems { get; set; }
        public DbSet<PercursoComentario> PercursoComentarios { get; set; }
        public DbSet<PercursosPercorridos> PercursosPercorridos { get; set; }
        public DbSet<PercursosCriados> PercursosCriados { get; set; }
        public DbSet<POI> POIs { get; set; }
        public DbSet<FotoPercursos> FotoPercursos { get; set; }
        public int SaveChanges()
        {
            return 0;
        }


        public void MarcarComoModificado(Reino item) { }
        public void MarcarComoModificado(Classe item) { }
        public void MarcarComoModificado(Especie item) { }
        public void MarcarComoModificado(Genero item) { }
        public void MarcarComoModificado(Percurso item) { }
        public void MarcarComoModificado(Familia item) { }
        public void MarcarComoModificado(Ordem item) { }
        public void MarcarComoModificado(PercursoComentario item) { }
        public void MarcarComoModificado(PercursosPercorridos item) { }
        public void MarcarComoModificado(PercursosCriados item) { }
        public void MarcarComoModificado(POI item) { }
        public void MarcarComoModificado(FotoPercursos item) { }


        public void Dispose() { }
    }
}
