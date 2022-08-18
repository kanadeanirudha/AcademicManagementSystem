using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class SalaryAllowanceMasterServiceAccess : ISalaryAllowanceMasterServiceAccess
	{
		ISalaryAllowanceMasterBA _salaryAllowanceMasterBA = null;
		public SalaryAllowanceMasterServiceAccess()
		{
			_salaryAllowanceMasterBA = new SalaryAllowanceMasterBA();
		}
		public IBaseEntityResponse<SalaryAllowanceMaster> InsertSalaryAllowanceMaster(SalaryAllowanceMaster item)
		{
			return _salaryAllowanceMasterBA.InsertSalaryAllowanceMaster(item);
		}
		public IBaseEntityResponse<SalaryAllowanceMaster> UpdateSalaryAllowanceMaster(SalaryAllowanceMaster item)
		{
			return _salaryAllowanceMasterBA.UpdateSalaryAllowanceMaster(item);
		}
		public IBaseEntityResponse<SalaryAllowanceMaster> DeleteSalaryAllowanceMaster(SalaryAllowanceMaster item)
		{
			return _salaryAllowanceMasterBA.DeleteSalaryAllowanceMaster(item);
		}
		public IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetBySearch(SalaryAllowanceMasterSearchRequest searchRequest)
		{
			return _salaryAllowanceMasterBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<SalaryAllowanceMaster> SelectByID(SalaryAllowanceMaster item)
		{
			return _salaryAllowanceMasterBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetAllowanceHeadNameList(SalaryAllowanceMasterSearchRequest searchRequest)
        {
            return _salaryAllowanceMasterBA.GetAllowanceHeadNameList(searchRequest);
        }
	}
}
