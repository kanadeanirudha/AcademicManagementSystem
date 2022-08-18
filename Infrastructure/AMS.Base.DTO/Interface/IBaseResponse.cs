using System.Collections.Generic;

namespace AMS.Base.DTO
{
    public interface IBaseResponse
    {
        List<MessageDTO> Message
        {
            get;
            set;
        }
    }
}
