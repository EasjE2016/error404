using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace kodning.Model
{
    class KuverterListe : ObservableCollection<Kuverter>
    {
        public KuverterListe()
        {
            Kuverter KuvertInstance = new Kuverter();
            

        }
    }
}
