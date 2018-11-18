using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class position
    {
        public int Id { get; set; }
        public string positionName { get; set; }
        public int restLimit { get; set; }

        public int baseSalary { get; set; }


    }
}