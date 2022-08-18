using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralMovementTypeServiceAccess
    {
        IBaseEntityResponse<GeneralMovementType> InsertGeneralMovementType(GeneralMovementType item);
        IBaseEntityResponse<GeneralMovementType> UpdateGeneralMovementType(GeneralMovementType item);
        IBaseEntityResponse<GeneralMovementType> DeleteGeneralMovementType(GeneralMovementType item);
        IBaseEntityResponse<GeneralMovementType> InsertGeneralMovementTypeRules(GeneralMovementType item);
        
        IBaseEntityCollectionResponse<GeneralMovementType> GetBySearch(GeneralMovementTypeSearchRequest searchRequest);
        IBaseEntityResponse<GeneralMovementType> SelectByID(GeneralMovementType item);
        IBaseEntityCollectionResponse<GeneralMovementType> GetGeneralMovementTypeSearchList(GeneralMovementTypeSearchRequest searchRequest);
    }
}
