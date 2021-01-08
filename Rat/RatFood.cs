using System;

namespace VirtualPet
{
    class RatFood : Item, IFood 
    {
        public RatFood(string name, int price, string description, int value, int uses) : base(name, price, description, value, uses)
        {
            
        }

        public int FoodValue
        {
           get{return this.Value;}
           set{this.Value = value;}     
        }

         public override string Species
        {
            get{return "Rat";}
        }
    }

    
}