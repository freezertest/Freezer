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
    }
}