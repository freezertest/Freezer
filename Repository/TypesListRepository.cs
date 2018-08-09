using System.Collections.Generic;
using Inventory.Model;
using System.Linq;
using Inventory.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repository
{

    public class TypesListRepository
    {
        private FreezerContext _db;
        public TypesListRepository()
        {
            _db = new FreezerContext();
        }
        public List<FoodType> GetAllTypes()
        {
            return _db.Types.ToList();
        }

        public List<TypeViewModel> CreateListByType(FoodType type, out string result)
        {
            var filteredTypeList = new List<TypeViewModel>();
            var filteredFoods = _db.Freezers.Include(p=>p.Drawers).ThenInclude(m=>m.DrawerFood.Where(a => a.TypeId == type.Id)).ThenInclude(j=>j.Type).Include(p=>p.Drawers).ThenInclude(m=>m.DrawerFood.Where(a => a.TypeId == type.Id)).ThenInclude(j=>j.Portion);
            if (filteredFoods.Count() <= 0)
                result = "Non sono presenti alimenti di tipo " + type.Name;
            foreach (var fr in filteredFoods)
    
                // filteredTypeList.Add(new TypeViewModel() { FreezerName = food.Freezer.Name, DrawerName = food.Drawer.Name, Portion = food.Portion.Name, Notes = food.Notes, Name = food.Name, Id = food.Id });

            result = "succes";
            return filteredTypeList;
        }
    }
}