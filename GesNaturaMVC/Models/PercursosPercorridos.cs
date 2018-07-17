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
        public string Nome { get; set; }
        public float Duracao { get; set; }
        public float Distancia { get; set; }
        public string ClientID { get; set; }
        public Utilizador Utilizador { get; set; }
        public int PercursoID { get; set; }
        public Percurso Percurso { get; set; }

    }
}