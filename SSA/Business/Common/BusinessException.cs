
namespace Business.Common
{
    public class BusinessException : Exception
    {
        List<ValidationResult> results=new List<ValidationResult>();

        public BusinessException(ValidationResult result)
        {
            this.results.Add(result);

        }
        public BusinessException(List<ValidationResult> results)
        {
            this.results.AddRange( results);
        }

        public List<ValidationResult> Results=>this.results;
    }
}
