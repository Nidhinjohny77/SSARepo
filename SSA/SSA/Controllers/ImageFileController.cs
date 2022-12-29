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
        private readonly IPropertyManager propertyManager;
        private readonly IMapper mapper;

        public ImageFileController(IWebHostEnvironment hostEnvironment,IPropertyManager propertyManager,IMapper mapper)
        {
            this.hostEnvironment = hostEnvironment;
            this.propertyManager = propertyManager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Uplaod")]
        public async Task<IActionResult> UploadFile([FromBody]PropertyImageModel propertyImage)
        {
            var result = await this.propertyManager.CreatePropertyImageAsync(this.User.UID, propertyImage);
            if (result.IsFaulted)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            else
            {
                var savedImage = result.Value;
                var httpRequest = this.HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        if (file.Length > 0)
                        {
                            var filePath = savedImage.UID + savedImage.FileType;
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
