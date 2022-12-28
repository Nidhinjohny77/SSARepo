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

        [HttpGet]
        [Route("Currencies")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            try
            {
                var data = await this.dataManager.GetAllCurrenciesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var data = await this.dataManager.GetAllItemsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("FurnishTypes")]
        public async Task<IActionResult> GetAllFurnishTypes()
        {
            try
            {
                var data = await this.dataManager.GetAllFurnishTypesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("PropertyTypes")]
        public async Task<IActionResult> GetAllPropertyTypes()
        {
            try
            {
                var data = await this.dataManager.GetAllPropertyTypesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("TenancyTypes")]
        public async Task<IActionResult> GetAllTenancyTypes()
        {
            try
            {
                var data = await this.dataManager.GetAllTenancyTypesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Universities")]
        public async Task<IActionResult> GetAllUniversities()
        {
            try
            {
                var data = await this.dataManager.GetAllUniversitiesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
