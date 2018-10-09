using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableStudent
{
    class Program
    {
        static void Main(string[] args)
        {

            student[] students = new student[]
               {
                    new student() { Name = "Ross", Family = "Geller", Average = 80 },
                    new student() { Name = "Chandler", Family = "Bing", Average = 70 },
                    new student() { Name = "Monica", Family = "Geller", Average = 90 },
                    new student() { Name = "aaa", Family = "aaaaa", Average = 50 },
                    new student() { Name = "aaa", Family = "zzzzz", Average = 90 }
               };

            Array.Sort(students);
            foreach (student student in students)
            {
                Console.WriteLine(student);
            }

            Console.ReadKey();
        }
    }
}
