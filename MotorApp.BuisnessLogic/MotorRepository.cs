using MotorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorApp.BuisnessLogic
{
    public class MotorRepository : IMotorRepository
    {
        MotorContext context = new MotorContext();

        public void Add(Motor p)
        {
            context.Motors.Add(p);
            context.SaveChanges();
        }

        public void Edit(Motor p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
        }

        public Motor FindById(int Id)
        {
            var result = (from r in context.Motors
                          where r.Id == Id
                          select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<Motor> GetMotors()
        {
            return context.Motors;
        }

        public void Remove(int Id)
        {
            Motor p = context.Motors.Find(Id);
            context.Motors.Remove(p);
            context.SaveChanges();
        }
    }
}
