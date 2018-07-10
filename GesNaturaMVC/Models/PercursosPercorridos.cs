using GesPhloraClassLibrary.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesNaturaMVC.Models
{
    public class PercursosPercorridos
    {
        public int ID { get; set; }
        public IdentityUser User { get; set; }
        public Percurso PercursoID { get; set; }
    }
}