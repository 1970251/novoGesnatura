﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GesPhloraClassLibrary.Models;
using GesNaturaMVC.Models;

namespace GesNaturaMVC.DAL
{
    public class IGesNaturaDbContext : ApplicationDbContext, IGesNaturaContext

    {
        public IGesNaturaDbContext() : base() { }
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

        public System.Data.Entity.DbSet<GesNaturaMVC.Models.PercursosCriados> PercursosCriados { get; set; }

        public DbSet<Reino> Reinos => throw new NotImplementedException();

        public void MarcarComoModificado(Reino item)
        {
            Entry(item).State = EntityState.Modified;
            //throw new NotImplementedException();
        }
        
    }
}