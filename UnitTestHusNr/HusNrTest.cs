using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using kodning.Model;

namespace UnitTestHusNr
{
    [TestClass]
    public class HusNrTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Kuverter HusNrTest = new Kuverter();

            if(HusNrTest.Husnummer < 1)
            {
                throw new ArgumentOutOfRangeException("Husnummer skal være positivt");
            }
        }
    }
}
