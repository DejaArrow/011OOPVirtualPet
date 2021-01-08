using System;

namespace VirtualPet
{
    class CatMedicine: Item, IMedicine
    {   
         public CatMedicine() : base("Cat Medicine", 5, "Heal 'em up!", 50, 1 )
        {
            
        }

        public int MedicineValue
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