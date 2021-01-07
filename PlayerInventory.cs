using System;

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
        }

        public void Purchase(IPetItem item)
        {
            Money -= item.Price;
            Items.Add (item);
        }


    }
}