//this class contain methods related to nationality functionality
var OnlineExamAllocateSupportStaff = {
    //Member variables
    ActionName: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExamAllocateSupportStaff.constructor();
        //OnlineExamAllocateSupportStaff.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#ExaminationName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });
      
        //for Dropdown of centre and Examination
        $('#SelectedCentreCode').unbind("change").change(function () {
            debugger;
            var selectedItem = $(this).val();
            var $ddlExam = $("#SelectedExam");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineExamAllocateSupportStaff/ExaminationNameList",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {

                        $('#ListViewModel').empty();
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Exam-------</option>');
                        if (data == "0") {
                            notify('Session is not created for selected Center', 'warning');
                        }else if (data.length != 0) {
                            $.each(data, function (id, option) {

                                $ddlExam.append($('<option></option>').val(option.id).html(option.name));
                            });
                            if (data[0].length != 0) {
                                $("#SessionID").val(data[0].SessionID);
                            }
                        } 
                        
                        $ExamProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Exam');
                        $ExamProgress.hide();
                    }
                });
            }
        });

        $("#btnShowList").unbind("click").click(function () {
            var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            var SelectedExam = $('#SelectedExam :selected').val();
            if (SelectedCentreCode == "") {
                notify('Please select Ceneter', 'warning');
                return false;
            }
            if (SelectedExam == "") {
                notify('Please select Examination', 'warning');
                return false;
            }
            OnlineExamAllocateSupportStaff.LoadList(SelectedCentreCode,SelectedExam);
        });
       
      

        // Create new record

        $('#CreateOnlineExamAllocateSupportStaffRecords').on("click", function () {
            var EmployeeID = $('#EmployeeID').val();
            if (EmployeeID == 0) {
                notify('Please select Employee', 'warning');
                return false;
            }

            OnlineExamAllocateSupportStaff.ActionName = "CreateEmployeeForExam";
            OnlineExamAllocateSupportStaff.AjaxCallOnlineExamAllocateSupportStaff();
        });

        $('#CreateOnlineExamAllocateSupportStaffRecord').on("click", function () {

            OnlineExamAllocateSupportStaff.ActionName = "Create";
            OnlineExamAllocateSupportStaff.AjaxCallOnlineExamAllocateSupportStaff();
        });

        //$('#EditOnlineExamAllocateSupportStaffRecord').on("click", function () {

        //    OnlineExamAllocateSupportStaff.ActionName = "Edit";
        //    OnlineExamAllocateSupportStaff.AjaxCallOnlineExamAllocateSupportStaff();
        //});

        $('#DeleteOnlineExamAllocateSupportStaffRecord').on("click", function () {
            debugger;
            OnlineExamAllocateSupportStaff.ActionName = "Delete";
            OnlineExamAllocateSupportStaff.AjaxCallOnlineExamAllocateSupportStaff();
        });

        $('#AllotedJobName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LevelCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

        });

        InitAnimatedBorder();

        CloseAlert();

    },
        //LoadList method is used to load List page
        LoadList: function (SelectedCentreCode, SelectedExam) {
            debugger;
            $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { CentreCode: SelectedCentreCode, OnlineExamExaminationMasterID: SelectedExam },
                 dataType: "html",
                 url: '/OnlineExamAllocateSupportStaff/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);

                 }
             });
        },
        //ReloadList method is used to load List page
        ReloadList: function (message, colorCode, actionMode) {
            debugger;
            var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            var SelectedExam = $('#SelectedExam :selected').val();
            $.ajax(
            {

                cache: false,
                type: "POST",
                dataType: "html",
                data: { actionMode: actionMode, CentreCode: SelectedCentreCode, OnlineExamExaminationMasterID: SelectedExam },
                url: '/OnlineExamAllocateSupportStaff/List',
                success: function (data) {
                    //Rebind Grid Data
                    $("#ListViewModel").empty().append(data);
                    //twitter type notification
                    notify(message, colorCode);
                }
            });
        },

    //Fire ajax call to insert update and delete record

    AjaxCallOnlineExamAllocateSupportStaff: function () {
        var OnlineExamAllocateSupportStaffData = null;

        if (OnlineExamAllocateSupportStaff.ActionName == "CreateEmployeeForExam") {
            debugger;
            $("#FormCreateOnlineExamAllocateSupportStaffCreateEmployeeForExam").validate();
            if ($("#FormCreateOnlineExamAllocateSupportStaffCreateEmployeeForExam").valid())
            {
                OnlineExamAllocateSupportStaffData = OnlineExamAllocateSupportStaff.GetOnlineExamAllocateSupportStaff();
                ajaxRequest.makeRequest("/OnlineExamAllocateSupportStaff/CreateEmployeeForExam", "POST", OnlineExamAllocateSupportStaffData, OnlineExamAllocateSupportStaff.Success, "CreateOnlineExamAllocateSupportStaffRecords");
            }
        }


        else if (OnlineExamAllocateSupportStaff.ActionName == "Create") {
            debugger;
            $("#FormCreateOnlineExamAllocateSupportStaff").validate();
            if ($("#FormCreateOnlineExamAllocateSupportStaff").valid())
            {
                OnlineExamAllocateSupportStaffData = OnlineExamAllocateSupportStaff.GetOnlineExamAllocateSupportStaff();
                ajaxRequest.makeRequest("/OnlineExamAllocateSupportStaff/Create", "POST", OnlineExamAllocateSupportStaffData, OnlineExamAllocateSupportStaff.Success, "CreateOnlineExamAllocateSupportStaffRecord");
            }
        }
            //else if (OnlineExamAllocateSupportStaff.ActionName == "Edit") {
            //    $("#FormEditOnlineExamAllocateSupportStaff").validate();
            //    if ($("#FormEditOnlineExamAllocateSupportStaff").valid()) {
            //        OnlineExamAllocateSupportStaffData = null;
            //        OnlineExamAllocateSupportStaffData = OnlineExamAllocateSupportStaff.GetOnlineExamAllocateSupportStaff();
            //        ajaxRequest.makeRequest("/OnlineExamAllocateSupportStaff/Edit", "POST", OnlineExamAllocateSupportStaffData, OnlineExamAllocateSupportStaff.Success);
            //    }
            //}
        else if (OnlineExamAllocateSupportStaff.ActionName == "Delete") {
            debugger;
            OnlineExamAllocateSupportStaffData = null;
            $("#FormCreateOnlineExamAllocateSupportStaff").validate();
            OnlineExamAllocateSupportStaffData = OnlineExamAllocateSupportStaff.GetOnlineExamAllocateSupportStaff();
            ajaxRequest.makeRequest("/OnlineExamAllocateSupportStaff/Delete", "POST", OnlineExamAllocateSupportStaffData, OnlineExamAllocateSupportStaff.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamAllocateSupportStaff: function () {
        debugger;
        var Data = {
        };

        if (OnlineExamAllocateSupportStaff.ActionName == "CreateEmployeeForExam") {

            Data.EmployeeID = $('#EmployeeID').val();
            Data.OnlineExamExaminationMasterID = $('#OnlineExamExaminationMasterID').val();
           }

        if (OnlineExamAllocateSupportStaff.ActionName == "Create") {

            Data.OnlineExamAllocateSupportStaffID = $('#OnlineExamAllocateSupportStaffID').val();
            Data.AllotedJobName = $('#AllotedJobName').val();
            Data.AllotedJobCode = $('#AllotedJobCode').val();
            Data.JobAllotedForCentreCode = $('#JobAllotedForCentreCode').val();
            Data.CentreCode = $('#SelectedCentreCode').val();
            Data.JobStartDate = $('#JobStartDate').val();
            Data.JobEndDate = $('#JobEndDate').val();
            Data.SubjectGroupId = $('#SubjectGroupId').val();
      
            Data.AcademicSessionID = $('#Session').val();
            Data.IsNotificationNeedToSentCompulsory = $("#IsNotificationNeedToSentCompulsory").is(":checked") ? "true" : "false";
        }
        else if (OnlineExamAllocateSupportStaff.ActionName == "Delete") {
            debugger;
            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
       //alert( Data);
        return Data;
        
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            OnlineExamAllocateSupportStaff.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
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
//       OnlineExamAllocateSupportStaff.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        OnlineExamAllocateSupportStaff.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


