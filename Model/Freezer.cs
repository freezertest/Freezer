using System.Collections.Generic;
using System.Linq;

namespace Inventory.Model
{
    public class Freezer
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public virtual List<Drawer> Drawers{get;set;}
    }
}