using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class SalaryAllowanceCurrentSettingServiceAccess : ISalaryAllowanceCurrentSettingServiceAccess
    {
        ISalaryAllowanceCurrentSettingBA _salaryAllowanceCurrentSettingBA = null;
        public SalaryAllowanceCurrentSettingServiceAccess()
        {
            _salaryAllowanceCurrentSettingBA = new SalaryAllowanceCurrentSettingBA();
        }
        public IBaseEntityResponse<SalaryAllowanceCurrentSetting> InsertSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item)
        {
            return _salaryAllowanceCurrentSettingBA.InsertSalaryAllowanceCurrentSetting(item);
        }
        public IBaseEntityResponse<SalaryAllowanceCurrentSetting> UpdateSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item)
        {
            return _salaryAllowanceCurrentSettingBA.UpdateSalaryAllowanceCurrentSetting(item);
        }
        public IBaseEntityResponse<SalaryAllowanceCurrentSetting> DeleteSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item)
        {
            return _salaryAllowanceCurrentSettingBA.DeleteSalaryAllowanceCurrentSetting(item);
        }
        public IBaseEntityCollectionResponse<SalaryAllowanceCurrentSetting> GetBySearch(SalaryAllowanceCurrentSettingSearchRequest searchRequest)
        {
            return _salaryAllowanceCurrentSettingBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<SalaryAllowanceCurrentSetting> SelectByID(SalaryAllowanceCurrentSetting item)
        {
            return _salaryAllowanceCurrentSettingBA.SelectByID(item);
        }
    }
}
