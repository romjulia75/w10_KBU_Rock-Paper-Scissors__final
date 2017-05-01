using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{      
    public class HumanPlayer : IPlayer
    {
        public HumanPlayer()
        {
        }
        public HumanPlayer(string navn)
        {
            Name = navn;
        }        
        public string Name { get; private set; }        
        
        public Weapon Choice { get; set; }
        
        public int RoundsWon { get; set; }
        
        public int GamesWon { get; set; }

        /*         
         @ pre: not defined name: Name = null; number > 0
         @ code: gives a name to the HumanPlayer
         @ post: Name = valid entred name  
        */       
        public void SetName(int number)
        {
            string navn = null;
            while (string.IsNullOrEmpty(navn))
            {
                Console.Write(string.Format(" Player_{0} name: ", number));
                navn = Console.ReadLine();
            }
            this.Name = navn;
        }

        /*         
         @ pre: HumanPlayer != null
         @ code: HumanPlayer makes a valid Choice
         @ post: valid Choice has been choosen
        */        
        void IPlayer.MakeChoice()
        {
            bool allowedInput = false;            
            while (!allowedInput)
            {
                Console.Write(" "+Name +" :");
                ConsoleKeyInfo input = Console.ReadKey(true);                             
                Console.Write(" ");
                int Choice = -1;
                
                if (int.TryParse(input.KeyChar.ToString(),out Choice) && Choice >= 1&&Choice<=3)
                {                  
                      
                    this.Choice = (Weapon)Choice;
                    Console.WriteLine("...");
                    allowedInput = true;                    
                }
                else Console.WriteLine(" - you have entered an invalid value...");
            }
        }
    }
}
