using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;
namespace AMS.ServiceAccess
{
	public class OnlineExaminationMasterServiceAccess : IOnlineExaminationMasterServiceAccess
	{
		IOnlineExaminationMasterBA _OnlineExaminationMasterBA = null;
		public OnlineExaminationMasterServiceAccess()
		{
			_OnlineExaminationMasterBA = new OnlineExaminationMasterBA();
		}
		public IBaseEntityResponse<OnlineExaminationMaster> InsertOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			return _OnlineExaminationMasterBA.InsertOnlineExaminationMaster(item);
		}
		public IBaseEntityResponse<OnlineExaminationMaster> UpdateOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			return _OnlineExaminationMasterBA.UpdateOnlineExaminationMaster(item);
		}
		public IBaseEntityResponse<OnlineExaminationMaster> DeleteOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			return _OnlineExaminationMasterBA.DeleteOnlineExaminationMaster(item);
		}
		public IBaseEntityCollectionResponse<OnlineExaminationMaster> GetBySearch(OnlineExaminationMasterSearchRequest searchRequest)
		{
			return _OnlineExaminationMasterBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<OnlineExaminationMaster> SelectByID(OnlineExaminationMaster item)
		{
			return _OnlineExaminationMasterBA.SelectByID(item);
		}

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster
        public IBaseEntityCollectionResponse<OnlineExaminationMaster> GetExaminationNameByCourseID(OnlineExaminationMasterSearchRequest searchRequest)
        {
            return _OnlineExaminationMasterBA.GetExaminationNameByCourseID(searchRequest);
        }
	}
}
