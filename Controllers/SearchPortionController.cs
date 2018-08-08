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
    public class SearchPortionController : ControllerBase
    {
        private PortionsListRepository _portionsRepository;
        private List<PortionViewModel> portionlistfiltered;
        private List<FoodPortion> _portions;
        public SearchPortionController()         //Costruttore-->Get lista freeezer da Repository
        {
            _portionsRepository = new PortionsListRepository();
            _portions = _portionsRepository.GetAllPortions();
        }

        [HttpGet("{searchterm}")]
        public ActionResult<string> Get(string searchTerm)
        {
            //conversione da stringa di ricerca a porzione 
            var invalidPortion = 0;
            FoodPortion searchPortion;
            searchPortion = new FoodPortion();
            switch (searchTerm.ToUpper())
            {
                case "X1":
                    searchPortion = _portions.FirstOrDefault(a => a.Name.ToUpper() == "X1");
                    break;
                case "X2":
                    searchPortion = _portions.FirstOrDefault(a => a.Name.ToUpper() == "X2");
                    break;
                case "X3":
                    searchPortion = _portions.FirstOrDefault(a => a.Name.ToUpper() == "X3");
                    break;
                case "NONE":
                    searchPortion = _portions.FirstOrDefault(a => a.Name.ToUpper() == "NONE");
                    break;
                default:
                    invalidPortion++;
                    break;
            }
            //check validità ricerca
            if (invalidPortion != 0)
            {
                return "Hai ricercato una porzione inesistente";
            }

            //Crea lista filtrata
            var ris = string.Empty;
            portionlistfiltered = _portionsRepository.CreateListByPortion(searchPortion, out ris);
            if(ris.ToUpper()!="SUCCESS")
            return ris;
            
            return new JsonResult(portionlistfiltered);
        }
    }
   
}