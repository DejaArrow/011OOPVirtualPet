using System;

namespace VirtualPet
{
    class Cat : Pet 
    {
       public override string species{get {return "Cat";
       } }

        public void CleanLitterTray()
        {
            Console.WriteLine("Litter Scooped!");
            cleanliness += 50;
        }
        //public override string Speak()
        //    Console.WriteLine("Meow!");
       // }

       public Cat ( double hunger, double mood, double health, double cleanliness, double energy, double prefTemp) : base(hunger, mood, health, cleanliness, energy, prefTemp)
        {
            
        }
    }
}