using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.Storage;
using Newtonsoft.Json;
using Windows.UI.Popups;



namespace kodning.ViewModel
{
    class MadPlanViewModel : INotifyPropertyChanged
    {
        public Madplan SelectedMadplan
        {
            get { return selectedMadplan; }
            set
            {
                selectedMadplan = value;
                OnPropertyChanged(nameof(SelectedMadplan));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Herunder er RelayCommands.
        public RelayCommand.RelayCommand AddMadPlan { get; set; }

        // Stop RelayCommands.

        // til RelayCommands.

        // Slut af Relays.

        public event PropertyChangedEventHandler PropertyChanged;
        public Madplan selectedMadplan { get; set; }
        public MadplanListe MadplanListen { get; private set; }


        // til JSON
        StorageFolder localfolder = null;
        private readonly string filnavn = "JsonText.json";

        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.MadplanListen.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }

        public async void HentDataFraDiskAsync()
        {

            try
            {
                StorageFile file = await localfolder.GetFileAsync(filnavn);

                string jsonText = await FileIO.ReadTextAsync(file);

                this.MadplanListen.Clear();

                //metoden på medarbejderlisten
                MadplanListe.IndsætJson(jsonText);

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

        //konstruktor

        public MadPlanViewModel()
        {
            MadplanListen = new MadplanListe();
        }
    }
}
