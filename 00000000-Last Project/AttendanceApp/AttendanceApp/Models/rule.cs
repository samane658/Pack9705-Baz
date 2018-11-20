using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class rule
    {
        public int id { get; set; }
        public int workingHour { get; set; }
        public int startWorkTime { get; set; }
        public int endWorkTime { get; set; }
        public int overWorkRate { get; set; }
        public int sendOutRate { get; set; }
        public int delayRate { get; set; }
        public int restLimit { get; set; }
    }
}