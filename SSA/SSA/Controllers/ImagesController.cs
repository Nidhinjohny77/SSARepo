﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Route("api/Property/[controller]")]
    [ApiController]
    [Authorize(Policy =GlobalConstant.LandlordPolicy)]
    public class ImagesController : SSAControllerBase
    {
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IMasterDataManager masterDataManager;
        private readonly IPropertyManager propertyManager;
        private readonly IFileService fileService;

        public ImagesController(IWebHostEnvironment hostEnvironment,IMasterDataManager masterDataManager,IPropertyManager propertyManager,
            IFileService fileService)
        {
            this.hostEnvironment = hostEnvironment;
            this.masterDataManager = masterDataManager;
            this.propertyManager = propertyManager;
            this.fileService = fileService;
        }

        //[FromForm]string propertyUID, [FromForm] string fileName, [FromForm] int fileTypeUID

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadFile([FromForm] PropertyImageModel propertyImage)
        {
            try
            {
                var httpRequest = this.HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    var file = httpRequest.Form.Files.FirstOrDefault();
                    if (file.Length > 0)
                    {
                        var result = await this.propertyManager.CreatePropertyImageAsync(this.User.UID, propertyImage);
                        if (result.IsFaulted)
                        {
                            return StatusCode(StatusCodes.Status400BadRequest);
                        }
                        else
                        {
                            var savedImage = result.Value;
                            var fileType = this.masterDataManager.GetAllFileTypesAsync().Result.FirstOrDefault(x => x.UID == savedImage.FileTypeUID).Name;
                            var filePath = savedImage.UID + "." + fileType;

                            try
                            {
                                var stream = new MemoryStream();
                                file.CopyTo(stream);
                                stream.Position = 0;
                                var flag = await this.fileService.UploadFileAsync(filePath, stream);
                                if (flag)
                                {
                                    return StatusCode(StatusCodes.Status201Created);
                                }
                            }
                            catch (Exception ex)
                            {
                                var deleteResult=await this.propertyManager.DeletePropertyImageAsync(this.User.UID, savedImage.UID);
                                if (deleteResult.IsFaulted)
                                {
                                    return StatusCode(StatusCodes.Status500InternalServerError,deleteResult.Errors);
                                }
                                else
                                {
                                    StatusCode(StatusCodes.Status304NotModified,new ValidationModel("The upload request failed and the database entry is rolled back."));
                                }
                            }
                        }
        
                    }
                    return StatusCode(StatusCodes.Status304NotModified,new ValidationModel("The request failed as the file content is empty."));
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified, new ValidationModel("The request failed as no files are send to upload."));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet]
        [Route("{imageUID}")]
        [Authorize(Policy = GlobalConstant.AllUsersPolicy)]
        public async Task<IActionResult> GetFile(string imageUID)
        {
            try
            {
                var result = await this.propertyManager.GetPropertyImageAsync(this.User.UID, imageUID);
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
                            var bytes=stream.ToArray();
                            var base64Encoded=Convert.ToBase64String(bytes);
                            var image = new ImageModel();
                            image.FileName = propertyImage.FileName;
                            image.Image = base64Encoded;
                            return Ok(image);
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
