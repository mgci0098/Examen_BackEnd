using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.ViewModels
{
    public class PachetPostModel
    {
        public string TaraOrigine { get; set; }
        public string DenumireExpeditor { get; set; }
        public string TaraDestinatie { get; set; }
        public string DenumireDestinatar { get; set; }
        public string AdresaDestinatar { get; set; }
        public double Cost { get; set; }
        public string CodTracking { get; set; }

        public static Pachet ToPachet(PachetPostModel pachetModel)
        {
            return new Pachet
            {
                TaraOrigine = pachetModel.TaraOrigine,
                DenumireExpeditor = pachetModel.DenumireExpeditor,
                TaraDestinatie = pachetModel.TaraDestinatie,
                DenumireDestinatar = pachetModel.DenumireDestinatar,
                AdresaDestinatar = pachetModel.AdresaDestinatar,
                Cost = pachetModel.Cost,
                CodTracking = pachetModel.CodTracking
            };
        }
    }
}
