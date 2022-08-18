using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralJobStatusServiceAccess : IGeneralJobStatusServiceAccess
    {
        IGeneralJobStatusBA _GeneralJobStatusBA = null;

        public GeneralJobStatusServiceAccess()
        {
            _GeneralJobStatusBA = new GeneralJobStatusBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobStatus> InsertGeneralJobStatus(GeneralJobStatus item)
        {
            return _GeneralJobStatusBA.InsertGeneralJobStatus(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobStatus> UpdateGeneralJobStatus(GeneralJobStatus item)
        {
            return _GeneralJobStatusBA.UpdateGeneralJobStatus(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobStatus> DeleteGeneralJobStatus(GeneralJobStatus item)
        {
            return _GeneralJobStatusBA.DeleteGeneralJobStatus(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralJobStatus table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralJobStatus> GetBySearch(GeneralJobStatusSearchRequest searchRequest)
        {
            return _GeneralJobStatusBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralJobStatus table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralJobStatus> GetBySearchList(GeneralJobStatusSearchRequest searchRequest)
        {
            return _GeneralJobStatusBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralJobStatus table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobStatus> SelectByID(GeneralJobStatus item)
        {
            return _GeneralJobStatusBA.SelectByID(item);
        }
    }
}

