using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kodning.ViewModel;
using kodning.Model;


namespace kodning.Model
{
    public class Kuverter
    {
        #region Mandag kuverter

        public int Husnummer { get; set; }
        public double MandagVoksne { get; set; }
        public double MandagTeens { get; set; }
        public double MandagBoern { get; set; }
        public double MandagBaby { get; set; }
        public double MandagKuvertForHustand { get; set; }
        public double MandagAntalKuverterForHustand
        {
            get
            { return MandagKuvertForHustand; }
            set
            {
                
                MandagKuvertForHustand += (MandagVoksne * 1) + (MandagTeens * 0.5) + (MandagBoern * 0.25) + (MandagBaby * 0);
            }
        }



        #endregion

        #region Tirsdag Kuverter
        public double TirsdagVoksne { get; set; }
        public double TirsdagTeens { get; set; }
        public double TirsdagBoern { get; set; }
        public double TirsdagBaby { get; set; }
        public double TirsdagKuvertForHustand { get; set; }
        public double TirsdagAntalKuverterForHustand
        {
            get
            { return TirsdagKuvertForHustand; }
            set
            {

                TirsdagKuvertForHustand += (TirsdagVoksne * 1) + (TirsdagTeens * 0.5) + (TirsdagBoern * 0.25) + (TirsdagBaby * 0);
            }
        }
        #endregion

        #region Onsdag Kuverter
        public double OnsdagVoksne { get; set; }
        public double OnsdagTeens { get; set; }
        public double OnsdagBoern { get; set; }
        public double OnsdagBaby { get; set; }
        public double OnsdagKuvertForHustand { get; set; }
        public double OnsdagAntalKuverterForHustand
        {
            get
            { return OnsdagKuvertForHustand; }
            set
            {

                OnsdagKuvertForHustand += (OnsdagVoksne * 1) + (OnsdagTeens * 0.5) + (OnsdagBoern * 0.25) + (OnsdagBaby * 0);
            }
        }
        #endregion

        #region Torsdag Kuverter
        public double TorsdagVoksne { get; set; }
        public double TorsdagTeens { get; set; }
        public double TorsdagBoern { get; set; }
        public double TorsdagBaby { get; set; }
        public double TorsdagKuvertForHustand { get; set; }
        public double TorsdagAntalKuverterForHustand
        {
            get
            { return TorsdagKuvertForHustand; }
            set
            {

                TorsdagKuvertForHustand += (TorsdagVoksne * 1) + (TorsdagTeens * 0.5) + (TorsdagBoern * 0.25) + (TorsdagBaby * 0);
            }
        }
        #endregion


        /// <summary> Kaspers Summary
        /// 
        /// 
        /// Problemet med hele den her klasse er åbenlys der er ikke generaliseret nok, grunden er dog som følgende: ToString herunder skal spytte Husnummer ud, hvis jeg generalisere klassen
        /// ville jeg for hvert object af denne klasse skulle tilføje tilsvarende husnummer dvs. At der i "view" skal være 4 bokse til husnummer hvor vi kun ønsker 1. Har ikke kunne komme udenom dette.
        /// 
        /// Eftertanke - klokken 02:15 Søndag nat: Jeg kunne have lavet klassen simpel og sagt i IF statement til tilføjelse af deltager at man nok kunne sige f.eks. 
        /// TirsdagKuvert.Husnummer = MandagKuvert.Husnummer
        /// OnsdagKuvert.Husnummer = MandagKuvert.Husnummer
        /// TorsdagKuvert.Husnummer = MandagKuvert.Husnummer
        /// Og derved binde boksen hvor man skriver husnummer ind til MandagKuvert.Husnummer. 
        /// 
        /// En mere generaliseret klasse kan ses under "Arbejdere"
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return "Husnummer " + Husnummer + " tilmeldt kuverter for hustanden er" + MandagKuvertForHustand;
        }

    }
}
