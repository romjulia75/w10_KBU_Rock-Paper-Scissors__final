using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{    
    public class MachinePlayer : IPlayer
    {        
        public string Name { get; private set; }
        
        public Weapon Choice { get; set; }
       
        public int RoundsWon { get; set; }
        
        public int GamesWon { get; set; }

        /*         
         @ pre: not defined name: Name = null; number > 0
         @ code: gives a name to the computer
         @ post: Name = Machine  
        */        
        public void SetName(int number)
        {
            Name = "Machine";
        }

        /*         
         @ pre: MachinePlayer != null
         @ code: MachinePlayer makes a random Choice
         @ post: valid Choice has been choosen
        */        
        void IPlayer.MakeChoice()
        {
            Random randomChoice = new Random();
            this.Choice = (Weapon)randomChoice.Next(1,4);
            Console.WriteLine("Machine have been choosen");
            Console.WriteLine();
        }
    }
}
