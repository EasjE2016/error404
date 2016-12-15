using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kodning.Model;
using System.ComponentModel;
using Windows.Storage;
using Windows.UI.Popups;
using kodning.RelayCommand;


namespace kodning.ViewModel
{
    public class KuvertViewModel : NotifyPropNotifications
    {
        public Kuverter Kuverter { get; set; }
        //public UgeKuverter UgeKuverter { get; set; }
        public PrisBeregning PrisBeregning { get; set; }
        public string Kuvertfilnavn { get; private set; }
        private KuverterListe _kuvertsliste;
        public KuvertCatalogSingleton Instance { get; set; }


        #region Foreach loop over samlet antal kuverter

        public double GivAlleKuverterMandag
        {
            get
            {
                return Instance.ReturKuvert(Instance.MandagListe);
            }
        }
        public double GivAlleKuverterTirsdag
        {
            get
            {
                return Instance.ReturKuvertTirsdag(Instance.TirsdagListe);
            }
        }
        public double GivAlleKuverterOnsdag
        {
            get
            {
                return Instance.ReturKuvertOnsdag(Instance.OnsdagListe);
            }
        }
        public double GivAlleKuverterTorsdag
        {
            get
            {
                return Instance.ReturKuvertTorsdag(Instance.TorsdagListe);
            }
        }

        // Dette SKAL ordnes. 

       public double PrisPerKuvertTest
        {
            set
            {
                PrisBeregning.Pris = +(PrisBeregning.Kok1Udlæg+ PrisBeregning.Kok2Udlæg+PrisBeregning.Kok3Udlæg+ PrisBeregning.Kok4Udlæg)/ +(Instance.kuverterForDagen + Instance.kuverterForTirsdag + Instance.kuverterForOnsdag + Instance.kuverterForTorsdag);
            }
            get
            { return PrisBeregning.Pris; }
        }
        
        public void prisErTest()
        {
            
            PrisPerKuvertTest = PrisPerKuvertTest;
            
        }


        #endregion


        #region RelayCommands

        public RelayCommand.RelayCommand TilmeldAlleCommand { get; set; }
        public RelayCommand.RelayCommand TilmeldCommand { get; set; }
        public RelayCommand.RelayCommand KuvertPerDagCommand { get; set; }
        public RelayCommand.RelayCommand BeregnKuvMandag { get; set; }
        public RelayCommand.RelayCommand TilMeldTirsdagCommand { get; set; }
        public RelayCommand.RelayCommand TilMeldOnsdagCommand { get; set; }
        public RelayCommand.RelayCommand TilMeldTorsdagCommand { get; set; }
        public RelayCommand.RelayCommand AccepterUdlægCommand { get; set; }
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

        //public PrisBeregning Pris
        //{
        //    get
        //    {
        //        return _Pris;
        //    }
        //    set
        //    {
        //        _Pris = value;
        //        OnPropertyChanged(nameof(Pris));
        //    }
        //}
        #region onpropchange til KuvertLister
        //public KuverterListe KuvertListenMandag
        //{
        //    get { return _kuvertsliste; }
        //    set
        //    {
        //        _kuvertsliste = value;
        //        OnPropertyChanged(nameof(KuvertListenMandag));
        //        //OnPropertyChanged(nameof(GivAlleKuverterMandag));S
        //    }
        //}

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
        public void AccepterUdlæg()
        {
            PrisBeregning Udlæg = new PrisBeregning();
            Udlæg.Kok1Udlæg = PrisBeregning.Kok1Udlæg;
            Udlæg.Kok2Udlæg = PrisBeregning.Kok2Udlæg;
            Udlæg.Kok3Udlæg = PrisBeregning.Kok3Udlæg;
            Udlæg.Kok4Udlæg = PrisBeregning.Kok4Udlæg;
            Udlæg.UdlægIAlt = PrisBeregning.UdlægIAlt;
        }

