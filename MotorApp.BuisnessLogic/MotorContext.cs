using MotorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorApp.BuisnessLogic
{
    public class MotorContext : DbContext
    {
        public MotorContext() : base("name = MotorAppConnectionString")  //() entity fram desides where we want to create Db,what name to dive Db
        {
        }

        public DbSet<Motor> Motors { get; set; }

    }
}
