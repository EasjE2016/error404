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
            Madplan Mandag = new Madplan();
            Mandag.Madplannen = "Boller i karry";
            Mandag.Ingredienser = "Kød, karry, æbler";
            Add(Mandag);
        }
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        //public void IndsætJson(string jsonText)
        //{
        //    List<MadplanListe> nyListe = JsonConvert.DeserializeObject<List<Madplan>>(jsonText);

        //    foreach (var Medarbejder in nyListe)
        //    {
        //        this.Add(Madplan);
        //    }
        //}
    }
}
