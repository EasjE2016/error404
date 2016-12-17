using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kodning.Model;

namespace kodning.Model
{
    public class Arbejdere
    {
        public string Title { get; set; }
        public string Navn { get; set; }

        public override string ToString()
        {
            return $"{nameof(Navn)}: {Navn}, {nameof(Title)}: {Title}";
        }



    }
}
