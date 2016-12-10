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
        }
        public KuverterListe KuvertListeMandag { get; set; } = new KuverterListe();        
    }
}
