using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PepperShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        public UserAccountController()
        {
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            /***
            	This is only used to demonstrate authorized requests
            	Currently no actual data is being retrieved
            */
            return "Access granted!";
        }

    }

}
