var OnlineExaminationQuestionPaperSetMaster = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    arrayList:new Array(),
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        OnlineExaminationQuestionPaperSetMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {

        $("#btnSpin").on("click", function () {
            OnlineExaminationQuestionPaperSetMaster.SpinQuestionList();
        });

        // Create new record
        $('#CreateOnlineExaminationQuestionPaperSetMasterRecord').on("click", function () {
          
            OnlineExaminationQuestionPaperSetMaster.ActionName = "Create";
            if (OnlineExaminationQuestionPaperSetMaster.IsValidXmlCreated()) {
                OnlineExaminationQuestionPaperSetMaster.AjaxCallOnlineExaminationQuestionPaperSetMaster();
            }
            else {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_TotalQuestionDifference", "DisplayMessage", "#FFCC80");
               // OnlineExaminationQuestionPaperSetMaster.ResetArrayList();
            }
            OnlineExaminationQuestionPaperSetMaster.ResetArrayList();
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

    //Spins question list
    SpinQuestionList: function () {
        $.ajax({
            type: 'GET',
            url: "/OnlineExaminationQuestionPaperSetMaster/SpinQuestionList",
            data: { ID : $("#OnlineExamExaminationMasterID").val() },
            success: function (data, textstatus) {
                if (data != '') {
                    $("#tblData > tbody").html('');
                    $("#tblData > tbody").append(data);
                    $("#tblData > tbody > tr:even").addClass("alt-row-class");
                    $("#tblData > tbody > tr:odd").removeClass("alt-row-class");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    },

    //Method to create xml
    IsValidXmlCreated: function () {
        $('#tblData tbody tr td input').each(function () {
            OnlineExaminationQuestionPaperSetMaster.arrayList.push($(this).val());
        });
        var TotalRecord = OnlineExaminationQuestionPaperSetMaster.arrayList.length;
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i++) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><OnlineExamQuestionBankMasterID>" + OnlineExaminationQuestionPaperSetMaster.arrayList[i] + "</OnlineExamQuestionBankMasterID></row>";
        }
        if (ParameterXml.length > 6) {
            OnlineExaminationQuestionPaperSetMaster.XMLstring = ParameterXml + "</rows>";
            return true;
        }
        else {
            OnlineExaminationQuestionPaperSetMaster.XMLstring = "";
            return false;
        }

    },
  
    IsValidated: function () {
        $('#tblData tbody tr td input').each(function () {
            OnlineExaminationQuestionPaperSetMaster.arrayList.push($(this).val());
        });
        var totalRows = OnlineExaminationQuestionPaperSetMaster.arrayList.length;
        var totalQueRequired = $("#TotalQuestion").val();
        return totalRows == totalQueRequired
    },

    ResetArrayList: function () {
      
        //OnlineExaminationQuestionPaperSetMaster.arrayList.splice(0, OnlineExaminationQuestionPaperSetMaster.arrayList.length)
        OnlineExaminationQuestionPaperSetMaster.arrayList = [];
    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OnlineExaminationQuestionPaperSetMaster/List',
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
            url: '/OnlineExaminationQuestionPaperSetMaster/List',
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
    AjaxCallOnlineExaminationQuestionPaperSetMaster: function () {
        var OnlineExaminationQuestionPaperSetMasterData = null;
        if (OnlineExaminationQuestionPaperSetMaster.ActionName == "Create") {
            $("#FormCreateOnlineExaminationQuestionPaperSetMaster").validate();
            if ($("#FormCreateOnlineExaminationQuestionPaperSetMaster").valid()) {
                OnlineExaminationQuestionPaperSetMasterData = null;
                OnlineExaminationQuestionPaperSetMasterData = OnlineExaminationQuestionPaperSetMaster.GetOnlineExaminationQuestionPaperSetMaster();
                ajaxRequest.makeRequest("/OnlineExaminationQuestionPaperSetMaster/Create", "POST", OnlineExaminationQuestionPaperSetMasterData, OnlineExaminationQuestionPaperSetMaster.Success);
            }
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetOnlineExaminationQuestionPaperSetMaster: function () {
        var Data = {
        };
        if (OnlineExaminationQuestionPaperSetMaster.ActionName == "Create") {
            Data.OnlineExamExaminationMasterID = $('#OnlineExamExaminationMasterID').val();
            Data.PaperSetCode = $('#PaperSetCode').val();
            Data.XMLString = OnlineExaminationQuestionPaperSetMaster.XMLstring;
        }
        else if (OnlineExaminationQuestionPaperSetMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        OnlineExaminationQuestionPaperSetMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
};

