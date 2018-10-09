using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_temp
{
    class CodeTemp
    {
        static void Main(string[] args)
        {


            int PointPlayer1 = 0;
            int PointPlayer2 = 0;
            bool IsScored = false;
            int Set = 1;
            // int[] totalset =new int[5];
            int GameNum = 1;
            int GamePlayer1 = 0;
            int GamePlayer2 = 0;
            int GameDif = 0;
            int AdPlayer1 = 0;
            int AdPlayer2 = 0;
            int round = 1;
            int RoundPointP1 = 1;
            int RoundPointP2 = 1;
            bool IsNextGame = false;
            int[] Result = new int[7];
            while (Set <= 5)
            {
                GameNum = 1;
                Console.WriteLine($"Set:{Set}");
                while (GameNum <= 6 /*&& GameDif==2*/)
                {
                    IsNextGame = false;
                    round = 1;
                    PointPlayer1 = 0;
                    PointPlayer2 = 0;
                    AdPlayer1 = 0;
                    AdPlayer2 = 0;
                    Console.WriteLine($"gamenum:{GameNum}");
                    while ((RoundPointP1 < 5 && RoundPointP2 < 5) || IsNextGame == false)
                    {
                        Console.WriteLine($"round = {round}");

                        Console.WriteLine($"iSNESTGAME{IsNextGame}");

                        //  Thread.Sleep(2000);


                        while (IsScored == false)
                        {

                            //diagnos entered key
                            var ReadKey = Console.ReadKey().Key;

                            if (ReadKey == ConsoleKey.RightArrow)
                            {
                                if (RoundPointP1 == 1 || RoundPointP1 == 2)
                                    PointPlayer1 += 15;
                                else
                                            if (RoundPointP1 == 3)
                                    PointPlayer1 += 10;
                                /* else
                                                 if (round == 4)
                                     PointPlayer1 += 10;*/

                                IsScored = true;
                                AdPlayer1++;
                                RoundPointP1++;
                                //break;

                            }
                            else
                                if (ReadKey == ConsoleKey.LeftArrow)
                            {
                                if (RoundPointP2 == 1 || RoundPointP2 == 2)
                                    PointPlayer2 += 15;
                                else
                                    if (RoundPointP2 == 3)
                                    PointPlayer2 += 10;
                                /*      else
                                              if (round == 4)
                                          PointPlayer2 += 10;*/

                                AdPlayer2++;
                                IsScored = true;
                                RoundPointP2++;
                                //break;
                            }




                            /*switch (ReadKey)
                           {
                               case ConsoleKey.RightArrow:

                                       if (round == 1 || round == 2)
                                           PointPlayer1 = 15;
                                       else
                                           if (round == 3)
                                           PointPlayer1 = 30;
                                       else
                                               if (round == 4)
                                           PointPlayer1 = 40;

                                       IsScored = true;
                                       AdPlayer1++;
                                       break;

                               case ConsoleKey.LeftArrow:

                                   if (round == 1 || round == 2)
                                       PointPlayer2 = 15;
                                   else
                                    if (round == 3)
                                       PointPlayer2 = 30;
                                   else
                                        if (round == 4)
                                       PointPlayer2 = 30;

                                   AdPlayer2++;
                                   IsScored = true;
                                   break;

                               default:
                                   continue; ///????????????
                           }*/


                        }
                        Console.WriteLine($"Is scored = {IsScored}");

                        Console.WriteLine($"Point Player1 :{PointPlayer1} , Ad : {AdPlayer1} ,RoundPointP : {RoundPointP1}");

                        Console.WriteLine($"Point Player2 :{PointPlayer2} , Ad : {AdPlayer2} , RoundPOintP : {RoundPointP2}");

                        if (IsScored)
                        {
                            round++;
                            IsScored = false;
                            if (AdPlayer2 - AdPlayer1 == 2)
                            {
                                IsNextGame = true;
                                GamePlayer1++;
                                GameDif = GamePlayer2 - GamePlayer1;
                                Console.WriteLine($"is scored:  {IsScored} , gamrdif :{GameDif}");
                            }
                            if (AdPlayer2 - AdPlayer1 == 2)
                            {
                                IsNextGame = true;
                                GamePlayer2++;
                                GameDif = GamePlayer1 - GamePlayer2;
                            }

                        }
                    }


                    GameNum++;

                }



                Set++;
            }




        }
    }
}











==============================================


    


                    if (Player1Lables[2] == 40)
                    {
                        ReadKey = Console.ReadKey().Key;
                        if (ReadKey == ConsoleKey.RightArrow)
                        {
                            ContinueRound = 0;
                            Player1Lables[1] += 1;
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
                        }


                         if (Player2Lables[2] == 40)
                               {
                                   while (AdPlayer1 < 2 || AdPlayer2 < 2)
                                   {
                                       ReadKey = Console.ReadKey().Key;
                                       if (ReadKey == ConsoleKey.RightArrow)
                                       {
                                           AdPlayer1++;
                                       }
                                       else
                                        if (ReadKey == ConsoleKey.LeftArrow)
                                       {
                                           AdPlayer2++;
                                       }
                                   }
                            if (AdPlayer1 == 2)
                            {
                                ContinueRound = 0;
                                Player1Lables[1] += 1;
                            }
                            else
                         if (AdPlayer2 == 2)
                            {
                                ContinueRound = 0;
                                Player2Lables[1] += 1;
                            }
                        }




                    }





                    if (Player2Lables[2] == 40)
                    {
                    
                        ReadKey = Console.ReadKey().Key;
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

                            if (Player1Lables[2] == 40)
                            {
                                while (AdPlayer1 < 2 || AdPlayer2 < 2)
                                {
                                    Console.WriteLine($"AdPlayer1 : {AdPlayer1} , AdPlayer2 : {AdPlayer2}");
                                    ReadKey = Console.ReadKey().Key;
                                    if (ReadKey == ConsoleKey.RightArrow)
                                    {
                                        AdPlayer1++;
                                    }
                                    else
                                     if (ReadKey == ConsoleKey.LeftArrow)
                                    {
                                        AdPlayer2++;
                                    }
                                }
                                if (AdPlayer1 == 2)
                                {
                                    ContinueRound = 0;
                                    Player1Lables[1] += 1;
                                }
                                else
                                 if (AdPlayer2 == 2)
                                {
                                    ContinueRound = 0;
                                    Player2Lables[1] += 1;
                                }
                            }
                         }

                            else
                         if (ReadKey == ConsoleKey.LeftArrow)
                            {
                                ContinueRound = 0;
                                Player2Lables[1] += 1;
                            }
                        }
