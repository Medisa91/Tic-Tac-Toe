using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace Tic_Tac_Toe
{
    class Program
    {

        static void Main(string[] args)
        {
            bool correctSelection = false, winFlag = false, XoGame = true;
            string player1 = "", player2 = "", score1 = "", score2 = "";
            int selection = 0;
            int turn = 1;

            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"../../bin/Debug/data/music/Lost-Jungle.wav";
            soundPlayer.LoadAsync();
            soundPlayer.Play();

            WriteTitle();
            GetNameOfPlayer(out player1, out player2);

            while (XoGame == true)
            {
                while (winFlag == false)
                {
                    DefineXOTabla();
                    Console.WriteLine("");

                    StartTurn(player1, player2, turn);
                    EstablishChoice(ref correctSelection, player1, player2, ref selection, turn);
                    correctSelection = false; // Reset

                    if (turn == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        if (playerPosition[selection] == "X")
                        {
                            Console.WriteLine("This position is not correct. ");
                            Console.Write("Try again.\n");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            playerPosition[selection] = "O";
                        }
                    }
                    if (turn == 2)
                    {
                        if (playerPosition[selection] == "O")
                        {

                            Console.WriteLine("This position is not correct. ");
                            Console.Write("Try again.\n");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            playerPosition[selection] = "X";
                        }
                    }

                    winFlag = CheckWin();
                    turn = ChangeTurn(winFlag, turn);
                }

                Console.Clear();

                DefineXOTabla();

                for (int i = 1; i < 10; i++) // Resets board ------------------------
                {
                    playerPosition[i] = i.ToString();
                }

                if (winFlag == false) // No one won 
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("No one won!");
                    Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                    Console.WriteLine("");
                    Console.WriteLine("What would you like to do now?\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1. Play again\n");
                    Console.WriteLine("2. Leave\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("");

                    while (correctSelection == false)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Enter your option: ");
                        selection = int.Parse(Console.ReadLine());

                        if (selection > 0 && selection < 3)
                        {
                            correctSelection = true;
                        }
                    }

                    correctSelection = false; // Reset

                    switch (selection)
                    {
                        case 1:
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Thanks for XoGame!");
                            Console.ReadLine();
                            XoGame = false;
                            break;
                    }
                }

                if (winFlag == true) // One Player won 
                {
                    if (turn == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        score1 += 1;
                        Console.WriteLine($"{player1} wins!\n");
                        Console.WriteLine("What would you like to do now?\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("1. Play again\n");
                        Console.WriteLine("2. Leave\n");

                        while (correctSelection == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Enter your option: ");
                            selection = int.Parse(Console.ReadLine());

                            if (selection > 0 && selection < 3)
                            {
                                correctSelection = true;
                            }
                        }

                        correctSelection = false;

                        switch (selection)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Thanks for your playing!");
                                Console.ReadLine();
                                XoGame = false;
                                break;
                        }
                    }

                    if (turn == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        score2 += 1;
                        Console.WriteLine($"{player2} wins!\n");
                        Console.WriteLine("What would you like to do now?\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("1. Play again\n");
                        Console.WriteLine("2. Leave Game\n");

                        while (correctSelection == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Enter your option: ");
                            selection = int.Parse(Console.ReadLine());

                            if (selection > 0 && selection < 3)
                            {
                                correctSelection = true;
                            }
                        }

                        correctSelection = false;

                        switch (selection)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Thanks for your playing!");
                                Console.ReadLine();
                                XoGame = false;
                                break;
                        }
                    }
                }
            }
        }

        private static int ChangeTurn(bool winFlag, int turn)
        {
            if (winFlag == false)
            {
                if (turn == 1)
                {
                    turn = 2;
                }
                else if (turn == 2)
                {
                    turn = 1;
                }
                Console.Clear();
            }

            return turn;
        }

        private static void EstablishChoice(ref bool correctSelection, string player1, string player2, ref int selection, int turn)
        {
            while (correctSelection == false)
            {
                if (turn == 1)
                {
                    Console.WriteLine($" {player1} Please choose your desired Position. \n");
                    selection = int.Parse(Console.ReadLine());
                    if (selection > 0 && selection < 10)
                    {
                        correctSelection = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (turn == 2)
                {
                    Console.WriteLine($" {player2} Please choose your desired Position. \n");
                    selection = int.Parse(Console.ReadLine());
                    if (selection > 0 && selection < 10)
                    {
                        correctSelection = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private static void WriteTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"     
 _    _      _                            _____       _____ _____ _____   _____ ___  _____   _____ _____ _____      
| |  | |    | |                          |_   _|     |_   _|_   _/  __ \ |_   _/ _ \/  __ \ |_   _|  _  |  ___|     
| |  | | ___| | ___ ___  _ __ ___   ___    | | ___     | |   | | | /  \/   | |/ /_\ \ /  \/   | | | | | | |__  
| |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \   | |/ _ \    | |   | | | |       | ||  _  | |       | | | | | |  __| 
\  /\  /  __/ | (_| (_) | | | | | |  __/   | | (_) |   | |  _| |_| \__/\   | || | | | \__/\   | | \ \_/ / |___ 
 \/  \/ \___|_|\___\___/|_| |_| |_|\___|   \_/\___/    \_/  \___/ \____/   \_/\_| |_/\____/   \_/  \___/\____/  
                                                                                                                        
                                                                                                                                            
");
            Console.Title = "Tic_Tac_Toe";
            Console.SetCursorPosition(45, 15);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please Wait ...");
            Thread.Sleep(3000);
            Console.Clear();
            Console.CursorVisible = false;

        }

        static string[] playerPosition = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        static void DefineXOTabla()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n            |           |            ");
            Console.WriteLine("            |           |            ");
            Console.WriteLine($"      {playerPosition[1]}     |     {playerPosition[2]}     |     {playerPosition[3]}      ");
            Console.WriteLine("            |           |            ");
            Console.WriteLine("            |           |            ");
            Console.WriteLine("  ---------------------------------");
            Console.WriteLine("            |           |            ");
            Console.WriteLine("            |           |            ");
            Console.WriteLine($"      {playerPosition[4]}     |     {playerPosition[5]}     |     {playerPosition[6]}      ");
            Console.WriteLine("            |           |            ");
            Console.WriteLine("            |           |            ");
            Console.WriteLine("  ---------------------------------");
            Console.WriteLine("            |           |            ");
            Console.WriteLine("            |           |            ");
            Console.WriteLine($"      {playerPosition[7]}     |     {playerPosition[8]}     |     {playerPosition[9]}      ");
            Console.WriteLine("            |           |            ");
            Console.WriteLine("            |           |            \n");
        }

        public static void GetNameOfPlayer(out string player1, out string player2)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("please enter the name of player 1?\n");
            player1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("ok , please enter the name of player 2?\n");
            player2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Very Good,{player1} is O and {player2} is X.\n\n{player1} is the First player.\n\nIf you are ready press any Button...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void StartTurn(string player1, string player2, int turn)
        {
            if (turn == 1)
            {
                Console.WriteLine($" {player1}'s turn");
            }
            if (turn == 2)
            {
                Console.WriteLine($" {player2}'s turn");
            }
        }

        static bool CheckWin()
        {
            if (playerPosition[1] == "O" && playerPosition[2] == "O" && playerPosition[3] == "O") // Horizontal 
            {
                return true;
            }
            else if (playerPosition[4] == "O" && playerPosition[5] == "O" && playerPosition[6] == "O")
            {
                return true;
            }
            else if (playerPosition[7] == "O" && playerPosition[8] == "O" && playerPosition[9] == "O")
            {
                return true;
            }

            else if (playerPosition[1] == "O" && playerPosition[5] == "O" && playerPosition[9] == "O") // Diagonal
            {
                return true;
            }
            else if (playerPosition[7] == "O" && playerPosition[5] == "O" && playerPosition[3] == "O")
            {
                return true;
            }

            else if (playerPosition[1] == "O" && playerPosition[4] == "O" && playerPosition[7] == "O")// Coloumns
            {
                return true;
            }
            else if (playerPosition[2] == "O" && playerPosition[5] == "O" && playerPosition[8] == "O")
            {
                return true;
            }
            else if (playerPosition[3] == "O" && playerPosition[6] == "O" && playerPosition[9] == "O")
            {
                return true;
            }

            if (playerPosition[1] == "X" && playerPosition[2] == "X" && playerPosition[3] == "X") // Horizontal ----------------------------------------
            {
                return true;
            }
            else if (playerPosition[4] == "X" && playerPosition[5] == "X" && playerPosition[6] == "X")
            {
                return true;
            }
            else if (playerPosition[7] == "X" && playerPosition[8] == "X" && playerPosition[9] == "X")
            {
                return true;
            }

            else if (playerPosition[1] == "X" && playerPosition[5] == "X" && playerPosition[9] == "X") // Diagonal 
            {
                return true;
            }
            else if (playerPosition[7] == "X" && playerPosition[5] == "X" && playerPosition[3] == "X")
            {
                return true;
            }

            else if (playerPosition[1] == "X" && playerPosition[4] == "X" && playerPosition[7] == "X") // Coloumns
            {
                return true;
            }
            else if (playerPosition[2] == "X" && playerPosition[5] == "X" && playerPosition[8] == "X")
            {
                return true;
            }
            else if (playerPosition[3] == "X" && playerPosition[6] == "X" && playerPosition[9] == "X")
            {
                return true;
            }
            else // No winner ----------------------------------------------
            {
                return false;
            }
        }
    }
}