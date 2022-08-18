using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class ScholarShipAllocationServiceAccess : IScholarShipAllocationServiceAccess
    {
        IScholarShipAllocationBA _scholarShipAllocationBA = null;
        public ScholarShipAllocationServiceAccess()
        {
            _scholarShipAllocationBA = new ScholarShipAllocationBA();
        }
        public IBaseEntityResponse<ScholarShipAllocation> InsertScholarShipAllocation(ScholarShipAllocation item)
        {
            return _scholarShipAllocationBA.InsertScholarShipAllocation(item);
        }
        public IBaseEntityResponse<ScholarShipAllocation> InsertScholarShipAllocationApproveRequest(ScholarShipAllocation item)
        {
            return _scholarShipAllocationBA.InsertScholarShipAllocationApproveRequest(item);
        }
        public IBaseEntityResponse<ScholarShipAllocation> UpdateScholarShipAllocation(ScholarShipAllocation item)
        {
            return _scholarShipAllocationBA.UpdateScholarShipAllocation(item);
        }
        public IBaseEntityResponse<ScholarShipAllocation> DeleteScholarShipAllocation(ScholarShipAllocation item)
        {
            return _scholarShipAllocationBA.DeleteScholarShipAllocation(item);
        }
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipAllocationBySearch(ScholarShipAllocationSearchRequest searchRequest)
        {
            return _scholarShipAllocationBA.GetScholarShipAllocationBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipAllocationRequestForApproval(ScholarShipAllocationSearchRequest searchRequest)
        {
            return _scholarShipAllocationBA.GetScholarShipAllocationRequestForApproval(searchRequest);
        }
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetStudentListBySearch(ScholarShipAllocationSearchRequest searchRequest)
        {
            return _scholarShipAllocationBA.GetStudentListBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetCourseYearList(ScholarShipAllocationSearchRequest searchRequest)
        {
            return _scholarShipAllocationBA.GetCourseYearList   (searchRequest);
        }
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipList(ScholarShipAllocationSearchRequest searchRequest)
        {
            return _scholarShipAllocationBA.GetScholarShipList(searchRequest);
        }
        public IBaseEntityResponse<ScholarShipAllocation> GetScholarShipAllocationByID(ScholarShipAllocation item)
        {
            return _scholarShipAllocationBA.GetScholarShipAllocationByID(item);
        }
    }
}
