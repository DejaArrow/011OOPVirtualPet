using System;

namespace VirtualPet
{
    class Room
    {
        const double AMBIENT_TEMP = 18.60;
        
        public double RoomTemp{get; private set;}

            public Room (double currentTemp)
             {
                RoomTemp = currentTemp; 
             }

        public void ThermostatUp()
        {
            RoomTemp += 2;
            
        }

        public void ThermostatDown()
        {
            RoomTemp -= 2;
           
        }

        public void Update()
        {
            if(RoomTemp > AMBIENT_TEMP)
            {
            RoomTemp -= 0.01;
            }
            else
            {
                RoomTemp += 0.01;
            }
        }
    
    }

    
}