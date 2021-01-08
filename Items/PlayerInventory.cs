using System;
using System.Collections.Generic;

namespace VirtualPet
{
    class PlayerInventory : Inventory
    {
        public int Money{get; set;}

        public PlayerInventory(int cash)
        {
            Money = cash;

        }

        public void Update()
        {
            Money++;

            List<IPetItem> newItems = new List<IPetItem>();
            foreach (IPetItem item in Items)
            {
                if (item.Uses > 0)
                {
                    newItems.Add(item);
                }
            }
            Items = newItems;
        }

        public void Purchase(IPetItem item)
        {
            Money -= item.Price;
            Items.Add (item.Clone());
        }


    }
}