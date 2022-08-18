using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ISalaryEmployeePayFixationMasterDataProvider
    {
        IBaseEntityResponse<SalaryEmployeePayFixationMaster> InsertSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item);
        IBaseEntityResponse<SalaryEmployeePayFixationMaster> UpdateSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item);
        IBaseEntityResponse<SalaryEmployeePayFixationMaster> DeleteSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item);
        IBaseEntityResponse<SalaryEmployeePayFixationMaster> GetSalaryEmployeePayFixationMasterByID(SalaryEmployeePayFixationMaster item);
        IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearchList(SalaryEmployeePayFixationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearch(SalaryEmployeePayFixationMasterSearchRequest searchRequest);
    }
}
