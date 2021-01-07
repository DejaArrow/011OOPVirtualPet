using System;

namespace VirtualPet
{
    class Cat : Pet 
    {
       public override string species{get {return "Cat";
       } }

        
        //public override string Speak()
        //    Console.WriteLine("Meow!");
       // }

       public Cat ( double hunger, double mood, double health, double cleanliness, double energy, double prefTemp, Room room) : base(hunger, mood, health, cleanliness, energy, prefTemp, room)
        {
            
        }
    }
}