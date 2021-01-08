using System;

namespace VirtualPet
{
    class RatToy : Item, IToy
    {
        public RatToy(string name, int price, string description, int value, int uses) : base(name, price, description, value, uses)
        {
           
        }

        public int ToyValue
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