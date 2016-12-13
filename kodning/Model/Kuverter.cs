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

        public string Ugedag { get; set; }
        public int Husnummer { get; set; }
        public double Voksne { get; set; }
        public double Teens { get; set; }
        public double Boern { get; set; }
        public double Baby { get; set; }


        public override string ToString()
        {
            return "Husnummer " + Husnummer + " tilmeldt";
        }
    }
}
