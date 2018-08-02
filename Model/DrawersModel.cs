
using System.Collections.Generic;
using System.Linq;

namespace FreeezeDotNet.Model{
public class Drawer{
    public string drawerName {get;set;}
    public List<Food> drawerFood;
    public Drawer(){
    drawerFood = new List<Food>();
    }
    public void AddFood(Food CurrentFood){
        drawerFood.Add(CurrentFood);
    }
}
}