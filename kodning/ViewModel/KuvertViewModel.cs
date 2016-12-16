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
using Newtonsoft.Json;

namespace kodning.ViewModel
{
    public class KuvertViewModel : NotifyPropNotifications
    {
        public Kuverter Kuverter { get; set; }
        //public UgeKuverter UgeKuverter { get; set; }
        public PrisBeregning PrisBeregning { get; set; }
        public string Kuvertfilnavn { get; private set; }
        //private KuverterListe _kuvertsliste;
        public KuvertCatalogSingleton Instance { get; set; }


        #region Foreach loop over samlet antal kuverter

        public double GivAlleKuverterMandag
        {
            get
            {
                return PrisBeregning.ReturKuvert(Instance.MandagListe);
            }
        }
        public double GivAlleKuverterTirsdag
        {
            get
            {
                return PrisBeregning.ReturKuvertTirsdag(Instance.TirsdagListe);
            }
        }
        public double GivAlleKuverterOnsdag
        {
            get
            {
                return PrisBeregning.ReturKuvertOnsdag(Instance.OnsdagListe);
            }
        }
        public double GivAlleKuverterTorsdag
        {
            get
            {
                return PrisBeregning.ReturKuvertTorsdag(Instance.TorsdagListe);
            }
        }

        // Dette SKAL ordnes. 

