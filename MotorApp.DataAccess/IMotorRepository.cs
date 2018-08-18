using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorApp.DataAccess
{
    /// <summary> That's will be define which database can be performed on our Data Entity </summary>
    public interface IMotorRepository
    {
        void Add(Motor p);
        void Edit(Motor p);
        void Remove(int Id);

        IEnumerable<Motor> GetMotors();
        Motor FindById(int Id);
    }
}
