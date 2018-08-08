using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inventory.Model;
using Inventory.Repository;
using Inventory.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FoodController : ControllerBase
    {
        private Food _currentFood;
        private FreezerContext _db;
        public FoodController()
        {
             _currentFood= new Food();
             _db=new FreezerContext();
        }

         [HttpGet]
         public List<Food> GetAllFoods()
         {
             return _db.Foods.ToList();
         }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Post([FromBody] FormViewModel value)
        {
            return  new JsonResult(_currentFood.VerifyFood(value));
        }

        [HttpDelete("{id}")]
            public string Delete(int id)
            {
                return _currentFood.Remove(id);
            }



    }
}