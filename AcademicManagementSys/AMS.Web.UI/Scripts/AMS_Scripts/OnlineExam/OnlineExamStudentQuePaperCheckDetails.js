//this class contain methods related to nationality functionality
var OnlineExamStudentQuePaperCheckDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExamStudentQuePaperCheckDetails.constructor();
        //OnlineExamExaminationQuePaperDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });

        $("#btnShowList").click(function () {
            var QuestionBankMaster = $("#OnlineExamQuestionBankMasterID").val();
            if (QuestionBankMaster == "") {
                notify('Please select Question Bank', 'warning');
                return false;
            }
            OnlineExamStudentQuePaperCheckDetails.LoadQuestionList();
        });

        //$("#btnIsFinal").click(function () {
        //    var OnlineExamExaminationQuestionPaperID = $("#OnlineExamExaminationQuestionPaperID").val();
        //    $.ajax(
        //     {
        //         cache: false,
        //         type: "POST",
        //         dataType: 'json',
        //         data: { "OnlineExamExaminationQuestionPaperID": OnlineExamExaminationQuestionPaperID },
        //         url: "/OnlineExamStudentQuePaperCheckDetails/QuestionPaperFinalSubmit",
        //         success: function (data) {
        //             var splitData = data.split(',');
        //             notify(splitData[0], splitData[1]);
        //             OnlineExamExaminationQuePaperDetails.LoadViewQuestionList()
        //         }
        //     });
        //});

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
             url: '/OnlineExamStudentQuePaperCheckDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    LoadStudentApplicableList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OnlineExamStudentQuePaperCheckDetails/StudentApplicableList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    LoadViewQuestionList: function () {
        debugger
        //var IsFinal = $('input[name=IsFinal]').val();
        var OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
        var OnlineExamSubjectGroupScheduleID = $('#OnlineExamSubjectGroupScheduleID').val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             //data: { },
             url: '/OnlineExamStudentQuePaperCheckDetails/ViewQuestionList',
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
            url: '/OnlineExamStudentQuePaperCheckDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    AjaxCallOnlineExamStudentQuePaperCheckDetails: function () {
        var OnlineExamStudentQuePaperCheckDetailsData = null;
        if (OnlineExamStudentQuePaperCheckDetails.ActionName == "Create") {
            $("#FormCreateOnlineExamStudentQuePaperCheckDetails").validate();
            if ($("#FormCreateOnlineExamStudentQuePaperCheckDetails").valid()) {
                OnlineExamStudentQuePaperCheckDetailsData = null;
                OnlineExamStudentQuePaperCheckDetailsData = OnlineExamStudentQuePaperCheckDetails.GetOnlineExamStudentQuePaperCheckDetails();
                ajaxRequest.makeRequest("/OnlineExamStudentQuePaperCheckDetails/Create", "POST", OnlineExamStudentQuePaperCheckDetailsData, OnlineExamStudentQuePaperCheckDetails.Success, "CreateOnlineExamStudentQuePaperCheckDetailsRecord");
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamStudentQuePaperCheckDetails: function () {
        var Data = {
        };

        if (OnlineExamStudentQuePaperCheckDetails.ActionName == "Create" || OnlineExamStudentQuePaperCheckDetails.ActionName == "Edit") {

            Data.ID = $('#ID').val();
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            OnlineExamStudentQuePaperCheckDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $.magnificPopup.close();
            OnlineExamStudentQuePaperCheckDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

