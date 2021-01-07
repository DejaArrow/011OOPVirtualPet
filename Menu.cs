using System;
using System.Collections.Generic;


namespace VirtualPet
{
    class Menu
    {
        public void Display()
        {
            Console.WriteLine("\nPlease pick an action.");
            Console.WriteLine("1 - Feed");
            Console.WriteLine("2 - Play");
            Console.WriteLine("3 - Medicate");
            Console.WriteLine("4 - Shop");
            Console.WriteLine("5 - Clean");
            Console.WriteLine("6 - Reset Temperature");
            

        }

        public void DisplayShop(Shop shop, PlayerInventory pl)
        {
            Console.WriteLine("\n---Shop---");
            Console.WriteLine("Please pick an Item to purchase");
            Console.WriteLine($"You have £{pl.Money}");
            shop.Menu();
            Console.WriteLine("Press X to Return");
        }

        public void DisplayInventory(PlayerInventory pl, PlayerAction action)
        {
            Dictionary<PlayerAction, string> optionTerms = new Dictionary<PlayerAction, string>
            {
                {PlayerAction.None, "Use"},
                {PlayerAction.Feed, "Feed"},
                {PlayerAction.Play, "Play with"},
                {PlayerAction.Medicate, "Medicate"}
            };
            
            Console.WriteLine("\n---Inventory---");
            Console.WriteLine($"Please pick an Item to {optionTerms[action]}");
            Console.WriteLine($"You have £{pl.Money}");
            pl.Menu();
            Console.WriteLine("Press X to Return");
        }

        public void DisplayHelp()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Help");
            Console.WriteLine("\n\nPress Any key to Continue \nHopefully this is helpful");
            Console.ReadKey(true);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
        }


    }
}