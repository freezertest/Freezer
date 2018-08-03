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
        //Costruttore-->Get lista freeezer da Repository
        public SearchTypeController()
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
            else
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
        //Costruttore-->Get lista freeezer da Repository
        public SearchPortionController()
        {
            _freezerRepository = new FreezerListRepository();
            freezerList = _freezerRepository.GetAll();
        }
        [HttpGet("{searchterm}")]
        public ActionResult<string> Get(string searchterm)
        {
        //conversione da stringa di ricerca a Enum 
        var invalidPortion = 0;
        FoodPortionEnum searchtermenum = FoodPortionEnum.None; //inizializzazione random
        switch (searchterm.ToUpper())
        {
            case "X1":
                searchtermenum = FoodPortionEnum.X1;
                break;
            case "X2":
                searchtermenum = FoodPortionEnum.X2;
                break;
            case "X3":
                searchtermenum = FoodPortionEnum.X3;
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
            typelistfiltered = new List<Freezer>();
            SearchFrUpByType(freezerList[0], ref typelistfiltered, searchterm, searchtermenum);
            SearchFrPtByType(freezerList[1], ref typelistfiltered, searchterm, searchtermenum);
            SearchFrCantByType(freezerList[2], ref typelistfiltered, searchterm, searchtermenum);

            return new JsonResult(typelistfiltered);
        }
        }
        // functions creazione lista con solo alimenti del tipo richiesto foreach freezer
        private void SearchFrUpByType(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodPortionEnum typeEnum)
        {
        currentList.Add(new Freezer("Freezer Cucina UP - " + type, "Cucina UP", 1));
        if (currentFreezer.drawers[0].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[0].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[0].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                }
            }
        }
        if (currentFreezer.drawers[1].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[1].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[0].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                }
            }
        }

        if (currentFreezer.drawers[2].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[2].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[0].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                }
            }
        }
        }

        private void SearchFrPtByType(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodPortionEnum typeEnum)
        {
        currentList.Add(new Freezer("Freezer Cucina PT - " + type, "Cucina PT", 2));
        if (currentFreezer.drawers[0].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[0].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[1].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                }
            }
        }
        if (currentFreezer.drawers[1].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[1].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[1].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                }
            }
        }

        if (currentFreezer.drawers[2].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[2].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[1].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                }
            }
        }
        }

        private void SearchFrCantByType(Freezer currentFreezer, ref List<Freezer> currentList, string type, FoodPortionEnum typeEnum)
        {
        currentList.Add(new Freezer("Freezer Cantina - " + type, "Cantina", 3));
        if (currentFreezer.drawers[0].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[0].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[0].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[2].drawers[0].DrawerFood.Add(currentFreezer.drawers[0].DrawerFood[i]);
                }
            }
        }
        if (currentFreezer.drawers[1].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[1].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[1].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[2].drawers[1].DrawerFood.Add(currentFreezer.drawers[1].DrawerFood[i]);
                }
            }
        }

        if (currentFreezer.drawers[2].DrawerFood.Count > 0)
        {
            for (var i = 0; i < currentFreezer.drawers[2].DrawerFood.Count; i++)
            {
                if (currentFreezer.drawers[2].DrawerFood[i].Portion == typeEnum)
                {
                    currentList[2].drawers[2].DrawerFood.Add(currentFreezer.drawers[2].DrawerFood[i]);
                }
            }
        }
        }
    }

}