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

    public class PortionsController : ControllerBase
    {
        private FreezerListRepository _freezerRepository;
        public PortionsController()
        {
            _freezerRepository = new FreezerListRepository();
        }
        [HttpGet]
         public ActionResult<string> GetPortions()
        {
            return new JsonResult(_freezerRepository.GetAllPortions());
        }
    }
}