using System.Collections.Generic;
using FreeezeDotNet.Model;
using System.Linq;
using FreeezeDotNet.ViewModel;


namespace FreeezeDotNet.Repository
{

    public class FreezerListRepository
    {
        private FreezerContext _db;
        public FreezerListRepository()
        {
            _db= new FreezerContext();
        }
        public List<Freezer> GetAllFreezers()
        {
            return _db.Freezers.ToList();
        }
        public Freezer GetById(int id)
        {
            return _db.Freezers.FirstOrDefault(a => a.Id == id);
        }

        
        
        public List<Freezer> CreateListByPortion(string portion, FoodPortionEnum portionEnum)
        {
            //creazione lista filtrata
            var filteredList = new List<Freezer>();
            SearchFrUpBySearchTerm(_db.Freezers.FirstOrDefault(), ref filteredList, portion, portionEnum);
            SearchFrPtBySearchTerm(_db.Freezers.Skip(1).FirstOrDefault(), ref filteredList, portion, portionEnum);
            SearchFrCantBySearchTerm(_db.Freezers.Skip(2).FirstOrDefault(), ref filteredList, portion, portionEnum);

            return filteredList;
        }

        

        //functions creazione lista con solo alimenti con la PORZIONE richiesta foreach freezer
        private List<Freezer> SearchFrUpBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string portion, FoodPortionEnum portionEnum)
        {
            // currentList.Add(new Freezer("Freezer Cucina UP - " + portion, "Cucina UP", 1));
            // if (currentFreezer.drawers[0].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[0].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[0].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
            //         }
            //     }
            // }
            // if (currentFreezer.drawers[1].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[1].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[0].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
            //         }
            //     }
            // }

            // if (currentFreezer.drawers[2].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[2].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[0].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
            //         }
            //     }
            // }
            // return currentList;
            return new List<Freezer>();
        }
        private List<Freezer> SearchFrPtBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string portion, FoodPortionEnum portionEnum)
        {
            // currentList.Add(new Freezer("Freezer Cucina PT - " + portion, "Cucina PT", 1));
            // if (currentFreezer.drawers[0].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[0].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[1].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
            //         }
            //     }
            // }
            // if (currentFreezer.drawers[1].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[1].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[1].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
            //         }
            //     }
            // }

            // if (currentFreezer.drawers[2].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[2].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[1].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
            //         }
            //     }
            // }
            // return currentList;
            return new List<Freezer>();

        }
        private List<Freezer> SearchFrCantBySearchTerm(Freezer currentFreezer, ref List<Freezer> currentList, string portion, FoodPortionEnum portionEnum)
        {
            // currentList.Add(new Freezer("Freezer Cucina UP - " + portion, "Cucina UP", 1));
            // if (currentFreezer.drawers[0].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[0].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[0].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
            //         }
            //     }
            // }
            // if (currentFreezer.drawers[1].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[1].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[0].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
            //         }
            //     }
            // }

            // if (currentFreezer.drawers[2].DrawerFood.Count > 0)
            // {
            //     for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
            //     {
            //         if (currentFreezer.drawers[2].DrawerFood[i].Portion == portionEnum)
            //         {
            //             currentList[0].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
            //         }
            //     }
            // }
            // return currentList;
            return new List<Freezer>();

        }
    }


}