using System.Collections.Generic;
using FreeezeDotNet.Model;
using System.Linq;
using FreeezeDotNet.ViewModel;

namespace FreeezeDotNet.Repository
{

    public class FreezerListRepository
    {
        private List<Freezer> _freezerList;
        public FreezerListRepository()
        {
            _freezerList = new List<Freezer>();
            _freezerList.Add(new Freezer("Freezer Cucina UP", "Cucina UP", 1));
            _freezerList.Add(new Freezer("Freezer Cucina PT", "Cucina PT", 2));
            _freezerList.Add(new Freezer("Freezer Cantina", "Cantina", 3));
        }
        public List<Freezer> GetAll()
        {
            return _freezerList;
        }
        public Freezer GetById(int id)
        {
            return _freezerList.FirstOrDefault(a => a.Id == id);
        }
        public string VerifyFood(FormViewModel newFood)
        {
            if (_freezerList.Where(a => a.Id == newFood.Freezer).Count() > 0)
            {
                var chosenFreezer = _freezerList.FirstOrDefault(a => a.Id == newFood.Freezer);
                if (chosenFreezer.drawers.Where(a => a.Id == newFood.Drawer).Count() > 0)
                {
                    var chosenDrawer = chosenFreezer.drawers.FirstOrDefault(a => a.Id == newFood.Drawer);
                    if ((newFood.Type == FoodTypeEnum.Pesce || newFood.Type == FoodTypeEnum.Carne || newFood.Type == FoodTypeEnum.Legumi || newFood.Type == FoodTypeEnum.Verdura) && newFood.Portion == FoodPortionEnum.None)
                    {
                        return "error";
                    }
                    else
                    {
                        chosenDrawer.DrawerFood.Add(new Food() { Name = newFood.Name, Type = newFood.Type, Portion = newFood.Portion, Notes = newFood.Notes });
                        return "insert";
                    }
                }
                else
                    return "drawererror";
            }
            else
                return "freezererror";

        }
        public List<Freezer> CreateListByType(string type, FoodTypeEnum typeEnum)
        {
                //creazione lista filtrata
                var filteredList = new List<Freezer>();
                SearchFrUpByType(_freezerList[0], ref filteredList, type, typeEnum);
                SearchFrPtByType(_freezerList[1], ref filteredList, type, typeEnum);
                SearchFrCantByType(_freezerList[2], ref filteredList, type, typeEnum);

                return filteredList;
        }
        
        // functions creazione lista con solo alimenti del tipo richiesto foreach freezer
         public void SearchFrUpByType(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodTypeEnum typeEnum)
            {
                currentList.Add(new Freezer("Freezer Cucina UP - " + type, "Cucina UP", 1));
                if (currentFreezer.drawers[0].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[0].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[0].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                        }
                    }
                }
                if (currentFreezer.drawers[1].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[1].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[0].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                        }
                    }
                }

                if (currentFreezer.drawers[2].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[2].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[0].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                        }
                    }
                }
            }
    
            private void SearchFrPtByType(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodTypeEnum typeEnum)
            {
                currentList.Add(new Freezer("Freezer Cucina PT - " + type, "Cucina PT", 2));
                if (currentFreezer.drawers[0].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[0].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[1].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                        }
                    }
                }
                if (currentFreezer.drawers[1].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[1].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[1].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                        }
                    }
                }

                if (currentFreezer.drawers[2].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[2].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[1].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                        }
                    }
                }
            }

            private void SearchFrCantByType(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodTypeEnum typeEnum)
            {
                currentList.Add(new Freezer("Freezer Cantina - " + type, "Cantina", 3));
                if (currentFreezer.drawers[0].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[0].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[2].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                        }
                    }
                }
                if (currentFreezer.drawers[1].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[1].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[2].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                        }
                    }
                }
                if (currentFreezer.drawers[2].DrawerFood.Count > 0)
                {
                    for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
                    {
                        if (currentFreezer.drawers[2].DrawerFood[i].Type == typeEnum)
                        {
                            currentList[2].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                        }
                    }
                }
            }

            
    }


}