using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy =GlobalConstant.StudentPolicy)]
    public class StudentController : SSAControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IStudentManager studentManager;

        public StudentController(IUserManager userManager, IStudentManager studentManager)
        {
            this.userManager = userManager;
            this.studentManager = studentManager;
        }

        [HttpPost]
        [Route("Profile/Create")]
        [Authorize(Policy = GlobalConstant.StudentPolicy)]
        public async Task<IActionResult> CreateStudentProfileAsync([FromBody] StudentProfileModel student)
        {
            try
            {
                var result = await this.studentManager.CreateStudentProfileAysnc(this.User.UID, student);
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
        [Route("Profile/Edit")]
        [Authorize(Policy = GlobalConstant.StudentPolicy)]
        public async Task<IActionResult> UpdateStudentProfileAsync([FromBody] StudentProfileModel student)
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
        [Route("Profile")]
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
    }
}
