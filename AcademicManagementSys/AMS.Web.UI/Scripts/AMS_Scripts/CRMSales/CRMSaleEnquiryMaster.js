//this class contain methods related to nationality functionality
var CRMSaleEnquiryMaster = {
    //Member variables
    ActionName: null,
    GeneralServiceXML: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMSaleEnquiryMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#contactPerson").hide();
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        $('#TransactionDate').datetimepicker({
            format: 'DD MMMM YYYY'
        });

        $("#TransactionDate").on("keydown", function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                return false;
            }
        })
        $("#btnShowList").on("click", function () {
            CRMSaleEnquiryMaster.LoadListByEnquiryAccountType($('#SelectedEnquiryAccountType :selected').val(), $('#TransactionDate').val());
        });
        // Create new record
        $('#CreateCRMSaleEnquiryMasterRecord').on("click", function () {
            //debugger;
            
            if ($('input[name=CRMSaleEnquiryAccountMasterID]').val() == 0) {
                $("#displayErrorMessage p").text("Invalid account! Please select proper account").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('input[name=CRMSaleEnquiryAccountContactPersonID]').val() == 0) {
                $("#displayErrorMessage p").text("Invalid account contact person! Please select proper contact person").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else {
                CRMSaleEnquiryMaster.ActionName = "Create";
                CRMSaleEnquiryMaster.AjaxCallCRMSaleEnquiryMaster();
            }
        });


        $('#ExpectedBillingAmount').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersOnly(e);
        });

        $("#AccountName").on("change", function (e) {
            debugger;            
            if ($(this).val() != "") {
                $("#contactPerson").show();
            }
            else {
                $("#contactPerson").hide();
            }
        });

        //$("#AccountName").on("keydown keyup", function (e) {
        //    debugger;
        //    var inputKeyCode = e.keyCode ? e.keyCode : e.which;
        //    alert(inputKeyCode);
        //});

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
             url: '/CRMSaleEnquiryMaster/List',
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
            data: { actionMode: actionMode },
            url: '/CRMSaleEnquiryMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    LoadListByEnquiryAccountType: function (SelectedEnquiryAccountType, TransactionDate) {

        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { SelectedEnquiryAccountType: SelectedEnquiryAccountType, TransactionDate: TransactionDate },
              dataType: "html",
              url: '/CRMSaleEnquiryMaster/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
              }
          });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleEnquiryMaster: function () {
        var CRMSaleEnquiryMasterData = null;
        if (CRMSaleEnquiryMaster.ActionName == "Create") {
            $("#FormCreateCRMSaleEnquiryMaster").validate();
            if ($("#FormCreateCRMSaleEnquiryMaster").valid()) {
                CRMSaleEnquiryMasterData = null;
                CRMSaleEnquiryMasterData = CRMSaleEnquiryMaster.GetCRMSaleEnquiryMaster();
                ajaxRequest.makeRequest("/CRMSaleEnquiryMaster/Create", "POST", CRMSaleEnquiryMasterData, CRMSaleEnquiryMaster.Success, "CreateCRMSaleEnquiryMasterRecord");
            }


        }
        else if (CRMSaleEnquiryMaster.ActionName == "Edit") {
            $("#FormEditCRMSaleEnquiryMaster").validate();
            if ($("#FormEditCRMSaleEnquiryMaster").valid()) {
                CRMSaleEnquiryMasterData = null;

                CRMSaleEnquiryMasterData = CRMSaleEnquiryMaster.GetCRMSaleEnquiryMaster();

                ajaxRequest.makeRequest("/CRMSaleEnquiryMaster/Edit", "POST", CRMSaleEnquiryMasterData, CRMSaleEnquiryMaster.Success);

            }
        }
        else if (CRMSaleEnquiryMaster.ActionName == "Delete") {
            CRMSaleEnquiryMasterData = null;
            //$("#FormCreateCRMSaleEnquiryMaster").validate();
            CRMSaleEnquiryMasterData = CRMSaleEnquiryMaster.GetCRMSaleEnquiryMaster();
            ajaxRequest.makeRequest("/CRMSaleEnquiryMaster/Delete", "POST", CRMSaleEnquiryMasterData, CRMSaleEnquiryMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMSaleEnquiryMaster: function () {

        var Data = {
        };
        if (CRMSaleEnquiryMaster.ActionName == "Create" || CRMSaleEnquiryMaster.ActionName == "Edit") {

            Data.CRMSaleEnquiryAccountMasterID = $('input[name=CRMSaleEnquiryAccountMasterID]').val();
            Data.CRMSaleEnquiryAccountContactPersonID = $('input[name=CRMSaleEnquiryAccountContactPersonID]').val();
            Data.EnquiryMasterLatitude = $('input[name=EnquiryMasterLatitude]').val();
            Data.EnquiryMasterLongitude = $('input[name=EnquiryMasterLongitude]').val();

            Data.EnquiryAccountType = $('#EnquiryAccountType').val();
            Data.EnquirySource = $('#EnquirySource').val();
            CRMSaleEnquiryMaster.GetGeneralServiceXML();
            Data.GenServiceRequiredName = CRMSaleEnquiryMaster.GeneralServiceXML;
            //Data.GenServiceRequiredID = $('#GenServiceRequiredName').val();
            //Data.GenServiceRequiredID = $("select[name=selectService]").val().toString();

            Data.ExpectedBillingAmount = $('#ExpectedBillingAmount').val();
            Data.EnquiryDesription = $('#EnquiryDesription').val();
            Data.EnquiryMasterAddress = $('#EnquiryMasterAddress').val();

            Data.EnquiryMasterCity = $('#EnquiryMasterCity').val();

            Data.EnquiryMasterCity = $('#EnquiryMasterCity').val();


        }
        else if (CRMSaleEnquiryMaster.ActionName == "Delete") {
            Data.CRMSaleEnquiryMasterID = $('input[name=CRMSaleEnquiryMasterID]').val();

        }
        return Data;
    },


    //Generate XML;
    GetGeneralServiceXML: function () {
        debugger;
        var DataArray = "";

        var selectedEmail = $("select[name=GenServiceRequiredName]").val().toString();
        if ($("#GenServiceRequiredName").val() != null && $("#GenServiceRequiredName").val() != "") {
            DataArray = selectedEmail.split(',');
        }

        var TotalRecord = selectedEmail.split(',').length;
        var GeneralServiceXML = "<rows>";
        for (var i = 0; i < TotalRecord; i++) {
            debugger;
            //EmployeeEmailXML = EmployeeEmailXML + "<row><ID>0</ID><ToUserIDs>3</ToUserIDs><ToMailIDs>AA@test.com</ToMailIDs></row>";

            if (DataArray[i] != "") {
                GeneralServiceXML = GeneralServiceXML + "<row><ID>0</ID><ToGenServiceIDs>" + DataArray[i] + "</ToGenServiceIDs></row>";
            }
        }
        if (GeneralServiceXML.length > 6) {
            CRMSaleEnquiryMaster.GeneralServiceXML = GeneralServiceXML + "</rows>";
        } else {
            CRMSaleEnquiryMaster.GeneralServiceXML = "";
        }
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleEnquiryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

