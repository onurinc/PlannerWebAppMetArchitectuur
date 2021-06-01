using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DataAccesLayer.Data;
using DataAccesLayer.Data.Context;
using LogicLayer.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlannerWebApp.Test.LogicLayer.Test
{
    [TestClass]
    class TestProjectsContainer
    {
        [TestMethod]
        public void TestProjectContainer_Add_Project()
        {
            ProjectContainer pContainer = new ProjectContainer();
            bool updated;
            try
            {
                pContainer.AddProject("projectOne");   
                updated = true;
            }
            catch (Exception)
            {
                updated = false;
            }

            Assert.IsTrue(updated);
        }


    }
}
