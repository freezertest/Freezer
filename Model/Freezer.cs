using System.Collections.Generic;
using System.Linq;

namespace FreeezeDotNet.Model
{
    public class Freezer
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public virtual List<Drawer> Drawers{get;set;}

        public Freezer(){
            Drawers=new List<Drawer>();
        }
    }
}