using System;
using System.Threading;

namespace VirtualPet
{

    public enum AppState
    {
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
        AppState appState = AppState.Running;
        Counter counter = new Counter(1000);
        public int delayms = 1;
        Pet pet1 = new Cat (50, 50, 50, 50, 50, 17);
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
            pet1.Initialise();
            
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
                    case ConsoleKey.R: Initialise();
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

        private void handleMenu(int option)
        {
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
            IPetItem item = player.Take(option);
            pet1.Feed(item);
            pet1.Play(item);
            pet1.Medicate(item);
            appState = AppState.Running;
        }

        public void Update()
        {
            
            pet1.Update();
            //player.Update();
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
