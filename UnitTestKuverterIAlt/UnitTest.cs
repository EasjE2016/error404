using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using kodning.Model;

namespace UnitTestKuverterIAlt
{
    [TestClass]
    public class KuverterIAltTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PrisBeregning KuvertTest = new PrisBeregning();

            KuvertTest.kuverterForDagen = 2;
            KuvertTest.kuverterForTirsdag = 2;
            KuvertTest.kuverterForOnsdag = 2;
            KuvertTest.kuverterForTorsdag = 2;

            double expected = 8;
            double HvadSomHelst = KuvertTest.KuvertIAlt;

            Assert.AreEqual(expected, HvadSomHelst, 8, "tag dig sammen");
            



            
            
        }
    }
}
