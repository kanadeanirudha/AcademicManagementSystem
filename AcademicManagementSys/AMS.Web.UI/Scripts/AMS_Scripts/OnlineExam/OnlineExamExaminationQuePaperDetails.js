//this class contain methods related to nationality functionality
var OnlineExamExaminationQuePaperDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExamExaminationQuePaperDetails.constructor();
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
            OnlineExamExaminationQuePaperDetails.LoadQuestionList();
        });

        $("#btnIsFinal").click(function () {
            var OnlineExamExaminationQuestionPaperID = $("#OnlineExamExaminationQuestionPaperID").val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: 'json',
             data:{"OnlineExamExaminationQuestionPaperID":OnlineExamExaminationQuestionPaperID},
             url: "/OnlineExamExaminationQuePaperDetails/QuestionPaperFinalSubmit",
             success: function (data) {
                 var splitData = data.split(',');
                 notify(splitData[0], splitData[1]);
                 OnlineExamExaminationQuePaperDetails.LoadViewQuestionList()
             }
          });
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
             url: '/OnlineExamExaminationQuePaperDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    LoadQuestionList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OnlineExamExaminationQuePaperDetails/QuestionList',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    LoadViewQuestionList: function () {
        var IsFinal = $('input[name=IsFinal]').val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: {"IsFinal":IsFinal},
             url: '/OnlineExamExaminationQuePaperDetails/ViewQuestionList',
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
            url: '/OnlineExamExaminationQuePaperDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    
    AjaxCallOnlineExamExaminationQuePaperDetails: function () {
        var OnlineExamExaminationQuePaperDetailsData = null;
        if (OnlineExamExaminationQuePaperDetails.ActionName == "Create") {
            $("#FormCreateOnlineExamExaminationQuePaperDetails").validate();
            if ($("#FormCreateOnlineExamExaminationQuePaperDetails").valid()) {
                OnlineExamExaminationQuePaperDetailsData = null;
                OnlineExamExaminationQuePaperDetailsData = OnlineExamExaminationQuePaperDetails.GetOnlineExamExaminationQuePaperDetails();
                ajaxRequest.makeRequest("/OnlineExamExaminationQuePaperDetails/Create", "POST", OnlineExamExaminationQuePaperDetailsData, OnlineExamExaminationQuePaperDetails.Success, "CreateOnlineExamExaminationQuePaperDetailsRecord");
            }
        } 
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExamExaminationQuePaperDetails: function () {
        var Data = {
        };

        if (OnlineExamExaminationQuePaperDetails.ActionName == "Create" || OnlineExamExaminationQuePaperDetails.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.PaperSetCode = $('#PaperSetCode').val();
        } 
        
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            OnlineExamExaminationQuePaperDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $.magnificPopup.close();
            OnlineExamExaminationQuePaperDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

