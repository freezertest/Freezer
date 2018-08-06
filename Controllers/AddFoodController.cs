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

    public class AddFoodController : ControllerBase
    {
        private FreezerListRepository _freezerRepository;
        public AddFoodController()
        {
            _freezerRepository = new FreezerListRepository();
        }
        [HttpPost]
        public void Post([FromBody] FormViewModel value)
        {
           _freezerRepository.VerifyFood(value);
        }
    }
}