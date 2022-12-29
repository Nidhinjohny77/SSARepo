
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
                var landlordProfileUID = landlordProfileResult.Value.UID;
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

        [HttpPost]
        [Route("{propertyListingUID}/Attribute/All")]
        public async Task<IActionResult> GetAllPropertyListingAttributesByListingUIDAsync(string propertyListingUID)
        {
            try
            {
                var result = await this.propertyManager.GetAllPropertyListingAttributesByListingUIDAsync(this.User.UID, propertyListingUID);
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
        [Route("{propertyListingUID}/Attribute")]
        public async Task<IActionResult> GetPropertyListingAttributeByListingUIDAsync(string propertyListingUID)
        {
            try
            {
                var result = await this.propertyManager.GetPropertyListingAttributeByListingUIDAsync(this.User.UID, propertyListingUID);
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
        [Route("Attribute/{propertyListingAttributeUID}")]
        public async Task<IActionResult> GetPropertyListingAttributeAsync(string propertyListingAttributeUID)
        {
            try
            {
                var result = await this.propertyManager.GetPropertyListingAttributeAsync(this.User.UID, propertyListingAttributeUID);
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
        [Route("Attribute")]
        [Authorize(Policy = GlobalConstant.PropertyListingPolicy)]
        public async Task<IActionResult> CreatePropertyListingAttributeAsync(PropertyListingAttributeModel propertyListingAttribute)
        {
            try
            {
                var result = await this.propertyManager.CreatePropertyListingAttributeAsync(this.User.UID, propertyListingAttribute);
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
        [Route("Attribute")]
        [Authorize(Policy = GlobalConstant.PropertyListingPolicy)]
        public async Task<IActionResult> UpdatePropertyListingAttributeAsync(PropertyListingAttributeModel propertyListingAttribute)
        {
            try
            {
                var result = await this.propertyManager.UpdatePropertyListingAttributeAsync(this.User.UID, propertyListingAttribute);
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
        [Route("Attribute/{propertyListingAttributeUID}")]
        [Authorize(Policy = GlobalConstant.PropertyListingPolicy)]
        public async Task<IActionResult> DeletePropertyListingAttributeAsync(string propertyListingAttributeUID)
        {
            try
            {
                var result = await this.propertyManager.DeletePropertyListingAttributeAsync(this.User.UID, propertyListingAttributeUID);
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
