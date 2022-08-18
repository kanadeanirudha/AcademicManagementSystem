using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralEducationMasterDataProvider
    {
        IBaseEntityCollectionResponse<GeneralEducationMaster> GetGeneralEducationMasterBySearch(GeneralEducationMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralEducationMaster> GetGeneralEducationMasterByID(GeneralEducationMaster item);

        IBaseEntityResponse<GeneralEducationMaster> InsertGeneralEducationMaster(GeneralEducationMaster item);

        IBaseEntityResponse<GeneralEducationMaster> UpdateGeneralEducationMaster(GeneralEducationMaster item);

        IBaseEntityResponse<GeneralEducationMaster> DeleteGeneralEducationMaster(GeneralEducationMaster item);

        IBaseEntityCollectionResponse<GeneralEducationMaster> GetByEducationTypeID(GeneralEducationMasterSearchRequest searchRequest);
        
    }
}
