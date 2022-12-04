using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Authorize(Policy = GlobalConstant.AllUsersPolicy)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : SSAControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IStudentManager studentManager;
        private readonly ILandlordManager landlordManager;

        public UserController(IUserManager userManager,IStudentManager studentManager,ILandlordManager landlordManager)
        {
            this.userManager = userManager;
            this.studentManager = studentManager;
            this.landlordManager = landlordManager;
        }

        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserModel user)
        {
            try
            {
               var result=await this.userManager.CreateUserAsync(user);
               if (result.IsFaulted)
               {
                    return BadRequest(result.Errors);
               }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Student/CreateProfile")]
        [Authorize(Policy = GlobalConstant.StudentPolicy)]
        public async Task<IActionResult> CreateStudentProfileAsync([FromBody] StudentModel student)
        {
            try
            {
                var result = await this.studentManager.CreateStudentProfileAysnc(this.User.UID,student);
                if (result.IsFaulted)
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Landlord/CreateProfile")]
        [Authorize(Policy = GlobalConstant.LandlordPolicy)]
        public async Task<IActionResult> CreateLandlordProfileAsync([FromBody] LandlordModel landlord)
        {
            try
            {
                var result = await this.landlordManager.CreateLandlordProfileAysnc(this.User.UID, landlord);
                if (result.IsFaulted)
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Landlord/UpdateProfile")]
        [Authorize(Policy = GlobalConstant.LandlordPolicy)]
        public async Task<IActionResult> UpdateLandlordProfileAsync([FromBody] LandlordModel landlord)
        {
            try
            {
                var result = await this.landlordManager.UpdateLandlordProfileAsync(this.User.UID, landlord);
                if (result.IsFaulted)
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Student/UpdateProfile")]
        [Authorize(Policy = GlobalConstant.StudentPolicy)]
        public async Task<IActionResult> UpdateStudentProfileAsync([FromBody] StudentModel student)
        {
            try
            {
                var result = await this.studentManager.UpdateStudentProfileAsync(this.User.UID, student);
                if (result.IsFaulted)
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Student/Profile")]
        [Authorize(Policy = GlobalConstant.StudentPolicy)]
        public async Task<IActionResult> GetStudentProfileAsync()
        {
            try
            {
                var result = await this.studentManager.GetStudentProfileAsync(this.User.UID);
                if (result.IsFaulted)
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Landlord/Profile")]
        [Authorize(Policy = GlobalConstant.LandlordPolicy)]
        public async Task<IActionResult> GetLandlordProfileAsync()
        {
            try
            {
                var result = await this.landlordManager.GetLandlordProfileAsync(this.User.UID);
                if (result.IsFaulted)
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("Student/Profile")]
        [Authorize(Policy = GlobalConstant.StudentPolicy)]
        public async Task<IActionResult> DeleteStudentProfileAsync()
        {
            try
            {
                var result = await this.studentManager.DeleteStudentProfileAsync(this.User.UID);
                if (result.IsFaulted)
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("Landlord/Profile")]
        [Authorize(Policy = GlobalConstant.LandlordPolicy)]
        public async Task<IActionResult> DeleteLandlordProfileAsync()
        {
            try
            {
                var result = await this.landlordManager.DeleteLandlordProfileAsync(this.User.UID);
                if (result.IsFaulted)
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
