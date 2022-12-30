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
        private readonly IFileService fileService;

        public ImageFileController(IWebHostEnvironment hostEnvironment,IMasterDataManager masterDataManager,IPropertyManager propertyManager,
            IFileService fileService)
        {
            this.hostEnvironment = hostEnvironment;
            this.masterDataManager = masterDataManager;
            this.propertyManager = propertyManager;
            this.fileService = fileService;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadFile([FromForm]string propertyUID, [FromForm] string fileName, [FromForm] int fileTypeUID)
        {
            try
            {
                var httpRequest = this.HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    var file = httpRequest.Form.Files.FirstOrDefault();
                    if (file.Length > 0)
                    {
                        var propertyImage = new PropertyImageModel();
                        propertyImage.PropertyUID = propertyUID;
                        propertyImage.FileName = fileName;
                        propertyImage.FileTypeUID = fileTypeUID;
                        propertyImage.IsActive = true;
                        var result = await this.propertyManager.CreatePropertyImageAsync(this.User.UID, propertyImage);
                        if (result.IsFaulted)
                        {
                            return StatusCode(StatusCodes.Status400BadRequest);
                        }
                        else
                        {
                            var savedImage = result.Value;
                            var fileType = this.masterDataManager.GetAllFileTypesAsync().Result.FirstOrDefault(x => x.UID == savedImage.FileTypeUID);
                            var filePath = savedImage.UID + "." + fileType;
                            var stream = new MemoryStream();
                            file.CopyTo(stream);
                            var flag = await this.fileService.UploadFileAsync(filePath, stream);
                            if (flag)
                            {
                                return StatusCode(StatusCodes.Status201Created);
                            }
                        }
        
                    }
                    return StatusCode(StatusCodes.Status304NotModified);
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet]
        [Route("{propertyImageUID}")]
        public async Task<IActionResult> GetFile([FromBody] string propertyImageUID)
        {
            try
            {
                var result = await this.propertyManager.GetPropertyImageAsync(this.User.UID, propertyImageUID);
                if (result.IsFaulted)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                else
                {
                    var propertyImage=result.Value;
                    if (propertyImage != null)
                    {
                        var fileType = this.masterDataManager.GetAllFileTypesAsync().Result.FirstOrDefault(x=>x.UID==propertyImage.FileTypeUID).Name;
                        var filePath = propertyImage.UID + "." + fileType;
                        var stream = await this.fileService.GetFileAsync(filePath);
                        if (stream != null)
                        {
                            var fileContentType = "image/" + fileType;
                            return File(stream, fileContentType);
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status204NoContent);
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent);
                    }

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
