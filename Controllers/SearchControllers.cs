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
    public class SearchTypeController : ControllerBase
    {
        private TypesListRepository _typesRepository;
        private List<TypeViewModel> typelistfiltered;
        private List<FoodType> _types;
        public SearchTypeController()         //Costruttore-->Get lista freeezer da Repository
        {
            _typesRepository = new TypesListRepository();
            _types = _typesRepository.GetAllTypes();
        }

        [HttpGet("{searchterm}")]
        public ActionResult<string> Get(string searchTerm, out string searchResult)
        {
            //conversione da stringa di ricerca a tipo 
            var invalidType = 0;
            FoodType searchType;
            searchType = new FoodType();
            switch (searchTerm.ToUpper())
            {
                case "PESCE":
                    searchType = _types.FirstOrDefault(a => a.Name.ToUpper() == "PESCE");
                    break;
                case "CARNE":
                    searchType = _types.FirstOrDefault(a => a.Name.ToUpper() == "CARNE");
                    break;
                case "LEGUMI":
                    searchType = _types.FirstOrDefault(a => a.Name.ToUpper() == "LEGUMI");
                    break;
                case "VERDURA":
                    searchType = _types.FirstOrDefault(a => a.Name.ToUpper() == "VERDURA");
                    break;
                case "ERBE":
                    searchType = _types.FirstOrDefault(a => a.Name.ToUpper().Contains("ERBE"));
                    break;
                case "SPEZIE":
                    searchType = _types.FirstOrDefault(a => a.Name.ToUpper().Contains("SPEZIE"));
                    break;
                case "ALTRO":
                    searchType = _types.FirstOrDefault(a => a.Name.ToUpper() == "ALTRO");
                    break;
                default:
                    invalidType++;
                    break;
            }
            //check validità ricerca
            if (invalidType != 0)
            {
                searchResult = "tipo inesistente";
                return "Hai ricercato un tipo inesistente";
            }

            //Crea lista filtrata
            var ris = string.Empty;
            typelistfiltered = _typesRepository.CreateListByType(searchType, out ris);
            searchResult = ris;
            return new JsonResult(typelistfiltered);
        }
    }

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
        public ActionResult<string> Get(string searchTerm, out string searchResult)
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
                searchResult = "porzione inesistente";
                return "Hai ricercato una porzione inesistente";
            }

            //Crea lista filtrata
            var ris = string.Empty;
            portionlistfiltered = _portionsRepository.CreateListByPortion(searchPortion, out ris);
            searchResult = ris;
            return new JsonResult(portionlistfiltered);
        }
    }
   

}