using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VINA_BATCH.FFManagement;


namespace VINA_BATCH_TESTS
{
    [TestClass]
    public class StructureTest
    {

        // Test creating two Structure objects
        [TestMethod]
        public void InitSturcture()
        {
            Structure structOne = new Structure(@"Z:\");
            Structure structTwo = new Structure(@"C:\Users\");
        }

        // Create a structure object and test the GetPath method
        [TestMethod]
        public void StructureGetPath()
        {
            Structure structOne = new Structure(@"Z:\");
            string testPath = structOne.GetPath();
        }

        // Create a structure object and test the GetName method
        [TestMethod]
        public void StructureGetName()
        {
            Structure structOne = new Structure(@"Z:\");
            string structName = structOne.GetName();
        }
    }
}
