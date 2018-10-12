using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace browserDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            int IsAnyThingFinished = 0;
            while (IsAnyThingFinished == 0)
            {
               // Console.Clear();
                string path = "";
                int DriveNum = 0;
                int DoWhat = 0;
                int notready;
               // int CouldContinueReadyDevice = 0;
                DriveNum = ShowDrives(out  notready);
                int n = notready;
                
                    DoWhat = WhatToDo(DriveNum, n);
                if(DoWhat== -3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Enter The Codes :");
                    Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(1000);
                    Console.Clear();
                }
                else

                if (DoWhat == -1)
                {
                    IsAnyThingFinished = 1;
                    break;

                }
                else
                    if (DoWhat == 0)
                {
                    Console.WriteLine("You Are at root"); Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                if (DoWhat == -2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Device Is Not ready");
                    Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    path += DriveInfo.GetDrives()[DoWhat - 1];
                    int conti = 0;
                    while (path.Length >= 3 || conti == 0)
                    {
                        Console.Clear();
                        int all = 1;
                     
                        Console.WriteLine(path);

                        DirectoryInfo dir = new DirectoryInfo(path);
                        try
                        {
                            if (dir.GetDirectories().Length != 0)
                            {
                                for (int i = 0; i < dir.GetDirectories().Length; i++)
                                {

                                    Console.WriteLine($"{all },  {dir.GetDirectories()[i].FullName}");
                                    all++;
                                }

                            }
                            if (dir.GetFiles().Length != 0)
                            {
                                for (int i = 0; i < dir.GetFiles().Length; i++)
                                {
                                    Console.Write($"{all}; {dir.GetFiles()[i].FullName}  ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\t (File)");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    all++;
                                }
                            }
                        }
                        catch { conti = 1; Console.WriteLine("system file");  Thread.Sleep(1200);  break; }
                        int dw = WhatToDo(all);
                        if(dw == -3)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Enter The Codes :");
                            Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(1000);
                            continue;

                        }
                        else
                        if (dw == -1)
                        {
                            IsAnyThingFinished = 1;
                            conti = 1;
                                break;
                        }
                        else
                        if (dw == 0)
                        {
                            try
                            {
                                if (dir.Parent.FullName != null)
                                    path = dir.Parent.FullName;
                                else
                                    conti = 1;
                            }
                            catch { conti = 1; path =@"C" ;}

                        }
                        else
                   
                            if (dw<=dir.GetDirectories().Length)
                            path = dir.GetDirectories()[dw - 1].FullName;
                        else
                            Process.Start(dir.GetFiles()[(dw-dir.GetDirectories().Length)-1].FullName);

                    }
                }


               

               










            }
           // Console.ReadKey();

        }

        static int ShowDrives(out int notready)
        {
            int i = 1;
             notready = 0;
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (d.IsReady)
                {
                    Console.WriteLine($"{i++}-{d.Name}\t {d.DriveType} " +
                        $"\t Free Space : {(d.AvailableFreeSpace)/1024/1024/1024} GB " +
                        $"\t Total Size : {d.TotalSize/1024/1024/1024} GB");

                }
                else
                {
                    notready++;
                    Console.Write($"{i++}-{d.Name}\t {d.DriveType} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t (Empty)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            return DriveInfo.GetDrives().Length;
        }

        static int WhatToDo(int driveNum,int n)
        {

           
                    string which ;
            int value;

                    Console.WriteLine(@"which do you want to Open ?Enter the Codes/n (Type Exit to Close the Browser.)");
                      which =Console.ReadLine();
            if (int.TryParse(which, out value))

            {
                if (value == 0)
                    return 0;
                else
                      if (Math.Abs(value) <= (driveNum - n))
                {
                    Console.WriteLine(Math.Abs(value));
                    return Math.Abs(value);
                }
                else
                    return -2;
            }
            else
                  if (which == "exit")
            {

                return -1;
            }
            else
                return -3;





        }
        static int WhatToDo(int driveNum)
        {

            string which = "";
            int value;
            Console.WriteLine("which do you want to Open ? (Type Exit to Close the Browser.)");
            which = Console.ReadLine();
            if(int.TryParse(which , out value))
            {
                if (value == 0)
                {

                    return 0;
                }

                else

                {

                    return Math.Abs(value);
                }
            }
            else
            {
                if (which.ToString().ToLower() == "exit")
                {

                    return -1;
                }
                else
                    return -3;

            }

         


        }
    }
}
