using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kodning.Model
{
    public class ArbejderListe : ObservableCollection<Arbejdere>
    {
        public ArbejderListe()
        {

        }

        #region Json
        public string SaveArbejderJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        #endregion
    }
}
