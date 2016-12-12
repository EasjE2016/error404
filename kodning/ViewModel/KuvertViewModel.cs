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
        public Kuverter Kuverter { get; set; }
        public UgeKuverter UgeKuverter { get; set; }
        public PrisBeregning PrisBeregning { get; set; }
        public string Kuvertfilnavn { get; private set; }
        private KuverterListe _kuvertsliste;



        #region Props til Tilmeldning

        #endregion


        #region Foreach loop over samlet antal kuverter
        public double GivAlleKuverterMandag
        {
            get
            {
                double KuverterForMandag = 0;
                foreach (var kuverter in KuvertListenMandag)
                {
                    KuverterForMandag = +(kuverter.Voksne * 1) + (kuverter.Teens * 0.5) + (kuverter.Boern * 0.25) + (kuverter.Baby * 0);
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
                    KuverterForTirsdag = +(kuverter.Voksne * 1) + (kuverter.Teens * 0.5) + (kuverter.Boern * 0.25) + (kuverter.Baby * 0);
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
                    KuverterForOnsdag = +(kuverter.Voksne * 1) + (kuverter.Teens * 0.5) + (kuverter.Boern * 0.25) + (kuverter.Baby * 0);
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
                    KuverterForTorsdag = +(kuverter.Voksne * 1) + (kuverter.Teens * 0.5) + (kuverter.Boern * 0.25) + (kuverter.Baby * 0);
                }
                return KuverterForTorsdag;
            }
        }
        public void BeregnPrisIAlt()
        {
            Kuverter.PrisIalt = +(GivAlleKuverterMandag + GivAlleKuverterTirsdag + GivAlleKuverterOnsdag + GivAlleKuverterTorsdag)/Kuverter.PrisIalt;
            
        }
        public void BeregnKuvertMandag()
        {
            Kuverter.MandagTotalKuvert = GivAlleKuverterMandag;
        }



        #endregion


        #region RelayCommands
        public RelayCommand.RelayCommand TilmeldCommand { get; set; }
        public RelayCommand.RelayCommand UdregnAlleKuverterForDag { get; set; }
        public RelayCommand.RelayCommand BeregnKuvMandag { get; set; }
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
            Kuverter Kuvert = new Kuverter();
            Kuvert.Husnummer = Kuverter.Husnummer;
            Kuvert.Voksne = Kuverter.Voksne;
            Kuvert.Teens = Kuverter.Teens;
            Kuvert.Boern = Kuverter.Boern;
            Kuvert.Baby = Kuverter.Baby;
            Kuvert.Ugedag = "";
            UgeKuverter.KuvertListeMandag.Add(Kuvert);
        }
        #endregion

        #region Konstruktør
        public KuvertViewModel()
        {
            Kuverter = new Kuverter();
            KuvertListenMandag = new KuverterListe();
            KuvertListenTirsdag = new KuverterListe();
            KuvertListenOnsdag = new KuverterListe();
            KuvertListenTorsdag = new KuverterListe();
            UgeKuverter = new UgeKuverter();
            TilmeldCommand = new RelayCommand.RelayCommand(AddNewKuvert);
            UdregnAlleKuverterForDag = new RelayCommand.RelayCommand(BeregnPrisIAlt);
            BeregnKuvMandag = new RelayCommand.RelayCommand(BeregnKuvertMandag);
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
