//this class contain methods related to nationality functionality
var SalaryDeductionMaster= {
    //Member variables
    ActionName: null,

    Initialize: function () {
        //organisationStudyCentre.loadData();
        SalaryDeductionMaster.constructor();
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
        $('#CreateSalaryDeductionMasterRecord').on("click", function () {
            debugger;
            SalaryDeductionMaster.ActionName = "Create";
            SalaryDeductionMaster.AjaxCallSalaryDeductionMaster();
        });
        $('#EditSalaryDeductionMasterRecord').on("click", function () {
            debugger;
            SalaryDeductionMaster.ActionName = "Edit";
            SalaryDeductionMaster.AjaxCallSalaryDeductionMaster();
        });
        $('#DeleteSalaryDeductionMasterRecord').on("click", function () {
            debugger;
            SalaryDeductionMaster.ActionName = "Delete";
            SalaryDeductionMaster.AjaxCallSalaryDeductionMaster();
        });


        $('#DeductionType').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#DeductionHeadName').on("keydown", function (e) {
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
             url: '/SalaryDeductionMaster/List',
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
            url: '/SalaryDeductionMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSalaryDeductionMaster: function () {
        debugger;
        var SalaryDeductionMasterData = null;
        if (SalaryDeductionMaster.ActionName == "Create") {
            $("#FormCreateSalaryDeductionMaster").validate();
            if ($("#FormCreateSalaryDeductionMaster").valid()) {
                SalaryDeductionMasterData = null;
                SalaryDeductionMasterData = SalaryDeductionMaster.GetSalaryDeductionMaster();
                ajaxRequest.makeRequest("/SalaryDeductionMaster/Create", "POST", SalaryDeductionMasterData, SalaryDeductionMaster.Success, "CreateSalaryDeductionMasterRecord");
            }
        }
        else if (SalaryDeductionMaster.ActionName == "Edit") {
            debugger;
            $("#FormEditSalaryDeductionMaster").validate();
            if ($("#FormEditSalaryDeductionMaster").valid()) {
                SalaryDeductionMasterData = null;
                SalaryDeductionMasterData = SalaryDeductionMaster.GetSalaryDeductionMaster();
                ajaxRequest.makeRequest("/SalaryDeductionMaster/Edit", "POST", SalaryDeductionMasterData, SalaryDeductionMaster.Success);
            }
        }
        else if (SalaryDeductionMaster.ActionName == "Delete") {
            debugger;
            SalaryDeductionMasterData = null;
            // $("#FormCreateSalaryDeductionMaster").validate();
            SalaryDeductionMasterData = SalaryDeductionMaster.GetSalaryDeductionMaster();
            ajaxRequest.makeRequest("/SalaryDeductionMaster/Delete", "POST", SalaryDeductionMasterData, SalaryDeductionMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryDeductionMaster: function () {
        var Data = {
        };

        if (SalaryDeductionMaster.ActionName == "Create") {
            debugger;
            Data.ID = $('#ID').val();
            Data.DeductionHeadName = $('#DeductionHeadName').val();
            Data.DeductionType = $('#DeductionType').val();
        }
        else if (SalaryDeductionMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.DeductionHeadName = $('#DeductionHeadName').val();
            Data.DeductionType = $('#DeductionType').val();
        }
        else if (SalaryDeductionMaster.ActionName == "Delete") {
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
            SalaryDeductionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            SalaryDeductionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

