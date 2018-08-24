using GesNaturaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestPercursoCriadoDbSet :TestDbSet<PercursosCriados>
    {

        public override PercursosCriados Find(params object[] keyValues)
        {
            return this.SingleOrDefault(pc => pc.ID == (int)keyValues.Single());
        }
    }
}
