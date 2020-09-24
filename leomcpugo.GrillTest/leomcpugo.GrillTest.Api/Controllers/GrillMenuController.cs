using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leomcpugo.GrillTest.Services.Grill;
using Microsoft.AspNetCore.Mvc;

namespace leomcpugo.GrillTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrillMenuController : ControllerBase
    {
        private IGrillMenuService grillService;

        public GrillMenuController(IGrillMenuService grillService)
        {
            this.grillService = grillService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return DefaultResponse(await grillService.GetAll());
        }
    }
}
