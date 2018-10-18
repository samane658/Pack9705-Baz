using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexPersianDate
{
    class Program
    {
        static void Main(string[] args)
        {
             //Regex PDataPattern = new Regex(@"^(\d{2,4}[./-]0\d[1-9][./-]\d[0-2]\d[1-9]) | (\d{2,4}[./-]1\d[0-2][./-]30)  | (\d{2,4}[./-]0\d[1-9][./-]\d[0-2]\d[1-9])  | (\d{2,4}[./-]1\d[0-2][./-]3\d[0-1])$");

            Regex PDataPattern = new Regex(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|([1-2][0-9])|(0[1-9]))))$");


            while (true)
            {

                Console.WriteLine("Any Text You Like : ");
                string str = Console.ReadLine();
                if (PDataPattern.IsMatch(str))
                {
                    Console.WriteLine("Yes, These Two are Match!!");
                    continue;
                }
                else
                {
                    Console.WriteLine("No, These Two are not Match!!");
                    continue;
                }

            }
        }
    }
}
