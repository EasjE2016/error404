using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodning.Model
{
    public sealed class KuvertCatalogSingleton
    {
        public static KuvertCatalogSingleton Instance { get; set; } = new KuvertCatalogSingleton();
        
        public KuverterListe MandagListe { get; set; } = new KuverterListe();
        public KuverterListe TirsdagListe { get; set; } = new KuverterListe();
        public KuverterListe OnsdagListe { get; set; } = new KuverterListe();
        public KuverterListe TorsdagListe { get; set; } = new KuverterListe();



        private KuvertCatalogSingleton()
        {
            MandagListe = new KuverterListe();
            TirsdagListe = new KuverterListe();
            OnsdagListe = new KuverterListe();
            TorsdagListe = new KuverterListe();
        }
     }
}
