using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNaturaMVC.Tests
{
    class TestPercursoComentarioDbSet : TestDbSet<PercursoComentario>
    {
        public override PercursoComentario Find(params object[] keyValues)
        {
            return this.SingleOrDefault(pc => pc.ID == (int)keyValues.Single());
        }
    }
}
