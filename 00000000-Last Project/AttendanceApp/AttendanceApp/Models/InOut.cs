using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class InOut
    {
        public int Id { get; set; }
        public int personId { get; set; }
        public DateTime date { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isRest { get; set; }
        public bool iscommited { get; set; }
    }
}