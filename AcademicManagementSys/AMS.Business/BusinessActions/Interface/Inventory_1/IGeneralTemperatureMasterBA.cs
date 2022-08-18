using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralTemperatureMasterBA
    {
        IBaseEntityResponse<GeneralTemperatureMaster> InsertGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityResponse<GeneralTemperatureMaster> UpdateGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityResponse<GeneralTemperatureMaster> DeleteGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetBySearch(GeneralTemperatureMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterSearchList(GeneralTemperatureMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTemperatureMaster> SelectByID(GeneralTemperatureMaster item);
    }
}

