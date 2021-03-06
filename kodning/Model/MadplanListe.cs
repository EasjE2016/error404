﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace kodning
{
    public class MadplanListe : ObservableCollection<Madplan>
    {
        public MadplanListe()
        {
            Madplan MadplanInstance = new Madplan();
            MadplanInstance.Madplannen = "";

            this.Add(new Madplan() { UgeDag = "Mandag", Madplannen = "Kylling og kartofler", UgeNr = 41});
            this.Add(new Madplan() { UgeDag = "Fredag",  Madplannen = "Pariser toast", UgeNr = 42});
            this.Add(new Madplan() { UgeDag = "Tirsdag", Madplannen = "Orve testikler", UgeNr = 43 });
            

        }
        #region Json
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public void IndsætJson(string jsonText)
        {
            List<Madplan> nyListeTobias = JsonConvert.DeserializeObject<List<Madplan>>(jsonText);
                

            foreach (var Madplan in nyListeTobias)
            {
                this.Add(Madplan);
            }
        }
        #endregion
    }
}
