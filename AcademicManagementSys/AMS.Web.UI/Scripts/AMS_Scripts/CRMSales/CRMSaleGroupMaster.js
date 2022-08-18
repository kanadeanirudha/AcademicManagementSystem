//this class contain methods related to nationality functionality
var CRMSaleGroupMaster = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMSaleGroupMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });


        // Create new record
        $('#CreateCRMSaleGroupMasterRecord').on("click", function () {
            CRMSaleGroupMaster.ActionName = "Create";
            CRMSaleGroupMaster.AjaxCallCRMSaleGroupMaster();
        });


        $('#EditCRMSaleGroupMasterRecord').on("click", function () {
            CRMSaleGroupMaster.ActionName = "Edit";
            CRMSaleGroupMaster.CountValueUsingParentTag();
            CRMSaleGroupMaster.getValueUsingParentTag_Check_UnCheck();
            CRMSaleGroupMaster.AjaxCallCRMSaleGroupMaster();
        });

        $('#DeleteCRMSaleGroupMasterRecord').on("click", function () {

            CRMSaleGroupMaster.ActionName = "Delete";
            CRMSaleGroupMaster.AjaxCallCRMSaleGroupMaster();
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
             url: '/CRMSaleGroupMaster/List',
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
            data: {actionMode: actionMode },
            url: '/CRMSaleGroupMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleGroupMaster: function () {
        var CRMSaleGroupMasterData = null;
        if (CRMSaleGroupMaster.ActionName == "Create") {
            $("#FormCreateCRMSaleGroupMaster").validate();
            if ($("#FormCreateCRMSaleGroupMaster").valid()) {
                CRMSaleGroupMasterData = null;
                CRMSaleGroupMasterData = CRMSaleGroupMaster.GetCRMSaleGroupMaster();

                ajaxRequest.makeRequest("/CRMSaleGroupMaster/Create", "POST", CRMSaleGroupMasterData, CRMSaleGroupMaster.Success, "CreateCRMSaleGroupMasterRecord");
            }


        }
        else if (CRMSaleGroupMaster.ActionName == "Edit") {
            $("#FormEditCRMSaleGroupMaster").validate();
            if ($("#FormEditCRMSaleGroupMaster").valid()) {
                CRMSaleGroupMasterData = null;

                CRMSaleGroupMasterData = CRMSaleGroupMaster.GetCRMSaleGroupMaster();
             
                ajaxRequest.makeRequest("/CRMSaleGroupMaster/Edit", "POST", CRMSaleGroupMasterData, CRMSaleGroupMaster.Success);

            }
        }
        else if (CRMSaleGroupMaster.ActionName == "Delete") {
            CRMSaleGroupMasterData = null;
            //$("#FormCreateCRMSaleGroupMaster").validate();
            CRMSaleGroupMasterData = CRMSaleGroupMaster.GetCRMSaleGroupMaster();
            ajaxRequest.makeRequest("/CRMSaleGroupMaster/Delete", "POST", CRMSaleGroupMasterData, CRMSaleGroupMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMSaleGroupMaster: function () {
     
        var Data = {
        };
        if (CRMSaleGroupMaster.ActionName == "Create" || CRMSaleGroupMaster.ActionName == "Edit") {
         
         //   Data.CRMSaleGroupMasterID = $('input[name=CRMSaleGroupMasterID]').val();
            Data.GroupName = $('#GroupName').val();
            Data.GeneralGroupTypeAttributesId = $('#GeneralGroupTypeAttributesId').val();
        }
        else if (CRMSaleGroupMaster.ActionName == "Delete") {
            Data.CRMSaleGroupMasterID = $('input[name=CRMSaleGroupMasterID]').val();

        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
  
};

