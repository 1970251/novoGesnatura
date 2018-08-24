using GesNaturaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestPercursosPercorridosDbSet : TestDbSet<PercursosPercorridos>
    {
        public override PercursosPercorridos Find(params object[] keyValues)
        {
            return this.SingleOrDefault(pp => pp.ID == (int)keyValues.Single());
        }
    }
}
