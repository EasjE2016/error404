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
        KuverterListe KuvertListeMandag = new KuverterListe();

        KuverterListe KuvertListeTirsdag = new KuverterListe();

        KuverterListe KuvertListeOnsdag = new KuverterListe();

        KuverterListe KuvertListeTorsdag = new KuverterListe();
    }
}
