
using System.Collections.Generic;
using System.Linq;

namespace FreeezeDotNet.Model
{
    public class Drawer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Food> DrawerFood { get; set; }
        public Freezer Freezer { get; set; }
        public int FreezerId {get;set;}
        public Drawer(){
            DrawerFood= new List<Food>();
        }
    
    }
}