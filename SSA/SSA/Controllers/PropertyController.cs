using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Authorize(Policy = GlobalConstant.PropertyPolicy)]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : SSAControllerBase
    {
        private readonly IPropertyManager propertyManager;
        private readonly ILandlordManager landlordManager;

        public PropertyController(IPropertyManager propertyManager,ILandlordManager landlordManager)
        {
            this.propertyManager = propertyManager;
            this.landlordManager = landlordManager;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllPropertiesAsync()
        {
            try
            {
                var landlordProfileResult=await this.landlordManager.GetLandlordProfileAsync(this.User.UID);
                if (landlordProfileResult.IsFaulted)
                {
                    return BadRequest(landlordProfileResult.Errors);
                }
                var landlordProfileUID = landlordProfileResult.Value.UID;
                var result = await this.propertyManager.GetPropertiesByLandlordAsync(this.User.UID,landlordProfileUID);
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
        [Route("Get")]
        public async Task<IActionResult> GetPropertyAsync(string propertyUID)
        {
            try
            {
                var result = await this.propertyManager.GetPropertyByUIDAsync(this.User.UID, propertyUID);
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
        public async Task<IActionResult> CreatePropertyAsync(PropertyModel property)
        {
            try
            {              
                var result = await this.propertyManager.CreatePropertyAsync(this.User.UID, property);
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
        public async Task<IActionResult> UpdatePropertyAsync(PropertyModel property)
        {
            try
            {
                var result = await this.propertyManager.UpdatePropertyAsync(this.User.UID, property);
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
        public async Task<IActionResult> DeletePropertyAsync(string propertyUID)
        {
            try
            {
                var result = await this.propertyManager.DeletePropertyAsync(this.User.UID, propertyUID);
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
        [Route("Attribute/{propertyUID}")]
        public async Task<IActionResult> GetPropertyAttributeAsync(string propertyUID)
        {
            try
            {
                var result = await this.propertyManager.GetPropertyAttributeByPropertyAsync(this.User.UID, propertyUID);
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
        public async Task<IActionResult> CreatePropertyAttributeAsync(PropertyAttributeModel propertyAttribute)
        {
            try
            {
                var result = await this.propertyManager.CreatePropertyAttributeAsync(this.User.UID, propertyAttribute);
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
        public async Task<IActionResult> UpdatePropertyAttributeAsync(PropertyAttributeModel propertyAttribute)
        {
            try
            {
                var result = await this.propertyManager.UpdatePropertyAttributeAsync(this.User.UID, propertyAttribute);
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
        [Route("Attribute/{propertyAttributeUID}")]
        public async Task<IActionResult> DeletePropertyAttributeAsync(string propertyAttributeUID)
        {
            try
            {
                var result = await this.propertyManager.DeletePropertyAttributeAsync(this.User.UID, propertyAttributeUID);
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
