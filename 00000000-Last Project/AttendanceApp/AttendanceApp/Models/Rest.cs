using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class Rest
    {
        public int Id { get; set; }
        public int personId { get; set; }
        public datatime startDate { get; set; }
        public datatime endDate { get; set; }
        public bool isCommited { get; set; }
    }
}