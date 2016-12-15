using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kodning.Model;
using Newtonsoft.Json;

namespace kodning.Model
{
    public class PrisBeregning : NotifyPropNotifications
    {
        public double _Pris;

        public double Kok1Udlæg { get; set; }
        public double Kok2Udlæg { get; set; }
        public double Kok3Udlæg { get; set; }
        public double Kok4Udlæg { get; set; }
        public int KuvertIAlt { get; set; }
        public double UdlægIAlt { get; set; }
        public double PrisIalt { get; set; }
        public double TotalKuvert { get; set; }
        //public double Pris { get; set; }
        public double kuverterForTirsdag { get; set; }
        public double kuverterForDagen { get; set; }
        public double kuverterForOnsdag { get; set; }
        public double kuverterForTorsdag { get; set; }


        #region
        public double ReturKuvert(KuverterListe listen)
        {

            foreach (var kuverter in listen)
            {
                kuverterForDagen += (kuverter.Voksne * 1) + (kuverter.Teens * 0.5) + (kuverter.Boern * 0.25) + (kuverter.Baby * 0);
            }
            return kuverterForDagen;
        }

        public double ReturKuvertTirsdag(KuverterListe Tirsdaglisten)
        {

            foreach (var kuverter in Tirsdaglisten)
            {
                kuverterForTirsdag += (kuverter.TirsdagVoksne * 1) + (kuverter.TirsdagTeens * 0.5) + (kuverter.TirsdagBoern * 0.25) + (kuverter.TirsdagBaby * 0);
            }
            return kuverterForTirsdag;
        }

        public double ReturKuvertOnsdag(KuverterListe Onsdaglisten)
        {

            foreach (var kuverter in Onsdaglisten)
            {
                kuverterForOnsdag += (kuverter.OnsdagVoksne * 1) + (kuverter.OnsdagTeens * 0.5) + (kuverter.OnsdagBoern * 0.25) + (kuverter.OndagsBaby * 0);
            }
            return kuverterForOnsdag;
        }





        public double ReturKuvertTorsdag(KuverterListe Torsdaglisten)
        {

            foreach (var kuverter in Torsdaglisten)
            {
                kuverterForTorsdag += (kuverter.TorsdagVoksne * 1) + (kuverter.TorsdagTeens * 0.5) + (kuverter.TorsdagBoern * 0.25) + (kuverter.TorsdagBaby * 0);
            }
            return kuverterForTorsdag;
        }
        #endregion




        public double Pris
        {
            get
            {
                return _Pris;
            }
            set
            {
                _Pris = value;
                OnPropertyChanged(nameof(Pris));
            }
        }


        public double PrisIAlt
        {
            get
            {

                UdlægIAlt = Kok1Udlæg + Kok2Udlæg + Kok3Udlæg + Kok4Udlæg;
                return UdlægIAlt;
            }
        }


    }
}
