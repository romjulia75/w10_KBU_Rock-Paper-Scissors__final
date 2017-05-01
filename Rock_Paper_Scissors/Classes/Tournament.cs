using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{   
    public class Tournament : ITournament
    {        
        public Tournament(int nPlayers)
        {
            NumberOfPlayers = nPlayers;
            ListOfGames = new List<Game>();
            ListOfPlayers = new List<IPlayer>();
            RunGame();
        }        
              
        public List<Game> ListOfGames { get; private set; }        
       
        public List<IPlayer> ListOfPlayers { get; private set; }
        
        public int NumberOfPlayers { get; }

        /*          
         @ pre: ListOfPlayers = 0 && ListOfGames = 0
         @ code: players initialisation; NumberOfPlayers defines ListOfPlayers; ListOfPlayers defines ListOfGames (certain opponents)
         @ post: if NumberOfPlayers = 1, then ListOfPlayers = 2 (new MashinePlayer is created), ListOfGames = 1 (disregarding a draw) 
                 if NumberOfPlayers = 2, then ListOfPlayers = 2, ListOfGames = 1 (disregarding a draw)
                 if NumberOfPlayers = 3, then ListOfPlayers = 3, ListOfGames = 3 (disregarding a draw)
        */
        public void RunGame()
        {
            if (NumberOfPlayers == 1)
            {
                MachinePlayer machinePlayer = new MachinePlayer();
                machinePlayer.SetName(0);
                ListOfPlayers.Add(machinePlayer);
            }

            for (int i = 1; i <= NumberOfPlayers; i++)
            {
                HumanPlayer humanPlayer = new HumanPlayer();
                humanPlayer.SetName(i);
                ListOfPlayers.Add(humanPlayer);
            }
            DefineGames();
        }

        /*          
         @ pre: List<IPlayer> == null
         @ code: determines the winner of the whole tournament
         @ post: winner is determined by the highest score; or nobody won
        */
        public void GetTournaumentWinner()
        {            
            List<IPlayer> ListOfWinners = new List<IPlayer>();

            int max = ListOfPlayers.Max(i => i.GamesWon);
            ListOfWinners.AddRange(ListOfPlayers.Where(x => x.GamesWon == max));

            if (ListOfWinners.Count == 1)
                Console.WriteLine(ListOfWinners.First().Name + " have won the tournament");
            else if (!ListOfWinners.Any())
                Console.WriteLine(" Nobody won the tournament");
            else
            {
                string s = "";
                foreach (var winner in ListOfWinners)
                    s += winner.Name + " and ";
                s = s.Substring(0, s.Length - 3);
                Console.WriteLine(s + " shared winners");
            }
            Console.WriteLine();
        }

        /*          
         @ pre: Game == null
         @ code: defines games that should be played and oppnents in every game
         @ post: games are defined
        */
        private void DefineGames()
        {
            switch (NumberOfPlayers)
            {
                case 1:
                case 2:
                    Game game = new Game();
                    game.Player1 = ListOfPlayers[0];
                    game.Player2 = ListOfPlayers[1];

                    ListOfGames.Add(game);
                    break;
                case 3:
                    for (int i = 0; i < NumberOfPlayers; i++)
                        ListOfGames.Add(new Game { Player1 = ListOfPlayers[i], Player2 = ListOfPlayers[(i + 1) % NumberOfPlayers] });
                    break;
                default: throw new Exception(" More then 3 players have been choosen! The game is under development...");
            }
        }
    }
}
