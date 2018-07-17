using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesNaturaMVC.ViewModels
{
    public class EstatisticaVM
    {
        public string ClientID { get; set; }
        public List<PercursoCriadoVM> PercursosCriados { get; set; }
        public List<PercursoPercorridoVM> PercursosPercorridos { get; set; }
    }
}