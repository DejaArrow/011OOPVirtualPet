using System;
using System.Collections.Generic;

namespace VirtualPet
{
    class Shop : Inventory
    {      
       public Shop()
       {
           Items.Add(new CatFood("Cat Food - Whiskas", 15, "Poulty Selection", 50, 12));
           Items.Add(new RatFood("Rat Food - Science Selective", 10, "Nibble Nutrition", 45, 15));
           Items.Add(new CatToy("Cat Toy - Laser Pointer", 7, "Elusive Red Dot", 20, 15));
           Items.Add(new RatToy("Rat Toy - See-Saw", 10, "Weeee!! ", 25, 5));
           Items.Add(new CatMedicine("Cat Medicine - Premium Care", 10, "Heal 'em up!", 45, 1));
           Items.Add(new RatMedicine("Rat Medicine - Sniffles-be-Gone", 8, "Banana flavour", 45, 2));
       }

    }
}