        public void AddNewKuvertMandag()
        {
            Kuverter Kuvert = new Kuverter();
            Kuvert.Husnummer = Kuverter.Husnummer;
            Kuvert.Voksne = Kuverter.Voksne;
            Kuvert.Teens = Kuverter.Teens;
            Kuvert.Boern = Kuverter.Boern;
            Kuvert.Baby = Kuverter.Baby;
            Kuvert.Ugedag = "";
            
            //referer til singleton
            Instance.MandagListe.Add(Kuvert);

        }
        public void AddNewKuvertTirsdag()
        {
            Kuverter TirsdagKuvert = new Kuverter();
            TirsdagKuvert.Husnummer = Kuverter.Husnummer;
            TirsdagKuvert.TirsdagVoksne = Kuverter.TirsdagVoksne;
            TirsdagKuvert.TirsdagTeens = Kuverter.TirsdagTeens;
            TirsdagKuvert.TirsdagBoern = Kuverter.TirsdagBoern;
            TirsdagKuvert.TirsdagBaby = Kuverter.TirsdagBaby;
            //referer til singleton
            Instance.TirsdagListe.Add(TirsdagKuvert);

        }
        public void AddNewKuvertOnsdag()
        {
            Kuverter OnsdagKuvert = new Kuverter();
            OnsdagKuvert.Husnummer = Kuverter.Husnummer;
            OnsdagKuvert.OnsdagVoksne = Kuverter.OnsdagVoksne;
            OnsdagKuvert.OnsdagTeens = Kuverter.OnsdagTeens;
            OnsdagKuvert.OnsdagBoern = Kuverter.OnsdagBoern;
            OnsdagKuvert.OndagsBaby = Kuverter.OndagsBaby;
            //referer til singleton
            Instance.OnsdagListe.Add(OnsdagKuvert);

        }
        public void AddNewKuvertTorsdag()
        {
            Kuverter TorsdagKuvert = new Kuverter();
            TorsdagKuvert.Husnummer = Kuverter.Husnummer;
            TorsdagKuvert.TorsdagVoksne = Kuverter.TorsdagVoksne;
            TorsdagKuvert.TorsdagTeens = Kuverter.TorsdagTeens;
            TorsdagKuvert.TorsdagBoern = Kuverter.TorsdagBoern;
            TorsdagKuvert.TorsdagBaby = Kuverter.TorsdagBaby;
            //referer til singleton
            Instance.TorsdagListe.Add(TorsdagKuvert);

        }

