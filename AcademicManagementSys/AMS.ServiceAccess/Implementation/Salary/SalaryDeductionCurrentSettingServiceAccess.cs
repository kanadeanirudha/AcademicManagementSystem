using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class SalaryDeductionCurrentSettingServiceAccess : ISalaryDeductionCurrentSettingServiceAccess
    {
        ISalaryDeductionCurrentSettingBA _SalaryDeductionCurrentSettingBA = null;
        public SalaryDeductionCurrentSettingServiceAccess()
        {
            _SalaryDeductionCurrentSettingBA = new SalaryDeductionCurrentSettingBA();
        }
        public IBaseEntityResponse<SalaryDeductionCurrentSetting> InsertSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
        {
            return _SalaryDeductionCurrentSettingBA.InsertSalaryDeductionCurrentSetting(item);
        }
        public IBaseEntityResponse<SalaryDeductionCurrentSetting> UpdateSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
        {
            return _SalaryDeductionCurrentSettingBA.UpdateSalaryDeductionCurrentSetting(item);
        }
        public IBaseEntityResponse<SalaryDeductionCurrentSetting> DeleteSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
        {
            return _SalaryDeductionCurrentSettingBA.DeleteSalaryDeductionCurrentSetting(item);
        }
        public IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> GetBySearch(SalaryDeductionCurrentSettingSearchRequest searchRequest)
        {
            return _SalaryDeductionCurrentSettingBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<SalaryDeductionCurrentSetting> SelectByID(SalaryDeductionCurrentSetting item)
        {
            return _SalaryDeductionCurrentSettingBA.SelectByID(item);
        }
    }
}
