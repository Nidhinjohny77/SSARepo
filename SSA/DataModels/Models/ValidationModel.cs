
namespace DataModels.Models
{
    public class ValidationModel
    {
        private const string GenericErrorCode = "999999";
        public ValidationModel()
        {

        }

        public ValidationModel(string message)
        {
            this.ErrorCode = GenericErrorCode;
            this.Message = message;
        }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
