//this class contain methods related to nationality functionality
var CRMCallerRoleAllocation = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMCallerRoleAllocation.constructor();
        //CRMCallerRoleAllocation.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        // Create new record
        $('#CreateCRMCallerRoleAllocationRecord').on("click", function () {
            CRMCallerRoleAllocation.ActionName = "Create";
            CRMCallerRoleAllocation.AjaxCallCRMCallerRoleAllocation();
        });

        $('#EditCRMCallerRoleAllocationRecord').on("click", function () {

            CRMCallerRoleAllocation.ActionName = "Edit";
            CRMCallerRoleAllocation.AjaxCallCRMCallerRoleAllocation();
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
             url: '/CRMCallerRoleAllocation/List',
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
            url: '/CRMCallerRoleAllocation/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallCRMCallerRoleAllocation: function () {
        var CRMCallerRoleAllocationData = null;

        if (CRMCallerRoleAllocation.ActionName == "Create") {
            $("#FormCreateCRMCallerRoleAllocation").validate();
            if ($("#FormCreateCRMCallerRoleAllocation").valid()) {
                CRMCallerRoleAllocationData = null;
                CRMCallerRoleAllocationData = CRMCallerRoleAllocation.GetCRMCallerRoleAllocation();
                ajaxRequest.makeRequest("/CRMCallerRoleAllocation/Create", "POST", CRMCallerRoleAllocationData, CRMCallerRoleAllocation.Success, "CreateCRMCallerRoleAllocationRecord");
            }
        }
        //else if (CRMCallerRoleAllocation.ActionName == "Edit") {
        //    $("#FormEditCRMCallerRoleAllocation").validate();
        //    if ($("#FormEditCRMCallerRoleAllocation").valid()) {
        //        CRMCallerRoleAllocationData = null;
        //        CRMCallerRoleAllocationData = CRMCallerRoleAllocation.GetCRMCallerRoleAllocation();
        //        ajaxRequest.makeRequest("/CRMCallerRoleAllocation/Edit", "POST", CRMCallerRoleAllocationData, CRMCallerRoleAllocation.Success);
        //    }
        //}      
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMCallerRoleAllocation: function () {
        var Data = {
        };
        if (CRMCallerRoleAllocation.ActionName == "Create") {
            Data.AdminRoleMasterID = $('#AdminRoleMasterID').val();
            Data.IsActive = $('#IsActive').val();
        }
        else if (CRMCallerRoleAllocation.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMCallerRoleAllocation.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};

