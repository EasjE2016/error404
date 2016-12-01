using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace kodning
{
    class MadplanListe : ObservableCollection<Madplan>
    {
        public MadplanListe()
        {
            Madplan MadplanInstance = new Madplan();
            MadplanInstance.Madplannen = "";

            this.Add(new Madplan() { Ingredienser = "Salt, Peper", UgeDag="Mandag", Madplannen="Kylling og kartoffler", UgeNr= 41, Pris= 150 });
            this.Add(new Madplan() { Ingredienser = "Ost, Skinke", UgeDag = "Fredag",  Madplannen = "Pariser toast", UgeNr = 42, Pris = 110 });
            this.Add(new Madplan() { Ingredienser = "Sved, orve, orme", UgeDag = "Tirsdag", Madplannen = "Orve testikler", UgeNr = 43, Pris = 170 });
            

        }
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public void IndsætJson(string jsonText)
        {
            List<Madplan> nyListe = JsonConvert.DeserializeObject<List<Madplan>>(jsonText);
                

            foreach (var Madplan in nyListe)
            {
                this.Add(Madplan);
            }
        }
    }
}
