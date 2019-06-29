using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class Pachet
    {
        public int Id { get; set; }
        public string TaraOrigine { get; set; }
        public string DenumireExpeditor { get; set; }
        public string TaraDestinatie { get; set; }
        public string DenumireDestinatar { get; set; }
        public string AdresaDestinatar { get; set; }
        public double Cost { get; set; }
        public string CodTracking { get; set; }
    }
}
