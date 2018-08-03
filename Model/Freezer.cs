using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FreeezeDotNet.Model
{
    public class Freezer
    {
        [Key]
        public int Id;
        public string Name;
        public string Location;
        

        public List<Drawer> drawers; //ogni new Freezer() ha una lista dei suoi cassetti
        
        public Freezer(){

        }

        public Freezer(string freezerName, string freezerLocation, int Id)
        { 
            //constructor --> ogni new Freezer() ha la lista con i 3 cassetti
            drawers = new List<Drawer>();
            drawers.Add(new Drawer() { Name = "Cassetto1", Id=1 });
            drawers.Add(new Drawer() { Name = "Cassetto2", Id=2 });
            drawers.Add(new Drawer() { Name = "Cassetto3", Id=3 });
            this.Name = freezerName;
            this.Location = freezerLocation;
            this.Id=Id;
        }
    }

}