using System;

namespace VirtualPet
{
    class CatFood : Item, IFood 
    {
        public CatFood() : base("Whiskas", 5, "Poultry Selection", 50, 12 )
        {
            
        }

        public int FoodValue
        {
           get{return this.Value;}
           set{this.Value = value;}     
        }

        public string Species
        {
            get{return "Cat";}
        }
    }

    
}