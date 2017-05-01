using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public interface IPlayer
    {                      
        string Name { get; }        
                
        int GamesWon { get; set; }        
             
        int RoundsWon { get; set; }        
           
        Weapon Choice { get; set; }                
        
        void SetName(int number);
             
        void MakeChoice();
    }
}
