using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{       
    public class Game : IGame
    {                  
        public IPlayer Player1 { get; set; }       
        
        public IPlayer Player2 { get; set; }

        /*         
         @ pre: amount of rounds: rounds > 0
         @ code: players choose their weapons 
         @ post: get the rounds winner if pyayer has won       
        */        
        public void Start(int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                Player1.MakeChoice();
                Player2.MakeChoice();
                GetRoundsWinner();
            }
        }

        /*         
         @ pre: players make their Choise of weapon
         @ code: finds a winner of the current round
         @ post: shows a draw or one of players has won       
        */       
        private void GetRoundsWinner()
        {
            if (Player1.Choice != Player2.Choice)
            {
                if ((Player1.Choice < Player2.Choice && Player2.Choice - Player1.Choice == 2) || (Player1.Choice == (Weapon)2 && Player2.Choice == (Weapon)1))
                {
                    Player1.RoundsWon++;
                    Console.WriteLine(" "+Player1.Name + " - have won the current game!");
                }
                else
                {
                    Player2.RoundsWon++;
                    Console.WriteLine(" "+Player2.Name + " - have won the current game!");
                }
            }
            else Console.WriteLine(" - Draw - ");
            Console.WriteLine();
        }

        /*
         @ pre: amount of rounds should be equal to 5
         @ code: finds a winner of a game, if nobody won then plays one round more
         @ post: get the game winner with number of points   
        */        
        public void GetWinner(int roundsPlayed)
        {
            if (Player1.RoundsWon == Player2.RoundsWon && Player2.RoundsWon == 0)
            {
                var draw = true;
                while (draw)
                {
                    int round = 1;
                    Console.WriteLine(string.Format(" {0} rounds nobody won. You have to play one round more!!! ", roundsPlayed));
                    Console.WriteLine();
                    Start(round);
                    roundsPlayed++;
                    if (Player1.RoundsWon != Player2.RoundsWon)
                        draw = false;
                }
            }
            if (Player1.RoundsWon == Player2.RoundsWon)
                Console.WriteLine(string.Format(" Draw. You both have won {0} rounds ", Player2.RoundsWon));
            else if (Player1.RoundsWon > Player2.RoundsWon)
            {
                Player1.GamesWon++;
                Console.WriteLine(" "+Player1.Name + " have won the game with " + Player1.RoundsWon + " points!");
            }
            else
            {
                Player2.GamesWon++;
                Console.WriteLine(" "+Player2.Name + " have won the game with " + Player2.RoundsWon + " points!");
            }
            Console.WriteLine();
        }
    }
}
