using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomExamQuestion
{
    class Program
    {
        static void Main(string[] args)
        {


            Exam exam = new Exam()
            {
                Name = "MCSD Exam",
                Questions = new Question[]
               {
                    new Question() {Id = 1 , Text = "What's your name" },
                    new Question() {Id = 2 , Text = "Describe OOP" },
                    new Question() {Id = 3, Text = "Describe GC" },
                    new Question() {Id = 4 , Text = "What's the difference between Interface and Abstract Class" },
                    new Question() {Id = 5 , Text = "Questin 5" },
                    new Question() {Id = 6 , Text = "Questin 6" },
                    new Question() {Id = 7 , Text = "Questin 7" },
                    new Question() {Id = 8 , Text = "Questin 8" },
                    new Question() {Id = 9 , Text = "Questin 9" },
                    new Question() {Id = 10 , Text = "Questin 10" },
                    new Question() {Id = 11 , Text = "Questin 11" },
                    new Question() {Id = 12 , Text = "Questin 12" },
                    new Question() {Id = 13 , Text = "Questin 13" },
                    new Question() {Id = 14 , Text = "Questin 14" },
                    new Question() {Id = 15 , Text = "Questin 15" },
                    new Question() {Id = 16 , Text = "Questin 16" },
                    new Question() {Id = 17 , Text = "Questin 17" },
                    new Question() {Id = 18 , Text = "Questin 18" },
                    new Question() {Id = 19 , Text = "Questin 19" },
                    new Question() {Id = 20 , Text = "Questin 20" },
                    new Question() {Id = 21 , Text = "Questin 21" },
                    new Question() {Id = 22 , Text = "Questin 22" },
                    new Question() {Id = 23 , Text = "Questin 23" },
                    new Question() {Id = 24 , Text = "Questin 24" },
                    new Question() {Id = 25 , Text = "Questin 25" },
                    new Question() {Id = 26 , Text = "Questin 26" },
                    new Question() {Id = 27 , Text = "Questin 27" },
                    new Question() {Id = 28 , Text = "Questin 28" },
                    new Question() {Id = 29 , Text = "Questin 29" },
                    new Question() {Id = 30 , Text = "Questin 30" },
                    new Question() {Id = 31 , Text = "Questin 31" },
                    new Question() {Id = 32 , Text = "Questin 32" },
                    new Question() {Id = 33 , Text = "Questin 33" },
                    new Question() {Id = 34 , Text = "Questin 34" },
                    new Question() {Id = 35 , Text = "Questin 35" },
                    new Question() {Id = 36 , Text = "Questin 36" },
                    new Question() {Id = 37 , Text = "Questin 37" },
                    new Question() {Id = 38 , Text = "Questin 38" },
                    new Question() {Id = 39 , Text = "Questin 39" },
                    new Question() {Id = 40 , Text = "Questin 40" },
                    new Question() {Id = 41 , Text = "Questin 41" },
                    new Question() {Id = 42 , Text = "Questin 42" },
                    new Question() {Id = 43 , Text = "Questin 43" },
                    new Question() {Id = 44 , Text = "Questin 44" },
                    new Question() {Id = 45 , Text = "Questin 45" },
                    new Question() {Id = 46 , Text = "Questin 46" },
                    new Question() {Id = 47 , Text = "Questin 47" },
                    new Question() {Id = 48 , Text = "Questin 48" },
                    new Question() {Id = 49 , Text = "Questin 49" },
                    new Question() {Id = 50 , Text = "Questin 50" },
                   

               }
            };
            foreach (Question q in exam)
            {
                Console.WriteLine(q);
            }
            Console.WriteLine(".........................................");
        
            Console.ReadKey();
        }
    }
}
