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
            Kuverter KuvertInstance = new Kuverter();
            this.Add(new Kuverter() {HusNr = 2, AntalVoksne = 2, AntalTeen = 41, AntalBoern = 150, AntalBaby = 0 });



        }

        public double AntalKuverterPaaListe()
        {
            double sum = 0;
            foreach (Kuverter kuvert in this)
            {
            sum = sum + kuvert.AntalKuverter();
            }
            return sum;
        }
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public void IndsætJson(string jsonText)
        {
            List<Kuverter> nyListeLisa = JsonConvert.DeserializeObject<List<Kuverter>>(jsonText);


            foreach (var kuverter in nyListeLisa)
            {
                //this.Add(kuverter);
            }
        }
    }
}
