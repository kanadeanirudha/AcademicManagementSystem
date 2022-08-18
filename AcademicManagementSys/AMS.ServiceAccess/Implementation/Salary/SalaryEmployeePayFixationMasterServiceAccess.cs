using System;
using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class SalaryEmployeePayFixationMasterServiceAccess : ISalaryEmployeePayFixationMasterServiceAccess
    {
        ISalaryEmployeePayFixationMasterBA _SalaryEmployeePayFixationMasterBA = null;
        public SalaryEmployeePayFixationMasterServiceAccess()
        {
            _SalaryEmployeePayFixationMasterBA = new SalaryEmployeePayFixationMasterBA();
        }
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> InsertSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            return _SalaryEmployeePayFixationMasterBA.InsertSalaryEmployeePayFixationMaster(item);
        }
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> UpdateSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            return _SalaryEmployeePayFixationMasterBA.UpdateSalaryEmployeePayFixationMaster(item);
        }
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> DeleteSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            return _SalaryEmployeePayFixationMasterBA.DeleteSalaryEmployeePayFixationMaster(item);
        }
        public IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearch(SalaryEmployeePayFixationMasterSearchRequest searchRequest)
        {
            return _SalaryEmployeePayFixationMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> SelectByID(SalaryEmployeePayFixationMaster item)
        {
            return _SalaryEmployeePayFixationMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearchList(SalaryEmployeePayFixationMasterSearchRequest searchRequest)
        {
            return _SalaryEmployeePayFixationMasterBA.GetBySearchList(searchRequest);
        }
    }
}
