using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string positionName { get; set; }
        public int managerId { get; set; }
        public DateTime birthDate { get; set; }
        public int cellPhone { get; set; }
        public string address { get; set; }
        public string Gender { get; set; }
    }
}