using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorApp.BuisnessLogic;
using MotorApp.DataAccess;
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
            Assert.AreEqual(3, numberOfRecords);
        }

        [TestMethod]
        public void IsRepositoryAddMotor()
        {
            Motor motorToInsert = new Motor
            {
                Id = 3,
                TimeStamp = Convert.ToDateTime("10:00:00"),
                MotorName = "Motor 3",
                Pressure = 160
            };

            Repo.Add(motorToInsert);
            //if motor inserted successfully, number of records will increase to 3
            var result = Repo.GetMotors();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(7, numberOfRecords);
        }
    }
}
