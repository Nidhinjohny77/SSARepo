using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy =GlobalConstant.LandlordPolicy)]
    public class ImageFileController : SSAControllerBase
    {
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IMasterDataManager masterDataManager;
        private readonly IPropertyManager propertyManager;

        public ImageFileController(IWebHostEnvironment hostEnvironment,IMasterDataManager masterDataManager,IPropertyManager propertyManager)
        {
            this.hostEnvironment = hostEnvironment;
            this.masterDataManager = masterDataManager;
            this.propertyManager = propertyManager;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadFile([FromForm]string propertyUID, [FromForm] string fileName, [FromForm] int fileTypeUID)
        {
            var propertyImage = new PropertyImageModel();
            propertyImage.PropertyUID = propertyUID;
            propertyImage.FileName = fileName;
            propertyImage.ImageFileTypeUID = fileTypeUID;
            propertyImage.IsActive = true;
            var result = await this.propertyManager.CreatePropertyImageAsync(this.User.UID, propertyImage);
            if (result.IsFaulted)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            else
            {
                var savedImage = result.Value;
                var fileType=this.masterDataManager.GetAllImageFileTypesAsync().Result.FirstOrDefault(x=>x.UID==savedImage.ImageFileTypeUID);
                var httpRequest = this.HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        if (file.Length > 0)
                        {
                            var filePath = savedImage.UID +"."+ fileType;
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }

        }
    }
}
