using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralPeriodTypeMasterServiceAccess
    {
        IBaseEntityResponse<GeneralPeriodTypeMaster> InsertGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityResponse<GeneralPeriodTypeMaster> UpdateGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityResponse<GeneralPeriodTypeMaster> DeleteGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetBySearch(GeneralPeriodTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetBySearchList(GeneralPeriodTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPeriodTypeMaster> SelectByID(GeneralPeriodTypeMaster item);
    }
}
