using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public interface IGame
    {        
        IPlayer Player1 { get; set; }
        
        IPlayer Player2 { get; set; }
        
        void Start(int rounds);
       
        void GetWinner(int roundsPlayed);
    }
}
