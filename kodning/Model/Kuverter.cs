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

        public string Ugedag { get; set; }
        public int Husnummer { get; set; }
        public double Voksne { get; set; }
        public double Teens { get; set; }
        public double Boern { get; set; }
        public double Baby { get; set; }



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
