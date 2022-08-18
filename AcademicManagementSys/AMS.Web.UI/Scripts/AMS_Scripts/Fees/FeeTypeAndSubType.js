//this class contain methods related to nationality functionality
var FeeTypeAndSubType = {
    //Member variables
    ActionName: null,
    SelectedAccBalsheetMstIDs: null,
    //Class intialisation method
    Initialize: function () {
        FeeTypeAndSubType.constructor();
    },
    //Attach all event of page
    constructor: function () {
     
        $('#CreateFeeTypeMasterRecord').on("click", function () {
           
            FeeTypeAndSubType.ActionName = "CreateFeeType";
            FeeTypeAndSubType.AjaxCallFeeTypeAndSubType();
        });
        $('#DeleteFeeTypeMasterRecord').on("click", function () {
            
            FeeTypeAndSubType.ActionName = "DeleteFeeType";
            FeeTypeAndSubType.AjaxCallFeeTypeAndSubType();
        });
        $('#CreateFeeSubTypeRecord').on("click", function () {

            FeeTypeAndSubType.ActionName = "CreateFeeSubType";
            FeeTypeAndSubType.AjaxCallFeeTypeAndSubType();
        });
        $('#DeleteFeeSubTypeMasterRecord').on("click", function () {
            
            FeeTypeAndSubType.ActionName = "DeleteFeeSubType";
            FeeTypeAndSubType.AjaxCallFeeTypeAndSubType();
        });

        InitAnimatedBorder();
        CloseAlert();
        
        $('#reset').on("click", function () {
            $('#AccountName').focus();
            $('#AccountType').val("");
            $('#ControlHeadlist').val("");
            $('#FeeSubTypeDesc').val("");
            $('#FeeSubShortDesc').val("");
            $('#ControlHeadlist').prop("disabled", true);
            $('#SurpDefFlagList').val("");
            $('#SubTypeIdentification').val("1");
            $('#FeeSource').val("1");
            return false;
        });


        $('#resetfee').on("click", function () {
            $('#FeeTypeDesc').val("");
            $('#FeeTypeCode').val("1");
            return false;
        });





        $('#FeeTypeDesc').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#FeeTypeCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#FeeSubTypeDesc').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#FeeSubShortDesc').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#AccountInNameOf').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#BankBranchName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#BankAccountNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#BankLimitAmount').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#RateOfInterest').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();


            $.ajax(
           {
               cache: false,
               type: "POST",
               data: { "selectedBalsheet": Balancesheet },
               dataType: "html",
               url: '/FeeTypeAndSubType/List',
               success: function (data) {
                   //Rebind Grid Data
                   $('#ListViewModel').html(data);
               }
           });

        
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var Balancesheet = $("#selectedBalsheetID").val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { "selectedBalsheet": Balancesheet, "actionMode": actionMode },
            dataType: "html",
            url: '/FeeTypeAndSubType/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
               notify(message, colorCode);

            }
        });
    },
    //LoadList method is used to load List page
    LoadListByCentreAndBalanceSheet: function (SelectedBalanceSheet) {

        $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             data: { BalanceSheetID: SelectedBalanceSheet },
             url: '/FeeTypeAndSubType/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
   //Fire ajax call to insert update and delete record
    AjaxCallFeeTypeAndSubType: function () {
        var FeeTypeAndSubTypeData = null;
        if (FeeTypeAndSubType.ActionName == "CreateFeeType") {
            $("#FormCreateFeeTypeMaster").validate();
            if ($("#FormCreateFeeTypeMaster").valid()) {
                FeeTypeAndSubTypeData = null;
                FeeTypeAndSubTypeData = FeeTypeAndSubType.GetFeeTypeAndSubType();
                ajaxRequest.makeRequest("/FeeTypeAndSubType/CreateFeeType", "POST", FeeTypeAndSubTypeData, FeeTypeAndSubType.Success, "CreateFeeTypeMasterRecord");
            }
        }
        else if (FeeTypeAndSubType.ActionName == "DeleteFeeType") {
            $("#FormDeleteFeeTypeMaster").validate();
            if ($("#FormDeleteFeeTypeMaster").valid()) {
                FeeTypeAndSubTypeData = null;
                FeeTypeAndSubTypeData = FeeTypeAndSubType.GetFeeTypeAndSubType();
                ajaxRequest.makeRequest("/FeeTypeAndSubType/DeleteFeeType", "POST", FeeTypeAndSubTypeData, FeeTypeAndSubType.Success, "DeleteFeeTypeMasterRecord");
            }
        }
        if (FeeTypeAndSubType.ActionName == "CreateFeeSubType") {
            $("#FormCreateFeeSubTypeMaster").validate();
            if ($("#FormCreateFeeSubTypeMaster").valid()) {
                FeeTypeAndSubTypeData = null;
                FeeTypeAndSubTypeData = FeeTypeAndSubType.GetFeeTypeAndSubType();
                ajaxRequest.makeRequest("/FeeTypeAndSubType/CreateFeeSubType", "POST", FeeTypeAndSubTypeData, FeeTypeAndSubType.Success, "CreateFeeSubTypeRecord");
            }
        }
        else if (FeeTypeAndSubType.ActionName == "DeleteFeeSubType") {
            $("#FormDeleteFeeSubTypeMaster").validate();
            if ($("#FormDeleteFeeSubTypeMaster").valid()) {
                FeeTypeAndSubTypeData = null;
                FeeTypeAndSubTypeData = FeeTypeAndSubType.GetFeeTypeAndSubType();
                ajaxRequest.makeRequest("/FeeTypeAndSubType/DeleteFeeSubType", "POST", FeeTypeAndSubTypeData, FeeTypeAndSubType.Success, "DeleteFeeSubTypeMasterRecord");
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeTypeAndSubType: function () {
        var Data = {
        };
       
            Data.ID = $('input[name=ID]').val();
            Data.FeeTypeDesc = $('input[name=FeeTypeDesc]').val();
            Data.FeeTypeCode = $('#FeeTypeCode').val();
            Data.FeeSubTypeID = $("input[name=FeeSubTypeID]").val();
            Data.FeeSubTypeDesc = $("#FeeSubTypeDesc").val();
            Data.FeeSubShortDesc = $("#FeeSubShortDesc").val();
            Data.AccountID = $("#AccountID").val();
            Data.SubTypeIdentification = $('#SubTypeIdentification').val();
            Data.CarryForwardFeeSubtypeID = $("input[id=CarryForwardFeeSubtypeID]").val();
            Data.FeeSource = $('#FeeSource').val();
            //Data.BankAccountNumber = $("#BankAccountNumber").val();
            //Data.BankLimitAmount = $("#BankLimitAmount").val();
            //Data.OpenDatetime = $('input[name=OpenDatetime]').val();
            //Data.DueDatetime = $('input[name=DueDatetime]').val();
            //Data.AccountInNameOf = $('#AccountInNameOf').val();
            //Data.BankBranchName = $("#BankBranchName").val();
            //Data.InterestMode = $("#InterestModeList").val();
            //Data.InterestType = $("#InterestTypeList").val();
            //Data.RateOfInterest = $('#RateOfInterest').val();
            //   alert(Data.RateOfInterest);
            //Data.SelectedXml = FeeTypeAndSubType.SelectedAccBalsheetMstIDs;
        
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            FeeTypeAndSubType.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }

    },
    
};