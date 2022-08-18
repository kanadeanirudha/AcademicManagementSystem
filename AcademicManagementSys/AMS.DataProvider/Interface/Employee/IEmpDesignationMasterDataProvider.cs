using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IEmpDesignationMasterDataProvider
    {
        IBaseEntityCollectionResponse<EmpDesignationMaster> GetEmpDesignationMasterBySearch(EmpDesignationMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<EmpDesignationMaster> GetEmpDesignationMasterBySearchList(EmpDesignationMasterSearchRequest searchRequest);

        IBaseEntityResponse<EmpDesignationMaster> GetEmpDesignationMasterByID(EmpDesignationMaster item);

        IBaseEntityResponse<EmpDesignationMaster> InsertEmpDesignationMaster(EmpDesignationMaster item);

        IBaseEntityResponse<EmpDesignationMaster> UpdateEmpDesignationMaster(EmpDesignationMaster item);

        IBaseEntityResponse<EmpDesignationMaster> DeleteEmpDesignationMaster(EmpDesignationMaster item);
    }
}
