using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodning.Model
{
    class Kuverter
    {

        
        public int HusNr { get; set; }
        public double AntalVoksne { get; set; }
        public double AntalTeen { get; set; }
        public double AntalBoern { get; set; }
        public double AntalBaby { get; set; }
        public string Ugedag { get; set; }

        public override string ToString()
        {
            return "hus nummer: " + HusNr + " Dag: " + Ugedag + " Antal Kuverter: ";// der skal tilføjes en metode til at beregne samlet antal kuverter for hustand
        }

    }
}
