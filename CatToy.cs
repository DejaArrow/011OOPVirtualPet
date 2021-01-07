using System;

namespace VirtualPet
{
    class CatToy : Item, IToy
    {
        public CatToy() : base("Laser Pointer", 7, "The Elusive Red Dot", 50, 10 )
        {
            
        }

        public int ToyValue
        {
           get{return this.Value;}
           set{this.Value = value;}     
        }
    }
}