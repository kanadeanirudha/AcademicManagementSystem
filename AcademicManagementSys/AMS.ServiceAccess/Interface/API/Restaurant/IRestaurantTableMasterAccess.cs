
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IRestaurantTableMasterServiceAccess
    {
        //IBaseEntityResponse<RestaurantTableMaster> InventoryCounterLogin(RestaurantTableMaster item);
        //IBaseEntityResponse<RestaurantTableMaster> PostOnline(RestaurantTableMaster item);
        //IBaseEntityResponse<RestaurantTableMaster> GetLocalInvoiceNo(RestaurantTableMaster item);
        IBaseEntityCollectionResponse<RestaurantTableMaster> RestaurantTableGetOnline(RestaurantTableMasterSearchRequest searchRequest);

        //Methods for RestaurantTableMaster form
        IBaseEntityResponse<RestaurantTableMaster> InsertRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityResponse<RestaurantTableMaster> UpdateRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityResponse<RestaurantTableMaster> DeleteRestaurantTableMaster(RestaurantTableMaster item);
        IBaseEntityCollectionResponse<RestaurantTableMaster> GetBySearch(RestaurantTableMasterSearchRequest searchRequest);
        IBaseEntityResponse<RestaurantTableMaster> SelectByID(RestaurantTableMaster item);
        IBaseEntityCollectionResponse<RestaurantTableMaster> GetRestaurantCategory(RestaurantTableMasterSearchRequest searchRequest);

    }
}
