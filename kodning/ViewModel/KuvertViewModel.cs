using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kodning.Model;
using System.ComponentModel;
using Windows.Storage;
using Windows.UI.Popups;

namespace kodning.ViewModel
{
    public class KuvertViewModel : INotifyPropertyChanged
    {
        public UgeKuverter UgeKuverter { get; set; }
        public PrisBeregning PrisBeregning { get; set; }
        public string Kuvertfilnavn { get; private set; }
        public double PrisIalt { get; private set; }

        private KuverterListe _kuvertsliste;



        #region Props til Tilmeldning
        public int Husnummer { get; set; }
        public double MandagVoksne { get; set; }
        public double MandagTeens { get; set; }
        public double MandagBoern { get; set; }
        public double MandagBaby { get; set; }
        #endregion


        #region Foreach loop over samlet antal kuverter
        public double GivAlleKuverterMandag
        {
            get
            {
                double KuverterForMandag = 0;
                foreach (var kuverter in KuvertListenMandag)
                {
                    KuverterForMandag = +(kuverter.AntalVoksne * 1) + (kuverter.AntalTeen * 0.5) + (kuverter.AntalBoern * 0.25) + (kuverter.AntalBaby * 0);
                }
                return KuverterForMandag;
            }
        }
        public double GivAlleKuverterTirsdag
        {
            get
            {
                double KuverterForTirsdag = 0;
                foreach (var kuverter in KuvertListenTirsdag)
                {
                    KuverterForTirsdag = +(kuverter.AntalVoksne * 1) + (kuverter.AntalTeen * 0.5) + (kuverter.AntalBoern * 0.25) + (kuverter.AntalBaby * 0);
                }
                return KuverterForTirsdag;
            }
        }
        public double GivAlleKuverterOnsdag
        {
            get
            {
                double KuverterForOnsdag = 0;
                foreach (var kuverter in KuvertListenOnsdag)
                {
                    KuverterForOnsdag = +(kuverter.AntalVoksne * 1) + (kuverter.AntalTeen * 0.5) + (kuverter.AntalBoern * 0.25) + (kuverter.AntalBaby * 0);
                }
                return KuverterForOnsdag;
            }
        }
        public double GivAlleKuverterTorsdag
        {
            get
            {
                double KuverterForTorsdag = 0;
                foreach (var kuverter in KuvertListenTorsdag)
                {
                    KuverterForTorsdag = +(kuverter.AntalVoksne * 1) + (kuverter.AntalTeen * 0.5) + (kuverter.AntalBoern * 0.25) + (kuverter.AntalBaby * 0);
                }
                return KuverterForTorsdag;
            }
        }
        public void BeregnPrisIAlt()
        {
            PrisIalt = +(GivAlleKuverterMandag + GivAlleKuverterTirsdag + GivAlleKuverterOnsdag + GivAlleKuverterTorsdag)/PrisIalt;
            
        }



        #endregion


        #region RelayCommands
        public RelayCommand.RelayCommand TilmeldCommand { get; set; }
        public RelayCommand.RelayCommand UdregnAlleKuverterForDag { get; set; }
        #endregion


        #region Metode til at fortælle hvorvidt der er sket en ændring propertychange
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        #region onpropchange til KuvertLister
        public KuverterListe KuvertListenMandag
        {
            get { return _kuvertsliste; }
            set
            {
                _kuvertsliste = value;
                OnPropertyChanged(nameof(KuvertListenMandag));
            }
        }
        public KuverterListe KuvertListenTirsdag
        {
            get { return _kuvertsliste; }
            set
            {
                _kuvertsliste = value;
                OnPropertyChanged(nameof(KuvertListenTirsdag));
            }
        }
        public KuverterListe KuvertListenOnsdag
        {
            get { return _kuvertsliste; }
            set
            {
                _kuvertsliste = value;
                OnPropertyChanged(nameof(KuvertListenOnsdag));
            }
        }
        public KuverterListe KuvertListenTorsdag
        {
            get { return _kuvertsliste; }
            set
            {
                _kuvertsliste = value;
                OnPropertyChanged(nameof(KuvertListenTorsdag));
            }
        }

        
        #endregion



        #region Metode til Tilføje Kuverter
        public void AddNewKuvert()
        {
            Kuverter MandagsKuvert = new Kuverter();
            MandagsKuvert.HusNr = Husnummer;
            MandagsKuvert.AntalVoksne = MandagVoksne;
            MandagsKuvert.AntalTeen = MandagTeens;
            MandagsKuvert.AntalBoern = MandagBoern;
            MandagsKuvert.AntalBaby = MandagBaby;
            MandagsKuvert.Ugedag = "Mandag";
            UgeKuverter.KuvertListeMandag.Add(MandagsKuvert);
        }
        #endregion

        #region Konstruktør
        public KuvertViewModel()
        {
            KuvertListenMandag = new KuverterListe();
            KuvertListenTirsdag = new KuverterListe();
            KuvertListenOnsdag = new KuverterListe();
            KuvertListenTorsdag = new KuverterListe();
            UgeKuverter = new UgeKuverter();
            TilmeldCommand = new RelayCommand.RelayCommand(AddNewKuvert);
            UdregnAlleKuverterForDag = new RelayCommand.RelayCommand(BeregnPrisIAlt);
        }
        #endregion

        #region Json

        private readonly string lisa = "JsonText.json";
        StorageFolder localfolder = null;
        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.KuvertListenMandag.GetJson();
            StorageFile lisa = await localfolder.CreateFileAsync(Kuvertfilnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(lisa, jsonText);
        }

        public async void HentDataFraDiskAsync()
        {

            try
            {
                StorageFile lisa = await localfolder.GetFileAsync(Kuvertfilnavn);

                string jsonText = await FileIO.ReadTextAsync(lisa);

                this.KuvertListenMandag.Clear();

                //metoden på medarbejderlisten
                KuvertListenMandag.IndsætJson(jsonText);

                // Try og catch for at fange en exception for at undgå grimme fejlmeddelser
            }
            catch (Exception)
            {
                //Popup vindue til at fortælle brugeren at filen ikke blev fundet. 
                MessageDialog messageDialog = new MessageDialog("Filen ikke fundet. Har du fjernet den?");
                await messageDialog.ShowAsync();
                //throw;
            }
        }
        #endregion
    }
}
