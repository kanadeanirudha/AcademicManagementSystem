using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralRelationshipTypeMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> InsertGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// Service access interface of update record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> UpdateGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// Service access interface of dalete record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> DeleteGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// Service access interface of select all record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetBySearch(GeneralRelationshipTypeMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetBySearchList(GeneralRelationshipTypeMasterSearchRequest searchRequest);


        

        ///// <summary>
        ///// Service access interface of select all record of GeneralRelationshipTypeMaster.
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetBySearchList(GeneralRelationshipTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRelationshipTypeMaster> SelectByID(GeneralRelationshipTypeMaster item);
    }
}
