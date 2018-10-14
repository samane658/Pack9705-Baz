using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BoxDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string again ="y";
            while (again =="y")
            {
                    EnteranceMessage();

                    int X = 0, Y = 0;
                    // DrawTable(13, 5, 3, 3, selectedX: X, selectedY: Y);
                    int tableSize = 3;

                    string[,] players = new string[3, 3] { {"*","*","*"},
                                                           {"*","*","*"},
                                                           {"*","*","*"}};
                    int turn;
                    Random r = new Random();
                    string msg = " ";
                    int toss = r.Next(0, 2);
                    if (toss == 1)
                    {
                        turn = 1;
                         msg = "X must Goes first ";
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                    
                    }
                    else
                    {
                        turn = 0;
                        msg = "O must Goes first ";
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                    
                    }

                    Thread.Sleep(1000);
                    DrawTable(2, 13, 5, 3, 3, selectedX: X, selectedY: Y);
                    int GameNum = 0; int FlageWin = 0;
                    string WhoWin = " ";
                    while (GameNum < 9 && FlageWin == 0)
                    {
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (Y != 0)
                                {
                                    RefreshArray(ref players, tableSize);
                                    Console.Clear();
                                    DrawTable(turn, 13, 5, 3, 3, selectedX: X, selectedY: --Y);
                                    RefreshArray(ref players, tableSize);
                                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                                    {
                                        if (turn == 1)
                                        {
                                            players[Y, X] = "X";
                                            turn = 0;
                                            GameNum++;
                                        }
                                        else
                                        {
                                            players[Y, X] = "O";
                                            turn = 1;
                                            GameNum++;
                                        }
                                        if (GameNum >= 3)
                                        {
                                            FlageWin = HasWinner(out WhoWin, ref players);
                                        }

                                    }



                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (Y != tableSize - 1)
                                {
                                    RefreshArray(ref players, tableSize);
                                    Console.Clear();
                                    DrawTable(turn, 13, 5, 3, 3, selectedX: X, selectedY: ++Y);
                                    RefreshArray(ref players, tableSize);
                                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                                    {
                                        if (turn == 1)
                                        {
                                            players[Y, X] = "X";
                                            turn = 0;
                                            GameNum++;
                                        }
                                        else
                                        {
                                            players[Y, X] = "O";
                                            turn = 1;
                                            GameNum++;
                                        }
                                        if (GameNum >= 3)
                                        {
                                            FlageWin = HasWinner(out WhoWin, ref players);
                                        }

                                    }

                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (X != 0)
                                {
                                    RefreshArray(ref players, tableSize);
                                    Console.Clear();
                                    DrawTable(turn, 13, 5, 3, 3, selectedX: --X, selectedY: Y);
                                    RefreshArray(ref players, tableSize);
                                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                                    {
                                        if (turn == 1)
                                        {
                                            players[Y, X] = "X";
                                            turn = 0;
                                            GameNum++;
                                        }
                                        else
                                        {
                                            players[Y, X] = "O";
                                            turn = 1;
                                            GameNum++;
                                        }
                                        if (GameNum >= 3)
                                        {
                                            FlageWin = HasWinner(out WhoWin, ref players);
                                        }

                                    }


                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (X != tableSize - 1)
                                {
                                    RefreshArray(ref players, tableSize);
                                    Console.Clear();
                                    DrawTable(turn, 13, 5, 3, 3, selectedX: ++X, selectedY: Y);
                                    RefreshArray(ref players, tableSize);
                                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                                    {
                                        if (turn == 1)
                                        {
                                            players[Y, X] = "X";
                                            turn = 0;
                                            GameNum++;
                                        }
                                        else
                                        {
                                            players[Y, X] = "O";
                                            turn = 1;
                                            GameNum++;
                                        }
                                        if (GameNum >= 3)
                                        {
                                            FlageWin = HasWinner(out WhoWin, ref players);
                                        }

                                    }
                                }
                                break;

                        }
                    }

                    Console.Clear();
                
                    RefreshArray(ref players, tableSize);


                    if (FlageWin == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        msg = $" No One Won the Game !!!";
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                    
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        msg = $" {WhoWin} Won the Game !!!";
                        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                    
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    msg = " Play Again ? Ente y for Yes or any key to No";
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                if (/*Console.ReadLine().ToLower() == "Yes" ||*/ Console.ReadLine().ToLower() == "y")
                    again = "y";
                else
                    again ="n";
        }

           // Console.ReadKey();
        }


      

        static void EnteranceMessage()
        {

            do
            {
                Console.Clear();
                string msg = $"We are ganna to Play XO Game .... the Rules are Simple \n" +
                    " 1- Use Arrow Key to Change the Position (Press Them Twice !!!) \n" +
                    " 2- Press Enter to Take a seat on the Position \n" +
                    " Ready?!!!!!!";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                msg = "when Ready Press Enter .";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
                Console.WriteLine();
                Console.WriteLine();
                msg = "Loadin ....";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg);
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            Console.Clear();

        }

        static void DrawBox(int width, 
            int height, 
            int left, 
            int top, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.BackgroundColor = color;
            Console.CursorVisible = false;
            for (int j = 0; j < height; j++)
            {
                Console.SetCursorPosition(left, top++);
                for (int i = 0; i < width; i++)
                {
                    Console.Write(" ");
                }

            }

            Console.BackgroundColor = ConsoleColor.Black;

        }

        static void WriteX(int width,
            int height,
            int left,
            int top, ConsoleColor color = ConsoleColor.Blue)
        {
            //Console.BackgroundColor = color;
           // Console.CursorVisible = false;
            for (int j = 0; j < height; j++)
            {
                Console.SetCursorPosition(left, top++);
                for (int i = 0; i < width; i++)
                {

                    if (i == width / 2 && j == height / 2)
                    {
                        Console.BackgroundColor = color;
                        Console.SetCursorPosition(left + i,top);
                        Console.WriteLine("X");
                    }
                    else
                       
                      Console.Write("");
                    
                }

            }

            Console.BackgroundColor = ConsoleColor.Black;
        }



        static void WriteO(int width,
           int height,
           int left,
           int top, ConsoleColor color = ConsoleColor.Blue)
        {
            //Console.BackgroundColor = color;
            // Console.CursorVisible = false;
            for (int j = 0; j < height; j++)
            {
                Console.SetCursorPosition(left, top++);
                for (int i = 0; i < width; i++)
                {

                    if (i == width / 2 && j == height / 2)
                    {
                        Console.BackgroundColor = color;
                        Console.SetCursorPosition(left + i, top);
                        Console.WriteLine("O");
                    }
                    else

                        Console.Write("");

                }

            }

            Console.BackgroundColor = ConsoleColor.Black;
        }


        static void RefreshArray(ref string[,] array , int size)
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("------------");
                for (int j = 0; j < size; j++)
                {

                    Console.Write($"{array[i, j]}  ");
                    

                }
                Console.WriteLine();
               
            }
        }



        static int HasWinner(out string winner, ref string[,] players)
        {
            if (players[0, 0] == "X" && players[0, 1] == "X" && players[0, 2] == "X")
            {
                winner = "X";
                return 1;
            }
            else
                if (players[1, 0] == "X" && players[1, 1] == "X" && players[1, 2] == "X")
            {
                winner = "X";
                return 1;
            }
            else
                if (players[2, 0] == "X" && players[2, 1] == "X" && players[2, 2] == "X")
            {
                winner = "X";
                return 1;
            }
            else
                 if (players[0, 0] == "X" && players[1, 0] == "X" && players[2, 0] == "X")
            {
                winner = "X";
                return 1;
            }
            else
                 if (players[0, 1] == "X" && players[1, 1] == "X" && players[2, 1] == "X")
            {
                winner = "X";
                return 1;
            }
            else
                if (players[0, 2] == "X" && players[1, 2] == "X" && players[2, 2] == "X")
            {
                winner = "X";
                return 1;
            }
            else
                 if (players[0, 0] == "X" && players[1, 1] == "X" && players[2, 2] == "X")
            {
                winner = "X";
                return 1;
            }
            else
                 if (players[0, 2] == "X" && players[1, 1] == "X" && players[2, 0] == "X")
            {
                winner = "X";
                return 1;
            }
            else
                  if (players[0, 0] == "O" && players[0, 1] == "O" && players[0, 2] == "O")
            {
                winner = "O";
                return 1;
            }
            else
                if (players[1, 0] == "O" && players[1, 1] == "O" && players[1, 2] == "O")
            {
                winner = "O";
                return 1;
            }
            else
                if (players[2, 0] == "O" && players[2, 1] == "O" && players[2, 2] == "O")
            {
                winner = "O";
                return 1;
            }
            else
                 if (players[0, 0] == "O" && players[1, 0] == "O" && players[2, 0] == "O")
            {
                winner = "O";
                return 1;
            }
            else
                 if (players[0, 1] == "O" && players[1, 1] == "O" && players[2, 1] == "O")
            {
                winner = "O";
                return 1;
            }
            else
                if (players[0, 2] == "O" && players[1, 2] == "O" && players[2, 2] == "O")
            {
                winner = "O";
                return 1;
            }
            else
                 if (players[0, 0] == "O" && players[1, 1] == "O" && players[2, 2] == "O")
            {
                winner = "O";
                return 1;
            }
            else
                 if (players[0, 2] == "O" && players[1, 1] == "O" && players[2, 0] == "O")
            {
                winner = "O";
                return 1;
            }
            else
            {
                winner = "No One";
                return 0;
            }




        }
        static void DrawTable(int turn,int cellWidth, 
            int cellHeight, 
            int left, 
            int top, 
            int size = 3, 
            ConsoleColor color = ConsoleColor.White,
            int selectedX = 0,
            int selectedY = 0,
            ConsoleColor selectedColor = ConsoleColor.Yellow)
        {
            var initialLeft = left;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    if (i == selectedY && j == selectedX)
                    {
                        DrawBox(cellWidth, cellHeight, left, top, selectedColor);
                        if(turn == 1)
                         WriteX(cellWidth, cellHeight, left, top, selectedColor);
                        else
                            if(turn==0)
                             WriteO(cellWidth, cellHeight, left, top, selectedColor);
                        
                    }
                    else
                    {
                        DrawBox(cellWidth, cellHeight, left, top, color);

                    }
                    left = left + (cellWidth + 1);
                }
                top = top + (cellHeight + 1);
                left = initialLeft;
            }
        }
    }
}
