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

    public class FreezerController : ControllerBase
    {
        private FreezerListRepository _freezerRepository;
        public FreezerController()
        {
            _freezerRepository = new FreezerListRepository();
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> GetFreezers()
        {
            return new JsonResult(_freezerRepository.GetAllFreezers());
        }
        public ActionResult<string> GetSingleFreezer(int id)
        {
            return new JsonResult(_freezerRepository.GetById(id));
        }
        [HttpGet]
         public ActionResult<string> GetDrawers()
        {
            return new JsonResult(_freezerRepository.GetAllDrawers());
        }
        public ActionResult<string> GetTypes()
        {
            return new JsonResult(_freezerRepository.GetAllTypes());
        }
        public ActionResult<string> GetPortions()
        {
            return new JsonResult(_freezerRepository.GetAllPortions());
        }

        [HttpPost]
        public void Post([FromBody] FormViewModel value)
        {
           _freezerRepository.VerifyFood(value);
        }
    }

}