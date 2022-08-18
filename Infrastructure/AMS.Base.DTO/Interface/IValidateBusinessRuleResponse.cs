namespace AMS.Base.DTO
{
   public interface IValidateBusinessRuleResponse:IBaseResponse
    {
       bool Passed { get; set; }           
    }
}
