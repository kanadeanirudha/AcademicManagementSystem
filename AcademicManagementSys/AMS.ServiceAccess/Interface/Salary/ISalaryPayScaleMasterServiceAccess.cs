using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ISalaryPayScaleMasterServiceAccess
    {
        IBaseEntityResponse<SalaryPayScaleMaster> InsertSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityResponse<SalaryPayScaleMaster> UpdateSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityResponse<SalaryPayScaleMaster> DeleteSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetBySearch(SalaryPayScaleMasterSearchRequest searchRequest);
        IBaseEntityResponse<SalaryPayScaleMaster> SelectByID(SalaryPayScaleMaster item);
        IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetSalaryPayRangeScale(SalaryPayScaleMasterSearchRequest searchRequest);
    }
}
