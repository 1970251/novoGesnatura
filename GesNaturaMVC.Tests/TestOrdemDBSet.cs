using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestOrdemDBSet : TestDbSet<Ordem>
    {
        public override Ordem Find(params object[] keyValues)
        {
            return this.SingleOrDefault(or => or.ID == (int)keyValues.Single());
        }
    }
}
