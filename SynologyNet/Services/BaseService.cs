using SynologyNet.Exceptions;
using SynologyNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    public class BaseService
    {
        protected virtual void CheckErrorCode<TErrorCode>(BaseResponse response)
            where TErrorCode : Enum 
        {
            if (response.Error == null)
                return;

            var error = (TErrorCode)(object) response.Error.Code;

            if (Enum.IsDefined(typeof(TErrorCode), error))
                throw new SynologyException(error.GetDisplayName());

            if (typeof(TErrorCode) != typeof(CommonErrorCode))
                CheckErrorCode<CommonErrorCode>(response);
        }
    }
}
