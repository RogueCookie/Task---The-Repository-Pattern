using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorApp.BuisnessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorApp.UnitTest
{
    [TestClass]
    public class MotorRepositoryTest
    {
        MotorRepository Repo;
        [TestInitialize]
        public void TestSetup()
        {
            MotorInitializeDB db = new MotorInitializeDB();
            System.Data.Entity.Database.SetInitializer(db);
            Repo = new MotorRepository();
        }
        
        [TestMethod]
        public void IsRepositoryInitializeWithValidNumberOdData()
        {
            var result = Repo.GetMotors();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(2, numberOfRecords);
        }
    }
}
