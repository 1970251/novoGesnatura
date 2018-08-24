using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestPOIDbSet : TestDbSet<POI>
    {
        public override POI Find(params object[] keyValues)
        {
            return this.SingleOrDefault(p => p.ID == (int)keyValues.Single());
        }
    }
}
