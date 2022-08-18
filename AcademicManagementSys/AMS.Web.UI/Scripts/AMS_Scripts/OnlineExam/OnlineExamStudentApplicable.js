//this class contain methods related to nationality functionality
var OnlineExamStudentApplicable = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExamStudentApplicable.constructor();
        //OnlineExamStudentApplicable.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });

        $('#SelectedCentreCode').unbind("change").change(function () {
            debugger;
            var selectedItem = $(this).val();
            var $ddlExam = $("#OnlineExaminationMasterID");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    url: "/OnlineExamStudentApplicable/GetOnlineExamGetExaminationListCentreWise",

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
                                $("#CenterwiseSessionID").val(data[0].CenterwiseSessionID);
                            }
                        }
                        $ExamProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Examinations.');
                        $ExamProgress.hide();
                    }
                });
            }
        });

        $('#OnlineExaminationMasterID').unbind("change").change(function () {
            debugger;
            var selectedItem = $(this).val();
            var centreCode = $("#SelectedCentreCode").val();
            if (centreCode == '') {
                notify('Please select Center.', 'warning');
                return false;
            }
            var $ddlExam = $("#CourseYearID");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#OnlineExaminationMasterID").val() != "") {
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
            debugger;
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
                    url: "/OnlineExamStudentApplicable/GetSubjectListOnlineCourseYearWise",

                    data: { "CourseYearID": CourseYearDetails[0], "SemesterMstID": CourseYearDetails[1], "OnlineExaminationMasterID": OnlineExaminationMasterID },
                    success: function (data) {
                        $('#ListViewModel').empty();
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Subject-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id + '~' + option.OnlineExamSubjectGroupScheduleID).html(option.name));
                        });
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
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Subjects.');
                        $ExamProgress.hide();
                    }
                });
            }
        });

        $("#btnShowList").unbind("click").click(function () {
            if ($('#SelectedCentreCode').val() == '') {
                notify('Please select Center', 'warning');
                return false;
            }
            if ($('#OnlineExaminationMasterID').val() == '') {
                notify('Please select Examination', 'warning');
                return false;
            }
            if ($('#CourseYearID').val() == '') {
                notify('Please select Course', 'warning');
                return false;
            }
            if ($('#SubjectID').val() == '') {
                notify('Please select Subject', 'warning');
                return false;
            }
            if ($('#SectionDetailID').val() == '') {
                notify('Please select Section', 'warning');
                return false;
            }
            OnlineExamStudentApplicable.LoadList();
        });

        $("#btnShowAllocatedStudentList").unbind("click").click(function () {
            if ($('#SelectedCentreCode').val() == '') {
                notify('Please select Center', 'warning');
                return false;
            }
            if ($('#OnlineExaminationMasterID').val() == '') {
                notify('Please select Examination', 'warning');
                return false;
            }
            if ($('#CourseYearID').val() == '') {
                notify('Please select Course', 'warning');
                return false;
            }
            if ($('#SubjectID').val() == '') {
                notify('Please select Subject', 'warning');
                return false;
            }
            if ($('#SectionDetailID').val() == '') {
                notify('Please select Section', 'warning');
                return false;
            }
            OnlineExamStudentApplicable.LoadAllocatedStudentList();
        });

        $('#btnAddAllStudent').on("click", function () {
            OnlineExamStudentApplicable.ActionName = "AddAllStudent";
            OnlineExamStudentApplicable.GetXmlData();
            OnlineExamStudentApplicable.AjaxCallOnlineExamStudentApplicable();
        });

        $('#btnRemoveAllStudent').on("click", function () {
            OnlineExamStudentApplicable.ActionName = "RemoveAllStudent";
            OnlineExamStudentApplicable.GetXmlData();
            OnlineExamStudentApplicable.AjaxCallOnlineExamStudentApplicable();
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
             url: '/OnlineExamStudentApplicable/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },

    LoadAllocatedStudentList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OnlineExamStudentApplicable/AllocatedStudentList',
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
            url: '/OnlineExamStudentApplicable/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    ReloadAllocatedStudentList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/OnlineExamStudentApplicable/AllocatedStudentList',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    AjaxCallOnlineExamStudentApplicable: function () {
        var OnlineExamStudentApplicableData = null;

        if (OnlineExamStudentApplicable.ActionName == "AddAllStudent") {

            OnlineExamStudentApplicableData = null;
            OnlineExamStudentApplicableData = OnlineExamStudentApplicable.GetOnlineExamStudentApplicable();
            ajaxRequest.makeRequest("/OnlineExamStudentApplicable/AddStudentForExam", "POST", OnlineExamStudentApplicableData, OnlineExamStudentApplicable.Success);

        } else if (OnlineExamStudentApplicable.ActionName == "RemoveAllStudent") {

            OnlineExamStudentApplicableData = null;
            OnlineExamStudentApplicableData = OnlineExamStudentApplicable.GetOnlineExamStudentApplicable();
            ajaxRequest.makeRequest("/OnlineExamStudentApplicable/RemoveStudentFromExam", "POST", OnlineExamStudentApplicableData, OnlineExamStudentApplicable.AllocatedSuccess);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamStudentApplicable: function () {
        var Data = {
        };
        if (OnlineExamStudentApplicable.ActionName == "AddAllStudent" || OnlineExamStudentApplicable.ActionName == "RemoveAllStudent") {
            Data.XMLString = OnlineExamStudentApplicable.XMLstring;
            var SubjectID = $("#SubjectID").val();
            var SubjectIDSplitData = SubjectID.split("~");
            Data.OnlineExamSubjectGroupScheduleID = SubjectIDSplitData[1];
            Data.CenterwiseSessionID = $("#CenterwiseSessionID").val();
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        OnlineExamStudentApplicable.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
    },

    AllocatedSuccess: function (data) {
        var splitData = data.split(',');
        OnlineExamStudentApplicable.ReloadAllocatedStudentList(splitData[0], splitData[1], splitData[2], splitData[3]);
    },

    CheckedAll: function () {
        $("#myDataTable thead tr th input[class='checkall-student']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#myDataTable tbody tr td p input[class='check-student']").prop("checked", true);
                $("#btnAddAllStudent").prop("disabled", false);
            }
            else {
                $("#myDataTable tbody tr td p input[class='check-student']").prop("checked", false);
                $("#btnAddAllStudent").prop("disabled", true);
            }
        });
    },

    CheckedSingle: function () {
        $("#myDataTable tbody tr td p input[class='check-student']").on('click', function () {
            var CheckedArray = [];
            var table = $('#myDataTable').DataTable();
            var TotalCheckedRecord;
            var data = table.$("input[class='check-student']").each(function () {
                CheckedArray.push($(this).val());
                var $this = $(this);
                if ($this.is(":checked")) {
                    CheckedArray.push($(this).val());
                    TotalCheckedRecord = CheckedArray.length;
                }
            });
            if (TotalCheckedRecord > 0) {
                $("#btnAddAllStudent").prop("disabled", false);
            }
            else {
                $("#btnAddAllStudent").prop("disabled", true);
            }
        });
    },

    CheckedAllRemove: function () {
        $("#myDataTable thead tr th input[class='checkall-student']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#myDataTable tbody tr td p input[class='check-student']").prop("checked", true);
                $("#btnRemoveAllStudent").prop("disabled", false);
            }
            else {
                $("#myDataTable tbody tr td p input[class='check-student']").prop("checked", false);
                $("#btnRemoveAllStudent").prop("disabled", true);
            }
        });
    },

    CheckedSingleRemove: function () {
        $("#myDataTable tbody tr td p input[class='check-student']").on('click', function () {
            var CheckedArray = [];
            var table = $('#myDataTable').DataTable();
            var TotalCheckedRecord;
            var data = table.$("input[class='check-student']").each(function () {
                CheckedArray.push($(this).val());
                var $this = $(this);
                if ($this.is(":checked")) {
                    CheckedArray.push($(this).val());
                    TotalCheckedRecord = CheckedArray.length;
                }
            });
            if (TotalCheckedRecord > 0) {
                $("#btnRemoveAllStudent").prop("disabled", false);
            }
            else {
                $("#btnRemoveAllStudent").prop("disabled", true);
            }
        });
    },

    GetXmlData: function () {
        var DataArray = [];
        ParameterXml = "<rows>";
        var table = $('#myDataTable').DataTable();
        var data = table.$("input[class='check-student']").each(function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                var checkboxVal = $this.val();
                ParameterXml = ParameterXml + "<row><ID>" + checkboxVal + "</ID></row>";
            }
        });
        OnlineExamStudentApplicable.XMLstring = ParameterXml + "</rows>";
    },
};

