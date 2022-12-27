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
        [Route("Edit")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserModel user)
        {
            try
            {
                var result = await this.userManager.UpdateUserAsync(this.User.UID, user);
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
        [Route("Delete")]
        [Authorize(Policy = GlobalConstant.AdminPolicy)]
        public async Task<IActionResult> DeleteUserAsync(UserModel user)
        {
            try
            {
                var result = await this.userManager.DeleteUserAsync(this.User.UID, user);
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
        [Authorize(Policy = GlobalConstant.AllUsersPolicy)]
        public async Task<IActionResult> GetUserAsync()
        {
            try
            {
                var result = await this.userManager.GetUserAsync(this.User.UID);
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
        [Route("{UID}")]
        [Authorize(Policy = GlobalConstant.AdminPolicy)]
        public async Task<IActionResult> GetUserAsync(string UID)
        {
            try
            {
                var result = await this.userManager.GetUserAsync(UID);
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
        [Route("All")]
        [Authorize(Policy = GlobalConstant.AdminPolicy)]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                var result = await this.userManager.GetAllUsersAsync();
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
