
namespace SSA.Controllers
{
    [Authorize(Policy = GlobalConstant.AllUsersPolicy)]
    [Route("api/Property/[controller]")]
    [ApiController]
    public class ListingController : SSAControllerBase
    {
        private readonly IPropertyManager propertyManager;
        private readonly ILandlordManager landlordManager;

        public ListingController(IPropertyManager propertyManager, ILandlordManager landlordManager)
        {
            this.propertyManager = propertyManager;
            this.landlordManager = landlordManager;
        }

        [HttpGet]
        [Route("Current/All")]
        [Authorize(Policy = GlobalConstant.LandlordPolicy)]
        public async Task<IActionResult> GetAllPropertyListingsAsync()
        {
            try
            {
                var landlordProfileResult = await this.landlordManager.GetLandlordProfileAsync(this.User.UID);
                if (landlordProfileResult.IsFaulted)
                {
                    return BadRequest(landlordProfileResult.Errors);
                }
                var landlordProfileUID = landlordProfileResult.Value.ProfileUID;
                var result = await this.propertyManager.GetAllPropertyListingsAsync(this.User.UID, landlordProfileUID);
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
        [Route("All")]
        public async Task<IActionResult> GetAllPropertyListingsAsync(PropertyListingFilterModel model)
        {
            try
            {
                var result = await this.propertyManager.GetAllPropertyListingsByFilterAsync(this.User.UID, model);
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
        [Route("{propertyListingUID}")]
        public async Task<IActionResult> GetPropertyListingAsync(string propertyListingUID)
        {
            try
            {
                var result = await this.propertyManager.GetPropertyListingByUIDAsync(this.User.UID, propertyListingUID);
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
        [Authorize(Policy = GlobalConstant.PropertyListingPolicy)]
        public async Task<IActionResult> CreatePropertyListingAsync(PropertyListingModel propertyListing)
        {
            try
            {
                var result = await this.propertyManager.CreatePropertyListingAsync(this.User.UID, propertyListing);
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
        [Authorize(Policy = GlobalConstant.PropertyListingPolicy)]
        public async Task<IActionResult> UpdatePropertyListingAsync(PropertyListingModel propertyListing)
        {
            try
            {
                var result = await this.propertyManager.UpdatePropertyListing(this.User.UID, propertyListing);
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
        [Authorize(Policy = GlobalConstant.PropertyListingPolicy)]
        public async Task<IActionResult> DeletePropertyListingAsync(string propertyListingUID)
        {
            try
            {
                var result = await this.propertyManager.DeletePropertyListingAsync(this.User.UID, propertyListingUID);
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
