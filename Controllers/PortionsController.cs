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
        private PortionsListRepository _portionsRepository;
        public PortionsController()
        {
            _portionsRepository = new PortionsListRepository();
        }
        [HttpGet]
         public ActionResult<string> GetPortions()
        {
            return new JsonResult(_portionsRepository.GetAllPortions());
        }
    }
}