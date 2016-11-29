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
        public Arbejdere ArbejdereUge48 { get; private set; }

        private Arbejdere selectedArbejder;
        public Arbejdere SelectedArbejder
        {
            get { return selectedArbejder; }
            set
            {
                selectedArbejder = value;
                OnPropertyChanged(nameof(SelectedArbejder));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ArbejderPlanViewModel()
        {
            ArbejdereUge48 = new Model.Arbejdere();
        }
    }
}
