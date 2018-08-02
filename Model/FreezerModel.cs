using System.Collections.Generic;
using System.Linq;

namespace FreeezeDotNet.Model
{
    public class Freezer
    {
        public string freezerName;
        public string freezerLocation;
        public int Id;

        public List<Drawer> drawers; //ogni new Freezer() ha una lista dei suoi cassetti
        public Freezer(string freezerName, string freezerLocation, int Id)
        { //constructor --> ogni new Freezer() ha la lista con i 3 cassetti
            drawers = new List<Drawer>();
            drawers.Add(new Drawer() { drawerName = "Cassetto1", Id=1 });
            drawers.Add(new Drawer() { drawerName = "Cassetto2", Id=2 });
            drawers.Add(new Drawer() { drawerName = "Cassetto3", Id=3 });
            this.freezerName = freezerName;
            this.freezerLocation = freezerLocation;
            this.Id=Id;
        }
    }

}