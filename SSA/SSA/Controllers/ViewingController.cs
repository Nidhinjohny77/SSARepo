

namespace SSA.Controllers
{
    [Authorize(Policy = GlobalConstant.PropertyViewingPolicy)]
    [Route("api/Property/Listing/[controller]")]
    [ApiController]
    public class ViewingController : SSAControllerBase
    {
        private readonly IPropertyManager propertyManager;
        private readonly ILandlordManager landlordManager;
        private readonly IStudentManager studentManager;

        public ViewingController(IPropertyManager propertyManager, ILandlordManager landlordManager,IStudentManager studentManager)
        {
            this.propertyManager = propertyManager;
            this.landlordManager = landlordManager;
            this.studentManager = studentManager;
        }

        [HttpGet]
        [Route("Current/All")]
        public async Task<IActionResult> GetAllPropertyViewingsAsync()
        {
            try
            {
                if (this.User.Role.Name == GlobalConstant.StudentRole)
                {
                    var studentProfileResult = await this.studentManager.GetStudentProfileAsync(this.User.UID);
                    if (studentProfileResult.IsFaulted)
                    {
                        return BadRequest(studentProfileResult.Errors);
                    }
                    var studentProfileUID = studentProfileResult.Value.ProfileUID;
                    var result = await this.propertyManager.GetAllPropertyViewingsByStudentAsync(this.User.UID, studentProfileUID);
                    if (result.IsFaulted)
                    {
                        return BadRequest(result.Errors);
                    }
                    else
                    {
                        return Ok(result.Value);
                    }
                }
                if (this.User.Role.Name == GlobalConstant.LandlordRole)
                {
                    var landlordProfileResult = await this.landlordManager.GetLandlordProfileAsync(this.User.UID);
                    if (landlordProfileResult.IsFaulted)
                    {
                        return BadRequest(landlordProfileResult.Errors);
                    }
                    var landlordProfileUID = landlordProfileResult.Value.ProfileUID;
                    var result = await this.propertyManager.GetAllPropertyViewingsByLandlordAsync(this.User.UID, landlordProfileUID);
                    if (result.IsFaulted)
                    {
                        return BadRequest(result.Errors);
                    }
                    else
                    {
                        return Ok(result.Value);
                    }
                }
                return StatusCode(StatusCodes.Status404NotFound);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize(Policy = GlobalConstant.StudentPolicy)]
        public async Task<IActionResult> CreatePropertyViewingAsync(PropertyViewingModel propertyViewing)
        {
            try
            {
                var result = await this.propertyManager.CreatePropertyViewing(this.User.UID, propertyViewing);
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

        [HttpPut]
        public async Task<IActionResult> UpdatePropertyViewingAsync(PropertyViewingModel propertyViewing)
        {
            try
            {
                var result = await this.propertyManager.UpdatePropertyViewingAsync(this.User.UID, propertyViewing);
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
        [Authorize(Policy = GlobalConstant.AdminPolicy)]
        public async Task<IActionResult> DeletePropertyViewingAsync(string propertyViewingUID)
        {
            try
            {
                var result = await this.propertyManager.DeletePropertyViewing(this.User.UID, propertyViewingUID);
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
