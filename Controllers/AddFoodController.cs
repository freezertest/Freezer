using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreeezeDotNet.Model;
using FreeezeDotNet.Repository;
using FreeezeDotNet.ViewModel;

namespace FreeezeDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AddFoodController : ControllerBase
    {
        private FreezerContext _db;
        private TypesListRepository _typesRepository;
        private List<FoodType> _types;
        private List<FoodPortion> _portions;
        private PortionsListRepository _portionsRepository;
        public AddFoodController()
        {
            _db = new FreezerContext();
            _typesRepository = new TypesListRepository();
            _types = _typesRepository.GetAllTypes();
            _portionsRepository = new PortionsListRepository();
            _portions = _portionsRepository.GetAllPortions();
        }

        [HttpPost]
        public string Post([FromBody] FormViewModel value)
        {
            return VerifyFood(value);
        }

        public string VerifyFood(FormViewModel newFood)
        {
            if (_db.Freezers.Where(a => a.Id == newFood.Freezer).Count() <= 0)
                return "Errore nel Freezer. Controlla la tua scelta";
            else
            {
                var chosenFreezer = _db.Freezers.FirstOrDefault(a => a.Id == newFood.Freezer);
                if (chosenFreezer.Drawers.Where(a => a.Id == newFood.Drawer).Count() <= 0)
                    return "Errore nel Cassetto. Controlla la tua scelta";
                else
                {
                    var type = _types.FirstOrDefault(a => a.Id == newFood.Type);
                    var portion = _portions.FirstOrDefault(a => a.Id == newFood.Portion);
                    if ((type.Name.ToUpper() == "PESCE" || type.Name.ToUpper() == "CARNE") && portion.Name.ToUpper() == "NONE" || type.Name.ToUpper().Contains("ERBE") && portion.Name.ToUpper() != "None")
                        return "Errore nel Tipo dell'alimento. Controlla la tua scelta";

                    var chosenDrawer = chosenFreezer.Drawers.FirstOrDefault(a => a.Id == newFood.Drawer);
                    chosenDrawer.DrawerFood.Add(new Food() { Name = newFood.Name, Type = type, Portion = portion, Notes = newFood.Notes });
                    return "L'alimento è stato inserito con successo!";

                }

            }




        }



    }
}