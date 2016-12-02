using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.ObjectModel;

namespace kodning.Model
{
    public class TilmeldListe : ObservableCollection<Tilmeld>
    {
        public TilmeldListe(){
        Tilmeld Tilmedling = new Tilmeld();

        
    }


        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public void IndsætJson(string JsonText)
        {
            List<Tilmeld> TilmeldListe = JsonConvert.DeserializeObject<List<Tilmeld>>(JsonText);

            foreach (var Tilmeld in TilmeldListe)
            {
                this.Add(Tilmeld);
            }
        }
       
    }
}
