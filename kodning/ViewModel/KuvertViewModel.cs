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
        public Kuverter NewKuvert { get; set; }


        private KuverterListe _kuvertsliste;

        public string Kuvertfilnavn { get; private set; }


        #region Foreach loop over samlet antal kuverter

        public double GivAlleKuverter
        {
            get
            {
                double KuverterForDag = 0;
                foreach (var kuverter in KuvertListenMandag)
                {
                    KuverterForDag = +(kuverter.AntalVoksne * 1) + (kuverter.AntalTeen * 0.5) + (kuverter.AntalBoern * 0.25) + (kuverter.AntalBaby * 0);
                }
                return KuverterForDag;
            }
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


        #region onpropchange til KuvertListenMandag
        public KuverterListe KuvertListenMandag
        {
            get { return _kuvertsliste; }
            set
            {
                _kuvertsliste = value;
                OnPropertyChanged(nameof(KuvertListenMandag));
            }
        }
        #endregion


        #region Metode til Tilføje Kuverter
        public void AddNewKuvert()
        {
            Kuverter MandagsKuvert = new Kuverter();
            MandagsKuvert.HusNr = NewKuvert.HusNr;
            MandagsKuvert.AntalVoksne = NewKuvert.AntalVoksne;
            MandagsKuvert.AntalTeen = NewKuvert.AntalTeen;
            MandagsKuvert.AntalBoern = NewKuvert.AntalBoern;
            MandagsKuvert.AntalBaby = NewKuvert.AntalBaby;
            MandagsKuvert.Ugedag = "Mandag";
            UgeKuverter.KuvertListeMandag.Add(MandagsKuvert);
        }
        #endregion

        #region Konstruktør
        public KuvertViewModel()
        {
            KuvertListenMandag = new KuverterListe();      
            UgeKuverter = new UgeKuverter();
            TilmeldCommand = new RelayCommand.RelayCommand(AddNewKuvert);
            //UdregnAlleKuverterForDag = new RelayCommand.RelayCommand();
            
            
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
