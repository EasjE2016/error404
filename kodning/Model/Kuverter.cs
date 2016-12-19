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




        public override string ToString()
        {
            return "Husnummer " + Husnummer + " tilmeldt kuverter for hustanden er" + MandagKuvertForHustand;
        }

    }
}
