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
        

        public override string ToString()
        {
            return "Ret: " + Madplannen + ". " + "Ingredienser: " + Ingredienser;
        }
    }
}
