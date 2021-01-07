using System;
using VirtualPet;

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

        int startCount;
        int count;
        bool active = true;
        public int TickSpeed { get; set; }

           
        
        public Pet( double hunger, double mood, double health, double cleanliness, double energy, double prefTemp)
        {
            this.hunger = hunger;
            this.mood = mood;
            this.health = health;
            this.cleanliness = cleanliness;
            this.energy = energy;
            this.prefTemp = prefTemp;
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
        }

        public void Update()
        {
            hunger += 1;
            mood -= 1;
            cleanliness -= 1;
            energy -= 1;
            double healthStep = 0.5;
            if (hunger > 70)
            { 
                healthStep +=0.5;
            }
            health -= healthStep;
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


        
    }


}