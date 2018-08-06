using System.Collections.Generic;
using FreeezeDotNet.Model;
using System.Linq;
using FreeezeDotNet.ViewModel;


namespace FreeezeDotNet.Repository
{

    public class TypesListRepository
    {
        private FreezerContext _db;
        public TypesListRepository()
        {
            _db= new FreezerContext();
        }
    public List<FoodType> GetAllTypes(){
            return _db.Types.ToList();
        }
    }
}