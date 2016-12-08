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
        public KuverterListe KuvertListeMandag { get; set; } = new KuverterListe();

        public KuverterListe KuvertListeTirsdag { get; set; } = new KuverterListe();

        public KuverterListe KuvertListeOnsdag { get; set; } = new KuverterListe();

        public KuverterListe KuvertListeTorsdag { get; set; } = new KuverterListe();
    }
}
