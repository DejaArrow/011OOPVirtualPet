using System;
using System.Collections.Generic;

namespace VirtualPet
{
    class Inventory
    {
        protected List<IPetItem> Items = new List <IPetItem>();

     

        public void Menu()
        {
            if (Items.Count == 0 )
            {
                Console.WriteLine("Inventory is Empty");
            }
            else
            {                
                for(int i = 0; i < Items.Count; i++ )
                {
                    Console.WriteLine($"{i}. {Items[i].Name}, {Items[i].Description}, £{Items[i].Price}, {Items[i].Uses} uses.");
                }
            }

        }

        public IPetItem Take(int index)
        {
            return Items[index];
        }

    }
}