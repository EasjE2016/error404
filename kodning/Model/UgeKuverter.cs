using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodning.Model
{
     public class UgeKuverter
    {

        public UgeKuverter()
        {
            KuvertListeMandag.GetJson();
            KuvertListeTirsdag.GetJson();
            KuvertListeOnsdag.GetJson();
            KuvertListeTorsdag.GetJson();
        }
        public KuverterListe KuvertListeMandag = new KuverterListe();

        public KuverterListe KuvertListeTirsdag = new KuverterListe();

        public KuverterListe KuvertListeOnsdag = new KuverterListe();

        public KuverterListe KuvertListeTorsdag = new KuverterListe();
    }
}
