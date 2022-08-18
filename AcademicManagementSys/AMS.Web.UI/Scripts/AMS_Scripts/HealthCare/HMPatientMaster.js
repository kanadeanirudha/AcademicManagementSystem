//this class contain methods related to nationality functionality
var HMPatientMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        HMPatientMaster.constructor();
        //HMPatientMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#PatientName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });

       

        // Create new record

        $('#CreateHMPatientMasterRecord').on("click", function () {
            debugger
            HMPatientMaster.ActionName = "Create";
            HMPatientMaster.AjaxCallHMPatientMaster();
        });

        $('#EditHMPatientMasterRecord').on("click", function () {

            HMPatientMaster.ActionName = "Edit";
            HMPatientMaster.AjaxCallHMPatientMaster();
        });

        $('#CounterCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

        });
        $('#DeleteHMPatientMasterRecord').on("click", function () {

            HMPatientMaster.ActionName = "Delete";
            HMPatientMaster.AjaxCallHMPatientMaster();
        });


        InitAnimatedBorder();

        CloseAlert();

       


       


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/HMPatientMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/HMPatientMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallHMPatientMaster: function () {
        var HMPatientMasterData = null;

        if (HMPatientMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateHMPatientMaster").validate();
            if ($("#FormCreateHMPatientMaster").valid()) {
                HMPatientMasterData = null;
                HMPatientMasterData = HMPatientMaster.GetHMPatientMaster();
                ajaxRequest.makeRequest("/HMPatientMaster/Create", "POST", HMPatientMasterData, HMPatientMaster.Success, "CreateHMPatientMasterRecord");
            }
        }
        else if (HMPatientMaster.ActionName == "Edit") {
            $("#FormEditHMPatientMaster").validate();
            if ($("#FormEditHMPatientMaster").valid()) {
                HMPatientMasterData = null;
                HMPatientMasterData = HMPatientMaster.GetHMPatientMaster();
                ajaxRequest.makeRequest("/HMPatientMaster/Edit", "POST", HMPatientMasterData, HMPatientMaster.Success, "EditHMPatientMasterRecord");
            }
        }
        else if (HMPatientMaster.ActionName == "Delete") {

            HMPatientMasterData = null;
            //$("#FormCreateHMPatientMaster").validate();
            HMPatientMasterData = HMPatientMaster.GetHMPatientMaster();
            ajaxRequest.makeRequest("/HMPatientMaster/Delete", "POST", HMPatientMasterData, HMPatientMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page


    GetHMPatientMaster: function () {
        var Data = {
        };
         

        if (HMPatientMaster.ActionName == "Create" || HMPatientMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.PatientCode = $('#PatientCode').val();
            Data.FirstName = $('#FirstName').val();
            Data.MiddleName = $('#MiddleName').val();
            Data.LastName = $('#LastName').val();
            Data.PatientName = $('#PatientName').val();
            Data.Age = $('#Age').val();
           // Data.Gender = $('#Gender').val();
            Data.DOB = $('#DOB').val();
            Data.Address = $('#Address').val();
            Data.City = $('#City').val();
            Data.PinCode = $('#PinCode').val();
            Data.Note = $('#Note').val();
            Data.IdentityNumber = $('#IdentityNumber').val();
            Data.FamilyMobileNumber = $('#FamilyMobileNumber').val();
            Data.NextAppointmentDate = $('#NextAppointmentDate').val();
            Data.LastAppointmentTransactionID = $('#LastAppointmentTransactionID').val();

            Data.IsIPDPatient = $('input[id=IsIPDPatient]:checked').val() ? true : false;
            //For IsIPs
            //if ($('#IsIPDPatient').is(':checked')) {
            //    Data.IsIPDPatient = "1";
            //}
            //else if ($('#IsIPDPatient').is(':checked')) {
            //    Data.IsIPDPatient = "0";
            //}
            alert(Data.IsIPDPatient)
            //For Gender
            if ($('#Male').is(':checked')) {
                Data.Gender = "1";
            }
            else if ($('#Female').is(':checked')) {
                Data.Gender = "0";
            }
            alert(Data.Gender)
        }
        else if (HMPatientMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            HMPatientMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       HMPatientMaster.ReloadList("Record Updated Sucessfully.", actionMode);
//        //  alert("Record Created Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    }

//},
////this is used to for showing successfully record deletion message and reload the list view
//deleteSuccess: function (data) {


//    if (data == "True") {

//        parent.$.colorbox.close();
//        HMPatientMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


