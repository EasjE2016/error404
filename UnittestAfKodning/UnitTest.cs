using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using kodning.ViewModel;
using kodning.Model;


namespace UnittestAfKodning
{
    [TestClass]
    public class UnitTest1
    {
       // private KuvertViewModel kvm;

        //[TestInitialize]
        //public void FørHverTest()
        //{
        //    kvm = new KuvertViewModel();
        //}

        [TestMethod]
        // Ingen tilmeldte
        public void TestMethod1()
        {
            //kvm.AddNewKuvertMandag();

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
            liste1.Add(new Kuverter() { Voksne = 2, Teens = 2, Boern = 4, Baby = 2 });

            double aktuel1 = beregn1.ReturKuvert(liste1);
            Assert.AreEqual(4, aktuel1);
        }
        [TestMethod]
        // Tilmeldt 2 lister
        public void TestMethod3()
        {
            PrisBeregning beregn2 = new PrisBeregning();
            KuverterListe liste2 = new KuverterListe();
            liste2.Add(new Kuverter() { Voksne = 2, Teens = 2, Boern = 4, Baby = 2 });
            liste2.Add(new Kuverter() { Voksne = 3 });

            double aktuel2 = beregn2.ReturKuvert(liste2);
            Assert.AreEqual(7, aktuel2);
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
        [TestMethod]
        // Udregn kuvertpris
        public void TestMethod5()
        {
            PrisBeregning beregn4 = new PrisBeregning();

           // PrisBeregning per Kuvert Test
        }
    }
}

