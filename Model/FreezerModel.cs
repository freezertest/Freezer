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
            drawers.Add(new Drawer() { drawerName = "Cassetto1" });
            drawers.Add(new Drawer() { drawerName = "Cassetto2" });
            drawers.Add(new Drawer() { drawerName = "Cassetto3" });
            this.freezerName = freezerName;
            this.freezerLocation = freezerLocation;
            this.Id=Id;
        }
        //funzione di verifica d'esistenza cassetto & verifica tipo
        public string VerifyFood(string currentDrawer, Food currentFood)
        {
            var valore = currentFood.FoodPortion;

            if (drawers.Exists(a => a.drawerName.ToUpper() == currentDrawer.ToUpper()))
            {
                var chosenDrawer = drawers.FirstOrDefault(a => a.drawerName.ToUpper() == currentDrawer.ToUpper());
                if (currentFood.FoodType != FoodTypeEnum.Altro && currentFood.FoodType != FoodTypeEnum.ErbeAromaticheSpezie && currentFood.FoodPortion != FoodPortionEnum.None || (currentFood.FoodType == FoodTypeEnum.ErbeAromaticheSpezie || currentFood.FoodType == FoodTypeEnum.Altro) && currentFood.FoodPortion != FoodPortionEnum.None)
                {
                    chosenDrawer.AddFood(currentFood);
                    return "inserito";
                }
                else
                {
                    return "typeError";
                }
            }
            else
                return "drawerError";
        }


    }

}