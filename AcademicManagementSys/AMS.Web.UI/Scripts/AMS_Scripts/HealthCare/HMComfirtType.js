//this class contain methods related to nationality functionality
var HMComfirtType = {
    //Member variables
    ActionName: null,

    Initialize: function () {
        //organisationStudyCentre.loadData();
        HMComfirtType.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#ComfirtType').focus();

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

            return false;
        });
        // Create new record
        $('#CreateHMComfirtTypeRecord').on("click", function () {
            debugger;
            HMComfirtType.ActionName = "Create";
            HMComfirtType.AjaxCallHMComfirtType();
        });
        $('#EditHMComfirtTypeRecord').on("click", function () {
            debugger;
            HMComfirtType.ActionName = "Edit";
            HMComfirtType.AjaxCallHMComfirtType();
        });
        $('#DeleteHMComfirtTypeRecord').on("click", function () {
            debugger;
            HMComfirtType.ActionName = "Delete";
            HMComfirtType.AjaxCallHMComfirtType();
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
             url: '/HMComfirtType/List',
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
            url: '/HMComfirtType/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallHMComfirtType: function () {
        debugger;
        var HMComfirtTypeData = null;
        if (HMComfirtType.ActionName == "Create") {
            $("#FormCreateHMComfirtType").validate();
            if ($("#FormCreateHMComfirtType").valid()) {
                HMComfirtTypeData = null;
                HMComfirtTypeData = HMComfirtType.GetHMComfirtType();
                ajaxRequest.makeRequest("/HMComfirtType/Create", "POST", HMComfirtTypeData, HMComfirtType.Success, "CreateHMComfirtTypeRecord");
            }
        }
        else if (HMComfirtType.ActionName == "Edit") {
            debugger;
            $("#FormEditHMComfirtType").validate();
            if ($("#FormEditHMComfirtType").valid()) {
                HMComfirtTypeData = null;
                HMComfirtTypeData = HMComfirtType.GetHMComfirtType();
                ajaxRequest.makeRequest("/HMComfirtType/Edit", "POST", HMComfirtTypeData, HMComfirtType.Success);
            }
        }
        else if (HMComfirtType.ActionName == "Delete") {
            debugger;
            HMComfirtTypeData = null;
            // $("#FormCreateHMComfirtType").validate();
            HMComfirtTypeData = HMComfirtType.GetHMComfirtType();
            ajaxRequest.makeRequest("/HMComfirtType/Delete", "POST", HMComfirtTypeData, HMComfirtType.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetHMComfirtType: function () {
        var Data = {
        };

        if (HMComfirtType.ActionName == "Create") {
            debugger;
            Data.ID = $('#ID').val();
            Data.ComfirtType = $('#ComfirtType').val();
            // Data.DeductionType = $('#DeductionType').val();
        }
        else if (HMComfirtType.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
           // Data.DeductionHeadName = $('#DeductionHeadName').val();
           // Data.DeductionType = $('#DeductionType').val();
        }
        else if (HMComfirtType.ActionName == "Delete") {
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
            HMComfirtType.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            HMComfirtType.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

