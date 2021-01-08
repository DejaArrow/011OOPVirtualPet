namespace VirtualPet
{
    class Rat : Pet 
    {
       public override string species{get {return "Rat";
       } 
       }

        
        public Rat ( double hunger, double mood, double health, double cleanliness, double energy, double prefTemp, Room room) : base(hunger, mood, health, cleanliness, energy, prefTemp, room)
        {
            
        }
    }
}