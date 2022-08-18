//this class contain methods related to nationality functionality
var OnlineExam = {
    //Member variables
    ActionName: null,
    minutes: 0,
    seconds: 0,
    elm: null,
    samay: null,
    sep: ':',
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExam.constructor();
        //OnlineExam.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });

        $("#SaveAndNext").click(function () {
            var DescriptiveAnswer = $('.AnswerEditor').code();
            var IsQuestionDescriptive = $('#IsQuestionDescriptive').val();
            var AttachedDocument = $('#AttachedDocument').val();
            var IsAttachmentCompalsary = $('#IsAttachmentCompalsary').val();
            if (IsQuestionDescriptive == 'True' && DescriptiveAnswer != "" && AttachedDocument == "" && IsAttachmentCompalsary == 2) {
                notify('Please attach document. Document is Mandatory.', 'warning');
                return false;
            }
            OnlineExam.ActionName = "SaveAndNext";
            OnlineExam.AjaxCallOnlineExam();
        });

        $("#SaveAndMarkForReview").click(function () {
            var DescriptiveAnswer = $('.AnswerEditor').code();
            var IsQuestionDescriptive = $('#IsQuestionDescriptive').val();
            var AttachedDocument = $('#AttachedDocument').val();
            var IsAttachmentCompalsary = $('#IsAttachmentCompalsary').val();
            if (IsQuestionDescriptive == 'True' && DescriptiveAnswer != "" && AttachedDocument == "" && IsAttachmentCompalsary == 2) {
                notify('Please attach document. Document is Mandatory.', 'warning');
                return false;
            }
            OnlineExam.ActionName = "SaveAndMarkForReview";
            OnlineExam.AjaxCallOnlineExam();
        });

        $("#ClearResponse").click(function () {
            OnlineExam.ActionName = "ClearResponse";
            OnlineExam.AjaxCallOnlineExam();
        });

        $("#DoNotSaveAndNext").click(function () {
            if (parseInt($('#QuestionOrder').val()) == parseInt($('#TotalQuestions').val())) {
                return false;
            }
            var OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
            var QuestionOrder = parseInt($('#QuestionOrder').val()) + 1;
            OnlineExam.LoadQuestions(OnlineExamIndStudentExamInfoID, QuestionOrder);
        });
        $("#Previous").click(function () {
            if (parseInt($('#QuestionOrder').val()) == 1) {
                return false;
            }
            var OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
            var QuestionOrder = parseInt($('#QuestionOrder').val()) - 1;
            OnlineExam.LoadQuestions(OnlineExamIndStudentExamInfoID, QuestionOrder);
        });

        $("#LoadObjectiveQuestion").click(function () {
            var OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
            var QuestionOrder = $('#ObjectiveStartQuestionOrder').val();
            OnlineExam.LoadQuestions(OnlineExamIndStudentExamInfoID, QuestionOrder);
        });

        $("#LoadDescriptiveQuestion").click(function () {
            var OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
            var QuestionOrder = $('#DescriptiveStartQuestionOrder').val();
            OnlineExam.LoadQuestions(OnlineExamIndStudentExamInfoID, QuestionOrder);
        });


        InitAnimatedBorder();

        CloseAlert();

    },

    init: function (h, m, s) {
        debugger
        h = parseInt(h, 10);
        m = parseInt(m, 10);
        s = parseInt(s, 10);
        if (h < 0 || m < 0 || s < 0 || isNaN(h) || isNaN(m) || isNaN(s)) {
            alert('Invalid Values');
            return;
        }
        OnlineExam.hours = h;
        OnlineExam.minutes = m;
        OnlineExam.seconds = s;
        OnlineExam.start();
    },
    start: function () {
        OnlineExam.samay = setInterval((OnlineExam.doCountDown), 1000);
    },
    doCountDown: function () {
        if (OnlineExam.seconds == 0) {
            if (OnlineExam.minutes == 0) {
                if (OnlineExam.hours == 0) {
                    clearInterval(OnlineExam.samay);
                    OnlineExam.timerComplete();
                    return;
                }
                else {
                    OnlineExam.seconds = 59;
                    OnlineExam.minutes = 59;
                    OnlineExam.hours--;
                }
            }
            else {
                OnlineExam.seconds = 59;
                OnlineExam.minutes--;
            }
        }
        else {
            OnlineExam.seconds--;
        }
        OnlineExam.updateTimer(OnlineExam.hours, OnlineExam.minutes, OnlineExam.seconds);
    },
    updateTimer: function (hr, min, secs) {
        hr = (hr < 10 ? '0' + hr : hr);
        min = (min < 10 ? '0' + min : min);
        secs = (secs < 10 ? '0' + secs : secs);
        if (hr <= 0 && min <= 0 && secs <= 0) {
            $('#hours').style.display = "none";
            $('#minutes').style.display = "none";
            $('#seconds').style.display = "none";
            return;
        }
        else {
            $('#hours').html(hr);
            $('#minutes').html(min);
            $('#seconds').html(secs);
        }
    },
    timerComplete: function () {
        OnlineExam.ActionName = "FinalSubmitExam";
        OnlineExam.AjaxCallOnlineExam();
    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OnlineExam/List',
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
            url: '/OnlineExam/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    LoadQuestions: function (OnlineExamIndStudentExamInfoID, QuestionOrder) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { OnlineExamIndStudentExamInfoID: OnlineExamIndStudentExamInfoID, QuestionOrder: QuestionOrder },
            url: '/OnlineExam/OnlineExamLoadQuestion',
            success: function (data) {
                //Rebind Grid Data
                $("#LoadQuestions").empty().append(data);

                if ($("#IsQuestionDescriptive").val() == 'True' && $("#LoadDescriptiveQuestion").hasClass("btn-primary")) {
                    $("#LoadDescriptiveQuestion").removeClass("btn-primary");
                    $("#LoadDescriptiveQuestion").addClass("btn-warning");
                    $("#LoadObjectiveQuestion").removeClass("btn-warning");
                    $("#LoadObjectiveQuestion").addClass("btn-primary");
                } else if ($("#IsQuestionDescriptive").val() == 'False' && $("#LoadObjectiveQuestion").hasClass("btn-primary")) {
                    $("#LoadObjectiveQuestion").removeClass("btn-primary");
                    $("#LoadObjectiveQuestion").addClass("btn-warning");
                    $("#LoadDescriptiveQuestion").removeClass("btn-warning");
                    $("#LoadDescriptiveQuestion").addClass("btn-primary");
                }
            }
        });
    },

    AjaxCallOnlineExam: function () {
        debugger
        var OnlineExamData = null;

        if (OnlineExam.ActionName == "Create") {
            $("#FormCreateOnlineExam").validate();
            if ($("#FormCreateOnlineExam").valid()) {
                OnlineExamData = null;
                OnlineExamData = OnlineExam.GetOnlineExam();
                ajaxRequest.makeRequest("/OnlineExam/Create", "POST", OnlineExamData, OnlineExam.Success, "CreateOnlineExamRecord");
            }
        } else if (OnlineExam.ActionName == "SaveAndNext" || OnlineExam.ActionName == "SaveAndMarkForReview" || OnlineExam.ActionName == "ClearResponse") {
            $("#FormOnlineExamQuestionPaperAndOptions").validate();
            if ($("#FormOnlineExamQuestionPaperAndOptions").valid()) {
                OnlineExamData = null;
                OnlineExamData = OnlineExam.GetOnlineExam();
                ajaxRequest.makeRequest("/OnlineExam/OnlineExamSaveAnswer", "POST", OnlineExamData, OnlineExam.SaveSuccess);
            }
        } else if (OnlineExam.ActionName == "FinalSubmitExam") {
            $("#FormOnlineExamQuestionPaperAndOptions").validate();
            if ($("#FormOnlineExamQuestionPaperAndOptions").valid()) {
                OnlineExamData = null;
                OnlineExamData = OnlineExam.GetOnlineExam();
                ajaxRequest.makeRequest("/OnlineExam/OnlineExamFinalSubmit", "POST", OnlineExamData, OnlineExam.SaveSuccess);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOnlineExam: function () {
        var Data = {
        };

        if (OnlineExam.ActionName == "Create" || OnlineExam.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.PaperSetCode = $('#PaperSetCode').val();
        } else if (OnlineExam.ActionName == "SaveAndNext") {
            Data.OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
            Data.QuestionOrder = $('#QuestionOrder').val();
            Data.AnswerOptionID = $('input[name=AnsweredOptionID]:checked').val();
            Data.DescriptiveAnswer = $('.AnswerEditor').code();
            Data.IsQuestionDescriptive = $('#IsQuestionDescriptive').val();
            Data.AttachedDocument = $('#AttachedDocument').val();
            if (Data.IsQuestionDescriptive == 'False') {
                if (Data.AnswerOptionID > 0) {
                    Data.CurrentStatus = 1;
                } else {
                    Data.CurrentStatus = 2;
                }
            } else if (Data.IsQuestionDescriptive == 'True') {
                if (Data.DescriptiveAnswer != "") {
                    Data.CurrentStatus = 1;
                } else {
                    Data.CurrentStatus = 2;
                }
            }
        } else if (OnlineExam.ActionName == "SaveAndMarkForReview") {
            Data.OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
            Data.QuestionOrder = $('#QuestionOrder').val();
            Data.AnswerOptionID = $('input[name=AnsweredOptionID]:checked').val();
            Data.DescriptiveAnswer = $('.AnswerEditor').code();
            Data.IsQuestionDescriptive = $('#IsQuestionDescriptive').val();
            Data.AttachedDocument = $('#AttachedDocument').val();
            if (Data.IsQuestionDescriptive == 'False') {
                if (Data.AnswerOptionID > 0) {
                    Data.CurrentStatus = 4;
                } else {
                    Data.CurrentStatus = 3;
                }
            } else if (Data.IsQuestionDescriptive == 'True') {
                if (Data.DescriptiveAnswer != "") {
                    Data.CurrentStatus = 4;
                } else {
                    Data.CurrentStatus = 3;
                }
            }
        } else if (OnlineExam.ActionName == "ClearResponse") {
            Data.OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
            Data.QuestionOrder = $('#QuestionOrder').val();
            Data.AnswerOptionID = 0;
            Data.CurrentStatus = 2;
            Data.DescriptiveAnswer = null;
            Data.AttachedDocument = $('#AttachedDocument').val();
            Data.IsQuestionDescriptive = $('#IsQuestionDescriptive').val();
        } else if (OnlineExam.ActionName == "FinalSubmitExam") {
            Data.OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            OnlineExam.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
    SaveSuccess: function (data) {
        debugger
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            var OnlineExamIndStudentExamInfoID = $('#OnlineExamIndStudentExamInfoID').val();
            if (OnlineExam.ActionName == "SaveAndNext" || OnlineExam.ActionName == "SaveAndMarkForReview") {
                if (parseInt($('#QuestionOrder').val()) == parseInt($('#TotalQuestions').val())) {
                    var QuestionOrder = parseInt($('#QuestionOrder').val());
                } else {
                    var QuestionOrder = parseInt($('#QuestionOrder').val()) + 1;
                }
                OnlineExam.LoadQuestions(OnlineExamIndStudentExamInfoID, QuestionOrder);
            } else if (OnlineExam.ActionName == "ClearResponse") {
                var QuestionOrder = parseInt($('#QuestionOrder').val());
                OnlineExam.LoadQuestions(OnlineExamIndStudentExamInfoID, QuestionOrder);
            } else if (OnlineExam.ActionName == "FinalSubmitExam") {
                swal({

                    title: 'Thank you',
                    text: "Examination has been completed. The answers are saved succesfully. You can view result on Portal.",
                    showCancelButton: false,
                    confirmButtonClass: 'btn-success',
                    confirmButtonText: "OK!"

                }, function (isConfirm) {
                    if (isConfirm) {
                        window.close();
                    }
                });
            }

        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

