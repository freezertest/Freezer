
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Model
{
    public class Drawer
    {
        public int Id { get; set; }
        public int FreezerId {get;set;}
        public string Name { get; set; }
        public virtual Freezer Freezer { get; set; }
        public virtual List<Food> DrawerFood { get; set; }
                    
    }
}