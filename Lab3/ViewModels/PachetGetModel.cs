using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.ViewModels
{
    public class PachetGetModel
    {
        public int Id { get; set; }
        public string TaraOrigine { get; set; }
        public string DenumireExpeditor { get; set; }
        public string TaraDestinatie { get; set; }
        public string DenumireDestinatar { get; set; }
        public string AdresaDestinatar { get; set; }
        public double Cost { get; set; }
        public string CodTracking { get; set; }

        public static PachetGetModel FromPachet(Pachet pachet)
        {
            return new PachetGetModel
            {
                Id = pachet.Id,
                TaraOrigine = pachet.TaraOrigine,
                DenumireExpeditor = pachet.DenumireExpeditor,
                TaraDestinatie = pachet.TaraDestinatie,
                DenumireDestinatar = pachet.DenumireDestinatar,
                AdresaDestinatar = pachet.AdresaDestinatar,
                Cost = pachet.Cost,
                CodTracking = pachet.CodTracking
            };
        }
    }
}
