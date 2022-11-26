using Business.Common;

namespace SSA.Utlities
{
    public static class ResultExtensions
    {
        public static ObjectResult ToResult<T>(this Result<T> result)
        {
            if (result == null)
            {
                return new ObjectResult("Unable to get a proper response.")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            if (result.IsFaulted)
            {
                if(result.Exception != null)
                {
                    if(result.Exception is BusinessException)
                    {
                        var bEx=result.Exception as BusinessException;
                        return new ObjectResult(bEx.Results)
                        {
                            StatusCode = StatusCodes.Status400BadRequest
                        };  
                    }
                    else
                    {
                        return new ObjectResult(result.Exception.Message)
                        {
                            StatusCode = StatusCodes.Status500InternalServerError
                        };
                    }
                }
                else
                {
                    return new ObjectResult("Unknown error.")
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                }
            }
            else
            {
                return new ObjectResult(result)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }
    }
}
