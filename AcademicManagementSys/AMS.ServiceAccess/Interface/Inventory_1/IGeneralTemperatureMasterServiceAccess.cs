using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralTemperatureMasterServiceAccess
    {
        IBaseEntityResponse<GeneralTemperatureMaster> InsertGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityResponse<GeneralTemperatureMaster> UpdateGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityResponse<GeneralTemperatureMaster> DeleteGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetBySearch(GeneralTemperatureMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTemperatureMaster> SelectByID(GeneralTemperatureMaster item);
        IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterSearchList(GeneralTemperatureMasterSearchRequest searchRequest);
    }
}
