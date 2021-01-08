using System;
using System.Collections.Generic;

namespace VirtualPet
{
    class Shop : Inventory
    {      
       public Shop()
       {
           Items.Add(new CatFood());
           Items.Add(new CatToy("Laser Pointer", 7, "Elusive Red Dot", 20, 15));
           Items.Add(new CatMedicine());
       }

    }
}