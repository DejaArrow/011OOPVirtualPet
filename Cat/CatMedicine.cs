using System;

namespace VirtualPet
{
    class CatMedicine: Item, IMedicine
    {   
         public CatMedicine(string name, int price, string description, int value, int uses) : base(name, price, description, value, uses)
        {
            
        }

        public int MedicineValue
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