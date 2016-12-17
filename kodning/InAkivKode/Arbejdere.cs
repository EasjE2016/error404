using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodning.Model
{
    public class Arbejdere
    {
        public string MandagTitle { get; set; }
        public string MandagNavn { get; set; }
        public string TirsdagTitle { get; set; }
        public string TirsdagNavn { get; set; }
        public string OnsdagTitle { get; set; }
        public string OnsdagNavn { get; set; }
        public string TorsdagTitle { get; set; }
        public string TorsdagNavn { get; set; }


   
        public override string ToString()
        {
            return "Opgave: " + MandagTitle + " Navn på ansvarlig: " + MandagNavn;
        }



    }
}
