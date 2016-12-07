using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace kodning.Model
{
    class KuverterListe : ObservableCollection<Kuverter>
    {
        public KuverterListe()
        {
            Kuverter KuvertInstance = new Kuverter();
            this.Add(new Kuverter() {HusNr = 2, AntalVoksne = 2, AntalTeen = 41, AntalBoern = 150, AntalBaby = 0 });


        }
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public void IndsætJson(string jsonText)
        {
            List<Madplan> nyListeLisa = JsonConvert.DeserializeObject<List<Madplan>>(jsonText);


            foreach (var kuverter in nyListeLisa)
            {
                //this.Add(kuverter);
            }
        }
    }
}
