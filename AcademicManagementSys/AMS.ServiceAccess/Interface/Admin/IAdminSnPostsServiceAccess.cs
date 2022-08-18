﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
   public interface IAdminSnPostsServiceAccess
    {
        IBaseEntityResponse<AdminSnPosts> InsertAdminSnPosts(AdminSnPosts item);

        IBaseEntityResponse<AdminSnPosts> UpdateAdminSnPosts(AdminSnPosts item);

        IBaseEntityResponse<AdminSnPosts> DeleteAdminSnPosts(AdminSnPosts item);

        IBaseEntityCollectionResponse<AdminSnPosts> GetBySearch(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminSnPosts> GetBySearchCentreCodeAndDepartmentIDForSPD(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminSnPosts> GetBySearchCentreCodeAndDepartmentID(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityResponse<AdminSnPosts> SelectByID(AdminSnPosts item);
    }
}
