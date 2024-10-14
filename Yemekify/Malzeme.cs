using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace Yemekify
{
    public class Malzeme
    {
        public int MalzemeID { get; set; }
        public string MalzemeAdi { get; set; }
        public string ToplamMiktar { get; set; }
        public string MalzemeBirim { get; set; }
        public double BirimFiyat { get; set; }

        public Malzeme(int MalzemeID,string MalzemeAdi,string ToplamMiktar,string MalzemeBirim,double BirimFiyat) {
            this.MalzemeID = MalzemeID;
            this.ToplamMiktar = ToplamMiktar;
            this.BirimFiyat = BirimFiyat;
            this.MalzemeBirim = MalzemeBirim;
            this.MalzemeAdi = MalzemeAdi;
        }

        public override string ToString()
        {
            return String.Concat(ToplamMiktar + " ", MalzemeBirim + " ", MalzemeAdi + " ");
        }
    }
}
