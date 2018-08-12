using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace GesPhloraClassLibrary.Models
{
    public interface IGesNaturaContext : IDisposable
    {
        DbSet<Reino> Reinoes { get; }
        int SaveChanges();
        void MarcarComoModificado(Reino item);
        
    }
}
