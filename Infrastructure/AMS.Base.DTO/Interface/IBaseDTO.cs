using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.Base.DTO
{
    public interface IBaseDTO
    {
        string Locale
        {
            get;
            set;
        }

        string ConnectionString
        {
            get;
            set;
        }

        int ErrorCode { get; set; }
    }
}
