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

        public Result(T data)
        {
            this.originalData = data;
        }

        public Result(Exception ex)
        {
            this.ex = ex;
            this.isFaulted=true;
        }

        public bool IsFaulted=>this.isFaulted;
        public Exception Exception=>this.ex;
        public T Value=>this.originalData;
    }
}
