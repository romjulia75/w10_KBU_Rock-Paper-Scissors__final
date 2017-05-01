using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    class Start
    {
        /*
         @ invariant: defined number of rounds: rounds = 5
         @ pre: amount of players between 1 and 3
         @ code: plays five roudns of the tournament
         @ post: get the tournaments winner       
        */
        public static void StartGame()
        {
            Console.WriteLine("  --- Rock Paper Scissors ---\n");             

            Tournament tournament = new Tournament(GetNumPlayers());
            int rounds = 5;
            foreach (Game game in tournament.ListOfGames)
            {
                Console.WriteLine("\n   Choose your weapon: Rock - 1 | Paper - 2 | Scissors - 3\n");
                game.Player1.RoundsWon = 0;
                game.Player2.RoundsWon = 0;
                game.Start(rounds);
                game.GetWinner(rounds);
            }
            if (tournament.ListOfGames.Count > 1)
            {
                tournament.GetTournaumentWinner();
            }
            Console.WriteLine(" Well done, Master!");
            Music.Beethoven();
        }

        /*
         @ pre: limited amount of players: 1 <= nPlayers <= 3
         @ code: user inputs amount of players
         @ post: returns amount of players between 1 and 3       
        */
        private static int GetNumPlayers()
        {
            bool allowedNumberPlayers = false;
            int nPlayers = 1;
            while (!allowedNumberPlayers)
            {
                Console.Write("   How many players will play?  (0 for Exit): ");
                string input = Console.ReadLine();
                Console.WriteLine();
                
                if (input==0.ToString())
                {
                    Console.WriteLine("   Goodbye...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    
                }
                if (int.TryParse(input, out nPlayers) && nPlayers >= 1 && nPlayers <= 3)
                    allowedNumberPlayers = true;
                else Console.WriteLine(" Invalid number of players!!! Try again! ");
            }
            return nPlayers;
        }
    }
}

