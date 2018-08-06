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

    public class TypesController : ControllerBase
    {
        private FreezerListRepository _freezerRepository;
        public TypesController()
        {
            _freezerRepository = new FreezerListRepository();
        }
        [HttpGet]
        public ActionResult<string> GetTypes()
        {
            return new JsonResult(_freezerRepository.GetAllTypes());
        }
    }
}