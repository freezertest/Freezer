using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreeezeDotNet.Model;
using FreeezeDotNet.Repository;

namespace FreeezeDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchTypeController : ControllerBase
    {
        private List<Freezer> freezerList;
        private List<Freezer> typelistfiltered;
        private FreezerListRepository _freezerRepository;
        public SearchTypeController()         //Costruttore-->Get lista freeezer da Repository
        {
            _freezerRepository = new FreezerListRepository();
            freezerList = _freezerRepository.GetAll();
        }

        [HttpGet("{searchterm}")]
        public ActionResult<string> Get(string searchterm)
        {
            //conversione da stringa di ricerca a Enum 
            var invalidType = 0;
            FoodTypeEnum searchtermEnum = FoodTypeEnum.Pesce; //inizializzazione random
            switch (searchterm.ToUpper())
            {
                case "PESCE":
                    break;
                case "CARNE":
                    searchtermEnum = FoodTypeEnum.Carne;
                    break;
                case "LEGUMI":
                    searchtermEnum = FoodTypeEnum.Legumi;
                    break;
                case "VERDURA":
                    searchtermEnum = FoodTypeEnum.Verdura;
                    break;
                case "ERBE":
                    searchtermEnum = FoodTypeEnum.ErbeAromaticheSpezie;
                    break;
                case "SPEZIE":
                    searchtermEnum = FoodTypeEnum.ErbeAromaticheSpezie;
                    break;
                case "ALTRO":
                    searchtermEnum = FoodTypeEnum.Altro;
                    break;
                default:
                    invalidType++;
                    break;
            }
            //check validità ricerca
            if (invalidType != 0) 
            {
                return "null";
            }
            else //Crea lista filtrata
            {
                typelistfiltered=_freezerRepository.CreateListByType(searchterm,searchtermEnum);
                return new JsonResult (typelistfiltered);
            }
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SearchPortionController : ControllerBase
    {
        private List<Freezer> freezerList;
        private List<Freezer> typelistfiltered;
        private FreezerListRepository _freezerRepository;
        public SearchPortionController()    //Costruttore-->Get lista freeezer da Repository
        {
            _freezerRepository = new FreezerListRepository();
            freezerList = _freezerRepository.GetAll();
        }

        [HttpGet("{searchterm}")]
        public ActionResult<string> Get(string searchterm)
        {
            //conversione da stringa di ricerca a Enum 
            var invalidPortion = 0;
            FoodPortionEnum searchtermEnum = FoodPortionEnum.None; //inizializzazione random
            switch (searchterm.ToUpper())
            {
            case "X1":
                searchtermEnum = FoodPortionEnum.X1;
                break;
            case "X2":
                searchtermEnum = FoodPortionEnum.X2;
                break;
            case "X3":
                searchtermEnum = FoodPortionEnum.X3;
                break;
            default:
                invalidPortion++;
                break;
            }
            //check validità ricerca
            if (invalidPortion != 0)
            {
            return "null";
            }
            else
            {//creazione lista filtrata
                typelistfiltered=_freezerRepository.CreateListByPortion(searchterm,searchtermEnum);
                return new JsonResult (typelistfiltered);
            }
        }
    }

}