using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class SalaryGradePayMasterServiceAccess : ISalaryGradePayMasterServiceAccess
	{
		ISalaryGradePayMasterBA _salaryGradePayMasterBA = null;
		public SalaryGradePayMasterServiceAccess()
		{
			_salaryGradePayMasterBA = new SalaryGradePayMasterBA();
		}
		public IBaseEntityResponse<SalaryGradePayMaster> InsertSalaryGradePayMaster(SalaryGradePayMaster item)
		{
			return _salaryGradePayMasterBA.InsertSalaryGradePayMaster(item);
		}
		public IBaseEntityResponse<SalaryGradePayMaster> UpdateSalaryGradePayMaster(SalaryGradePayMaster item)
		{
			return _salaryGradePayMasterBA.UpdateSalaryGradePayMaster(item);
		}
		public IBaseEntityResponse<SalaryGradePayMaster> DeleteSalaryGradePayMaster(SalaryGradePayMaster item)
		{
			return _salaryGradePayMasterBA.DeleteSalaryGradePayMaster(item);
		}
		public IBaseEntityCollectionResponse<SalaryGradePayMaster> GetBySearch(SalaryGradePayMasterSearchRequest searchRequest)
		{
			return _salaryGradePayMasterBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<SalaryGradePayMaster> SelectByID(SalaryGradePayMaster item)
		{
			return _salaryGradePayMasterBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<SalaryGradePayMaster> GetListGradePayAmount(SalaryGradePayMasterSearchRequest searchRequest)
        {
            return _salaryGradePayMasterBA.GetListGradePayAmount(searchRequest);
        }
	}
}
