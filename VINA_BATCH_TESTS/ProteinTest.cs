using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VINA_BATCH.FFManagement;

namespace VINA_BATCH_TESTS
{
    [TestClass]
    public class ProteinTest
    {
        // Test creating two Protein objects
        [TestMethod]
        public void InitProtein()
        {
            Protein proteinOne = new Protein(@"C:\");
            Protein proteinTwo = new Protein(@"Z:\");
        }
    }
}