        public double PrisPerKuvertTest
        {
            set
            {
                PrisBeregning.Pris = +(PrisBeregning.PrisIAlt) / +(PrisBeregning.KuvertIAltTest);
            }
            get
            { return PrisBeregning.Pris; }
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
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
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

        //public KuverterListe KuvertListenTirsdag
        //{
        //    get { return _kuvertsliste; }
        //    set
        //    {
        //        _kuvertsliste = value;
        //        OnPropertyChanged(nameof(KuvertListenTirsdag));
        //    }
        //}
        //public KuverterListe KuvertListenOnsdag
        //{
        //    get { return _kuvertsliste; }
        //    set
        //    {
        //        _kuvertsliste = value;
        //        OnPropertyChanged(nameof(KuvertListenOnsdag));
        //    }
        //}
        //public KuverterListe KuvertListenTorsdag
        //{
        //    get { return _kuvertsliste; }
        //    set
        //    {
        //        _kuvertsliste = value;
        //        OnPropertyChanged(nameof(KuvertListenTorsdag));
        //    }
        //}







        #endregion



        #region Metode til Tilføje Kuverter
        //public void AccepterUdlæg()
        //{
        //    PrisBeregning Udlæg = new PrisBeregning();
        //    Udlæg.Kok1Udlæg = PrisBeregning.Kok1Udlæg;
        //    Udlæg.Kok2Udlæg = PrisBeregning.Kok2Udlæg;
        //    Udlæg.Kok3Udlæg = PrisBeregning.Kok3Udlæg;
        //    Udlæg.Kok4Udlæg = PrisBeregning.Kok4Udlæg;
        //    Udlæg.UdlægIAlt = PrisBeregning.UdlægIAlt;
        //}

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
        public void prisErTest()
        {
            PrisBeregning Udlæg = new PrisBeregning();
            Udlæg.Kok1Udlæg = PrisBeregning.Kok1Udlæg;
            Udlæg.Kok2Udlæg = PrisBeregning.Kok2Udlæg;
            Udlæg.Kok3Udlæg = PrisBeregning.Kok3Udlæg;
            Udlæg.Kok4Udlæg = PrisBeregning.Kok4Udlæg;
            Udlæg.UdlægIAlt = PrisBeregning.UdlægIAlt;
            PrisPerKuvertTest = PrisPerKuvertTest;

        }
        #region Metode med IF statements der tilføjer kuverter til listen
        public void AddAlleDage()
        {
            //if (Kuverter.Voksne == 0 && Kuverter.Teens == 0 && Kuverter.Boern == 0 && Kuverter.Baby == 0)
            //{
            //    // her skal der tilføjes en exception - Måske Try catch? catch (System.IndexOutOfRangeException ex)
            //    //{
            //    //    System.ArgumentException argEx = new System.ArgumentException("noob text her ", ex);
            //    //    throw argEx;
            //    //}
            //}

            bool erNulTilmeldte = true;

            if (Kuverter.Husnummer != 0)
            {
                if (Kuverter.Voksne > 0 || Kuverter.Teens > 0 || Kuverter.Boern > 0 || Kuverter.Baby > 0)
                {
                    erNulTilmeldte = false;
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

                //if (Kuverter.TirsdagVoksne == 0 && Kuverter.TirsdagTeens == 0 && Kuverter.TirsdagBaby == 0 && Kuverter.TirsdagBaby == 0)
                //{

                //}

                if (Kuverter.TirsdagVoksne > 0 || Kuverter.TirsdagTeens > 0 || Kuverter.TirsdagBaby > 0 || Kuverter.TirsdagBaby > 0)
                {
                    erNulTilmeldte = false;

                    Kuverter TirsdagKuvert = new Kuverter();
                    TirsdagKuvert.Husnummer = Kuverter.Husnummer;
                    TirsdagKuvert.TirsdagVoksne = Kuverter.TirsdagVoksne;
                    TirsdagKuvert.TirsdagTeens = Kuverter.TirsdagTeens;
                    TirsdagKuvert.TirsdagBoern = Kuverter.TirsdagBoern;
                    TirsdagKuvert.TirsdagBaby = Kuverter.TirsdagBaby;
                    //referer til singleton
                    Instance.TirsdagListe.Add(TirsdagKuvert);

                }



                //if (Kuverter.OnsdagVoksne == 0 && Kuverter.OnsdagTeens == 0 && Kuverter.OnsdagBoern == 0 && Kuverter.OndagsBaby == 0)
                //{

                //}

                if (Kuverter.OnsdagVoksne > 0 || Kuverter.OnsdagTeens > 0 || Kuverter.OnsdagBoern > 0 || Kuverter.OndagsBaby > 0)
                {
                    erNulTilmeldte = false;

                    Kuverter OnsdagKuvert = new Kuverter();
                    OnsdagKuvert.Husnummer = Kuverter.Husnummer;
                    OnsdagKuvert.OnsdagVoksne = Kuverter.OnsdagVoksne;
                    OnsdagKuvert.OnsdagTeens = Kuverter.OnsdagTeens;
                    OnsdagKuvert.OnsdagBoern = Kuverter.OnsdagBoern;
                    OnsdagKuvert.OndagsBaby = Kuverter.OndagsBaby;
                    //referer til singleton
                    Instance.OnsdagListe.Add(OnsdagKuvert);

                }

                //if (Kuverter.TorsdagVoksne == 0 && Kuverter.TorsdagTeens == 0 && Kuverter.TorsdagBoern == 0 && Kuverter.TorsdagBaby == 0)
                //{

                //}

                if (Kuverter.TorsdagVoksne > 0 || Kuverter.TorsdagTeens > 0 || Kuverter.TorsdagBoern > 0 || Kuverter.TorsdagBaby > 0)
                {
                    erNulTilmeldte = false;

                    Kuverter TorsdagKuvert = new Kuverter();
                    TorsdagKuvert.Husnummer = Kuverter.Husnummer;
                    TorsdagKuvert.TorsdagVoksne = Kuverter.TorsdagVoksne;
                    TorsdagKuvert.TorsdagTeens = Kuverter.TorsdagTeens;
                    TorsdagKuvert.TorsdagBoern = Kuverter.TorsdagBoern;
                    TorsdagKuvert.TorsdagBaby = Kuverter.TorsdagBaby;
                    //referer til singleton
                    Instance.TorsdagListe.Add(TorsdagKuvert);

                }

                if (erNulTilmeldte)
                {
                    new MessageDialog("Du skal huske at tilmelde dig en af dagene").ShowAsync();
                }
                else if (!erNulTilmeldte)
                {
                    this.GemDataTilDiskAsync();
                }
            }
            else
            {
                new MessageDialog("Bolignummer mangler").ShowAsync();
            }
            

        }
        #endregion

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
            //AccepterUdlægCommand = new RelayCommand.RelayCommand(AccepterUdlæg);
            KuvertPerDagCommand = new RelayCommand.RelayCommand(prisErTest);

            this.HentDataFraDiskAsync();
        }
        #endregion

        #region Json

        StorageFolder localfolder = null;
        public async void GemDataTilDiskAsync()
        {
            string jsonText = Instance.MandagListe.SaveJson();
            string jsonText1 = Instance.TirsdagListe.SaveJson();
            string jsonText2 = Instance.OnsdagListe.SaveJson();
            string jsonText3 = Instance.TorsdagListe.SaveJson();

            StorageFile MandagListen = await ApplicationData.Current.LocalFolder.CreateFileAsync("MandagsListen.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(MandagListen, jsonText);
            StorageFile TirsdagListen = await ApplicationData.Current.LocalFolder.CreateFileAsync("TirsdagsListen.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(TirsdagListen, jsonText1);
            StorageFile OnsdagListen = await ApplicationData.Current.LocalFolder.CreateFileAsync("OnsdagsListen.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(OnsdagListen, jsonText2);
            StorageFile TorsdagListen = await ApplicationData.Current.LocalFolder.CreateFileAsync("TorsdagsListen.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(TorsdagListen, jsonText3);
        }


        public async void HentDataFraDiskAsync()
        {

            try
            {


                StorageFile MandagListen = await ApplicationData.Current.LocalFolder.GetFileAsync("MandagsListen.Json");
                StorageFile TirsdagListen = await ApplicationData.Current.LocalFolder.GetFileAsync("TirsdagsListen.Json");
                StorageFile OnsdagListen = await ApplicationData.Current.LocalFolder.GetFileAsync("OnsdagsListen.Json");
                StorageFile TorsdagListen = await ApplicationData.Current.LocalFolder.GetFileAsync("TorsdagsListen.Json");

                string jsonText = await FileIO.ReadTextAsync(MandagListen);
                string jsonText1 = await FileIO.ReadTextAsync(TirsdagListen);
                string jsonText2 = await FileIO.ReadTextAsync(OnsdagListen);
                string jsonText3 = await FileIO.ReadTextAsync(TorsdagListen);

                Instance.MandagListe = (KuverterListe)JsonConvert.DeserializeObject(jsonText, typeof(KuverterListe));
                Instance.TirsdagListe = (KuverterListe)JsonConvert.DeserializeObject(jsonText1, typeof(KuverterListe));
                Instance.OnsdagListe = (KuverterListe)JsonConvert.DeserializeObject(jsonText2, typeof(KuverterListe));
                Instance.TorsdagListe = (KuverterListe)JsonConvert.DeserializeObject(jsonText3,typeof(KuverterListe));

                ////metoden på medarbejderlisten
                ////KuvertListenMandag.IndsætJson(jsonText);
                //Instance.MandagListe.HentJson(jsonText);

                // Try og catch for at fange en exception for at undgå grimme fejlmeddelser
            }
            catch (Exception ex)
            {
                //Popup vindue til at fortælle brugeren at filen ikke blev fundet. 
                MessageDialog messageDialog = new MessageDialog(ex.Message,"Filen ikke fundet");
                await messageDialog.ShowAsync();
                //throw;
            }
        }
        #endregion
    }
}
