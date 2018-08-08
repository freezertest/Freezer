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
        public ActionResult<string> Get(string searchTerm)
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
                return "Hai ricercato un tipo inesistente";
            }

            //Crea lista filtrata
            string ris;
            typelistfiltered = _typesRepository.CreateListByType(searchType, ref ris);
            if(ris.ToUpper()!="SUCCESS")
            return ris;

            return new JsonResult(typelistfiltered);
        }
    }

    
}