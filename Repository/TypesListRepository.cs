using System.Collections.Generic;
using FreeezeDotNet.Model;
using System.Linq;
using FreeezeDotNet.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FreeezeDotNet.Repository
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
            var filteredFoods = _db.Foods.Where(a => a.TypeId == type.Id);
            if (filteredFoods.Count() <= 0)
                result = "Non sono presenti alimenti di tipo " + type.Name;
            foreach (var food in filteredFoods)
                filteredTypeList.Add(new TypeViewModel() { FreezerName = food.Drawer.Freezer.Name, DrawerName = food.Drawer.Name, Portion = food.Portion.Name, Notes = food.Notes, Name = food.Name, Id = food.Id });

            result = "succes";
            return filteredTypeList;
        }
    }
}