using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kodning.Model
{
    public class Tilmeld
    {
        public int HusNr { get; set; }
        public int UgeDageBestilt { get; set; }
        public int AntalVoksne { get; set; }
        public int AntalUnge { get; set; }
        public int AntalBørn { get; set; }
        public int AntalBaby { get; set; }
        public int UgeNrBestilt { get; set; }

        public string UdregnTilmeld()
        {
            return "Der er " + AntalVoksne + " voksne og " + AntalUnge + " unge og " + AntalBørn + " børn og " + AntalBaby + "babyer";
        }
    }
}
