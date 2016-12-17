using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.Storage;
using Newtonsoft.Json;
using Windows.UI.Popups;
using kodning.Model;
using kodning.InAkivKode;

namespace kodning.ViewModel
{
    class ArbejderPlanViewModel : NotifyPropNotifications
    {
        public Arbejdere Arbejdere { get; set; }

        public ArbejderCatalogSingleton Instance { get; set; }

        #region Relaycommands
        public RelayCommand.RelayCommand TilmeldArbejderCommand { get; set; }
        public RelayCommand.RelayCommand RydListeOverArbejdere { get; set; }
        #endregion

        #region Rydder listen over arbejdere
        public void StartNyUge()
        {
            Instance.ArbejderMandagListe.Clear();
            Instance.ArbejderTirsdagListe.Clear();
            Instance.ArbejderOnsdagListe.Clear();
            Instance.ArbejderTorsdagListe.Clear();
            this.GemDataTilDiskAsync();
        }
        #endregion

        #region Metode at tilmelde sig til lister over arbejdere
        public void TilmeldArbejde()
        {
            bool ErLigNulTilmeldte = true;

            if (Arbejdere.MandagTitle == null && Arbejdere.MandagNavn == null)
            {
                if (Arbejdere.MandagTitle == "" && Arbejdere.MandagNavn == "")
                {
                    ErLigNulTilmeldte = false;
                    Arbejdere MandagArbejder = new Arbejdere();
                    MandagArbejder.MandagNavn = Arbejdere.MandagNavn;
                    MandagArbejder.MandagTitle = Arbejdere.MandagTitle;

                    Instance.ArbejderMandagListe.Add(MandagArbejder);
                }


                if (Arbejdere.TirsdagTitle == "" && Arbejdere.TirsdagNavn == "")
                {
                    ErLigNulTilmeldte = false;
                    Arbejdere TirsdagArbejder = new Arbejdere();
                    TirsdagArbejder.TirsdagNavn = Arbejdere.TirsdagNavn;
                    TirsdagArbejder.TirsdagTitle = Arbejdere.TirsdagTitle;

                    Instance.ArbejderTirsdagListe.Add(TirsdagArbejder);
                }


                if (Arbejdere.OnsdagTitle == "" && Arbejdere.OnsdagNavn == "")
                {
                    ErLigNulTilmeldte = false;
                    Arbejdere OnsdagArbejder = new Arbejdere();
                    OnsdagArbejder.OnsdagNavn = Arbejdere.OnsdagNavn;
                    OnsdagArbejder.OnsdagTitle = Arbejdere.OnsdagTitle;

                    Instance.ArbejderOnsdagListe.Add(OnsdagArbejder);
                 }


                         if (Arbejdere.TorsdagTitle == "" && Arbejdere.TorsdagNavn == "")
                            {
                                ErLigNulTilmeldte = false;
                                Arbejdere TorsdagArbejder = new Arbejdere();
                                TorsdagArbejder.OnsdagNavn = Arbejdere.TorsdagNavn;
                                TorsdagArbejder.OnsdagTitle = Arbejdere.TorsdagTitle;

                                Instance.ArbejderOnsdagListe.Add(TorsdagArbejder);
                            }
                            if (ErLigNulTilmeldte)
                            {
                                new MessageDialog("Du skal huske at tilmelde dig en af dagene").ShowAsync();
                            }
                            else if (!ErLigNulTilmeldte)
                            {
                                this.GemDataTilDiskAsync();
                            }
                        }
                        else
                        {
                            new MessageDialog("Du skal huske at tilmelde dig en af dagene").ShowAsync();
                        }
                    }

        #endregion

        #region Konstruktør
        public ArbejderPlanViewModel()
        {
            Instance = ArbejderCatalogSingleton.Instance;
            Arbejdere = new Arbejdere();

            TilmeldArbejderCommand = new RelayCommand.RelayCommand(TilmeldArbejde);
            RydListeOverArbejdere = new RelayCommand.RelayCommand(StartNyUge);

            this.HentDataFraDiskAsync();
        }
        #endregion

        #region Json
        public async void GemDataTilDiskAsync()
        {
            string jsonTextArbejder = Instance.ArbejderMandagListe.SaveArbejderJson();
            string jsonTextArbejder1 = Instance.ArbejderTirsdagListe.SaveArbejderJson();
            string jsonTextArbejder2 = Instance.ArbejderOnsdagListe.SaveArbejderJson();
            string jsonTextArbejder3 = Instance.ArbejderTorsdagListe.SaveArbejderJson();

            StorageFile ArbejderMandagListe = await ApplicationData.Current.LocalFolder.CreateFileAsync("ArbejderMandagListe.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ArbejderMandagListe, jsonTextArbejder);
            StorageFile ArbejderTirsdagListe = await ApplicationData.Current.LocalFolder.CreateFileAsync("ArbejderTirsdagListe.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ArbejderTirsdagListe, jsonTextArbejder1);
            StorageFile ArbejderOnsdagListe = await ApplicationData.Current.LocalFolder.CreateFileAsync("ArbejderOnsdagListe.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ArbejderOnsdagListe, jsonTextArbejder2);
            StorageFile ArbejderTorsdagListe = await ApplicationData.Current.LocalFolder.CreateFileAsync("ArbejderTorsdagListe.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ArbejderTorsdagListe, jsonTextArbejder3);
        }


        public async void HentDataFraDiskAsync()
        {

            try
            {


                StorageFile ArbejderMandagListen = await ApplicationData.Current.LocalFolder.GetFileAsync("ArbejderMandagsListen.Json");
                StorageFile ArbejderTirsdagListen = await ApplicationData.Current.LocalFolder.GetFileAsync("ArbejderTirsdagsListen.Json");
                StorageFile ArbejderOnsdagListen = await ApplicationData.Current.LocalFolder.GetFileAsync("ArbejderOnsdagsListen.Json");
                StorageFile ArbejderTorsdagListen = await ApplicationData.Current.LocalFolder.GetFileAsync("ArbejderTorsdagsListen.Json");

                string jsonTextArbejder = await FileIO.ReadTextAsync(ArbejderMandagListen);
                string jsonTextArbejder1 = await FileIO.ReadTextAsync(ArbejderTirsdagListen);
                string jsonTextArbejder2 = await FileIO.ReadTextAsync(ArbejderOnsdagListen);
                string jsonTextArbejder3 = await FileIO.ReadTextAsync(ArbejderTorsdagListen);

                Instance.ArbejderMandagListe = (ArbejderListe)JsonConvert.DeserializeObject(jsonTextArbejder, typeof(ArbejderListe));
                Instance.ArbejderTirsdagListe = (ArbejderListe)JsonConvert.DeserializeObject(jsonTextArbejder1, typeof(ArbejderListe));
                Instance.ArbejderOnsdagListe = (ArbejderListe)JsonConvert.DeserializeObject(jsonTextArbejder2, typeof(ArbejderListe));
                Instance.ArbejderTorsdagListe = (ArbejderListe)JsonConvert.DeserializeObject(jsonTextArbejder3, typeof(ArbejderListe));


                // Try og catch for at fange en exception for at undgå grimme fejlmeddelser
            }
            catch (Exception ex)
            {
                //Popup vindue til at fortælle brugeren at filen ikke blev fundet. 
                MessageDialog messageDialog = new MessageDialog(ex.Message, "Filen ikke fundet");
                await messageDialog.ShowAsync();
            }
        }
        #endregion
    }
}
