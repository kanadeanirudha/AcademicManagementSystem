﻿using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public interface IOnlineExaminationMasterServiceAccess
	{
		IBaseEntityResponse<OnlineExaminationMaster> InsertOnlineExaminationMaster(OnlineExaminationMaster item);
		IBaseEntityResponse<OnlineExaminationMaster> UpdateOnlineExaminationMaster(OnlineExaminationMaster item);
		IBaseEntityResponse<OnlineExaminationMaster> DeleteOnlineExaminationMaster(OnlineExaminationMaster item);
		IBaseEntityCollectionResponse<OnlineExaminationMaster> GetBySearch(OnlineExaminationMasterSearchRequest searchRequest);
		IBaseEntityResponse<OnlineExaminationMaster> SelectByID(OnlineExaminationMaster item);

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster
        IBaseEntityCollectionResponse<OnlineExaminationMaster> GetExaminationNameByCourseID(OnlineExaminationMasterSearchRequest searchRequest); 
	}
}
