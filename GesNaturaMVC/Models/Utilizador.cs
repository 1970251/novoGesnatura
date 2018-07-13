using GesPhloraClassLibrary.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GesNaturaMVC.Models
{
    public class Utilizador : IdentityUser
    {
        public string UtilizadorID { get; set; }
        public ICollection<Percurso> Percursos { get; set; }
    }
}