
using System.Collections.Generic;
using System.Linq;

namespace FreeezeDotNet.Model
{
    public class Drawer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Food> DrawerFood;
        public Drawer()
        {
            DrawerFood = new List<Food>();
        }
    }
}