        public void AddAlleDage()
        {
            if (Kuverter.Voksne == 0 && Kuverter.Teens == 0 && Kuverter.Boern == 0 && Kuverter.Baby == 0)
            {
                throw new NullReferenceException();        
            }

            else if (Kuverter.Voksne > 0 || Kuverter.Teens > 0 || Kuverter.Boern > 0 || Kuverter.Baby > 0)
            {
                Kuverter Kuvert = new Kuverter();
                Kuvert.Husnummer = Kuverter.Husnummer;
                Kuvert.Voksne = Kuverter.Voksne;
                Kuvert.Teens = Kuverter.Teens;
                Kuvert.Boern = Kuverter.Boern;
                Kuvert.Baby = Kuverter.Baby;
                Kuvert.Ugedag = "";

                //referer til singleton
                Instance.MandagListe.Add(Kuvert);

            }

            if (Kuverter.TirsdagVoksne == 0 && Kuverter.TirsdagTeens == 0 && Kuverter.TirsdagBaby == 0 && Kuverter.TirsdagBaby == 0)
            {
                throw new NullReferenceException();
            }

            else if (Kuverter.TirsdagVoksne > 0 || Kuverter.TirsdagTeens > 0 || Kuverter.TirsdagBaby > 0 || Kuverter.TirsdagBaby > 0)
            {
                Kuverter TirsdagKuvert = new Kuverter();
                TirsdagKuvert.Husnummer = Kuverter.Husnummer;
                TirsdagKuvert.Voksne = Kuverter.Voksne;
                TirsdagKuvert.Teens = Kuverter.Teens;
                TirsdagKuvert.Boern = Kuverter.Boern;
                TirsdagKuvert.Baby = Kuverter.Baby;
                TirsdagKuvert.Ugedag = "";

                //referer til singleton
                Instance.MandagListe.Add(TirsdagKuvert);

            }



            if (Kuverter.OnsdagVoksne == 0 && Kuverter.OnsdagTeens == 0 && Kuverter.OnsdagBoern == 0 && Kuverter.OndagsBaby == 0)
            {
              
            }

            else if (Kuverter.OnsdagVoksne > 0 || Kuverter.OnsdagTeens > 0 || Kuverter.OnsdagBoern > 0 || Kuverter.OndagsBaby > 0)
            {
                Kuverter OnsdagKuvert = new Kuverter();
                OnsdagKuvert.Husnummer = Kuverter.Husnummer;
                OnsdagKuvert.Voksne = Kuverter.Voksne;
                OnsdagKuvert.Teens = Kuverter.Teens;
                OnsdagKuvert.Boern = Kuverter.Boern;
                OnsdagKuvert.Baby = Kuverter.Baby;
                OnsdagKuvert.Ugedag = "";

                //referer til singleton
                Instance.MandagListe.Add(OnsdagKuvert);

            }

            if (Kuverter.TorsdagVoksne == 0 && Kuverter.TorsdagTeens == 0 && Kuverter.TorsdagBoern == 0 && Kuverter.TorsdagBaby == 0)
            {
                
            }

            else if (Kuverter.TorsdagVoksne > 0 || Kuverter.TorsdagTeens > 0 || Kuverter.TorsdagBoern > 0 || Kuverter.TorsdagBaby > 0)
            {
                Kuverter TorsdagKuvert = new Kuverter();
                TorsdagKuvert.Husnummer = Kuverter.Husnummer;
                TorsdagKuvert.Voksne = Kuverter.Voksne;
                TorsdagKuvert.Teens = Kuverter.Teens;
                TorsdagKuvert.Boern = Kuverter.Boern;
                TorsdagKuvert.Baby = Kuverter.Baby;
                TorsdagKuvert.Ugedag = "";

                //referer til singleton
                Instance.MandagListe.Add(TorsdagKuvert);

            }

        }

        #endregion

        #region Konstruktør
        public KuvertViewModel()
        {
            Instance = KuvertCatalogSingleton.Instance;
            PrisBeregning = new PrisBeregning();
            Kuverter = new Kuverter();
            TilmeldAlleCommand = new RelayCommand.RelayCommand(AddAlleDage);
            TilmeldCommand = new RelayCommand.RelayCommand(AddNewKuvertMandag);
            TilMeldTirsdagCommand = new RelayCommand.RelayCommand(AddNewKuvertTirsdag);
            TilMeldOnsdagCommand = new RelayCommand.RelayCommand(AddNewKuvertOnsdag);
            TilMeldTorsdagCommand = new RelayCommand.RelayCommand(AddNewKuvertTorsdag);
            AccepterUdlægCommand = new RelayCommand.RelayCommand(AccepterUdlæg);
            KuvertPerDagCommand = new RelayCommand.RelayCommand(prisErTest);

        }
        #endregion

        #region Json

        StorageFolder localfolder = null;
        public async void GemDataTilDiskAsync()
        {
            string jsonText = Instance.MandagListe.GetJson();

            StorageFile lisa = await localfolder.CreateFileAsync(Kuvertfilnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(lisa, jsonText);
        }


        public async void HentDataFraDiskAsync()
        {

            try
            {
                StorageFile lisa = await localfolder.GetFileAsync(Kuvertfilnavn);

                string jsonText = await FileIO.ReadTextAsync(lisa);

                Instance.MandagListe.Clear();
                //this.KuvertListenMandag.Clear();

                //metoden på medarbejderlisten
                //KuvertListenMandag.IndsætJson(jsonText);
                Instance.MandagListe.IndsætJson(jsonText);
                
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
