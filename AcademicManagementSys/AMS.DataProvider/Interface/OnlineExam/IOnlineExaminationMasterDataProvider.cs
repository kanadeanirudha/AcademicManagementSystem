using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.DataProvider
{
	public interface IOnlineExaminationMasterDataProvider
	{
		IBaseEntityResponse<OnlineExaminationMaster> InsertOnlineExaminationMaster(OnlineExaminationMaster item);
		IBaseEntityResponse<OnlineExaminationMaster> UpdateOnlineExaminationMaster(OnlineExaminationMaster item);
		IBaseEntityResponse<OnlineExaminationMaster> DeleteOnlineExaminationMaster(OnlineExaminationMaster item);
		IBaseEntityCollectionResponse<OnlineExaminationMaster> GetOnlineExaminationMasterBySearch(OnlineExaminationMasterSearchRequest searchRequest);
		IBaseEntityResponse<OnlineExaminationMaster> GetOnlineExaminationMasterByID(OnlineExaminationMaster item);

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster
        IBaseEntityCollectionResponse<OnlineExaminationMaster> GetExaminationNameByCourseID(OnlineExaminationMasterSearchRequest searchRequest);
	}
}
