using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class EntranceExamInfrastructureDetailServiceAccess : IEntranceExamInfrastructureDetailServiceAccess
    {
        IEntranceExamInfrastructureDetailBA _entranceExamInfrastructureDetailBA = null;        

        public EntranceExamInfrastructureDetailServiceAccess()
        {
            _entranceExamInfrastructureDetailBA = new EntranceExamInfrastructureDetailBA();
        }

        // EntranceExamAvailableCentres Table Property.
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            return _entranceExamInfrastructureDetailBA.InsertEntranceExamAvailableCentres(item);
        }
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            return _entranceExamInfrastructureDetailBA.UpdateEntranceExamAvailableCentres(item);
        }
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            return _entranceExamInfrastructureDetailBA.DeleteEntranceExamAvailableCentres(item);
        }
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            return _entranceExamInfrastructureDetailBA.GetEntranceExamAvailableCentresBySearch(searchRequest);
        }
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> SelectEntranceExamAvailableCentresByID(EntranceExamInfrastructureDetail item)
        {
            return _entranceExamInfrastructureDetailBA.SelectEntranceExamAvailableCentresByID(item);
        }


        //Service Access for Item Name Search List
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            return _entranceExamInfrastructureDetailBA.GetEntranceExamAvailableCentresSearchList(searchRequest);
        }


        // EntranceExamInfrastructureDetail Table Property.
        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            return _entranceExamInfrastructureDetailBA.InsertEntranceExamInfrastructureDetail(item);
        }
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            return _entranceExamInfrastructureDetailBA.UpdateEntranceExamInfrastructureDetail(item);
        }
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            return _entranceExamInfrastructureDetailBA.DeleteEntranceExamInfrastructureDetail(item);
        }
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            return _entranceExamInfrastructureDetailBA.GetEntranceExamInfrastructureDetailBySearch(searchRequest);
        }
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> SelectEntranceExamInfrastructureDetailByID(EntranceExamInfrastructureDetail item)
        {
            return _entranceExamInfrastructureDetailBA.SelectEntranceExamInfrastructureDetailByID(item);
        }


        //Service Access for Item Name Search List
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            return _entranceExamInfrastructureDetailBA.GetEntranceExamInfrastructureDetailSearchList(searchRequest);
        }
    }
}
