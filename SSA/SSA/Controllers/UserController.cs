using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Authorize(Policy =GlobalConstant.StudentCreatorPolicy)]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : SSAControllerBase
    {
        private readonly IMapper mapper;

        public UserController()
        {
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserModel user)
        {
            try
            {
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Student/CreateProfile")]
        public async Task<IActionResult> CreateStudentProfileAsync([FromBody] StudentModel student)
        {
            try
            {
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Landlord/CreateProfile")]
        public async Task<IActionResult> CreateLandlordProfileAsync([FromBody] LandlordModel landlord)
        {
            try
            {
                return Ok(landlord);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Landlord/UpdateProfile")]
        public async Task<IActionResult> UpdateLandlordProfileAsync([FromBody] LandlordModel landlord)
        {
            try
            {
                return Ok(landlord);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Student/UpdateProfile")]
        public async Task<IActionResult> UpdateStudentProfileAsync([FromBody] StudentModel student)
        {
            try
            {
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
