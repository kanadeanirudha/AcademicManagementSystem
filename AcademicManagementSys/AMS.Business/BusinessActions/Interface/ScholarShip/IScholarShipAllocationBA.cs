using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IScholarShipAllocationBA
    {
        IBaseEntityResponse<ScholarShipAllocation> InsertScholarShipAllocation(ScholarShipAllocation item);
        IBaseEntityResponse<ScholarShipAllocation> InsertScholarShipAllocationApproveRequest(ScholarShipAllocation item);
        IBaseEntityResponse<ScholarShipAllocation> UpdateScholarShipAllocation(ScholarShipAllocation item);
        IBaseEntityResponse<ScholarShipAllocation> DeleteScholarShipAllocation(ScholarShipAllocation item);
        IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipAllocationBySearch(ScholarShipAllocationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipAllocationRequestForApproval(ScholarShipAllocationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ScholarShipAllocation> GetStudentListBySearch(ScholarShipAllocationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ScholarShipAllocation> GetCourseYearList(ScholarShipAllocationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipList(ScholarShipAllocationSearchRequest searchRequest);
        IBaseEntityResponse<ScholarShipAllocation> GetScholarShipAllocationByID(ScholarShipAllocation item);
    }
}
