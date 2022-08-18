//this class contain methods related to nationality functionality
var SalaryDeductionCurrentSetting = {
    //Member variables
    ActionName: null,
    map: {},
    map2: {},
    Initialize: function () {
        //organisationStudyCentre.loadData();
       SalaryDeductionCurrentSetting.constructor();
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
        $('#CreateSalaryDeductionCurrentSettingRecord').on("click", function () {
            debugger;
           SalaryDeductionCurrentSetting.ActionName = "Create";
           SalaryDeductionCurrentSetting.AjaxCallSalaryDeductionCurrentSetting();
        });
        $('#EditSalaryDeductionCurrentSettingRecord').on("click", function () {
            debugger;
           SalaryDeductionCurrentSetting.ActionName = "Edit";
           SalaryDeductionCurrentSetting.AjaxCallSalaryDeductionCurrentSetting();
        });
        $('#DeleteSalaryDeductionCurrentSettingRecord').on("click", function () {
            debugger;
           SalaryDeductionCurrentSetting.ActionName = "Delete";
           SalaryDeductionCurrentSetting.AjaxCallSalaryDeductionCurrentSetting();
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
             url: '/SalaryDeductionCurrentSetting/List',
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
            url: '/SalaryDeductionCurrentSetting/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSalaryDeductionCurrentSetting: function () {
        debugger;
        varSalaryDeductionCurrentSettingData = null;
        if (SalaryDeductionCurrentSetting.ActionName == "Create") {
            $("#FormCreateSalaryDeductionCurrentSetting").validate();
            if ($("#FormCreateSalaryDeductionCurrentSetting").valid()) {
              // SalaryDeductionCurrentSettingData = null;
               SalaryDeductionCurrentSettingData =SalaryDeductionCurrentSetting.GetSalaryDeductionCurrentSetting();
                ajaxRequest.makeRequest("/SalaryDeductionCurrentSetting/Create", "POST",SalaryDeductionCurrentSettingData,SalaryDeductionCurrentSetting.Success, "CreateSalaryDeductionCurrentSettingRecord");
            }
        }
        else if (SalaryDeductionCurrentSetting.ActionName == "Edit") {
            debugger;
            $("#FormEditSalaryDeductionCurrentSetting").validate();
            if ($("#FormEditSalaryDeductionCurrentSetting").valid()) {
               SalaryDeductionCurrentSettingData = null;
               SalaryDeductionCurrentSettingData =SalaryDeductionCurrentSetting.GetSalaryDeductionCurrentSetting();
                ajaxRequest.makeRequest("/SalaryDeductionCurrentSetting/Edit", "POST",SalaryDeductionCurrentSettingData,SalaryDeductionCurrentSetting.Success);
            }
        }
        else if (SalaryDeductionCurrentSetting.ActionName == "Delete") {
            debugger;
           SalaryDeductionCurrentSettingData = null;
            // $("#FormCreateSalaryDeductionCurrentSetting").validate();
           SalaryDeductionCurrentSettingData =SalaryDeductionCurrentSetting.GetSalaryDeductionCurrentSetting();
            ajaxRequest.makeRequest("/SalaryDeductionCurrentSetting/Delete", "POST",SalaryDeductionCurrentSettingData,SalaryDeductionCurrentSetting.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryDeductionCurrentSetting: function () {
        var Data = {
        };

        if (SalaryDeductionCurrentSetting.ActionName == "Create") {
            debugger;
           
            Data.SalaryDeductionMasterID = $('#DeductionHeadName').val();
            Data.FixAmount = $('#FixAmount').val();
            Data.Percentage = $('#Percentage').val();
            Data.MapAccountID = $('#AccountName').val();
            Data.CalculateOn = $('#CalculateOn').val();
          
        }
        else if (SalaryDeductionCurrentSetting.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.SalaryDeductionMasterID = $('#DeductionHeadName').val();
            Data.FixAmount = $('#FixAmount').val();
            Data.Percentage = $('#Percentage').val();
            Data.MapAccountID = $('#AccountName').val();
            Data.CalculateOn = $('#CalculateOn').val();
        }
        else if (SalaryDeductionCurrentSetting.ActionName == "Delete") {
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
           SalaryDeductionCurrentSetting.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
           SalaryDeductionCurrentSetting.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

