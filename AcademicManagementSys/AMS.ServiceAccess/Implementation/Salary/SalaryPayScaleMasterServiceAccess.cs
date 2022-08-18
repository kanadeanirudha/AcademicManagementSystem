using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class SalaryPayScaleMasterServiceAccess : ISalaryPayScaleMasterServiceAccess
    {
        ISalaryPayScaleMasterBA _salaryPayScaleMasterBA = null;
        public SalaryPayScaleMasterServiceAccess()
        {
            _salaryPayScaleMasterBA = new SalaryPayScaleMasterBA();
        }
        public IBaseEntityResponse<SalaryPayScaleMaster> InsertSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            return _salaryPayScaleMasterBA.InsertSalaryPayScaleMaster(item);
        }
        public IBaseEntityResponse<SalaryPayScaleMaster> UpdateSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            return _salaryPayScaleMasterBA.UpdateSalaryPayScaleMaster(item);
        }
        public IBaseEntityResponse<SalaryPayScaleMaster> DeleteSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            return _salaryPayScaleMasterBA.DeleteSalaryPayScaleMaster(item);
        }
        public IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetBySearch(SalaryPayScaleMasterSearchRequest searchRequest)
        {
            return _salaryPayScaleMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<SalaryPayScaleMaster> SelectByID(SalaryPayScaleMaster item)
        {
            return _salaryPayScaleMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetSalaryPayRangeScale(SalaryPayScaleMasterSearchRequest searchRequest)
        {
            return _salaryPayScaleMasterBA.GetSalaryPayRangeScale(searchRequest);
        }
    }
}
