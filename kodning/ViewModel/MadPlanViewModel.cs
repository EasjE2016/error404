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

namespace kodning.ViewModel
{
    class MadPlanViewModel : INotifyPropertyChanged
    {
        public void AddNewMadplan()
        {
            Madplan tempMadplan = new Madplan();
            tempMadplan.UgeNr = NewMad.UgeNr;
            tempMadplan.UgeDag = NewMad.UgeDag;
            tempMadplan.Pris = NewMad.Pris;
            tempMadplan.Madplannen = NewMad.Madplannen;
            tempMadplan.purchaser = NewMad.purchaser;

            MadplanListen.Add(tempMadplan);
        }

        public void RemoveMadPlan()
        {
            MadplanListen.Remove(SelectedMadplan);
        }

        private Madplan _selectedMadplan;

        public Madplan SelectedMadplan
        {
            get { return _selectedMadplan; }
            set
            {
                _selectedMadplan = value;
                OnPropertyChanged(nameof(SelectedMadplan));
            }
        }

        StorageFolder localfolder = null;

        private readonly string Madplanfilnavn = "JsonText.json";

        //public async void HentdataFraDiskAsync()
        //{
        //    this.MadplanListen.Clear();

        //    StorageFile Madplanfile = await localfolder.GetFileAsync(Madplanfilnavn);
        //    string jsonText = await FileIO.ReadTextAsync(Madplanfile);

        //    MadplanListen.IndsætJson(jsonText);
        //} 

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Herunder er RelayCommands.
        public RelayCommand.RelayCommand AddMadPlanCommand { get; set; }
        public RelayCommand.RelayCommand RemoveMadplanCommand { get; set; }
        public RelayCommand.RelayCommand LoadMadplanCommand { get; set; }
        public RelayCommand.RelayCommand SaveMadplanCommand { get; set; }

        // Slut af Relays.

        public event PropertyChangedEventHandler PropertyChanged;
        
        //public MadplanListe MadplanListen { get; private set; }
        public Madplan NewMad { get;  set; }

        private MadplanListe _madplansliste;

        public MadplanListe MadplanListen
        {
            get { return _madplansliste; }
            set {
                _madplansliste = value;
                OnPropertyChanged(nameof(MadplanListen));
            }
        }


        // til JSON

        private readonly string file = "JsonText.json";

        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.MadplanListen.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(Madplanfilnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }

        public async void HentDataFraDiskAsync()
        {

            try
            {
                StorageFile file = await localfolder.GetFileAsync(Madplanfilnavn);

                string jsonText = await FileIO.ReadTextAsync(file);

                this.MadplanListen.Clear();

                //metoden på medarbejderlisten
                MadplanListen.IndsætJson(jsonText);

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
            localfolder = ApplicationData.Current.LocalFolder;
            NewMad = new Madplan();
            SelectedMadplan = new Madplan();
            AddMadPlanCommand = new RelayCommand.RelayCommand(AddNewMadplan);
            RemoveMadplanCommand = new RelayCommand.RelayCommand(RemoveMadPlan);
            LoadMadplanCommand = new RelayCommand.RelayCommand(HentDataFraDiskAsync);
            SaveMadplanCommand = new RelayCommand.RelayCommand(GemDataTilDiskAsync);           
        }
    }
}
