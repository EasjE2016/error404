using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kodning.Model;


namespace kodning.InAkivKode
{
    public sealed class ArbejderCatalogSingleton
    {
        public static ArbejderCatalogSingleton Instance { get; set; } = new ArbejderCatalogSingleton();

        public ArbejderListe ArbejderMandagListe { get; set; } = new ArbejderListe();
        public ArbejderListe ArbejderTirsdagListe { get; set; } = new ArbejderListe();
        public ArbejderListe ArbejderOnsdagListe { get; set; } = new ArbejderListe();
        public ArbejderListe ArbejderTorsdagListe { get; set; } = new ArbejderListe();



        private ArbejderCatalogSingleton()
        {
            ArbejderMandagListe = new ArbejderListe();
            ArbejderTirsdagListe = new ArbejderListe();
            ArbejderOnsdagListe = new ArbejderListe();
            ArbejderTorsdagListe = new ArbejderListe();
        }
    }
}
