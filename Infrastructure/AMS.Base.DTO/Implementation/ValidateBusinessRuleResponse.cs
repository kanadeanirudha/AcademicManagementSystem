using System.Collections.Generic;

namespace AMS.Base.DTO
{
    public class ValidateBusinessRuleResponse : IValidateBusinessRuleResponse
    {
        public ValidateBusinessRuleResponse()
        {
            if (Message == null)
                Message = new List<MessageDTO>();
        }

        public bool Passed
        {
            get;
            set;
        }

        public List<MessageDTO> Message
        {
            get;
            set;
        }
    }
}