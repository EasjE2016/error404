using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodning.Model
{
    class ArbejderListe : ObservableCollection<Arbejdere>
    {
        public ArbejderListe()
        {
            Arbejdere Nr1 = new Arbejdere();
            Nr1.Title = "Kok";
            Nr1.UgeDag = "Mandag";
            Nr1.UgeNR = 48;
        }
        //public string GetJson()
        //{
        //    string json = JsonConvert.SerializeObject(this);
        //    return json;
        //}
        //public void IndsætJson(string jsonText)
        //{
        //    List<Madplan> nyListe2 = JsonConvert.DeserializeObject<List<Madplan>>(jsonText);


        //    foreach (var ArbejderOversigt in nyListe2)
        //    {
        //        this.Add(ArbejderOversigt);
        //    }
        //}
    }
}
