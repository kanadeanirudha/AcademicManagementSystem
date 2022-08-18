
using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class RestaurantTableMasterServiceAccess : IRestaurantTableMasterServiceAccess 
    {
        IRestaurantTableMasterBA _RestaurantTableMasterBA = null;

        public RestaurantTableMasterServiceAccess()
        {
            _RestaurantTableMasterBA = new RestaurantTableMasterBA();
        }

        public IBaseEntityCollectionResponse<RestaurantTableMaster> RestaurantTableGetOnline(RestaurantTableMasterSearchRequest searchRequest)
        {
            return _RestaurantTableMasterBA.RestaurantTableGetOnline (searchRequest);
        }
        //Methods for RestaurantTableMaster form
        public IBaseEntityResponse<RestaurantTableMaster> InsertRestaurantTableMaster(RestaurantTableMaster item)
        {
            return _RestaurantTableMasterBA.InsertRestaurantTableMaster(item);
        }
        public IBaseEntityResponse<RestaurantTableMaster> UpdateRestaurantTableMaster(RestaurantTableMaster item)
        {
            return _RestaurantTableMasterBA.UpdateRestaurantTableMaster(item);
        }
        public IBaseEntityResponse<RestaurantTableMaster> DeleteRestaurantTableMaster(RestaurantTableMaster item)
        {
            return _RestaurantTableMasterBA.DeleteRestaurantTableMaster(item);
        }
        public IBaseEntityCollectionResponse<RestaurantTableMaster> GetBySearch(RestaurantTableMasterSearchRequest searchRequest)
        {
            return _RestaurantTableMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<RestaurantTableMaster> SelectByID(RestaurantTableMaster item)
        {
            return _RestaurantTableMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<RestaurantTableMaster> GetRestaurantCategory(RestaurantTableMasterSearchRequest searchRequest)
        {
            return _RestaurantTableMasterBA.GetRestaurantCategory(searchRequest);
        }

    }
}
