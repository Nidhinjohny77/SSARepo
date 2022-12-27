using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = GlobalConstant.LandlordPolicy)]
    public class LandlordController : SSAControllerBase
    {
        private readonly IUserManager userManager;
        private readonly ILandlordManager landlordManager;

        public LandlordController(IUserManager userManager,ILandlordManager landlordManager)
        {
            this.userManager = userManager;
            this.landlordManager = landlordManager;
        }

        [HttpPost]
        [Route("Landlord/Profile/Create")]
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
        [Route("Landlord/Profile/Edit")]
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
