using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerlifting.Service.Models
{
    public class ProgramDTO
    {
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }

        public int WorkoutID { get; set; }

    }
}
