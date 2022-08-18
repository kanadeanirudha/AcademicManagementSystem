using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
namespace AMS.ServiceAccess
{
   public class GeneralSessionMasterServiceAccess: IGeneralSessionMasterServiceAccess
    {
       IGeneralSessionMasterBA _generalSessionMasterBA = null;

        public GeneralSessionMasterServiceAccess()
        {
            _generalSessionMasterBA = new GeneralSessionMasterBA();
        }
         /// <summary>
         /// Service access of create new record of General Session Master.
         /// </summary>
         /// <param name="item"></param>
         /// <returns></returns>
        public IBaseEntityResponse<GeneralSessionMaster> InsertGeneralSessionMaster(GeneralSessionMaster item)
        {
            return _generalSessionMasterBA.InsertGeneralSessionMaster(item);
        }

         /// <summary>
         /// Service access of update a specific record of General Session Master.
         /// </summary>
         /// <param name="item"></param>
         /// <returns></returns>
        public IBaseEntityResponse<GeneralSessionMaster> UpdateGeneralSessionMaster(GeneralSessionMaster item)
        {
            return _generalSessionMasterBA.UpdateGeneralSessionMaster(item);
        }

         /// <summary>
         /// Service access of delete a selected record from General Session Master.
         /// </summary>
         /// <param name="item"></param>
         /// <returns></returns>
        public IBaseEntityResponse<GeneralSessionMaster> DeleteGeneralSessionMaster(GeneralSessionMaster item)
        {
            return _generalSessionMasterBA.DeleteGeneralSessionMaster(item);
        }

         /// <summary>
         /// /// Service access of select all record from General Session Master table with search parameters.
         /// </summary>
         /// <param name="searchRequest"></param>
         /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralSessionMaster> GetBySearch(GeneralSessionMasterSearchRequest searchRequest)
        {
            return _generalSessionMasterBA.GetBySearch(searchRequest);
        }
       
           
         /// <summary>
         /// /// Service access of select all record from General Session Master table with search parameters.
         /// </summary>
         /// <param name="searchRequest"></param>
         /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralSessionMaster> GetBySearchList(GeneralSessionMasterSearchRequest searchRequest)
        {
            return _generalSessionMasterBA.GetBySearchList(searchRequest);
        }
         /// <summary>
         /// Service access of select a record from General Session Master table by ID
         /// </summary>
         /// <param name="item"></param>
         /// <returns></returns>
        public IBaseEntityResponse<GeneralSessionMaster> SelectByID(GeneralSessionMaster item)
        {
            return _generalSessionMasterBA.SelectByID(item);
        }

       //Used in Online Exam
        public IBaseEntityCollectionResponse<GeneralSessionMaster> GetSession(GeneralSessionMasterSearchRequest searchRequest)
        {
            return _generalSessionMasterBA.GetSession(searchRequest);
        }
    }
}
