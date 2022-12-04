using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common
{
    public class Result<T>
    {
        T originalData;
        Exception ex;
        bool isFaulted=false;
        List<ValidationResult> results = null;

        public Result(T data)
        {
            this.originalData = data;
        }

        public Result(Exception ex)
        {
            this.ex = ex;
            this.isFaulted=true;
            results = new List<ValidationResult>();
            if(ex is BusinessException)
            {
                var bex= ex as BusinessException;
                this.results.AddRange(bex.Results);
            }
            else
            {
                this.results.Add(new ValidationResult(ex.Message));
            }
        }

        public bool IsFaulted=>this.isFaulted;
        public Exception Exception=>this.ex;
        public T Value=>this.originalData;
        public List<ValidationResult> Errors => this.results;
    }
}
