using System;

namespace VirtualPet
{
    class Counter : RealTimeComponent
    {
        int startCount;
        int count;
        bool active = true;
        public int TickSpeed { get; set; }

        public Counter(int startValue)
        {
            startCount = startValue;
        }

       

        public void Initialise()
        {
            TickSpeed = 1;
            count = startCount;
        }

        public void Update()
        {
            if (count > 0)
            {
                count -= TickSpeed;
            }
            else
            {
                active = false;
            }
        }
    }
}