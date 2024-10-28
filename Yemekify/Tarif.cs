using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yemekify
{
    public class Tarif
    {
        public int TarifID { get; set; }
        public string TarifAdi { get; set; }
        public string Kategori { get; set; }
        public string HazirlamaSuresi { get; set; }
        public string Talimatlar { get; set; }
        public byte[] imageBytes { get; set; }

        public bool HasMissingIngredients { get; set; }
        public double MatchingPercentage { get; set; }

        public List<Malzeme> RequiredIngredients { get; set; } = new List<Malzeme>(); 


        public List<Malzeme> MissingIngredients { get; set; } = new List<Malzeme>();


        public Tarif(int tarifID, string tarifAdi, string kategori, string hazirlamaSuresi, string talimatlar, byte[] imageBytes)
        {
            TarifID = tarifID;
            TarifAdi = tarifAdi;
            Kategori = kategori;
            HazirlamaSuresi = hazirlamaSuresi;
            Talimatlar = talimatlar;
            this.imageBytes = imageBytes;
        }

    }
}
