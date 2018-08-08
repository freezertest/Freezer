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
            var test=new JsonResult(_freezerRepository.GetAllFreezers());
            return test;
        }

        [Route("getsinglefreezer/{id}")]
        [HttpGet]
        public ActionResult<string> GetSingleFreezer(int id)
        {
            return new JsonResult(_freezerRepository.GetById(id));
        }
       
       
    }

}