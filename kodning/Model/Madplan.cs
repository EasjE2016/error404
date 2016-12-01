﻿using System;
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
        public string UgeDag { get; set; }
        public int UgeNr { get; set; }
        public double Pris { get; set; }
        
        


        public override string ToString()
        {
            return "Uge: "+UgeNr + " Dag: "+ UgeDag + " Ret: " + Madplannen + " Ingredienser: " + Ingredienser + " pris " + Pris;
        }
    }
}
