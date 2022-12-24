using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy =GlobalConstant.AllUsersPolicy)]
    public class MasterDataController : SSAControllerBase
    {
        private readonly IMasterDataManager dataManager;

        public MasterDataController(IMasterDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        [Route("Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var data=await this.dataManager.GetAllRolesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var data = await this.dataManager.GetAllCountriesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
