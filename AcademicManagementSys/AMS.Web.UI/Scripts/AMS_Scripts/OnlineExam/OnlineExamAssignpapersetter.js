//this class contain methods related to nationality functionality
var OnlineExamAssignpapersetter = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExamAssignpapersetter.constructor();
        //GeneralPaperSetMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#PaperSetCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });

        $('#SelectedCentreCode').unbind("change").change(function () {
            var selectedItem = $(this).val();
            var $ddlExam = $("#SelectedExam");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineExamAssignpapersetter/GetOnlineExamGetExaminationListCentreWise",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $('#ListViewModel').empty();
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Exam-------</option>');
                        if (data == "0") {
                            notify('Session is not created for selected Center', 'warning');
                        } else if (data.length != 0) {
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
        $('#SelectedExam').unbind("change").change(function () {
            var selectedItem = $(this).val();
            var centreCode = $("#SelectedCentreCode").val();
            if (centreCode == '') {
                notify('Please select Center.', 'warning');
                return false;
            }
            var $ddlExam = $("#CourseYearID");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#SelectedExam").val() != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    url: "/OnlineExamStudentApplicable/GetCourseYearListOnlineExaminationMasterWise",

                    data: { "OnlineExaminationMasterID": selectedItem, "CentreCode": centreCode },
                    success: function (data) {
                        $('#ListViewModel').empty();
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Course-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id + '~' + option.dataAttr).html(option.name));
                        });
                        $ExamProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Examinations.');
                        $ExamProgress.hide();
                    }
                });
            }
        });
        $("#btnShowList").unbind('click').click(function () {
            var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            var SelectedExam = $('#SelectedExam :selected').val();
            var SelectedCourse = $('#CourseYearID').val();
            if (SelectedCentreCode == '') {
                notify('Please select Center', 'warning');
                return false;
            }
            if (SelectedExam == '') {
                notify('Please select Examination', 'warning');
                return false;
            }
            if (SelectedCourse == '') {
                notify('Please select Course', 'warning');
                return false;
            }
            OnlineExamAssignpapersetter.LoadList(SelectedCentreCode, SelectedExam);
        });
        // Create new record

        $('#CreateOnlineExamAssignpapersetterRecord').on("click", function () {
            OnlineExamAssignpapersetter.ActionName = "Create";
            OnlineExamAssignpapersetter.AjaxCallOnlineExamAssignpapersetter();
        });

        $('#DeleteOnlineExamAssignpapersetterRecord').on("click", function () {
            OnlineExamAssignpapersetter.ActionName = "Delete";
            OnlineExamAssignpapersetter.AjaxCallOnlineExamAssignpapersetter();
        });

        $('#PaperSetCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        //$('#MovementCode').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});

        InitAnimatedBorder();

        CloseAlert();

      

    },
    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode, SelectedExam) {
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { CentreCode: SelectedCentreCode, OnlineExamExaminationMasterID: SelectedExam},
             dataType: "html",
             url: '/OnlineExamAssignpapersetter/List',
             success: function (data) {
                 //Rebind Grid Data                
                 $('#ListViewModel').html(data);

             }
         });
    },

    LoadViewQuestionList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OnlineExamAssignpapersetter/ViewQuestionList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        var SelectedExam = $('#SelectedExam :selected').val();
        $.ajax(
        {
            
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, CentreCode: SelectedCentreCode, OnlineExamExaminationMasterID: SelectedExam },
            url: '/OnlineExamAssignpapersetter/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

  
    //Fire ajax call to insert update and delete record

    AjaxCallOnlineExamAssignpapersetter: function () {
        var OnlineExamAssignpapersetterData = null;

        if (OnlineExamAssignpapersetter.ActionName == "Create") {
            $("#FormCreateOnlineExamAssignpapersetter").validate();
            if ($("#FormCreateOnlineExamAssignpapersetter").valid()) {
                OnlineExamAssignpapersetterData = null;
                OnlineExamAssignpapersetterData = OnlineExamAssignpapersetter.GetOnlineExamAssignpapersetter();
                ajaxRequest.makeRequest("/OnlineExamAssignpapersetter/Create", "POST", OnlineExamAssignpapersetterData, OnlineExamAssignpapersetter.Success, "CreateOnlineExamAssignpapersetterRecord");
            }
        }
        else if (OnlineExamAssignpapersetter.ActionName == "Delete") {
            OnlineExamAssignpapersetterData = null;
            //$("#FormCreateOnlineExamAssignpapersetter").validate();
            OnlineExamAssignpapersetterData = OnlineExamAssignpapersetter.GetOnlineExamAssignpapersetter();
            ajaxRequest.makeRequest("/OnlineExamAssignpapersetter/Delete", "POST", OnlineExamAssignpapersetterData, OnlineExamAssignpapersetter.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamAssignpapersetter: function () {
        var Data = {
        };

        if (OnlineExamAssignpapersetter.ActionName == "Create" || OnlineExamAssignpapersetter.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.PaperSet = $('#PaperSet').val();
            Data.OnlineExamExaminationMasterID = $('#OnlineExamExaminationMasterID').val();
            Data.OnlineExamSubjectGroupScheduleID = $('#OnlineExamSubjectGroupScheduleID').val();
            Data.OnlineExamAllocateJobSupportStaffID = $('#OnlineExamAllocateJobSupportStaffID').val();
            
        }
        else if (OnlineExamAssignpapersetter.ActionName == "Delete") {

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
            OnlineExamAssignpapersetter.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $.magnificPopup.close();
            OnlineExamAssignpapersetter.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       OnlineExamAssignpapersetter.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        OnlineExamAssignpapersetter.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


