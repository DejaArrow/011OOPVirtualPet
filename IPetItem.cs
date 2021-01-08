using System;

namespace VirtualPet
{
    interface IPetItem
    {
         string Species {get;}

         string Name {get; set;}

         int Price {get; set;}

         string Description {get; set;}

         int Value {get; set;}

         int Uses {get; set;}

         IPetItem Clone();
        
    }


}