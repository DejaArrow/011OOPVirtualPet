using System;

namespace VirtualPet
{
    class CatToy : Item, IToy
    {
        public CatToy(string name, int price, string description, int value, int uses) : base(name, price, description, value, uses)
        {
           
        }

        public int ToyValue
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