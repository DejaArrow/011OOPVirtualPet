using System;

namespace VirtualPet
{
    class CatToy : Item, IToy
    {
        public CatToy() : base( "Laser Pointer", 7, "Elusive Red Dot", 20, 15)
        {
           
        }

        public int ToyValue
        {
           get{return this.Value;}
           set{this.Value = value;}     
        }
    }
}