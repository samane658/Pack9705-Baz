using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = new string[1];
            string[] Names = new string[1];
            string[] LastNames = new string[1];
            int selectedFunction;
            int wannaExit = 0;

           
            while (wannaExit == 0)
            {
                MainMenue(ref numbers, ref Names, ref LastNames);
             
                    Console.WriteLine("Select a Number Between 0 to 4 for the Function You Wanted to Do : ");
                    selectedFunction = int.Parse(Console.ReadLine());
             

                if (selectedFunction == 1)
                {

                    AddToPhoneBook(ref numbers, ref Names, ref LastNames);
                    continue;
                }
                else
                       if (selectedFunction == 2)
                {

                        RemoveFromePhoneBook( ref numbers, ref Names, ref LastNames);

                    continue;

                }
                else
                       if (selectedFunction == 3)
                {

                    EditPhoneBook(ref numbers, ref Names, ref LastNames);
                    continue;
                }
                else
                       if (selectedFunction == 4)
                {
                    wannaExit = 1;
                }
                else
                    Console.WriteLine("Enter the Number Between 1 and 4 PLEASE: ");

                Console.WriteLine(" Sure to Exit : y or n :");
                while (true)
                {
                    string suretoexit = Console.ReadLine().ToLower();
                    if (suretoexit == "y")
                        break;
                    else
                        if (suretoexit == "n")
                             {
                                 wannaExit = 0;
                                 break;

                             }
                }
                    

            }

            // Console.ReadKey();

        }

        static void MainMenue(ref string[] numbers,ref string[] names,ref string[] lastnames )
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (numbers[0] != null)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                   
                    Console.WriteLine($"{i + 1} : {names[i]}  {lastnames[i]}  {numbers[i]}");
                    Console.WriteLine();
                }

            }

           
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(" 1. Add\t\t 2.Delete ");
            Console.WriteLine(" 3. Edit\t 4.Exit ");
            Console.WriteLine();


        }

        static void AddToPhoneBook(ref string[] arraynum , ref string[] arrayname, ref string[] arraylastname)
        {
            Console.Clear();
            string name;
            string lastname;
            string number;
            int adding = 1;
            Console.WriteLine();
            Console.WriteLine("Add To PhoneBook ");
            Console.WriteLine();
            while (adding==1)
            {
                    Console.WriteLine("Enter Name to add to PhoneBook  then Press Enter and Enter the LastName :");
                     name = Console.ReadLine();
                     lastname = Console.ReadLine();
                    Console.WriteLine("Enter Phone Number to add to PhoneBook ");
                     number = Console.ReadLine();


                    if (arraynum[0] != null)
                    {
                        string[] newArray = new string[arraynum.Length + 1];

                        for (int i = 0; i < arraynum.Length; i++)
                        {
                            newArray[i] = arraynum[i];
                        }
                        newArray[newArray.Length - 1] = number;
                        arraynum = newArray;
                    }
                    else

                    {
                        arraynum[0] = number;
                    }

                    // Adding Name

                    if (arrayname[0] != null)
                    {
                        string[] newArray = new string[arrayname.Length + 1];

                        for (int i = 0; i < arrayname.Length; i++)
                        {
                            newArray[i] = arrayname[i];
                        }
                        newArray[newArray.Length - 1] = name;
                        arrayname = newArray;
                    }
                    else

                    {
                        arrayname[0] = name;
                    }

                    // Adding LastName

                    if (arraylastname[0] != null)
                    {
                        string[] newArray = new string[arraylastname.Length + 1];

                        for (int i = 0; i < arraylastname.Length; i++)
                        {
                            newArray[i] = arraylastname[i];
                        }
                        newArray[newArray.Length - 1] = lastname;
                        arraylastname = newArray;
                    }
                    else

                    {
                        arraylastname[0] = lastname;
                    }


                Console.WriteLine("wanna Add Another Contact ? y or n " );
                string anotheradd = Console.ReadLine().ToLower();
                while (true)
                {
                    if (anotheradd == "y")

                        break;

                    else
                        if (anotheradd == "n")
                    {
                        adding = 0;
                        break;
                    }
                }
                
            }



        }




        static void RemoveFromePhoneBook(ref string[] arraynum, ref string[] arrayname, ref string[] arraylastname )
        {
            int IsExist = 0;
            int  removenum;
               // check empty phoneBook
            if (arraynum.Length == 1 && arraynum[0] == null)
                {
                    Console.WriteLine("Nothing To Delete !!!! Press Any Key to Exit ..");
                    Console.ReadKey();
                }
            else

                while (IsExist==0)
            {
                Console.WriteLine("Enter the Code Of Line wanted to Delete :");
                removenum = int.Parse(Console.ReadLine());



                if (removenum > 0 && removenum <= arraynum.Length)
                {
                    Console.WriteLine("Removing..");
                    Thread.Sleep(200);

                    if (arraynum.Length > 1)
                    {
                        string[] newArraynum = new string[arraynum.Length - 1];
                        string[] newArrayname = new string[arrayname.Length - 1];
                        string[] newArraylastname = new string[arraylastname.Length - 1];

                      
                            for (int i = 1, j = 0; i <= arraynum.Length; i++)
                            {
                                if (i != removenum)
                                {
                                    newArraynum[j] = arraynum[i - 1];
                                    newArrayname[j] = arrayname[i - 1];
                                    newArraylastname[j] = arraylastname[i - 1];
                                    j++;
                                }
                            }
                            arraynum = newArraynum;
                            arrayname = newArrayname;
                            arraylastname = newArraylastname;
                            IsExist = 1;
                   

                    }
                    else
                    {
                        string[] newArraynum = new string[arraynum.Length];
                        string[] newArrayname = new string[arrayname.Length];
                        string[] newArraylastname = new string[arraylastname.Length];

                        arraynum = newArraynum;
                        arrayname = newArrayname;
                        arraylastname = newArraylastname;
                        IsExist = 1;
                        
                    }
                  


                }
                else
                    Console.WriteLine("This Code Not Exist !!!! ");
              
            }

           
              


        }

        static void EditPhoneBook(ref string[] arraynum, ref string[] arrayname, ref string[] arraylastname)
        {
            if (arraynum[0] == null && arraynum.Length==1)
            {
                Console.WriteLine("There is Nothing To Edit ...");
                Console.WriteLine("You Must First Add Contacts to PhoneBook !!!! Press Any Key to Exit ..");

                Console.ReadKey();

            }
            else
            {
                int AnotherEdit = 1;
                while (AnotherEdit == 1)
                {
                    Console.Clear();
                
                for (int i = 0; i < arraynum.Length; i++)
                {

                    Console.WriteLine($"{i + 1} : {arrayname[i]}  {arraylastname[i]}  {arraynum[i]}");
                    Console.WriteLine();
                }
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------------------");
               

                    int IsExist = 0;
                    while (IsExist == 0)
                    {
                        Console.WriteLine("which Row Do You Want to Edit ? ");
                        var SelectToEdit = int.Parse(Console.ReadLine());

                        if (SelectToEdit > 0 && SelectToEdit <= arraynum.Length)
                        {
                            int IsNameEdit;
                            Console.WriteLine($"{arrayname[SelectToEdit - 1]} /t {arraylastname[SelectToEdit - 1]} /t {arraynum[SelectToEdit - 1]}");
                            int IsDone = 0;
                            while (IsDone == 0)
                            {
                                Console.WriteLine("Enter 1 to Edit Name  ...  Enter 2 to Edit LastName  ...  Enter 3 to Edit PhoneNumber ");
                                IsNameEdit = int.Parse(Console.ReadLine().ToLower());
                                if (IsNameEdit == 1)
                                {
                                    Console.WriteLine("Enter The Correct Name :");
                                    arrayname[SelectToEdit - 1] = Console.ReadLine();
                                    IsDone = 1;


                                }
                                else
                                    if (IsNameEdit == 2)
                                {
                                    Console.WriteLine("Enter The Correct LastName :");
                                    arraylastname[SelectToEdit - 1] = Console.ReadLine();
                                    IsDone = 1;

                                }
                                else
                                    if (IsNameEdit == 3)
                                {
                                    Console.WriteLine("Enter The Correct LastName :");
                                    arraynum[SelectToEdit - 1] = Console.ReadLine();
                                    IsDone = 1;

                                }

                            }


                            IsExist = 1;
                        }
                        else
                        {
                            Console.WriteLine("This Row Does not Exist ");

                        }
                    }

                    Console.WriteLine("Another Edit ?  enter n to End");
                    if (Console.ReadLine().ToLower()=="n")
                    {
                        AnotherEdit = 0;
                    }

                }

            }

            //Console.ReadLine();

        }




    }
}
