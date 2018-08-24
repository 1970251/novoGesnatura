using GesNaturaMVC.Tests;
using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestFamiliaDbSet : TestDbSet<Familia>
    {
        public override Familia Find(params object[] keyValues)
        {
            return this.SingleOrDefault(f => f.ID == (int)keyValues.Single());
        }
    }
}
