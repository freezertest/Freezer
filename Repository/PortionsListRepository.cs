using System.Collections.Generic;
using FreeezeDotNet.Model;
using System.Linq;
using FreeezeDotNet.ViewModel;


namespace FreeezeDotNet.Repository
{

    public class PortionsListRepository
    {
        private FreezerContext _db;
        public PortionsListRepository()
        {
            _db= new FreezerContext();
        }

        public List<FoodPortion> GetAllPortions(){
            return _db.Portions.ToList();
        }

        public List<PortionViewModel> CreateListByPortion(FoodPortion portion, out string result)
        {
            var filteredPortionList = new List<PortionViewModel>();
            var filteredFoods = _db.Foods.Where(a => a.PortionId == portion.Id);
            if (filteredFoods.Count() <= 0)
                result="Non sono presenti alimenti di porzione " + portion.Name;
            foreach (var food in filteredFoods)
                filteredPortionList.Add(new PortionViewModel() { FreezerName = food.Drawer.Freezer.Name, DrawerName = food.Drawer.Name, Type = food.Type.Name, Notes = food.Notes });
    
            result="succes";
            return filteredPortionList;
        }
    }
}