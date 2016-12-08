using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kodning.RelayCommand
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action execute;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }
        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }



        //Til at oprette ny på liste så den ikke overwriter.
        //Model.Medarbejder TempMedarbejder = new Model.Medarbejder();
        //TempMedarbejder.funktion = NewMedarbejder.funktion;
        //        TempMedarbejder.ID = NewMedarbejder.ID;
        //        TempMedarbejder.navn = NewMedarbejder.navn;
                //Medarbejderliste.Add(TempMedarbejder);
    }
}
