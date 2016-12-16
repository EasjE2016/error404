using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using kodning.ViewModel;

namespace UnittestAfKodning
{
    [TestClass]
    public class UnitTest1
    {
        private KuvertViewModel kvm;

        [TestInitialize]
        public void FørHverTest()
        {
            kvm = new KuvertViewModel();
        }

        [TestMethod]
        public void TestMethod1()
        {
            kvm.AddNewKuvertMandag();
        }
    }
}
