
namespace Business.Common
{
    public class BusinessException : Exception
    {
        List<ValidationModel> results=new List<ValidationModel>();

        public BusinessException(ValidationModel result)
        {
            this.results.Add(result);

        }
        public BusinessException(List<ValidationModel> results)
        {
            this.results.AddRange( results);
        }

        public List<ValidationModel> Results=>this.results;
    }
}
