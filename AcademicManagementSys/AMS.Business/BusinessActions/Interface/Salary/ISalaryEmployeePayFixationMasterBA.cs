using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface ISalaryEmployeePayFixationMasterBA
    {
        IBaseEntityResponse<SalaryEmployeePayFixationMaster> InsertSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item);
        IBaseEntityResponse<SalaryEmployeePayFixationMaster> UpdateSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item);
        IBaseEntityResponse<SalaryEmployeePayFixationMaster> DeleteSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item);
        IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearch(SalaryEmployeePayFixationMasterSearchRequest searchRequest);
        IBaseEntityResponse<SalaryEmployeePayFixationMaster> SelectByID(SalaryEmployeePayFixationMaster item);
        IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearchList(SalaryEmployeePayFixationMasterSearchRequest searchRequest);
    }
}
