using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{   
    public interface ITournament
    {        
        List<Game> ListOfGames { get; }

        List<IPlayer> ListOfPlayers { get; }
        
        int NumberOfPlayers { get; }
        
        void GetTournaumentWinner();        
               
        void RunGame();
    }
}
