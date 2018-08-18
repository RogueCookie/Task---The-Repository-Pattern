using MotorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorApp.BuisnessLogic
{
    public class MotorInitializeDB : DropCreateDatabaseIfModelChanges<MotorContext>
    {
        protected override void Seed(MotorContext context)
        {
            context.Motors.Add(new Motor
            {
                Id = 1,
                TimeStamp = Convert.ToDateTime("10:00:00"),
                MotorName = "Motor 1",
                Current = 8.7

            });
            context.Motors.Add(new Motor
            {
                Id = 2,
                TimeStamp = Convert.ToDateTime("10:00:00"),
                MotorName = "Motor 2",
                Revs = 3000

            });
            context.Motors.Add(new Motor
            {
                Id = 3,
                TimeStamp = Convert.ToDateTime("10:00:00"),
                MotorName = "Motor 2",
                Pressure = 160

            });
            context.SaveChanges();

            base.Seed(context); 
        }
    }
}
