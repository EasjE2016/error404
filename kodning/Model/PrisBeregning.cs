using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodning.Model
{
    public class PrisBeregning
    {
        public double Kok1Udlæg { get; set; }
        public double Kok2Udlæg { get; set; }
        public double Kok3Udlæg { get; set; }
        public double Kok4Udlæg { get; set; }
        public int KuvertIAlt { get; private set; }
        public double PrisiAlt { get; private set; }
        public double PrisIalt { get; set; }

        public double PrisIAlt { get
            {
                PrisiAlt = 0;                
                PrisiAlt = +Kok1Udlæg + Kok2Udlæg + Kok3Udlæg + Kok4Udlæg;
                return PrisiAlt;
            }
        }



    }
}
