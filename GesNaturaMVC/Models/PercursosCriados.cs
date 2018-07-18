using GesPhloraClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesNaturaMVC.Models
{
    public class PercursosCriados
    {
        public int ID { get; set; }
        public string IDCliente { get; set; }
        public string NomeCliente { get; set; }
        public int PercursoID { get; set; }
        public Percurso Percurso { get; set; }
        public string NomePercurso { get; set; }


    }
}