//this class contain methods related to nationality functionality
var HMAppointmentTransaction = {
    //Member variables
    ActionName: null,

    Initialize: function () {
        //organisationStudyCentre.loadData();
        HMAppointmentTransaction.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#TransactionDate').focus();

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

            return false;
        });
        $("#CentreCode").change(function () {

            if ($("#CentreCode").val() != null ) {
                $("#PatientName").val('');
            }
            else {
                $("#PatientName").val();
            }
        });

        

        $("#CreateHMAppointmentTransactionRecord").on("click", function () {
            debugger;
            var ct = $('#CentreCode').val()
            if (ct =='' ) {
                notify("Please Select Centre and Search Patient", 'warning');
            }
            else
            {
                notify("Please Search Patient", 'warning');
            }
        });
        // Create new record
        $('#CreateHMAppointmentTransactionRecord').on("click", function () {
            debugger;
            HMAppointmentTransaction.ActionName = "Create";
            HMAppointmentTransaction.AjaxCallHMAppointmentTransaction();
        });
        $('#EditHMAppointmentTransactionRecord').on("click", function () {
            debugger;
            HMAppointmentTransaction.ActionName = "Edit";
            HMAppointmentTransaction.AjaxCallHMAppointmentTransaction();
        });
        $('#DeleteHMAppointmentTransactionRecord').on("click", function () {
            debugger;
            HMAppointmentTransaction.ActionName = "Delete";
            HMAppointmentTransaction.AjaxCallHMAppointmentTransaction();
        });
        InitAnimatedBorder();
        CloseAlert();
    },
    //For Create Tab
    CreateTab: function () {
        $('ul#TaskList li').on('click' , function () {
            debugger;
            var Newurl = '';
            var TaskCode = $(this).attr('id');
            var GeneralPatientMasterId = $('input[name=GeneralPatientMasterId]').val();
            var CenterCode = $("#CentreCode").val();
           // alert($(this).attr('id'))
            debugger;
           
            if (TaskCode == "HMAppointmentTransaction") {
                Newurl = '/HMAppointmentTransaction/General';
            }
            
            else if (TaskCode == "HMPatientCaseHistory") {
                Newurl = '/HMAppointmentTransaction/LastCaseHistory';
            }
            else if (TaskCode == "HMPatientMedicine") {
                Newurl = '/HMAppointmentTransaction/LastPrescription';
            }

            $.ajax(
                    {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: {"TaskCode": TaskCode, "GeneralPatientMasterId": GeneralPatientMasterId, "CenterCode": CenterCode},
                      url: Newurl,
                      success: function (result) {
                          //alert(result);
                         
                          $('.tab-content').html(result);
                      }
                  });
        });
    },
   
    //LoadList method is used to load List page
    LoadList: function () {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/HMAppointmentTransaction/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/HMAppointmentTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallHMAppointmentTransaction: function () {
        debugger;
        var HMAppointmentTransactionData = null;
        if (HMAppointmentTransaction.ActionName == "Create") {
            $("#FormCreateHMAppointmentTransaction").validate();
            if ($("#FormCreateHMAppointmentTransaction").valid()) {
                HMAppointmentTransactionData = null;
                HMAppointmentTransactionData = HMAppointmentTransaction.GetHMAppointmentTransaction();
                ajaxRequest.makeRequest("/HMAppointmentTransaction/Create", "POST", HMAppointmentTransactionData, HMAppointmentTransaction.Success, "CreateHMAppointmentTransactionRecord");
            }
        }
        else if (HMAppointmentTransaction.ActionName == "Edit") {
            debugger;
            $("#FormEditHMAppointmentTransaction").validate();
            if ($("#FormEditHMAppointmentTransaction").valid()) {
                HMAppointmentTransactionData = null;
                HMAppointmentTransactionData = HMAppointmentTransaction.GetHMAppointmentTransaction();
                ajaxRequest.makeRequest("/HMAppointmentTransaction/Edit", "POST", HMAppointmentTransactionData, HMAppointmentTransaction.Success);
            }
        }
        else if (HMAppointmentTransaction.ActionName == "Delete") {
            debugger;
            HMAppointmentTransactionData = null;
            // $("#FormCreateHMAppointmentTransaction").validate();
            HMAppointmentTransactionData = HMAppointmentTransaction.GetHMAppointmentTransaction();
            ajaxRequest.makeRequest("/HMAppointmentTransaction/Delete", "POST", HMAppointmentTransactionData, HMAppointmentTransaction.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetHMAppointmentTransaction: function () {
        var Data = {
        };

        if (HMAppointmentTransaction.ActionName == "Create") {
            debugger;
         
            Data.CentreCode = $('#CentreCode').val();
            Data.Name = $('#Name').val();
            Data.Age = $('#Age').val();
            Data.Gender = $('#Gender').val();
            Data.TransactionDate = $('#TransactionDate').val();
            Data.IsNewPatient = $('#IsNewPatient').val();
            Data.GeneralPatientMasterId = $('#GeneralPatientMasterId').val();
            Data.Symtomp = $('#Symtomp').val();
            Data.CaseHistoryNumber = $('#CaseHistoryNumber').val();
            Data.ConsultantID = $('#ConsultantID').val();
            Data.NextAppointmentDate = $('#NextAppointmentDate').val();
            Data.Status = $('#Status').val();
            Data.LastAppointmentDate = $('#LastAppointmentDate').val();
            Data.OPDName = $('#SelectedHMOPDHealthCentreID').text();
            Data.HMOPDHealthCentreID = $('#SelectedHMOPDHealthCentreID').val();

        }
        else if (HMAppointmentTransaction.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
        }
        else if (HMAppointmentTransaction.ActionName == "Delete") {
            debugger;
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.errorMessage.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            HMAppointmentTransaction.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

