using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodning
{
    class Madplan
    {
        public string Madplannen { get; set; }
        public string Ingredienser { get; set; }
        public string ugeDag { get; set; }

        public override string ToString()
        {
            return "Ugedag = " + ugeDag + "Ret: " + Madplannen + ". " + "Ingredienser: " + Ingredienser;
        }
    }
}
