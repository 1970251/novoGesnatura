using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestEspecieDbSet : TestDbSet<Especie>
    {

        public override Especie Find(params object[] keyValues)
        {
            return this.SingleOrDefault(esp => esp.ID == (int)keyValues.Single());
        }
    }
}
