using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableStudent
{
    class student :IComparable
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public double Average { get; set; }

        public int CompareTo(object obj)
        {
            student std = (student)obj;
            if (this.Family.CompareTo(std.Family) == 0)
            {
                if (this.Name.CompareTo(std.Name) == 0)
                    return 0;
                else
                    if (this.Name.CompareTo(std.Name) == 1)
                    return 1;
                else
                    return -1;
            }
            else
                if (this.Family.CompareTo(std.Family) == 1)
                return 1;
            else
                return -1;

        }

        public override string ToString()
        {
            return $"{Name} {Family} [{Average}]";
        }
    }
}
