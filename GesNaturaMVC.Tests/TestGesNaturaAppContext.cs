using GesNaturaMVC.DAL;
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
        }
        public DbSet<Reino> Reinoes { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarcarComoModificado(Reino item) { }
        public void Dispose() { }
    }
}
