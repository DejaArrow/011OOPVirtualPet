using System;

namespace VirtualPet
{
    class CatFood : Item, IFood 
    {
        public CatFood(string name, int price, string description, int value, int uses) : base(name, price, description, value, uses)
        {
            
        }

        public int FoodValue
        {
           get{return this.Value;}
           set{this.Value = value;}     
        }

         public override string Species
        {
            get{return "Cat";}
        }
    }

    
}