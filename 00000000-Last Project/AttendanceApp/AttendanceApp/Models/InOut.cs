using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class inout
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int personId { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public bool isRest { get; set; }
        public int  workInThisDay { get; set; }
        public int delayInThisDay { get; set; }
        public bool isCommited { get; set; }
    }
}