using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ISalaryPayScaleMasterDataProvider
    {
        IBaseEntityResponse<SalaryPayScaleMaster> InsertSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityResponse<SalaryPayScaleMaster> UpdateSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityResponse<SalaryPayScaleMaster> DeleteSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetSalaryPayScaleMasterBySearch(SalaryPayScaleMasterSearchRequest searchRequest);
        IBaseEntityResponse<SalaryPayScaleMaster> GetSalaryPayScaleMasterByID(SalaryPayScaleMaster item);
        IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetSalaryPayRangeScale(SalaryPayScaleMasterSearchRequest searchRequest);
    }
}
