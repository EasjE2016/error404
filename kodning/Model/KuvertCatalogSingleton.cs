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
            MandagListe.GetJson();
            TirsdagListe = new KuverterListe();
            TirsdagListe.GetJson();
            OnsdagListe = new KuverterListe();
            OnsdagListe.GetJson();
            TorsdagListe = new KuverterListe();
            TorsdagListe.GetJson();
        }
        public double ReturKuvert(KuverterListe listen)
        {
            double kuverterForDagen = 0;
            foreach (var kuverter in listen)
            {
                kuverterForDagen += (kuverter.Voksne * 1) + (kuverter.Teens * 0.5) + (kuverter.Boern * 0.25) + (kuverter.Baby * 0);
            }
            return kuverterForDagen;
        }

        public double ReturKuvertTirsdag(KuverterListe Tirsdaglisten)
        {
            double kuverterForTirsdag = 0;
            foreach (var kuverter in Tirsdaglisten)
            {
                kuverterForTirsdag += (kuverter.TirsdagVoksne * 1) + (kuverter.TirsdagTeens * 0.5) + (kuverter.TirsdagBoern * 0.25) + (kuverter.TirsdagBaby * 0);
            }
            return kuverterForTirsdag;
        }

        public double ReturKuvertOnsdag(KuverterListe Onsdaglisten)
        {
            double kuverterForOnsdag = 0;
            foreach (var kuverter in Onsdaglisten)
            {
                kuverterForOnsdag += (kuverter.OnsdagVoksne * 1) + (kuverter.OnsdagTeens * 0.5) + (kuverter.OnsdagBoern * 0.25) + (kuverter.OndagsBaby * 0);
            }
            return kuverterForOnsdag;
        }





        public double ReturKuvertTorsdag(KuverterListe Torsdaglisten)
        {
            double kuverterForTorsdag = 0;
            foreach (var kuverter in Torsdaglisten)
            {
                kuverterForTorsdag += (kuverter.TorsdagVoksne * 1) + (kuverter.TorsdagTeens * 0.5) + (kuverter.TorsdagBoern * 0.25) + (kuverter.TorsdagBaby * 0);
            }
            return kuverterForTorsdag;
        }
    }
}
