using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Service.Enum
{
    public enum ErrorCodeEnum
    {
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        InternalError = 500,
        NotImplemented = 501
    }
}
