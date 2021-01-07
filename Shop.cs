using System;
using System.Collections.Generic;

namespace VirtualPet
{
    class Shop : Inventory
    {      
       public Shop()
       {
           Items.Add(new CatFood());
           Items.Add(new CatToy());
           Items.Add(new CatMedicine());
       }

    }
}