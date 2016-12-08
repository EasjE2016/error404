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
    class KuvertViewModel : INotifyPropertyChanged
    {
        //props
        private KuverterListe _kuvertsliste;
        // public Kuverter NewKuvert { get; set; }

        public int Husnummer { get; set; }
        #region mandags property
        public int MandagVoksne { get; set; }
        public int MandagTeens { get; set; }
        public int MandagBoern { get; set; }
        public int MandagBaby { get; set; }

        public UgeKuverter UgeKuverter { get; set; }

        #endregion
        //slut props
        //foreach loop der giver sum af kuverter
        public double GivAlleKuverter
        {
            get
            {
                double KuverterForDag = 0;
                foreach (var kuverter in _kuvertsliste)
                {
                    KuverterForDag = +(kuverter.AntalVoksne * 1) + (kuverter.AntalTeen * 0.5) + (kuverter.AntalBoern * 0.25) + (kuverter.AntalBaby * 0);
                }
                return KuverterForDag;
            }
        }


        //slut foreach



        //relaycommands
        // Her tilføjes knapper til at trykke "tilmeld"

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
        
        public KuverterListe KuvertListen
        {
            get { return _kuvertsliste; }
            set
            {
                _kuvertsliste = value;
                OnPropertyChanged(nameof(KuvertListen));
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
            KuvertListen = new KuverterListe();
            UgeKuverter = new UgeKuverter();
        }


        // til JSON

        private readonly string lisa = "JsonText.json";
        StorageFolder localfolder = null;
        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.KuvertListen.GetJson();
            StorageFile lisa = await localfolder.CreateFileAsync(Kuvertfilnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(lisa, jsonText);
        }

        public async void HentDataFraDiskAsync()
        {

            try
            {
                StorageFile lisa = await localfolder.GetFileAsync(Kuvertfilnavn);

                string jsonText = await FileIO.ReadTextAsync(lisa);

                this.KuvertListen.Clear();

                //metoden på medarbejderlisten
                KuvertListen.IndsætJson(jsonText);

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
