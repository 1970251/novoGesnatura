using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GesPhloraClassLibrary.Models;
using GesNaturaMVC.Models;

namespace GesNaturaMVC.DAL
{
    public class GesNaturaDbContext : ApplicationDbContext, IGesNaturaContext

    {
        public GesNaturaDbContext() : base() { }
        public DbSet<Percurso> Percursos { get; set; }
        public DbSet<POI> POIs { get; set; }
        public DbSet<Reino> Reinoes { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Ordem> Ordems { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Genero> Generoes { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<FotoAtlas> FotoAtlas { get; set; }
        public DbSet<FotoPercursos> FotoPercursos { get; set; }
        public DbSet<FotoPois> FotoPois { get; set; }
        public DbSet<Utilizador> Utilizadors { get; set; }
        public DbSet<PercursoComentario> PercursoComentarios { get; set; }
        public DbSet<PercursosPercorridos> PercursosPercorridos { get; set; }
        public DbSet<PercursosCriados> PercursosCriados { get; set; }


        public void MarcarComoModificado(Reino item)
        {
            Entry(item).State = EntityState.Modified;
            
        }
        public void MarcarComoModificado(Classe item)
        {
            Entry(item).State = EntityState.Modified;
           
        }
        public void MarcarComoModificado(Especie item)
        {
            Entry(item).State = EntityState.Modified;
        }   
        public void MarcarComoModificado(Genero item)
        {
            Entry(item).State = EntityState.Modified;
            
        }
        public void MarcarComoModificado(Percurso item)
        {
            Entry(item).State = EntityState.Modified;
            
        }
        public void MarcarComoModificado(Familia item)
        {
            Entry(item).State = EntityState.Modified;
           
        }
        public void MarcarComoModificado(Ordem item)
        {
            Entry(item).State = EntityState.Modified;

        }
        public void MarcarComoModificado(PercursoComentario item)
        {
            Entry(item).State = EntityState.Modified;

        }
        public void MarcarComoModificado(PercursosCriados item)
        {
            Entry(item).State = EntityState.Modified;

        }
        public void MarcarComoModificado(PercursosPercorridos item)
        {
            Entry(item).State = EntityState.Modified;

        }
        public void MarcarComoModificado(POI item)
        {
            Entry(item).State = EntityState.Modified;

        }
        public void MarcarComoModificado(FotoPercursos item)
        {
            Entry(item).State = EntityState.Modified;

        }

    }
}