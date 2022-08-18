var OnlineExaminationMaster = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    TotalQueCount:null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OnlineExaminationMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {

        //Hides textbox
        $("#divNegativeMarksPerQue").hide();

        $("input[id=IsNegativeMarkingApplicable]").on("change", function () {
            if ($(this).is(':checked')) {
                $("#divNegativeMarksPerQue").show();
            }
            else {
                $("#divNegativeMarksPerQue").hide();
            }
        });

        $("#TotalQuestion").on("keyup", function () {
            $("#TotalMarks").val($(this).val() * $("#MarksInEachQuestion").val());
        });
        $("#MarksInEachQuestion").on("keyup", function () {
            $("#TotalMarks").val($(this).val() * $("#TotalQuestion").val());
        });
        
        

        //Enable/Disable subject textbox according to questiontype
        $("#QuestionType").on("change", function () {
            var relatedWith = $(this).val().split("~")[0];
            if (relatedWith == "S") {
                $("#SubjectName").prop("disabled", false);
            }
            else {
                $("#SubjectName").prop("disabled", true);
                $("#SubjectID").val(0);
                $("#SubjectName").val('');
            }
        });

        //Initialize subject searchlist
        $("#SubjectName").on("keydown", function () {
            OnlineExaminationMaster.SubjectSearchList();
        });

        //Add row in table
        $("#addItem").on("click", function () {            
            var relatedWith = $("#QuestionType").val().split('~')[0];
            var questionTypeId = $("#QuestionType").val().split('~')[1];
            var subjectId = $("#SubjectID").val();
            if (relatedWith == "S" && subjectId == 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SubjectRequiredForQueType", "DisplayMessage", "#FFCC80");
            }
            else {
                if (OnlineExaminationMaster.IsValidInput(relatedWith, questionTypeId, subjectId)) {
                    OnlineExaminationMaster.AddRow();
                }
                else {
                    ajaxRequest.ErrorMessageForJS("Message_RecordAlreadyExists", "DisplayMessage", "#FFCC80");
                }
            }
        });

        // Create new record
        $('#CreateOnlineExaminationMasterRecord').on("click", function () {
            OnlineExaminationMaster.ActionName = "Create";
            if (OnlineExaminationMaster.IsSubjectAllotedToExam()) {
                if (OnlineExaminationMaster.TotalQueCount == $("#TotalQuestion").val()) {
                    OnlineExaminationMaster.AjaxCallOnlineExaminationMaster();
                }
                else {
                    ajaxRequest.ErrorMessageForJS("JsValidationMessages_TotalQuestionDifference", "DisplayMessage", "#FFCC80");
                }                
            } 
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_ExamDetailsRequired", "DisplayMessage", "#FFCC80");
            }
            OnlineExaminationMaster.TotalQueCount = 0;
        });

        //Delete record
        $('#DeleteOnlineExaminationMasterRecord').on("click", function () {
            OnlineExaminationMaster.ActionName = "Delete";
            OnlineExaminationMaster.AjaxCallOnlineExaminationMaster();
        });

        $('#ExaminationName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Purpose').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#TotalQuestion').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#TotalMarks').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#TotalTime').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#MarksInEachQuestion').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('#TotalPaperSet').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#NegativeMarksInEachQuestion').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });
        
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $(".ajax").colorbox();


    },

    //Search list for subject
    SubjectSearchList: function () {
        $("#SubjectName").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Base/GetSubjectList",
                    type: "POST",
                    dataType: "json",
                    data: { "term": request.term },
                    success: function (data) {
                        if (!data.length) {
                            var result = [{ label: 'No matches found', value: response.term }];
                            response(result);
                        }
                        else {
                            response($.map(data, function (item) {
                                return { label: item.name, value: item.name, id: item.id };
                            }))
                        }
                    }
                })
            },
            select: function (event, ui) {                
                if (ui.item.value != "No matches found") {
                    $(this).val(ui.item.label);
                    $("#SubjectID").val(parseInt(ui.item.id));
                }
            }
        });
    },

    //Checks Type of Question Type
    CheckQuestionTypeOnLoad: function () {
        var relatedWith = $("#QuestionType").val().split('~')[0];
        if (relatedWith == "S") {
            $("#SubjectName").prop("disabled", false);
        }
    },

    //Adds row
    AddRow: function () {
        $("#tblData tbody").append(
            "<tr>" +
            "<td ><input type='text' value=" + $('#QuestionType :selected').val().split("~")[1] + " style='display:none' /> " + $('#QuestionType :selected').text() + "</td>" +
            "<td><input  type='text' value=" + $('#SubjectID').val() + " style='display:none' /> " + $('#SubjectName').val() + "</td>" +
            "<td><input  type='text' value=" + parseFloat($('#TotalQuestionQueTypeWise').val()) + " style='width:60%;height:16px;text-align:right'/></td>" +
            "<td  style='text-align:center; '><i class='icon-trash' style='cursor:pointer;'  title = Delete></td>" +
            "</tr>");
        OnlineExaminationMaster.DeleteRow();
    },

    //Delete row
    DeleteRow: function () {
        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
        });
    },

    //Checks duplicate entry
    IsValidInput: function (relatedWith, questionTypeId, subjectId) {
        var DataArray = [];        
        var x = 0;
        var isValid = true;
        $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
        var Count = DataArray.length / 3;
        for (var i = 0; i < Count; i++) {
            if (questionTypeId == DataArray[x] && subjectId == DataArray[x+1]) {
                isValid = false;
                break;
            }
            x = x + 3;
        }
        return isValid;
    },

    //Method to create xml
    IsSubjectAllotedToExam: function () {
        var DataArray = [];
        $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        OnlineExaminationMaster.TotalQueCount = 0;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 3) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><QuestionTypeID>" + DataArray[i] + "</QuestionTypeID><SubjectID>" + DataArray[i + 1] + "</SubjectID><TotalQuestion>" + DataArray[i + 2] + "</TotalQuestion></row>";
            OnlineExaminationMaster.TotalQueCount = parseInt(OnlineExaminationMaster.TotalQueCount) +parseInt(DataArray[i + 2]);
        }
        if (ParameterXml.length > 6) {
            OnlineExaminationMaster.XMLstring = ParameterXml + "</rows>";
            return true;
        }
        else {
            OnlineExaminationMaster.XMLstring = "";
            return false;
        }
    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OnlineExaminationMaster/List',
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
            data: { "actionMode": actionMode },
            url: '/OnlineExaminationMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallOnlineExaminationMaster: function () {
        var OnlineExaminationMasterData = null;
        if (OnlineExaminationMaster.ActionName == "Create") {
            $("#FormCreateOnlineExaminationMaster").validate();
            if ($("#FormCreateOnlineExaminationMaster").valid()) {
                OnlineExaminationMasterData = null;
                OnlineExaminationMasterData = OnlineExaminationMaster.GetOnlineExaminationMaster();
                ajaxRequest.makeRequest("/OnlineExaminationMaster/Create", "POST", OnlineExaminationMasterData, OnlineExaminationMaster.Success);
            }
        }
        else if (OnlineExaminationMaster.ActionName == "Delete") {
            OnlineExaminationMasterData = null;
            $("#FormDeleteOnlineExaminationMaster").validate();
            OnlineExaminationMasterData = OnlineExaminationMaster.GetOnlineExaminationMaster();
            ajaxRequest.makeRequest("/OnlineExaminationMaster/Delete", "POST", OnlineExaminationMasterData, OnlineExaminationMaster.Success);
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetOnlineExaminationMaster: function () {
        var Data = {
        };
        if (OnlineExaminationMaster.ActionName == "Create") {
            Data.ID = $('#ID').val();
            Data.ExaminationName = $('#ExaminationName').val();
            Data.Purpose = $('#Purpose').val();
            Data.AcadSessionId = $('#AcadSessionId').val();
            Data.TotalQuestion = $('#TotalQuestion').val();
            Data.TotalMarks = $('#TotalMarks').val();
            Data.TotalTime = $('#TotalTime').val();
            Data.MarksInEachQuestion = $('#MarksInEachQuestion').val();
            Data.TotalPaperSet = $('#TotalPaperSet').val();
            Data.IsNegativeMarkingApplicable = $("input[id=IsNegativeMarkingApplicable]:checked").val();
           
            if (Data.IsNegativeMarkingApplicable == "true") {
                Data.NegativeMarksInEachQuestion = $('#NegativeMarksInEachQuestion').val();
            }
            else {
                Data.NegativeMarksInEachQuestion = 0;
            }
            Data.XMLString = OnlineExaminationMaster.XMLstring;
        }
        else if (OnlineExaminationMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        OnlineExaminationMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
};

