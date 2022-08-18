using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IHMAppointmentTransactionBA
    {
        IBaseEntityResponse<HMAppointmentTransaction> InsertHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> UpdateHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> DeleteHMAppointmentTransaction(HMAppointmentTransaction item);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetBySearch(HMAppointmentTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetHMAppointmentTransactionSearchList(HMAppointmentTransactionSearchRequest searchRequest);
        //For General Data
        IBaseEntityResponse<HMAppointmentTransaction> GetGeneralDataByGeneralPatientMasterId(HMAppointmentTransaction item);
        IBaseEntityCollectionResponse<HMAppointmentTransaction> GetListOfPatient(HMAppointmentTransactionSearchRequest searchRequest);
        IBaseEntityResponse<HMAppointmentTransaction> LastcaseHistory(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> LastPrescription(HMAppointmentTransaction item);
        IBaseEntityResponse<HMAppointmentTransaction> SelectByID(HMAppointmentTransaction item);
        //For Patient Appointment
        IBaseEntityCollectionResponse<HMAppointmentTransaction>GetAppointmentData(HMAppointmentTransactionSearchRequest searchRequest);
    }
}

