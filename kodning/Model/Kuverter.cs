using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodning.Model
{
    class Kuverter
    {

        // Constructor
        public int HusNr { get; set; }
        public int AntalVoksne { get; set; }
        public int AntalTeen { get; set; }
        public int AntalBoern { get; set; }
        public int AntalBaby { get; set; }
       
        public void AddNewKuvert()
        {
            Kuverter kuv = new Kuverter();
            kuv.HusNr = NewKuvert.HusNr;
            kuv.AntalVoksne = NewKuvert.AntalVoksne;
            kuv.AntalTeen = NewKuvert.AntalTeen;
            kuv.AntalBoern = NewKuvert.AntalBoern;
            kuv.AntalBaby = NewKuvert.AntalBaby;

            KuverterListe.Add(kuv);

        }

        //KuvertListe
        public Kuverter NewKuvert { get; set; }

    }
}
