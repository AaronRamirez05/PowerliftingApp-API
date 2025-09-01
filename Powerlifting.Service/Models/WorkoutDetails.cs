using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerlifting.Service.Models
{
    public class WorkoutDetails
    {
        public int Day { get; set; }
        public string WorkoutName { get; set; }
        public string SRRWeek1 { get; set; }
        public string SRRWeek2 { get; set; }
        public string SRRWeek3 { get; set; }
        public string SRRWeek4 { get; set; }
        public string ProgramName { get; set; }
        public string UserId { get; set; }
    }
}
