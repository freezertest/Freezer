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

    public class DrawersController : ControllerBase
    {
        private DrawerListRepository _drawerRepository;
        public DrawersController()
        {
            _drawerRepository = new DrawerListRepository();
        }

        [HttpGet("{currentFreezerId}")]         
        public ActionResult<string> GetDrawers(int currentFreezerId)
        {
            var test=_drawerRepository.GetDrawersByFreezerId(currentFreezerId);
            return new JsonResult(_drawerRepository.GetDrawersByFreezerId(currentFreezerId));
        }


    }
}
