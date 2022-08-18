using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralUnitsServiceAccess
    {
        IBaseEntityResponse<GeneralUnits> InsertGeneralUnits(GeneralUnits item);
        IBaseEntityResponse<GeneralUnits> UpdateGeneralUnits(GeneralUnits item);
        IBaseEntityResponse<GeneralUnits> DeleteGeneralUnits(GeneralUnits item);
        IBaseEntityCollectionResponse<GeneralUnits> GetBySearch(GeneralUnitsSearchRequest searchRequest);
        IBaseEntityResponse<GeneralUnits> SelectByID(GeneralUnits item);
        IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsSearchList(GeneralUnitsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsByCentreCode(GeneralUnitsSearchRequest searchRequest);
    }
}
