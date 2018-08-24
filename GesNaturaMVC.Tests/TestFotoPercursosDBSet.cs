using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestFotoPercursosDBSet : TestDbSet<FotoPercursos>
    {

        public override FotoPercursos Find(params object[] keyValues)
        {
            return this.SingleOrDefault(esp => esp.ID == (int)keyValues.Single());
        }
    }
}
