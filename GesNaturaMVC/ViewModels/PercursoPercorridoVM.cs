using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesNaturaMVC.ViewModels
{
    public class PercursoPercorridoVM
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string ClientID { get; set; }
        public int Classificacao { get; set; }
        public float Duracao { get; set; }
        public float KmsPercorridos { get; set; }

    }
}