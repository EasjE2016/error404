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
        #endregion

        #region Tirsdagsprops
        public int TirsdagVoksne { get; set; }
        public int TirsdagTeens { get; set; }
        public int TirsdagBoern { get; set; }
        public int TirsdagBaby { get; set; }
        #endregion
        #region Onsdagsprops
        public int OnsdagVoksne { get; set; }
        public int OnsdagTeens { get; set; }
        public int OnsdagBoern { get; set; }
        public int OnsdagBaby { get; set; }
        #endregion
        #region Torsdagsprops
        public int TorsdagVoksne { get; set; }
        public int TorsdagTeens { get; set; }
        public int TorsdagBoern { get; set; }
        public int TorsdagBaby { get; set; }
        #endregion
        //slut props
        public UgeKuverter UgeKuverter { get; set; }
        //foreach loop der giver sum af kuverter
        public double GivAlleKuverter
        {
            get
            {
                double KuverterForDag = 0;
                foreach (var kuverter in _kuvertsliste)
                {
                    KuverterForDag = +(kuverter.AntalVoksne * 1) + (kuverter.AntalTeen * 0.75) + (kuverter.AntalBoern * 0.5) + (kuverter.AntalBaby * 0.25);
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

            #region
            Kuverter TirsdagsKuvert = new Kuverter();
            TirsdagsKuvert.HusNr = Husnummer;
            TirsdagsKuvert.AntalVoksne = TirsdagVoksne;
            TirsdagsKuvert.AntalTeen = TirsdagTeens;
            TirsdagsKuvert.AntalBoern = TirsdagBoern;
            TirsdagsKuvert.AntalBaby = TirsdagBaby;
            TirsdagsKuvert.Ugedag = "Tirsdag";
            UgeKuverter.KuvertListeTirsdag.Add(TirsdagsKuvert);
            #endregion

            #region
            Kuverter OnsdagsKuvert = new Kuverter();
            OnsdagsKuvert.HusNr = Husnummer;
            OnsdagsKuvert.AntalVoksne = OnsdagVoksne;
            OnsdagsKuvert.AntalTeen = OnsdagTeens;
            OnsdagsKuvert.AntalBoern = OnsdagBoern;
            OnsdagsKuvert.AntalBaby = OnsdagBaby;
            OnsdagsKuvert.Ugedag = "Onsdag";
            UgeKuverter.KuvertListeOnsdag.Add(OnsdagsKuvert);
            #endregion

            #region 
            Kuverter TorsdagsKuvert = new Kuverter();
            TorsdagsKuvert.HusNr = Husnummer;
            TorsdagsKuvert.AntalVoksne = TorsdagVoksne;
            TorsdagsKuvert.AntalTeen = TorsdagTeens;
            TorsdagsKuvert.AntalBoern = TorsdagBoern;
            TorsdagsKuvert.AntalBaby = TorsdagBaby;
            TorsdagsKuvert.Ugedag = "Torsdag";
            UgeKuverter.KuvertListeTorsdag.Add(TorsdagsKuvert);
            #endregion

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
