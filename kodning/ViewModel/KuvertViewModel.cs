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
        //props
        private KuverterListe _kuvertsliste;
        // public Kuverter NewKuvert { get; set; }
       
        public int Husnummer { get; set; }
        #region mandags property
        public double MandagVoksne { get; set; }
        public double MandagTeens { get; set; }
        public double MandagBoern { get; set; }
        public double MandagBaby { get; set; }
        #endregion



        //slut props
        public UgeKuverter UgeKuverter { get; set; }
        //foreach loop der giver sum af kuverter
  

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
    

        //slut foreach



        //relaycommands
        // Her tilføjes knapper til at trykke "tilmeld"
        public RelayCommand.RelayCommand TilmeldCommand { get; set; }
        public RelayCommand.RelayCommand UdregnAlleKuverterForDag { get; set; }
        //slut relaycommands

        //inotifyprop
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // inotifyprop slut
        
        public KuverterListe KuvertListenMandag
        {
            get { return _kuvertsliste; }
            set
            {
                _kuvertsliste = value;
                OnPropertyChanged(nameof(KuvertListenMandag));
            }
        }
        



        public string Kuvertfilnavn { get; private set; }

        //Metode til at tilføje ny Kuvert.
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

           

            //KuvertListen.Add(MandagsKuvert);

        }

        //Konstruktor
        public KuvertViewModel()
        {
            KuvertListenMandag = new KuverterListe();      
            UgeKuverter = new UgeKuverter();
            TilmeldCommand = new RelayCommand.RelayCommand(AddNewKuvert);
            //UdregnAlleKuverterForDag = new RelayCommand.RelayCommand(GivAlleKuverter);
            
            
        }


        // til JSON

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
        // Slut JSON
    }
}
