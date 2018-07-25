using GesPhloraClassLibrary.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GesNaturaMVC.Models
{
    public class PercursosPercorridos
    {
        public int ID { get; set; }
        public string ClientID { get; set; }
        public float TempoGasto { get; set; }
        public DateTime Data { get; set; }
        public Utilizador Utilizador { get; set; }
        [ForeignKey("Percurso")]
        public int PercursoID { get; set; }
        public Percurso Percurso { get; set; }

    }
}