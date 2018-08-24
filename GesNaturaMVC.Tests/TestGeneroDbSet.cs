using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestGeneroDbSet : TestDbSet<Genero>
    {
        public override Genero Find(params object[] keyValues)
        {
            return this.SingleOrDefault(g => g.ID == (int)keyValues.Single());
        }
    }
}
