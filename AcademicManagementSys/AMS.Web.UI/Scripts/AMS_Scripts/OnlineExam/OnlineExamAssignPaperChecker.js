var OnlineExamAssignPaperChecker = {
    ActionName: null,
    Initialize: function () {
        OnlineExamAssignPaperChecker.constructor();
    },
  
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
                    url: "/OnlineExamAssignPaperChecker/GetOnlineExamGetExaminationListCentreWise",

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
        $('#CourseYearID').unbind("change").change(function () {
            var selectedItem = $(this).val();
            var CourseYearDetails = selectedItem.split("~");
            var $ddlExam = $("#SubjectID");
            var $ddlExamSection = $("#SectionDetailID");
            var OnlineExaminationMasterID = $("#OnlineExaminationMasterID").val();
            if (OnlineExaminationMasterID == '') {
                notify('Please select Examination.', 'warning');
                return false;
            }
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#CourseYearID").val() != "") {
                        $.ajax({
                            cache: false,
                            type: "POST",
                            url: "/OnlineExamStudentApplicable/GetSectionListOnlineCourseYearWise",

                            data: { "CourseYearID": CourseYearDetails[0] },
                            success: function (data) {
                                $ddlExamSection.html('');
                                $ddlExamSection.append('<option value="">--------Select Section-------</option>');
                                $.each(data, function (id, option) {

                                    $ddlExamSection.append($('<option></option>').val(option.id).html(option.name));
                                });
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                alert('Failed to retrieve Sections.');
                                $ExamProgress.hide();
                            }
                        });
                        $ExamProgress.hide();
            }
        });
        $("#btnShowList").unbind('click').click(function () {
            var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
            var SelectedExam = $('#SelectedExam :selected').val();
            var SelectedCourse = $('#CourseYearID').val();
            var SectionDetailID = $('#SectionDetailID').val();
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
            if ($('#SectionDetailID').val() == '') {
                notify('Please select Section', 'warning');
                return false;
            }
            OnlineExamAssignPaperChecker.LoadList(SelectedCentreCode, SelectedExam);
        });
        // Create new record

        $('#CreateOnlineExamAssignPaperCheckerRecord').on("click", function () {
            OnlineExamAssignPaperChecker.ActionName = "Create";
            OnlineExamAssignPaperChecker.AjaxCallOnlineExamAssignPaperChecker();
        });

        $('#DeleteOnlineExamAssignPaperCheckerRecord').on("click", function () {
            OnlineExamAssignPaperChecker.ActionName = "Delete";
            OnlineExamAssignPaperChecker.AjaxCallOnlineExamAssignPaperChecker();
        });

        $('#PaperSetCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        InitAnimatedBorder();
        CloseAlert();
    },
    LoadList: function (SelectedCentreCode, SelectedExam) {
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { CentreCode: SelectedCentreCode, OnlineExamExaminationMasterID: SelectedExam },
             dataType: "html",
             url: '/OnlineExamAssignPaperChecker/List',
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
             url: '/OnlineExamAssignPaperChecker/ViewQuestionList',
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
            url: '/OnlineExamAssignPaperChecker/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallOnlineExamAssignPaperChecker: function () {
        var OnlineExamAssignPaperCheckerData = null;
        if (OnlineExamAssignPaperChecker.ActionName == "Create") {
            $("#FormCreateOnlineExamAssignPaperChecker").validate();
            if ($("#FormCreateOnlineExamAssignPaperChecker").valid()) {
                OnlineExamAssignPaperCheckerData = null;
                OnlineExamAssignPaperCheckerData = OnlineExamAssignPaperChecker.GetOnlineExamAssignPaperChecker();
                ajaxRequest.makeRequest("/OnlineExamAssignPaperChecker/Create", "POST", OnlineExamAssignPaperCheckerData, OnlineExamAssignPaperChecker.Success, "CreateOnlineExamAssignPaperCheckerRecord");
            }
        }
        else if (OnlineExamAssignPaperChecker.ActionName == "Delete") {
            OnlineExamAssignPaperCheckerData = null;
            //$("#FormCreateOnlineExamAssignpapersetter").validate();
            OnlineExamAssignPaperCheckerData = OnlineExamAssignPaperChecker.GetOnlineExamAssignPaperChecker();
            ajaxRequest.makeRequest("/OnlineExamAssignPaperChecker/Delete", "POST", OnlineExamAssignPaperCheckerData, OnlineExamAssignPaperChecker.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamAssignPaperChecker: function () {
        var Data = {
        };

        if (OnlineExamAssignPaperChecker.ActionName == "Create" || OnlineExamAssignPaperChecker.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.OnlineExamExaminationMasterID = $('#OnlineExamExaminationMasterID').val();
            Data.OnlineExamSubjectGroupScheduleID = $('#OnlineExamSubjectGroupScheduleID').val();
            Data.OnlineExamAllocateJobSupportStaffID = $('#OnlineExamAllocateJobSupportStaffID').val();
            Data.SectionDetailID = $('#SectionDetailID').val();
        }
        else if (OnlineExamAssignPaperChecker.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            OnlineExamAssignPaperChecker.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $.magnificPopup.close();
            OnlineExamAssignPaperChecker.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

};




