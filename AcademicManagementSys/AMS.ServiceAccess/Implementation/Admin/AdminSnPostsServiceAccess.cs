using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;

namespace AMS.ServiceAccess 
{
    public class AdminSnPostsServiceAccess : IAdminSnPostsServiceAccess
    {
         IAdminSnPostsBA _adminSnPostsBA = null;

         public AdminSnPostsServiceAccess()
        {
            _adminSnPostsBA = new AdminSnPostsBA();
        }

         public IBaseEntityResponse<AdminSnPosts> InsertAdminSnPosts(AdminSnPosts item)
        {
            return _adminSnPostsBA.InsertAdminSnPosts(item);
        }

         public IBaseEntityResponse<AdminSnPosts> UpdateAdminSnPosts(AdminSnPosts item)
        {
            return _adminSnPostsBA.UpdateAdminSnPosts(item);
        }

         public IBaseEntityResponse<AdminSnPosts> DeleteAdminSnPosts(AdminSnPosts item)
        {
            return _adminSnPostsBA.DeleteAdminSnPosts(item);
        }

         public IBaseEntityCollectionResponse<AdminSnPosts> GetBySearch(AdminSnPostsSearchRequest searchRequest)
        {
            return _adminSnPostsBA.GetBySearch(searchRequest);
        }

         public IBaseEntityCollectionResponse<AdminSnPosts> GetBySearchCentreCodeAndDepartmentID(AdminSnPostsSearchRequest searchRequest)
         {
             return _adminSnPostsBA.GetBySearchCentreCodeAndDepartmentID(searchRequest);
         }

         public IBaseEntityCollectionResponse<AdminSnPosts> GetBySearchCentreCodeAndDepartmentIDForSPD(AdminSnPostsSearchRequest searchRequest)//SPN-SnactionPostDescription
         {
             return _adminSnPostsBA.GetBySearchCentreCodeAndDepartmentIDForSPD(searchRequest);
         }

         public IBaseEntityResponse<AdminSnPosts> SelectByID(AdminSnPosts item)
        {
            return _adminSnPostsBA.SelectByID(item);
        }
    }
}
