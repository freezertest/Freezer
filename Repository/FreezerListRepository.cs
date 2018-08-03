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
            if (_freezerList.Where(a => a.Id == newFood.Freezer).Count() <= 0)
                return "freezererror";
            else
            {
                var chosenFreezer = _freezerList.FirstOrDefault(a => a.Id == newFood.Freezer);
                if (chosenFreezer.drawers.Where(a => a.Id == newFood.Drawer).Count() <= 0)
                    return "drawererror";
                else
                
                    if ((newFood.Type == FoodTypeEnum.Pesce || newFood.Type == FoodTypeEnum.Carne || newFood.Type == FoodTypeEnum.Legumi || newFood.Type == FoodTypeEnum.Verdura) && newFood.Portion == FoodPortionEnum.None)
                        return "error";
                    
                    var chosenDrawer = chosenFreezer.drawers.FirstOrDefault(a => a.Id == newFood.Drawer);
                    chosenDrawer.DrawerFood.Add(new Food() { Name = newFood.Name, Type = newFood.Type, Portion = newFood.Portion, Notes = newFood.Notes });
                    return "insert";

                
            }

        }
        public List<Freezer> CreateListByType(string type, FoodTypeEnum typeEnum)
        {
            //creazione lista filtrata
            var filteredList = new List<Freezer>();
            SearchFrUpBySearchTerm(_freezerList[0], ref filteredList, type, typeEnum);
            SearchFrPtBySearchTerm(_freezerList[1], ref filteredList, type, typeEnum);
            SearchFrCantBySearchTerm(_freezerList[2], ref filteredList, type, typeEnum);

            return filteredList;
        }
        public List<Freezer> CreateListByPortion(string portion, FoodPortionEnum portionEnum)
        {
            //creazione lista filtrata
            var filteredList = new List<Freezer>();
            SearchFrUpBySearchTerm(_freezerList[0], ref filteredList, portion, portionEnum);
            SearchFrPtBySearchTerm(_freezerList[1], ref filteredList, portion, portionEnum);
            SearchFrCantBySearchTerm(_freezerList[2], ref filteredList, portion, portionEnum);

            return filteredList;
        }

        // functions creazione lista con solo alimenti del TIPO richiesto foreach freezer
        public void SearchFrUpBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodTypeEnum typeEnum)
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

        private void SearchFrPtBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodTypeEnum typeEnum)
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

        private void SearchFrCantBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodTypeEnum typeEnum)
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

        //functions creazione lista con solo alimenti con la PORZIONE richiesta foreach freezer
        private List<Freezer> SearchFrUpBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string portion, FoodPortionEnum portionEnum)
        {
            currentList.Add(new Freezer("Freezer Cucina UP - " + portion, "Cucina UP", 1));
            if (currentFreezer.drawers[0].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[0].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[0].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                    }
                }
            }
            if (currentFreezer.drawers[1].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[1].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[0].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                    }
                }
            }

            if (currentFreezer.drawers[2].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[2].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[0].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                    }
                }
            }
            return currentList;
        }
        private List<Freezer> SearchFrPtBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string portion, FoodPortionEnum portionEnum)
        {
            currentList.Add(new Freezer("Freezer Cucina PT - " + portion, "Cucina PT", 1));
            if (currentFreezer.drawers[0].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[0].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[1].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                    }
                }
            }
            if (currentFreezer.drawers[1].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[1].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[1].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                    }
                }
            }

            if (currentFreezer.drawers[2].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[2].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[1].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                    }
                }
            }
            return currentList;
        }
        private List<Freezer> SearchFrCantBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string portion, FoodPortionEnum portionEnum)
        {
            currentList.Add(new Freezer("Freezer Cucina UP - " + portion, "Cucina UP", 1));
            if (currentFreezer.drawers[0].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[0].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[0].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                    }
                }
            }
            if (currentFreezer.drawers[1].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[1].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[0].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                    }
                }
            }

            if (currentFreezer.drawers[2].DrawerFood.Count > 0)
            {
                for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
                {
                    if (currentFreezer.drawers[2].DrawerFood[i].Portion == portionEnum)
                    {
                        currentList[0].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                    }
                }
            }
            return currentList;
        }
    }


}