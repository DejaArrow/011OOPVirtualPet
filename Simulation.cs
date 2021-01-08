using System;
using System.Threading;

namespace VirtualPet
{

    public enum AppState
    {
        Begin,
        Running,
        Help,
        Paused,
        Exiting,

       
        Shop,
        Inventory

       


    }

    public enum PlayerAction
    {
        None,
        Feed,
        Play,
        Medicate
        

    }

    class Simulation : RealTimeComponent
    {
        //private bool appRunning = true;
        AppState appState = AppState.Begin;
        Counter counter = new Counter(1000);
        public int delayms = 1;
        Room room = new Room(21);
        Pet pet1;
        PlayerInventory player = new PlayerInventory(20);
        Shop shop = new Shop();

        Menu menu = new Menu();

         PlayerAction optionSelected = PlayerAction.None;

        public Simulation()
        {
          
        }

        public void Run()
        {
            Initialise();

            do
            {
                CheckKeyInput();
                Console.Clear();

                switch (appState)
                {
                    case AppState.Begin:
                    menu.PetMenu();
                    break;
                    case AppState.Running:
                        Update();
                        Display();
                        menu.Display();
                        break;
                    case AppState.Paused:
                        break;
                    case AppState.Inventory:
                        menu.DisplayInventory(player, optionSelected);
                        
                        break;
                    case AppState.Shop:
                        menu.DisplayShop(shop, player);
                        break;    
                    case AppState.Help:
                        menu.DisplayHelp();
                        appState = AppState.Running;
                        break;
                    
                    default:
                        break;
                }
                
                
                Thread.Sleep(1000/delayms);
            } while (appState != AppState.Exiting);
        }

        public void Initialise()
        {
            Console.CursorVisible = false;
            Console.Clear();
            counter.Initialise();
            
            
        }

        public void CheckKeyInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                
              
                switch(keyPressed.Key)
                {

                    case ConsoleKey.Escape: appState = AppState.Exiting;
                    break;
                    case ConsoleKey.R: appState = AppState.Begin;
                    break;
                    case ConsoleKey.H: appState = AppState.Help;
                    break;
                    case ConsoleKey.P: Pause ();
                    break;
                    case ConsoleKey.X : appState = AppState.Running;
                    break;
                }
                
                
                
                
                if (Char.IsNumber(keyPressed.KeyChar))
                {
                    int option = Convert.ToInt32( Char.GetNumericValue(keyPressed.KeyChar));
                    
                    switch (appState)
                    {
                        case AppState.Running: handleMenu(option);
                        break;
                        case AppState.Shop: handleShop(option);
                        break;
                        case AppState.Inventory: handleItem(option);
                        break;
                        case AppState.Begin : handlePetChoice(option);
                        break;


                    }
                }

        

                

            }
        }

        private void Pause()
        {
             if (appState != AppState.Paused)
                    {
                        appState = AppState.Paused;
                    }
                    else if (appState == AppState.Paused)
                    {
                        appState = AppState.Running;
                    }
        }
        private void handlePetChoice(int option)
        {
            try{
            switch (option)
            {
                case 1 : pet1 = new Cat (50, 50, 50, 50, 50, 17, room);
                break;
                case 2 : pet1 = new Rat (25, 50, 50, 50, 50, 19, room);
                break;
            }

            appState = AppState.Running;
            pet1.Initialise();
        }   
             catch (ArgumentOutOfRangeException e) 
            {
                Console.WriteLine("Invalid Option");
            }  
        }
        private void handleMenu(int option)
        {   try{
            switch (option)
            {
                case 1 : appState = AppState.Inventory;
                optionSelected = PlayerAction.Feed;
                break;
                case 2 : appState = AppState.Inventory;
                optionSelected = PlayerAction.Play;
                break;
                case 3 : appState = AppState.Inventory;
                optionSelected = PlayerAction.Medicate;
                break;
                case 4 : appState = AppState.Shop;
                break;
                case 5 : pet1.Clean();
                break;
                case 6 : room.ThermostatUp();
                break;
                case 7 : room.ThermostatDown();
                break;
                
            }
            }catch (ArgumentOutOfRangeException e) 
                {
                    Console.WriteLine("Invalid Option");
                }  
        }

        private void handleShop(int option)
        {
            IPetItem item = shop.Take(option);
            if (item.Price < player.Money)
            {
                player.Purchase(item);
                appState = AppState.Inventory;

            }   
            else
            {
                Console.WriteLine("Not enough money.");
            } 

        }

        private void handleItem(int option)
        {
            try {
            IPetItem item = player.Take(option);
            switch (optionSelected)
            {
                case PlayerAction.Feed:
                pet1.Feed(item);
                break;
                case PlayerAction.Play:
                pet1.Play(item);
                break;
                case PlayerAction.Medicate:
                pet1.Medicate(item);
                break;

            } 
            } catch (ArgumentOutOfRangeException e) 
            {
                Console.WriteLine("Invalid Option");
            }         
            
            appState = AppState.Running;
        }

        public void Update()
        {
            
            pet1.Update();
            player.Update();
            room.Update();
        }

        public void Display()
        {
            
            pet1.Display();
        }

       

        public void Sleep()
        {
            pet1.energy +=50;
        }

        public void Play()
        {
            pet1.mood += 30;
        }

        public void Clean()
        {
            pet1.cleanliness += 50;
        }

        public void Medicine()
        {
            pet1.health += 50;
        }
    }
}
