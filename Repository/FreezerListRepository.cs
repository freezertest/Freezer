using System.Collections.Generic;
using Inventory.Model;
using System.Linq;
using Inventory.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repository
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
            var test = _db.Freezers.Include(p => p.Drawers).ThenInclude(l => l.DrawerFood).ToList();
            return test;
        }
        public Freezer GetById(int id)
        {
            return _db.Freezers.FirstOrDefault(a => a.Id == id);
        }
    }


}