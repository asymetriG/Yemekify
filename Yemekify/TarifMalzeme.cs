using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yemekify
{
    public class TarifMalzeme
    {
        private int TarifID { get; set; }
        private int MalzemeID { get; set; }
        private float MalzemeMiktar { get; set; }

        public TarifMalzeme(int tarifID, int malzemeID, float malzemeMiktar)
        {
            TarifID = tarifID;
            MalzemeID = malzemeID;
            MalzemeMiktar = malzemeMiktar;
        }

    }
}
