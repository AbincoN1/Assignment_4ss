using System;
using System.Collections.Generic;
using System.Text;
namespace Assignment_4ss
{
    class Program
    {
        private static void Main(string[] args)
        {
            InitGame();
        }


        public static void InitGame()
        {
            Console.Clear();

            Console.WriteLine("1 = About The Author");
            Console.WriteLine("2 = exit");
            Console.WriteLine("3 = Start the Game");

            string choose = Console.ReadLine();

            if (choose == "3")
            {

                return; ;
            }
            else if (choose == "1")
            {
                Author.DisplayAuthorInfo();
                return;
            }
            else if (choose == "2")
            {
                QuitGame.Exit();
                return;
            }
        }
    }
    class Author
    {

        public static void DisplayAuthorInfo()
        {
            Console.Clear();

            Console.WriteLine("AbincoN1 is 20 years old and making Amazing games :D :)");



            Console.WriteLine("Enter 'M' get back to the Main Menu");

            if (Console.ReadLine().ToLower() == "m")
                Program.InitGame();

        }
        class GameEngine
        {

            private static int gameRound = 0;


            private static int CheckWin(char[] arr)


            {
                if (arr[0] == arr[1] && arr[1] == arr[2])
                {
                    return 1;
                }
                else if (arr[3] == arr[4] && arr[4] == arr[5])
                {
                    return 1;
                }
                else if (arr[6] == arr[7] && arr[7] == arr[8])
                {
                    return 1;
                }
                else if (arr[0] == arr[3] && arr[3] == arr[6])
                {
                    return 1;
                }
                else if (arr[1] == arr[4] && arr[4] == arr[7])
                {
                    return 1;
                }
                else if (arr[2] == arr[5] && arr[5] == arr[8])
                {
                    return 1;
                }
                else if (arr[0] == arr[4] && arr[4] == arr[8])
                {
                    return 1;
                }
                else if (arr[2] == arr[4] && arr[4] == arr[6])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }


            public static void StartGame()
            {

                bool gameStatus = false; gameRound = 0;


                int currentPlayer = 0;


                char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                do
                {

                    Console.Clear();


                    currentPlayer = GetNextPlayer(currentPlayer);


                    HeadsUpDisplay(currentPlayer);


                    DrawGameboard(gameMarkers);


                    PlayEngine(gameMarkers, currentPlayer);


                    gameStatus = isGameOver();

                    int status = CheckWin(gameMarkers);


                    if (status == 1)
                    {
                        Console.Clear();

                        HeadsUpDisplay(currentPlayer);
                        DrawGameboard(gameMarkers);

                        Console.WriteLine("Game Over!");
                        Console.WriteLine("Current player " + currentPlayer + " wins");


                        Console.WriteLine("to go back the main menu, press M");

                        string choose = Console.ReadLine().ToLower();

                        if (choose == "m")
                        {
                            Program.InitGame();
                            return;
                        }

                        return;
                    }

                } while (!gameStatus);

                Console.Clear();

                HeadsUpDisplay(currentPlayer);
                DrawGameboard(gameMarkers);


                if (gameStatus)
                {
                    Console.Clear();
                    HeadsUpDisplay(currentPlayer);
                    DrawGameboard(gameMarkers);

                    Console.WriteLine("Game Over!");
                    Console.WriteLine("The game ended in a draw!");


                    Console.WriteLine("Get back to the main menu, press M");

                    string choose = Console.ReadLine().ToLower();

                    if (choose == "m")
                    {
                        Program.InitGame();
                        return;
                    }

                }
            }


            private static bool isGameOver()
            {
                return gameRound == 9 ? true : false;
            }


            private static void PlayEngine(char[] gameMarkers, int currentPlayer)
            {
                bool notValidMove = true;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out int result) && (result > 0 && result < 10))
                    {
                        char currentMarker = gameMarkers[result - 1];
                        if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                        {
                            Console.WriteLine("Illegal move! Try again.");
                        }
                        else
                        {
                            gameMarkers[result - 1] = GetPlayerMarker(currentPlayer);

                            notValidMove = false;

                            gameRound++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid value!");
                    }
                }
                while (notValidMove);

            }

            private static char GetPlayerMarker(int player)
            {
                if (player % 2 == 0)
                {
                    return 'O';
                }
                return 'X';
            }


            private static int GetNextPlayer(int currentPlayer)
            {
                if (currentPlayer.Equals(1))
                {
                    return 2;
                }

                return 1;
            }

            private static void DrawGameboard(char[] gameMarkers)
            {


                Console.WriteLine("///////////////////");
                Console.WriteLine("// +---+---+---+ //");
                Console.WriteLine($"// | {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} | //");
                Console.WriteLine("// +---+---+---+ //");
                Console.WriteLine($"// | {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} | //");
                Console.WriteLine("// +---+---+---+ //");
                Console.WriteLine($"// | {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} | //");
                Console.WriteLine("// +---+---+---+ //");
                Console.WriteLine("///////////////////");
                Console.WriteLine();

            }

            private static void HeadsUpDisplay(int currentPlayer)
            {


                Console.WriteLine("Welcome to the Tic-Tac-Toe Game!");



                Console.WriteLine("Player 1: X");
                Console.WriteLine("Player 2: O");
                Console.WriteLine();




                Console.WriteLine($"Player {currentPlayer} to move, select 1 through 9 from the game board");
                Console.WriteLine();
            }
        }
    }
    class QuitGame
    {

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Do you really want to exit ? y/Yes, n/No");
            string yesNo = Console.ReadLine().ToLower();

            if (yesNo == "y")
                Console.WriteLine("See You Again");

            if (yesNo == "n") ;



        }
    }
}



