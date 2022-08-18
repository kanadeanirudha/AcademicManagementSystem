using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class SalaryDeductionMasterServiceAccess : ISalaryDeductionMasterServiceAccess
	{
        ISalaryDeductionMasterBA _SalaryDeductionMasterBA = null;
		public SalaryDeductionMasterServiceAccess()
		{
			_SalaryDeductionMasterBA = new SalaryDeductionMasterBA();
		}
		public IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionMaster(SalaryDeductionMaster item)
		{
			return _SalaryDeductionMasterBA.InsertSalaryDeductionMaster(item);
		}
		public IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionMaster(SalaryDeductionMaster item)
		{
			return _SalaryDeductionMasterBA.UpdateSalaryDeductionMaster(item);
		}
		public IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionMaster(SalaryDeductionMaster item)
		{
			return _SalaryDeductionMasterBA.DeleteSalaryDeductionMaster(item);
		}
		public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetBySearch(SalaryDeductionMasterSearchRequest searchRequest)
		{
			return _SalaryDeductionMasterBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<SalaryDeductionMaster> SelectByID(SalaryDeductionMaster item)
		{
			return _SalaryDeductionMasterBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetAllowanceHeadNameList(SalaryDeductionMasterSearchRequest searchRequest)
        {
            return _SalaryDeductionMasterBA.GetAllowanceHeadNameList(searchRequest);
        }
	}
}
