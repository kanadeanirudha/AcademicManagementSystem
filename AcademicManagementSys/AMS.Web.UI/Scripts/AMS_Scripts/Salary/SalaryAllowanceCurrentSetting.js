//this class contain methods related to nationality functionality
var SalaryAllowanceCurrentSetting = {
    //Member variables
    ActionName: null,
    map: {},
    map2: {},
    Initialize: function () {
        //organisationStudyCentre.loadData();
        SalaryAllowanceCurrentSetting.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#Designation').focus();

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

            return false;
        });
        // Create new record
        $('#CreateSalaryAllowanceCurrentSettingRecord').on("click", function () {
            debugger;
            SalaryAllowanceCurrentSetting.ActionName = "Create";
            SalaryAllowanceCurrentSetting.AjaxCallSalaryAllowanceCurrentSetting();
        });
        $('#EditSalaryAllowanceCurrentSettingRecord').on("click", function () {
            debugger;
            SalaryAllowanceCurrentSetting.ActionName = "Edit";
            SalaryAllowanceCurrentSetting.AjaxCallSalaryAllowanceCurrentSetting();
        });
        $('#DeleteSalaryAllowanceCurrentSettingRecord').on("click", function () {
            debugger;
            SalaryAllowanceCurrentSetting.ActionName = "Delete";
            SalaryAllowanceCurrentSetting.AjaxCallSalaryAllowanceCurrentSetting();
        });


        $('#AllowanceType').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#AllowanceHeadName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });



        InitAnimatedBorder();
        CloseAlert();
    },

    //LoadList method is used to load List page
    LoadList: function () {
        debugger;
        $.ajax(
         {


             cache: false,
             type: "POST",
             dataType: "html",
             url: '/SalaryAllowanceCurrentSetting/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/SalaryAllowanceCurrentSetting/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSalaryAllowanceCurrentSetting: function () {
        debugger;
        var SalaryAllowanceCurrentSettingData = null;
        if (SalaryAllowanceCurrentSetting.ActionName == "Create") {
            $("#FormCreateSalaryAllowanceCurrentSetting").validate();
            if ($("#FormCreateSalaryAllowanceCurrentSetting").valid()) {
                SalaryAllowanceCurrentSettingData = null;
                SalaryAllowanceCurrentSettingData = SalaryAllowanceCurrentSetting.GetSalaryAllowanceCurrentSetting();
                ajaxRequest.makeRequest("/SalaryAllowanceCurrentSetting/Create", "POST", SalaryAllowanceCurrentSettingData, SalaryAllowanceCurrentSetting.Success, "CreateSalaryAllowanceCurrentSettingRecord");
            }
        }
        else if (SalaryAllowanceCurrentSetting.ActionName == "Edit") {
            debugger;
            $("#FormEditSalaryAllowanceCurrentSetting").validate();
            if ($("#FormEditSalaryAllowanceCurrentSetting").valid()) {
                SalaryAllowanceCurrentSettingData = null;
                SalaryAllowanceCurrentSettingData = SalaryAllowanceCurrentSetting.GetSalaryAllowanceCurrentSetting();
                ajaxRequest.makeRequest("/SalaryAllowanceCurrentSetting/Edit", "POST", SalaryAllowanceCurrentSettingData, SalaryAllowanceCurrentSetting.Success);
            }
        }
        else if (SalaryAllowanceCurrentSetting.ActionName == "Delete") {
            debugger;
            SalaryAllowanceCurrentSettingData = null;
            // $("#FormCreateSalaryAllowanceCurrentSetting").validate();
            SalaryAllowanceCurrentSettingData = SalaryAllowanceCurrentSetting.GetSalaryAllowanceCurrentSetting();
            ajaxRequest.makeRequest("/SalaryAllowanceCurrentSetting/Delete", "POST", SalaryAllowanceCurrentSettingData, SalaryAllowanceCurrentSetting.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryAllowanceCurrentSetting: function () {
        var Data = {
        };

        if (SalaryAllowanceCurrentSetting.ActionName == "Create") {
            debugger;
            //Data.ID = $('#ID').val();
            Data.SalaryAllowanceMasterID = $('#AllowanceHeadName').val();
            Data.FixedAmount = $('#FixedAmount').val();
            Data.Percentage = $('#Percentage').val();
            Data.EffectedDate = $('#EffectedDate').val();
            Data.CloseDate = $('#CloseDate').val();
            Data.IsCurrent = $('input[id=IsCurrent]:checked').val() ? true : false;
            Data.SalaryPayRulesID = $('#PayScaleRuleDescription').val();
            Data.MapAccountID = $('#AccountName').val();
            Data.CalculateOn = $('#CalculateOn').val();
           // Data.AccountName = $('#AccountName').val();
            //Data.AllowanceHeadName = $('#AllowanceHeadName').val();
            //Data.PayScaleRuleDescription = $('#PayScaleRuleDescription').val();
        }
        else if (SalaryAllowanceCurrentSetting.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.SalaryAllowanceMasterID = $('#AllowanceHeadName').val();
            Data.FixedAmount = $('#FixedAmount').val();
            Data.Percentage = $('#Percentage').val();
            Data.EffectedDate = $('#EffectedDate').val();
            Data.CloseDate = $('#CloseDate').val();
            Data.IsCurrent = $('input[id=IsCurrent]:checked').val() ? true : false;
            Data.SalaryPayRulesID = $('#PayScaleRuleDescription').val();
            Data.MapAccountID = $('#AccountName').val();
            Data.CalculateOn = $('#CalculateOn').val();
        }
        else if (SalaryAllowanceCurrentSetting.ActionName == "Delete") {
            debugger;
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            SalaryAllowanceCurrentSetting.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            SalaryAllowanceCurrentSetting.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

