using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kodning.ViewModel;

namespace kodning.Model
{
    public class Kuverter
    {

        
        public int HusNr { get; set; }
        public double AntalVoksne { get; set; }
        public double AntalTeen { get; set; }
        public double AntalBoern { get; set; }
        public double AntalBaby { get; set; }
        public string Ugedag { get; set; }

        public override string ToString()
        {
            return "Antal kuverter: ";// der skal tilføjes en metode til at beregne samlet antal kuverter for hustand
        }
        public double AntalKuverter()
        {
            return 0;
        }

    }
}
