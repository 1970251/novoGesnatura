using GesNaturaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace GesPhloraClassLibrary.Models
{
    public interface IGesNaturaContext : IDisposable
    {
        DbSet<Reino> Reinoes { get; }
        DbSet<Classe> Classes { get; }
        DbSet<Especie> Especies { get; }
        DbSet<Genero> Generoes { get; }
        DbSet<Percurso> Percursos { get; }
        DbSet<POI> POIs { get; }
        DbSet<Familia> Familias { get; }
        DbSet<Ordem> Ordems { get; }
        DbSet<PercursoComentario> PercursoComentarios { get; }
        DbSet<PercursosCriados> PercursosCriados { get; }
        DbSet<PercursosPercorridos> PercursosPercorridos { get; }
        DbSet<FotoPercursos> FotoPercursos { get; }
        int SaveChanges();
        
        void MarcarComoModificado(Reino item);
        void MarcarComoModificado(Classe item);
        void MarcarComoModificado(Especie item);
        void MarcarComoModificado(Genero item);
        void MarcarComoModificado(Percurso item);
        void MarcarComoModificado(POI item);
        void MarcarComoModificado(Familia item);
        void MarcarComoModificado(Ordem item);
        void MarcarComoModificado(PercursosCriados item);
        void MarcarComoModificado(PercursoComentario item);
        void MarcarComoModificado(PercursosPercorridos item);
        void MarcarComoModificado(FotoPercursos item);

    }
}
