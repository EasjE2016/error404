using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kodning.ViewModel;
using kodning.Model;

namespace kodning.Model
{
    public class Kuverter
    {
        #region Mandag kuverter

        public int Husnummer { get; set; }
        public double MandagVoksne { get; set; }
        public double MandagTeens { get; set; }
        public double MandagBoern { get; set; }
        public double MandagBaby { get; set; }

        #endregion

        public double TirsdagVoksne { get; set; }
        public double TirsdagTeens { get; set; }
        public double TirsdagBoern { get; set; }
        public double TirsdagBaby { get; set; }



        public double OnsdagVoksne { get; set; }
        public double OnsdagTeens { get; set; }
        public double OnsdagBoern { get; set; }
        public double OndagsBaby { get; set; }


        public double TorsdagVoksne { get; set; }
        public double TorsdagTeens { get; set; }
        public double TorsdagBoern { get; set; }
        public double TorsdagBaby { get; set; }




        public override string ToString()
        {
            return "Husnummer " + Husnummer + " tilmeldt";
        }
    }
}
