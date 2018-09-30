using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


namespace Tennis
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var arr = new[] { @"  $$$$$$$  $$$$  $$     $  $$    $  $$$  $$$$$ ",
                              @"    $     $     $ $    $  $ $   $   $    $    ",
                              @"    $     $$$$  $  $   $  $  $  $   $     $   ",
                              @"    $     $     $   $  $  $   $ $   $      $ ",
                              @"     $     $$$$  $    $ $  $    $$  $$$  $$$$$ ",
                            };
            Console.WindowWidth = 60;
            Console.WriteLine("\n\n");
            foreach (string line in arr)
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + line.Length / 2) + "}", line);
           // Console.ReadKey();

            Thread.Sleep(4000);
            Console.Clear();
            string msg = "Lets Play Tennis !";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
            Thread.Sleep(700);
            bool ShallStart = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            string player1;
            int lenPlayer1 = 0;
            do
            {
                Console.WriteLine("Enter Player`s Name Who Played at Right Side \n The Name Must Have More Than 3 Character");
                player1 = Console.ReadLine();
                lenPlayer1 = player1.Length;

            } while (lenPlayer1<3);
            
            player1 = player1.Substring(0, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            string player2;
            int LenPlayer2 = 0;
            do
            {
                Console.WriteLine("Enter Player`s Name Who Played at Left Side \n The Name Must Have More Than 3 Character");
                player2 = Console.ReadLine();
                LenPlayer2 = player2.Length;
            } while (LenPlayer2<3);
            player2 = player2.Substring(0, 3);
            int MaxLen = lenPlayer1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"          ** Coin Toss Decided who Must Serve First , \n               '0' Means {player2} and '1' Means {player1}  **");
            Console.WriteLine();
            Thread.Sleep(2000);
            if (LenPlayer2 > lenPlayer1)
                MaxLen = LenPlayer2;
            // jingooolake coin 
            Random coin = new Random();
            int turn = coin.Next(0, 2);
            Console.Write($" Coin : {turn}  So  ");
            if (turn == 0)
            {
                ShallStart = true;
                Console.WriteLine($" {player2} Must Start the Match");
            }
            else
                if (turn == 1)
            {
                ShallStart = true;
                Console.WriteLine($" {player1} Must Start the Match");
            }
            else
                Console.WriteLine($"Coin Must Be Beetween 0 and 1");

            int[] Player1Lables = new int[3] {0,0,0};


            int[] Player2Lables = new int[3] {0,0,0};

            if (ShallStart)

            {
                // voice needed
                int[] Sound = new int[] { 261, 329, 261, 329, 370, 370, 261, 326, 261, 329, 370, 370, 261, 466, 415, 370, 349, 415, 370, 349, 329, 277, 261 };
                int Duration = 250;
                for (int f = 0; f < Sound.Length; f++)
                    Console.Beep(Sound[f], Duration);

                Console.WriteLine("Match Started ");
                Console.WriteLine();
                Thread.Sleep(1000);        

                int leftOffSet = (Console.WindowWidth / 2)-3;
                int topOffSet = (Console.WindowHeight / 2)-2;
                // round variables
                int Player1NoPoint = 1;
                int Player2NoPoint = 1;
                int RoundIndex = 0;

                string[] Player1AD = new string[2];
                string[] Player2AD = new string[2];

//Set Begin
             int MAXSET = 5;
             int set = 1;
            while(set<=MAXSET)
            {


// Game Variables
                    int IsGameFinished = 0; Player1Lables[1] = 0;Player2Lables[1] = 0;
                    int GameNo = 0; ;
// Game Begin
                while (IsGameFinished == 0)
                {
                        GameNo++;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        
                        msg = $"------------------------";
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                       
                        msg = $"           Set     Game     Round       ";
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                     
                        msg = $"  {player1} ::   {Player1Lables[0]}        {Player1Lables[1]}       {Player1Lables[2]}";
                        Console.WriteLine("{0," + (((Console.WindowWidth / 2) + msg.Length / 2)-4) + "}", msg);
                       
                        Console.WriteLine();
                       
                        msg = $"  {player2} ::   {Player2Lables[0]}        {Player2Lables[1]}       {Player2Lables[2]}";
                        Console.WriteLine("{0," + (((Console.WindowWidth / 2) + msg.Length / 2) - 4) + "}", msg);
                        
                        msg = $"------------------------";
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);

                      

                        int ContinueRound = 1; RoundIndex = 0; Player1Lables[2] = 0; Player2Lables[2] = 0; Player1NoPoint = 1; Player2NoPoint = 1;
     //Round Begin    
                    while (ContinueRound == 1)
                    {
                        RoundIndex++;
                        Console.WriteLine();
                        Console.WriteLine($"Point Left Or Right  ");
                        var ReadKey = Console.ReadKey().Key;
                        if (ReadKey == ConsoleKey.RightArrow)
                        {
                            if (Player1NoPoint == 1 || Player1NoPoint == 2)
                            {
                                Player1Lables[2] += 15;
                                Player1NoPoint++;
                            }
                            else
                                if (Player1NoPoint == 3)
                            {
                                Player1Lables[2] += 10;
                                Player1NoPoint++;
                            }
                            else
                              if (RoundIndex == 4)
                            {
                                if (Player2Lables[2] != 40)
                                {
                                    ContinueRound = 0;
                                    Player1Lables[1] = Player1Lables[1] + 1;
                                    Player1Lables[2] = 0;
                                    Player2Lables[2] = 0;
                                    break;
                                }
                                else
                                {

                                    int i = 0; int j = 0;
                                    while (i < 2 && j < 2)
                                    {
                                        ReadKey = Console.ReadKey().Key;
                                        if (ReadKey == ConsoleKey.RightArrow)
                                        {
                                            i++;
                                            Player1AD[i - 1] = "Ad";

                                            if (i == 2)
                                            {
                                                if (j == 0)
                                                {
                                                    ContinueRound = 0;
                                                    Player1Lables[1] = Player1Lables[1] + 1; ;
                                                    Player1Lables[2] = 0;
                                                    Player2Lables[2] = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    i = 0;
                                                    j = 0;
                                                    Player1AD[0] = " ";
                                                    Player1AD[1] = " ";
                                                    Player2AD[0] = " ";
                                                    Player2AD[1] = " ";
                                                }

                                            }

                                        }
                                        else
                                        if (ReadKey == ConsoleKey.LeftArrow)
                                        {
                                            j++;
                                            Player2AD[j - 1] = "Ad";
                                            if (j == 2)
                                            {
                                                if (i == 0)
                                                {
                                                    ContinueRound = 0;
                                                    Player2Lables[1] = Player2Lables[1] + 1;
                                                    Player2Lables[2] = 0;
                                                    Player1Lables[2] = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    i = 0;
                                                    j = 0;
                                                    Player1AD[0] = " ";
                                                    Player1AD[1] = " ";
                                                    Player2AD[0] = " ";
                                                    Player2AD[1] = " ";
                                                }

                                            }



                                        }
                                    }

                                    Console.WriteLine($" {Player1AD[0]} ,{Player1AD[1]}");
                                    Console.WriteLine($" {Player2AD[0]} ,{Player2AD[1]} ");
                                }

                            }
                            else
                            {
                                if (Player2Lables[2] != 40)
                                {
                                    ContinueRound = 0;
                                    Player1Lables[1] = Player1Lables[1] + 1;
                                    Player1Lables[2] = 0;
                                    Player2Lables[2] = 0;
                                    break;
                                }
                                else
                                {

                                    int i = 0; int j = 0;
                                    while (i < 2 && j < 2)
                                    {

                                        ReadKey = Console.ReadKey().Key;
                                        if (ReadKey == ConsoleKey.RightArrow)
                                        {
                                            i++;
                                            Player1AD[i - 1] = "Ad";

                                            if (i == 2)
                                            {
                                                if (j == 0)
                                                {
                                                    ContinueRound = 0;
                                                    Player1Lables[1] = Player1Lables[1] + 1;
                                                    Player1Lables[2] = 0;
                                                    Player2Lables[2] = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    i = 0;
                                                    j = 0;
                                                    Player1AD[0] = " ";
                                                    Player1AD[1] = " ";
                                                    Player2AD[0] = " ";
                                                    Player2AD[1] = " ";
                                                }

                                            }

                                        }
                                        else
                                        if (ReadKey == ConsoleKey.LeftArrow)
                                        {
                                            j++;
                                            Player2AD[j - 1] = "Ad";
                                            if (j == 2)
                                            {
                                                if (i == 0)
                                                {
                                                    ContinueRound = 0;
                                                    Player2Lables[1] = Player2Lables[1] + 1;
                                                    Player1Lables[2] = 0;
                                                    Player2Lables[2] = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    i = 0;
                                                    j = 0;
                                                    Player1AD[0] = " ";
                                                    Player1AD[1] = " ";
                                                    Player2AD[0] = " ";
                                                    Player2AD[1] = " ";
                                                }

                                            }



                                        }
                                    }

                                    Console.WriteLine($" {Player1AD[0]} ,{Player1AD[1]}");
                                    Console.WriteLine($" {Player2AD[0]} ,{Player2AD[1]} ");
                                }
                            }
                        }
                        else
                          if (ReadKey == ConsoleKey.LeftArrow)
                        {
                            if (Player2NoPoint == 1 || Player2NoPoint == 2)
                            {
                                Player2Lables[2] += 15;
                                Player2NoPoint++;
                            }
                            else
                                if (Player2NoPoint == 3)
                            {
                                Player2Lables[2] += 10;
                                Player2NoPoint++;
                            }
                            else
                           if (RoundIndex == 4)
                            {
                                if (Player1Lables[2] != 40)
                                {
                                    ContinueRound = 0;
                                    Player2Lables[1] = Player2Lables[1] + 1;
                                    Player2Lables[2] = 0;
                                    Player1Lables[2] = 0;
                                    break;
                                }
                                else
                                {

                                    int i = 0; int j = 0;
                                    while (i < 2 && j < 2)
                                    {
                                        ReadKey = Console.ReadKey().Key;
                                        if (ReadKey == ConsoleKey.RightArrow)
                                        {
                                            i++;
                                            Player1AD[i - 1] = "Ad";

                                            if (i == 2)
                                            {
                                                if (j == 0)
                                                {
                                                    ContinueRound = 0;
                                                    Player1Lables[1] = Player1Lables[1] + 1;
                                                    Player1Lables[2] = 0;
                                                    Player2Lables[2] = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    i = 0;
                                                    j = 0;
                                                    Player1AD[0] = " ";
                                                    Player1AD[1] = " ";
                                                    Player2AD[0] = " ";
                                                    Player2AD[1] = " ";
                                                }

                                            }

                                        }
                                        else
                                        if (ReadKey == ConsoleKey.LeftArrow)
                                        {
                                            j++;
                                            Player2AD[j - 1] = "Ad";
                                            if (j == 2)
                                            {
                                                if (i == 0)
                                                {
                                                    ContinueRound = 0;
                                                    Player2Lables[1] = Player2Lables[1] + 1;
                                                    Player2Lables[2] = 0;
                                                    Player1Lables[2] = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    i = 0;
                                                    j = 0;
                                                    Player1AD[0] = " ";
                                                    Player1AD[1] = " ";
                                                    Player2AD[0] = " ";
                                                    Player2AD[1] = " ";
                                                }

                                            }



                                        }
                                    }

                                    Console.WriteLine($" {Player1AD[0]} ,{Player1AD[1]}");
                                    Console.WriteLine($" {Player2AD[0]} ,{Player2AD[1]} ");
                                }

                            }
                            else 
                            {
                                if (Player1Lables[2] != 40)
                                {
                                    ContinueRound = 0;
                                    Player2Lables[1] = Player2Lables[1] + 1;
                                    Player2Lables[2] = 0;
                                    Player1Lables[2] = 0;
                                    break;
                                }
                                else
                                {

                                    int i = 0; int j = 0;
                                    while (i < 2 && j < 2)
                                    {
                                        ReadKey = Console.ReadKey().Key;
                                        if (ReadKey == ConsoleKey.RightArrow)
                                        {
                                            i++;
                                            Player1AD[i - 1] = "Ad";

                                            if (i == 2)
                                            {
                                                if (j == 0)
                                                {
                                                    ContinueRound = 0;
                                                    Player1Lables[1] = Player1Lables[1] + 1;
                                                    Player1Lables[2] = 0;
                                                    Player2Lables[2] = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    i = 0;
                                                    j = 0;
                                                    Player1AD[0] = " ";
                                                    Player1AD[1] = " ";
                                                    Player2AD[0] = " ";
                                                    Player2AD[1] = " ";
                                                }

                                            }

                                        }
                                        else
                                        if (ReadKey == ConsoleKey.LeftArrow)
                                        {
                                            j++;
                                            Player2AD[j - 1] = "Ad";
                                            if (j == 2)
                                            {
                                                if (i == 0)
                                                {
                                                    ContinueRound = 0;
                                                    Player2Lables[1] = Player2Lables[1] + 1;
                                                    Player2Lables[2] = 0;
                                                    Player1Lables[2] = 0;
                                                    break;
                                                }
                                                else
                                                {
                                                    i = 0;
                                                    j = 0;
                                                    Player1AD[0] = " ";
                                                    Player1AD[1] = " ";
                                                    Player2AD[0] = " ";
                                                    Player2AD[1] = " ";
                                                }

                                            }



                                        }
                                    }

                                    Console.WriteLine($" player1 :{Player1AD[0]} ,{Player1AD[1]}");
                                    Console.WriteLine($" Player2 :{Player2AD[0]} ,{Player2AD[1]} ");
                                }

                            }

                        }

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;

                       
                            msg = $"------------------------";
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                           
                            msg = $"           Set     Game     Round       ";
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                            
                            msg = $"  {player1} ::   {Player1Lables[0]}        {Player1Lables[1]}       {Player1Lables[2]}";
                            Console.WriteLine("{0," + (((Console.WindowWidth / 2) + msg.Length / 2) -4) + "}", msg);
                         
                            Console.WriteLine();
                           
                            msg = $"  {player2} ::   {Player2Lables[0]}        {Player2Lables[1]}       {Player2Lables[2]}";
                            Console.WriteLine("{0," + (((Console.WindowWidth / 2) + msg.Length / 2) - 4) + "}", msg);
                           
                            msg = $"------------------------";
                            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);



                        }//EndOfRound Loop
                    Console.WriteLine("End Round");

                    if ((Player1Lables[1] + Player2Lables[1]) >= 6 && Math.Abs(Player1Lables[1] - Player2Lables[1]) >= 2)
                    {
                        IsGameFinished = 1;
                        if (Player1Lables[1] > Player2Lables[1])
                        {
                              

                                Player1Lables[0] = Player1Lables[0] + 1;
                             
                        }
                        else
                       if(Player2Lables[1]> Player1Lables[1])
                        {
                             

                                Player2Lables[0] = Player2Lables[0] + 1;
                            

                            }
                        }
                }// EndOfGames
                //Console.WriteLine("End Game");
                set++;
            }//EndOfSet
             //Console.WriteLine("End Set");


                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;

                
                msg = $"------------------------";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                
                msg = $"           Set     Game     Round       ";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
               
                
                msg = $"  {player1} ::   {Player1Lables[0]}        {Player1Lables[1]}       {Player1Lables[2]}";
                Console.WriteLine("{0," + (((Console.WindowWidth / 2) + msg.Length / 2) - 4) + "}", msg);
                
               
                Console.WriteLine();
               
                msg = $"  {player2} ::   {Player2Lables[0]}        {Player2Lables[1]}       {Player2Lables[2]}";
                Console.WriteLine("{0," + (((Console.WindowWidth / 2) + msg.Length / 2) - 4) + "}", msg);
               
                msg = $"------------------------";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);

                if(Player1Lables[0]>Player2Lables[0])
                {
                    msg = $"{player1}  Win The Match ";
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                }
                else
                {
                    msg = $"{player2}  Win The Match ";
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                }

                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                    msg = $"Press a key to Terminate the Game ";
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
              
                Console.ReadKey();
            }


    }
}
}

