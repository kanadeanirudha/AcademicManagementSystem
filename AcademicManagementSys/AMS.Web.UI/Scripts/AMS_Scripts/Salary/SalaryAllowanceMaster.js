//this class contain methods related to nationality functionality
var SalaryAllowanceMaster = {
    //Member variables
    ActionName: null,

    Initialize: function () {
        //organisationStudyCentre.loadData();
        SalaryAllowanceMaster.constructor();
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
        $('#CreateSalaryAllowanceMasterRecord').on("click", function () {
            debugger;
            SalaryAllowanceMaster.ActionName = "Create";
            SalaryAllowanceMaster.AjaxCallSalaryAllowanceMaster();
        });
        $('#EditSalaryAllowanceMasterRecord').on("click", function () {
            debugger;
            SalaryAllowanceMaster.ActionName = "Edit";
            SalaryAllowanceMaster.AjaxCallSalaryAllowanceMaster();
        });
        $('#DeleteSalaryAllowanceMasterRecord').on("click", function () {
            debugger;
            SalaryAllowanceMaster.ActionName = "Delete";
            SalaryAllowanceMaster.AjaxCallSalaryAllowanceMaster();
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
             url: '/SalaryAllowanceMaster/List',
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
            url: '/SalaryAllowanceMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallSalaryAllowanceMaster: function () {
        debugger;
        var SalaryAllowanceMasterData = null;
        if (SalaryAllowanceMaster.ActionName == "Create") {
            $("#FormCreateSalaryAllowanceMaster").validate();
            if ($("#FormCreateSalaryAllowanceMaster").valid()) {
                SalaryAllowanceMasterData = null;
                SalaryAllowanceMasterData = SalaryAllowanceMaster.GetSalaryAllowanceMaster();
                ajaxRequest.makeRequest("/SalaryAllowanceMaster/Create", "POST", SalaryAllowanceMasterData, SalaryAllowanceMaster.Success, "CreateSalaryAllowanceMasterRecord");
            }
        }
        else if (SalaryAllowanceMaster.ActionName == "Edit") {
            debugger;
            $("#FormEditSalaryAllowanceMaster").validate();
            if ($("#FormEditSalaryAllowanceMaster").valid()) {
                SalaryAllowanceMasterData = null;
                SalaryAllowanceMasterData = SalaryAllowanceMaster.GetSalaryAllowanceMaster();
                ajaxRequest.makeRequest("/SalaryAllowanceMaster/Edit", "POST", SalaryAllowanceMasterData, SalaryAllowanceMaster.Success);
            }
        }
        else if (SalaryAllowanceMaster.ActionName == "Delete") {
            debugger;
            SalaryAllowanceMasterData = null;
            // $("#FormCreateSalaryAllowanceMaster").validate();
            SalaryAllowanceMasterData = SalaryAllowanceMaster.GetSalaryAllowanceMaster();
            ajaxRequest.makeRequest("/SalaryAllowanceMaster/Delete", "POST", SalaryAllowanceMasterData, SalaryAllowanceMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSalaryAllowanceMaster: function () {
        var Data = {
        };

        if (SalaryAllowanceMaster.ActionName == "Create") {
            debugger;
            Data.ID = $('#ID').val();
            Data.AllowanceHeadName = $('#AllowanceHeadName').val();
            Data.AllowanceType = $('#AllowanceType').val();
        }
        else if (SalaryAllowanceMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.AllowanceHeadName = $('#AllowanceHeadName').val();
            Data.AllowanceType = $('#AllowanceType').val();
        }
        else if (SalaryAllowanceMaster.ActionName == "Delete") {
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
            SalaryAllowanceMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            SalaryAllowanceMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

