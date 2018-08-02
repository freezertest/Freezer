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
        public ActionResult<IEnumerable<string>> Get()
        {
            return new JsonResult(_freezerRepository.GetAll());
        }

        public ActionResult<string> GetSingle(int id)
        {
            return new JsonResult(_freezerRepository.GetById(id));
        }

        [HttpPost]
        public void Post([FromBody] FormViewModel value)
        {
           _freezerRepository.VerifyFood(value);
        }
    }

}