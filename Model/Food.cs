using System.Collections.Generic;
using System.Linq;

namespace FreeezeDotNet.Model
{

    public class Food
    {
        public int Id{get;set;}
        public string Name { get; set; }
        public FoodType Type { get; set; }
        public FoodPortion Portion { get; set; }
        public Drawer Drawer {get;set;}
        public int DrawerId {get;set;}
        public string Notes { get; set; }
        public int TypeId{get;set;}
        public int PortionId{get;set;}
    }


}