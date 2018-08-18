using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorApp.DataAccess
{
    public class Motor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        [MaxLength(100)]
        public string MotorName { get; set; }

        [Required]
        public decimal Current { get; set; }

        
        public decimal DifferenceC { get; set; }

        [Required]
        public int Revs { get; set; }

        public int DifferenceR { get; set; }

        [Required]
        public int Pressure { get; set; }

        public int DifferenceP { get; set; }
    }
}
