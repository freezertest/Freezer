using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inventory.Model;
using Inventory.Repository;
using Inventory.ViewModel;

namespace Inventory.Controllers
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
        public JsonResult GetFreezers()
        {
            return new JsonResult(_freezerRepository.GetAllFreezers().ToList());
        }

        [Route("getsinglefreezer/{id}")]
        [HttpGet]
        public ActionResult<string> GetSingleFreezer(int id)
        {
            return new JsonResult(_freezerRepository.GetById(id));
        }
       
       
    }

}