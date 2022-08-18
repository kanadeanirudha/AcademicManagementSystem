using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralJobProfileServiceAccess : IGeneralJobProfileServiceAccess
    {
        IGeneralJobProfileBA _GeneralJobProfileBA = null;

        public GeneralJobProfileServiceAccess()
        {
            _GeneralJobProfileBA = new GeneralJobProfileBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobProfile> InsertGeneralJobProfile(GeneralJobProfile item)
        {
            return _GeneralJobProfileBA.InsertGeneralJobProfile(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobProfile> UpdateGeneralJobProfile(GeneralJobProfile item)
        {
            return _GeneralJobProfileBA.UpdateGeneralJobProfile(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobProfile> DeleteGeneralJobProfile(GeneralJobProfile item)
        {
            return _GeneralJobProfileBA.DeleteGeneralJobProfile(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralJobProfile table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralJobProfile> GetBySearch(GeneralJobProfileSearchRequest searchRequest)
        {
            return _GeneralJobProfileBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralJobProfile table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralJobProfile> GetBySearchList(GeneralJobProfileSearchRequest searchRequest)
        {
            return _GeneralJobProfileBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralJobProfile table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobProfile> SelectByID(GeneralJobProfile item)
        {
            return _GeneralJobProfileBA.SelectByID(item);
        }
    }
}

