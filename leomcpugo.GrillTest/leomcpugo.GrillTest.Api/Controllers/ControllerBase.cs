using Microsoft.AspNetCore.Mvc;

namespace leomcpugo.GrillTest.Api.Controllers
{
    public class ControllerBase : Controller
    {
        public IActionResult DefaultResponse(object result = null)
        {
            return Ok(new BaseResponse { Data = result, IsError = false });
        }

        public class BaseResponse
        {
            public object Data { get; set; }
            public bool IsError { get; set; }
        }
    }
}
