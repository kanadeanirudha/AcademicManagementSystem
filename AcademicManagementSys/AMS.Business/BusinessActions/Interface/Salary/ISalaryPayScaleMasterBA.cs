using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface ISalaryPayScaleMasterBA
    {
        IBaseEntityResponse<SalaryPayScaleMaster> InsertSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityResponse<SalaryPayScaleMaster> UpdateSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityResponse<SalaryPayScaleMaster> DeleteSalaryPayScaleMaster(SalaryPayScaleMaster item);
        IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetBySearch(SalaryPayScaleMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetSalaryPayRangeScale(SalaryPayScaleMasterSearchRequest searchRequest);
        IBaseEntityResponse<SalaryPayScaleMaster> SelectByID(SalaryPayScaleMaster item);
    }
}
