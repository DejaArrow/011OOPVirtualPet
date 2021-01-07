using System;
using System.Threading;

namespace VirtualPet
{
    abstract class Pet : RealTimeComponent
    {
        public abstract string species {get; }

        public double hunger;

        public double mood;

        public double health;

        public double cleanliness;

        public double energy;

        public double prefTemp;

        protected Room room;

        int startCount;
        int count;
        bool active = true;
        public int TickSpeed { get; set; }

           
        
        public Pet( double hunger, double mood, double health, double cleanliness, double energy, double prefTemp, Room room)
        {
            this.hunger = hunger;
            this.mood = mood;
            this.health = health;
            this.cleanliness = cleanliness;
            this.energy = energy;
            this.prefTemp = prefTemp;
            this.room = room;

        }
        public void Initialise()
        {
            TickSpeed = 1;
            count = startCount;
           
        }
        public void Display()
        {
            Console.WriteLine($"{species}");
            Console.WriteLine($"Hunger: {hunger}");
            Console.WriteLine($"Mood: {mood}");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Cleanliness: {cleanliness}");
            Console.WriteLine($"Energy: {energy}");
            Console.WriteLine($"Room is currently {room.RoomTemp} degrees");
        }

        public void Update()
        {
            if( hunger <= 99)
            {
                hunger += 1;
            }

            if (mood > 0)
           {
                mood -= 1;
           }

           if(cleanliness > 0)
           {
            cleanliness -= 1;
           }

           if (energy > 10 )
           {
            energy -= 1;
           }
           else if (health > 0)
           {
               Console.WriteLine("ZzZzZz...");
               Thread.Sleep(2000);
               energy += 70;
           }
                         
           
            if (health > 0)
            {
                double healthStep = 0;
                 if (hunger > 70)
                 {
                     healthStep +=0.5;
                 }

                if (room.RoomTemp < (prefTemp - 2))
                {
                    Console.WriteLine("It's too cold!");
                    healthStep +=0.5;
                }
                else if (room.RoomTemp > (prefTemp +2))
                {
                    Console.WriteLine("It's too hot!");
                    healthStep +=0.5;
                }
                health -= healthStep;
                           
            }

             if(health == 0)
            {
                Die ();
            }
            
                                   
        
            
        }

        

         public void Feed(IPetItem food) 
        {
            if (food is IFood)
            {
                var realFood = (IFood) food;
                hunger -= realFood.FoodValue;

            }
            else{
                Console.WriteLine($"{food.Name} is not edible.");
            }

            food.Uses --;

            
        }
        public void Play(IPetItem toy)
        {
            if (toy is IToy)
            {
                var realToy = (IToy) toy;
                mood += realToy.ToyValue;
            }
            else{
                Console.WriteLine($"{toy.Name} is not a toy.");
            }

            toy.Uses --;
        }

        public void Medicate(IPetItem medicine)
        {
            if (medicine is IMedicine)
            {
                var realMedicine = (IMedicine) medicine;
                health += realMedicine.MedicineValue;
            }
            else{
                Console.WriteLine($"{medicine.Name} will not help.");
            }
        }

        public void Clean()
        {
            Console.WriteLine("Litter Scooped!");
            cleanliness += 50;
        }

        private void Die()
        {
            hunger = 0;
            mood = 0;
            health = 0;
            energy = 0;

            Console.WriteLine("++ Oh no! ++");

        }


        
    }


}