

namespace SSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAuthHandler handler;
        public LoginController(IMapper mapper,IAuthHandler handler)
        {
            this.mapper = mapper;
            this.handler = handler;
        }

        [HttpPost]
        [AllowAnonymous]
        public  async Task<IActionResult> Login([FromBody] UserCredentialModel model)
        {
            var token=await this.handler.AuthenticateAsync(model);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
    }
}
