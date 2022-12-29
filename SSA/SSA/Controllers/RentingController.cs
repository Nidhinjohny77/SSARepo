using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Route("api/Property/Listing/[controller]")]
    [ApiController]
    [Authorize(Policy = GlobalConstant.PropertyListingPolicy)]
    public class RentingController : SSAControllerBase
    {
        private readonly IPropertyManager propertyManager;
        private readonly ILandlordManager landlordManager;

        public RentingController(IPropertyManager propertyManager, ILandlordManager landlordManager)
        {
            this.propertyManager = propertyManager;
            this.landlordManager = landlordManager;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Policy = GlobalConstant.LandlordPolicy)]
        public async Task<IActionResult> GetAllPropertyRentingsAsync()
        {
            try
            {
                var landlordProfileResult = await this.landlordManager.GetLandlordProfileAsync(this.User.UID);
                if (landlordProfileResult.IsFaulted)
                {
                    return BadRequest(landlordProfileResult.Errors);
                }
                var landlordProfileUID = landlordProfileResult.Value.UID;
                var result = await this.propertyManager.GetAllPropertyRentingsByLandlordAsync(this.User.UID, landlordProfileUID);
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
        [Route("Current/All")]
        public async Task<IActionResult> GetAllActivePropertyRentingsAsync()
        {
            try
            {
                var landlordProfileResult = await this.landlordManager.GetLandlordProfileAsync(this.User.UID);
                if (landlordProfileResult.IsFaulted)
                {
                    return BadRequest(landlordProfileResult.Errors);
                }
                var landlordProfileUID = landlordProfileResult.Value.UID;
                var result = await this.propertyManager.GetAllActivePropertyRentingsByLandlordAsync(this.User.UID, landlordProfileUID);
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
        [Route("Current/{propertyUID}")]
        public async Task<IActionResult> GetPropertyRentingAsync(string propertyUID)
        {
            try
            {
                var result = await this.propertyManager.GetActivePropertyRentingByPropertyUIDAsync(this.User.UID, propertyUID);
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
        public async Task<IActionResult> CreatePropertyRentingAsync(PropertyRentingModel propertyRenting)
        {
            try
            {
                var result = await this.propertyManager.CreatePropertyRentingAsync(this.User.UID, propertyRenting);
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
        public async Task<IActionResult> UpdatePropertyRentingAsync(PropertyRentingModel propertyRenting)
        {
            try
            {
                var result = await this.propertyManager.UpdatePropertyRentingAsync(this.User.UID, propertyRenting);
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
        public async Task<IActionResult> DeletePropertyRentingAsync(string propertyRentingUID)
        {
            try
            {
                var result = await this.propertyManager.DeletePropertyRentingAsync(this.User.UID, propertyRentingUID);
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
