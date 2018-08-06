using System.Collections.Generic;
using System.Linq;
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
            if(_db.Freezers.Count()==0)
            {
                var newFreezer=new Freezer() { Name = "Cucina Up" };
                _db.Freezers.Add(newFreezer);
                _db.SaveChanges();
                var newId=newFreezer.Id;
                _db.Drawers.Add(new Drawer() { Name = "Cassetto1", FreezerId = newId });
                _db.Drawers.Add(new Drawer() { Name = "Cassetto2", FreezerId = newId });
                _db.Drawers.Add(new Drawer() { Name = "Cassetto3", FreezerId = newId });
                _db.SaveChanges();

                newFreezer=new Freezer() { Name = "Cucina Pt" };
                _db.Freezers.Add(newFreezer);
                _db.SaveChanges();
                newId=newFreezer.Id;
                _db.Drawers.Add(new Drawer() { Name = "Cassetto1", FreezerId = newId });
                _db.Drawers.Add(new Drawer() { Name = "Cassetto2", FreezerId = newId });
                _db.Drawers.Add(new Drawer() { Name = "Cassetto3", FreezerId = newId });
                _db.SaveChanges();

                newFreezer=new Freezer() { Name = "Cantina" };
                _db.Freezers.Add(newFreezer);
                _db.SaveChanges();
                newId=newFreezer.Id;
                _db.Drawers.Add(new Drawer() { Name = "Cassetto1", FreezerId = newId });
                _db.Drawers.Add(new Drawer() { Name = "Cassetto2", FreezerId = newId });
                _db.Drawers.Add(new Drawer() { Name = "Cassetto3", FreezerId = newId });
                _db.SaveChanges();
            }

                _db.Types.Add(new FoodType(){Name="Pesce"});
                _db.Types.Add(new FoodType(){Name="Carne"});
                _db.Types.Add(new FoodType(){Name="Legumi"});
                _db.Types.Add(new FoodType(){Name="Verdura"});
                _db.Types.Add(new FoodType(){Name="Erbe aromatiche e spezie"});
                _db.Types.Add(new FoodType(){Name="Altro"});
            
                _db.Portions.Add(new FoodPortion(){Name="X1"});
                _db.Portions.Add(new FoodPortion(){Name="X2"});
                _db.Portions.Add(new FoodPortion(){Name="X3"});
                _db.Portions.Add(new FoodPortion(){Name="None"});
                _db.SaveChanges();
            
        }

       [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}