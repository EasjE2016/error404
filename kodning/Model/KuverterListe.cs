using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace kodning.Model
{
   public  class KuverterListe : ObservableCollection<Kuverter>
    {
        public KuverterListe()
        {

        }


        public string SaveJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
    }
}
