

namespace Business.Interface
{
    public interface IImageFileManager
    {

        Task<Result<ImageModel>> UploadImageAsync(string userUID,ImageModel imageModel);
        Task<Result<bool>>DeleteImageAsync(string userUID,ImageModel imageModel);

    }
}
