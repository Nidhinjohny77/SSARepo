using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy =GlobalConstant.AllTenantsPolicy)]
    public class TenantController : SSAControllerBase
    {
        private readonly IUserManager userManager;
        private readonly ITenantManager tenantManager;

        public TenantController(IUserManager userManager,ITenantManager tenantManager)
        {
            this.userManager = userManager;
            this.tenantManager = tenantManager;
        }

        [HttpPost]
        [Route("Profile/Create")]
        public async Task<IActionResult> CreateTenantProfileAsync([FromBody] TenantModel tenant)
        {
            try
            {
                var result = await this.tenantManager.CreateTenantProfileAysnc(this.User.UID, tenant);
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
        public async Task<IActionResult> UpdateTenantProfileAsync([FromBody] TenantModel tenant)
        {
            try
            {
                var result = await this.tenantManager.UpdateTenantProfileAsync(this.User.UID, tenant);
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
        public async Task<IActionResult> GetTenantProfileAsync()
        {
            try
            {
                var result = await this.tenantManager.GetTenantProfileAsync(this.User.UID);
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
        [Route("Profile")]
        public async Task<IActionResult> DeleteTenantProfileAsync()
        {
            try
            {
                var result = await this.tenantManager.DeleteTenantProfileAsync(this.User.UID);
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
        [Route("Preferences/Create")]
        public async Task<IActionResult> CreateTenantPreferencesAsync([FromBody] TenantPreferenceModel tenantPreference)
        {
            try
            {
                var result = await this.tenantManager.CreateTenantPreferencesAysnc(this.User.UID, tenantPreference);
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
        [Route("Preferences/Edit")]
        public async Task<IActionResult> UpdateTenantPreferencesAsync([FromBody] TenantPreferenceModel tenantPreference)
        {
            try
            {
                var result = await this.tenantManager.UpdateTenantPreferencesAsync(this.User.UID, tenantPreference);
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
        [Route("Preferences/{tenantUID}")]
        public async Task<IActionResult> GetTenantPreferencesAsync(string tenantUID)
        {
            try
            {
                var result = await this.tenantManager.GetTenantPreferencesAsync(this.User.UID, tenantUID);
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
        [Route("Preferences/{tenantPreferanceUID}")]
        public async Task<IActionResult> DeleteTenantPreferenceAsync(string tenantPreferanceUID)
        {
            try
            {
                var result = await this.tenantManager.DeleteTenantPreferencesAsync(this.User.UID, tenantPreferanceUID);
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
