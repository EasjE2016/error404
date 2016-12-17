using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using kodning.ViewModel;
using kodning.Model;


namespace UnittestAfKodning
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // Ingen tilmeldte
        public void TestMethod1()
        {
            PrisBeregning beregn = new PrisBeregning();
            KuverterListe liste = new KuverterListe();

            double aktuel = beregn.ReturKuvert(liste);
            Assert.AreEqual(0, aktuel);
        }
        [TestMethod]
        // Tilmeldt 1 liste
        public void TestMethod2()
        {
            PrisBeregning beregn1 = new PrisBeregning();
            KuverterListe liste1 = new KuverterListe();
            liste1.Add(new Kuverter() { MandagVoksne = 2, MandagTeens = 2, MandagBoern = 4, MandagBaby = 2 });

            double aktuel1 = beregn1.ReturKuvert(liste1);
            Assert.AreEqual(4, aktuel1);
        }
        [TestMethod]
        // Tilmeldt 2 lister
        public void TestMethod3()
        {
            PrisBeregning beregn2 = new PrisBeregning();
            KuverterListe liste2 = new KuverterListe();
            liste2.Add(new Kuverter() { MandagVoksne = 2, MandagTeens = 2, MandagBoern = 4, MandagBaby = 2 });
            liste2.Add(new Kuverter() { MandagVoksne = 3 });

            double aktuel2 = beregn2.ReturKuvert(liste2);
            Assert.AreEqual(7, aktuel2);
        }
        [TestMethod]
        public void TestMethod4()
        {
            PrisBeregning beregn3 = new PrisBeregning();

            beregn3.kuverterForDagen = 2;
            beregn3.kuverterForTirsdag = 2;
            beregn3.kuverterForOnsdag = 2;
            beregn3.kuverterForTorsdag = 2;

            double aktuel3 = 8;
            double HvadSomHelst = beregn3.KuvertIAlt;
            Assert.AreEqual(8, aktuel3);

            //Assert.AreEqual(expected, HvadSomHelst, 8, "tag dig sammen");
        }
        //[TestMethod]
        //// Udregn kokkens udlæg. Vi har ikke testet metoder
        //public void TestMethod4()
        //{
        //    PrisBeregning beregn3 = new PrisBeregning();

        //    double Kok1Udlæg = 100;
        //    double Kok2Udlæg = 100;
        //    double Kok3Udlæg = 100;
        //    double Kok4Udlæg = 400;

        //    double aktuel4 = beregn3.PrisIAlt();
        //    Assert.AreEqual(400, beregn3);
        //}
        
        
    }
}

