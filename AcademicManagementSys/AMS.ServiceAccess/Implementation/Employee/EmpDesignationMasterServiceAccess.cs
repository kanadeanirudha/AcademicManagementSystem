using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;

namespace AMS.ServiceAccess
{
    public class EmpDesignationMasterServiceAccess : IEmpDesignationMasterServiceAccess
    {
        IEmpDesignationMasterBA _empDesignationMasterBA = null;

        public EmpDesignationMasterServiceAccess()
        {
            _empDesignationMasterBA = new EmpDesignationMasterBA();
        }

        public IBaseEntityResponse<EmpDesignationMaster> InsertEmpDesignationMaster(EmpDesignationMaster item)
        {
            return _empDesignationMasterBA.InsertEmpDesignationMaster(item);
        }

        public IBaseEntityResponse<EmpDesignationMaster> UpdateEmpDesignationMaster(EmpDesignationMaster item)
        {
            return _empDesignationMasterBA.UpdateEmpDesignationMaster(item);
        }

        public IBaseEntityResponse<EmpDesignationMaster> DeleteEmpDesignationMaster(EmpDesignationMaster item)
        {
            return _empDesignationMasterBA.DeleteEmpDesignationMaster(item);
        }

        public IBaseEntityCollectionResponse<EmpDesignationMaster> GetBySearch(EmpDesignationMasterSearchRequest searchRequest)
        {
            return _empDesignationMasterBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<EmpDesignationMaster> SelectByID(EmpDesignationMaster item)
        {
            return _empDesignationMasterBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<EmpDesignationMaster> GetBySearchList(EmpDesignationMasterSearchRequest searchRequest)
        {
            return _empDesignationMasterBA.GetBySearchList(searchRequest);
        }

    }
}
