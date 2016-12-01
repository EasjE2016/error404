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
    class ArbejderPlanViewModel : INotifyPropertyChanged
    {
        public Arbejdere SelectedArbejder
        {
            get { return SelectedArbejder; }
            set
            {
                SelectedArbejder = value;
                OnPropertyChanged(nameof(SelectedArbejder));
            }
        }

        public void AddNewArbejder()
        {
            ArbejderListen.Add(NewArbejder);
        }

        public void RemoveArbejder()
        {
            ArbejderListen.Remove(SelectedArbejder);
        }

        private readonly string arbejderfilnavn = "JsonText.json";

        public async void HentdataFraDiskAsync()
        {
            this.ArbejderListen.Clear();

            StorageFile arbejderfile = await localfolder3.GetFileAsync(arbejderfilnavn);
            string jsonText = await FileIO.ReadTextAsync(arbejderfile);

            ArbejderListen.IndsætJson(jsonText);
        }



        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.ArbejderListen.GetJson();
            StorageFile file = await localfolder3.CreateFileAsync(arbejderfilnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }

        StorageFolder localfolder3 = null;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //RelayCommands

        public RelayCommand.RelayCommand AddArberjderCommand { get; set; }
        public RelayCommand.RelayCommand RemoveArberjderCommand { get; set; }
        public RelayCommand.RelayCommand LoadArberjderCommand { get; set; }
        public RelayCommand.RelayCommand SaveArberjderCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ArbejderListe ArbejderListen { get; private set; }
        public Arbejdere NewArbejder { get; set; }

        public ArbejderPlanViewModel()
        {
            ArbejderListen = new ArbejderListe();
            SelectedArbejder = new Arbejdere();
            NewArbejder = new Arbejdere();
            localfolder3 = ApplicationData.Current.LocalFolder;
            AddArberjderCommand = new RelayCommand.RelayCommand(AddNewArbejder);
            RemoveArberjderCommand = new RelayCommand.RelayCommand(RemoveArbejder);
            LoadArberjderCommand = new RelayCommand.RelayCommand(RemoveArbejder);
            SaveArberjderCommand = new RelayCommand.RelayCommand(GemDataTilDiskAsync); 
        }

    }
}
