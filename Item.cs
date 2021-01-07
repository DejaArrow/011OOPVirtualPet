using System;

namespace VirtualPet
{
    class Item : IPetItem
    {
        
        public string Name {get; set;}

        public int Price {get; set;}

        public string Description {get; set;}

        public int Value {get; set;}

        public int Uses {get; set;}

        

        public Item (string name, int price, string description, int value, int uses) {
            Name = name;
            Price = price;
            Description = description;
            Value = value;
            Uses = uses;
        }
    }
    
}