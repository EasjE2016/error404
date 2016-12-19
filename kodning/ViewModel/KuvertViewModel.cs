using kodning.Model;
using kodning.RelayCommand;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace kodning.ViewModel
{
    public class KuvertViewModel : NotifyPropNotifications
    {
        public Kuverter Kuverter { get; set; }

        public PrisBeregning PrisBeregning { get; set; }

        public KuvertCatalogSingleton Instance { get; set; }


        #region Foreach loop over kuverter

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


        public double PrisPerKuvert
        {
            set
            {
                PrisBeregning.Pris = + (PrisBeregning.PrisIAlt()) / +(PrisBeregning.KuvertIAltTest);
            }
            get
            { return PrisBeregning.Pris; }
        }

        public void prisPerKuvertEr()
        {
            PrisBeregning Udlæg = new PrisBeregning();
            Udlæg.Kok1Udlæg = PrisBeregning.Kok1Udlæg;
            Udlæg.Kok2Udlæg = PrisBeregning.Kok2Udlæg;
            Udlæg.Kok3Udlæg = PrisBeregning.Kok3Udlæg;
            Udlæg.Kok4Udlæg = PrisBeregning.Kok4Udlæg;
            Udlæg.UdlægIAlt = PrisBeregning.UdlægIAlt;
            PrisPerKuvert = PrisPerKuvert;

        }


        #endregion

        #region RelayCommands

        public RelayCommand.RelayCommand TilmeldAlleCommand { get; set; }
        public RelayCommand.RelayCommand KuvertPerDagCommand { get; set; }
        public RelayCommand.RelayCommand RydListeOverDeltagere { get; set; }


        #endregion

        #region Metode med IF statements der tilføjer kuverter til listen
        public void AddAlleDage()
        {
            bool erNulTilmeldte = true;

            if (Kuverter.Husnummer != 0)
            {
                if (Kuverter.MandagVoksne > 0 || Kuverter.MandagTeens > 0 || Kuverter.MandagBoern > 0 || Kuverter.MandagBaby > 0)
                {
                    erNulTilmeldte = false;
                    Kuverter Kuvert = new Kuverter();
                    Kuvert.Husnummer = Kuverter.Husnummer;
                    Kuvert.MandagVoksne = Kuverter.MandagVoksne;
                    Kuvert.MandagTeens = Kuverter.MandagTeens;
                    Kuvert.MandagBoern = Kuverter.MandagBoern;
                    Kuvert.MandagBaby = Kuverter.MandagBaby;

                    //referer til singleton
                    Instance.MandagListe.Add(Kuvert);


                }

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

                if (Kuverter.OnsdagVoksne > 0 || Kuverter.OnsdagTeens > 0 || Kuverter.OnsdagBoern > 0 || Kuverter.OnsdagBaby > 0)
                {
                    erNulTilmeldte = false;

                    Kuverter OnsdagKuvert = new Kuverter();
                    OnsdagKuvert.Husnummer = Kuverter.Husnummer;
                    OnsdagKuvert.OnsdagVoksne = Kuverter.OnsdagVoksne;
                    OnsdagKuvert.OnsdagTeens = Kuverter.OnsdagTeens;
                    OnsdagKuvert.OnsdagBoern = Kuverter.OnsdagBoern;
                    OnsdagKuvert.OnsdagBaby = Kuverter.OnsdagBaby;

                    //referer til singleton
                    Instance.OnsdagListe.Add(OnsdagKuvert);

                }

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
                    new MessageDialog("Du er nu tilmeldt").ShowAsync();
                }
            }
            else
            {
                new MessageDialog("Bolignummer mangler").ShowAsync();
            }
            

        }
        #endregion

        #region Metode til at starte en ny uge
        public void StartNyUge()
        {
            Instance.MandagListe.Clear();
            Instance.TirsdagListe.Clear();
            Instance.OnsdagListe.Clear();
            Instance.TorsdagListe.Clear();
            this.GemDataTilDiskAsync();
        }
        #endregion

        #region Konstruktør
        public KuvertViewModel()
        {
            Instance = KuvertCatalogSingleton.Instance;
            PrisBeregning = new PrisBeregning();
            Kuverter = new Kuverter();


            TilmeldAlleCommand = new RelayCommand.RelayCommand(AddAlleDage);
            KuvertPerDagCommand = new RelayCommand.RelayCommand(prisPerKuvertEr);
            RydListeOverDeltagere = new RelayCommand.RelayCommand(StartNyUge);
            
            this.HentDataFraDiskAsync();
        }
        #endregion

        #region Json

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

                
                // Try og catch for at fange en exception for at undgå grimme fejlmeddelser
            }
            catch (Exception ex)
            {
                //Popup vindue til at fortælle brugeren at filen ikke blev fundet. 
                MessageDialog messageDialog = new MessageDialog(ex.Message,"Filen ikke fundet");
                await messageDialog.ShowAsync();
            }
        }
        #endregion
    }
}
