using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestReinoDbSet : TestDbSet<Reino>
    {
        public override Reino Find(params object[] keyValues)
        {
            return this.SingleOrDefault(reino => reino.ID == (int)keyValues.Single());
        }

    }
}
