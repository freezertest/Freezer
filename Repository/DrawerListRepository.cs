using System.Collections.Generic;
using Inventory.Model;
using System.Linq;
using Inventory.ViewModel;


namespace Inventory.Repository
{

    public class DrawerListRepository
    {
        private FreezerContext _db;
        private List<Drawer> drawers;
        public DrawerListRepository()
        {
            _db = new FreezerContext();
        }
        public List<Drawer> GetAllDrawers()
        {
            return _db.Drawers.ToList();
        }
        public List<Drawer> GetDrawersByFreezerId(int freezerId)
        {
            var test=_db.Drawers.Where(a => a.FreezerId == freezerId).ToList();
            return _db.Drawers.Where(a => a.FreezerId == freezerId).ToList();
        }
    }
}