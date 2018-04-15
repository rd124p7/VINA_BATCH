using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VINA_BATCH.FFManagement;

namespace VINA_BATCH_TESTS
{
    [TestClass]
    public class StructureListTest
    {
        // Test the creation of an empty StructureList
        [TestMethod]
        public void InitStructureListTest()
        {
            StructureList structList = new StructureList();
        }

        // Test the creation of a StructureList that has an array
        [TestMethod]
        [Timeout(100)]      //Allow 100ms for this test method
        public void InitArrayStructureListTest()
        {
            Structure[] arrStructs = {
                new Structure(@"C:\Users"),
                new Structure(@"Z:\bin"),
                new Structure(@"Z:\")
            };
        }
    }
}
