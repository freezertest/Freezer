using FreeezeDotNet.Model;
using Microsoft.AspNetCore.Mvc;

namespace FreeezeDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateBaseController : ControllerBase
    {
        private FreezerContext _db;

        public CreateBaseController()
        {
            _db = new FreezerContext();
            _db.Freezers.Add(new Freezer() { Name = "Cucina Up" });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto1", FreezerId = 1 });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto2", FreezerId = 1 });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto3", FreezerId = 1 });
            _db.Freezers.Add(new Freezer() { Name = "Cucina Pt" });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto1", FreezerId = 2 });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto2", FreezerId = 2 });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto3", FreezerId = 2 });
            _db.Freezers.Add(new Freezer() { Name = "Cantina" });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto1", FreezerId = 3 });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto2", FreezerId = 3 });
            _db.Drawers.Add(new Drawer() { Name = "Cassetto3", FreezerId = 3 });
            _db.Portions.Add(new FoodPortion(){Name="X1"});
            _db.Portions.Add(new FoodPortion(){Name="X2"});
            _db.Portions.Add(new FoodPortion(){Name="X3"});
            _db.Portions.Add(new FoodPortion(){Name="None"});
            _db.Types.Add(new FoodType(){Name="Carne"});
            _db.Types.Add(new FoodType(){Name="Pesce"});
            _db.Types.Add(new FoodType(){Name="Legumi"});
            _db.Types.Add(new FoodType(){Name="Verdura"});
            _db.Types.Add(new FoodType(){Name="Erbe Aromatiche & Spezie"});
            _db.Types.Add(new FoodType(){Name="Altro"});
            _db.SaveChanges();
        }

    }
}