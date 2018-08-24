using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestClasseDbSet : TestDbSet<Classe>
    {
        public override Classe Find(params object[] keyValues)
        {
            return this.SingleOrDefault(cl => cl.ID == (int)keyValues.Single());
        }

    }
}
