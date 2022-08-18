//this class contain methods related to nationality functionality
var PurchaseInvoice = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PurchaseInvoice.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#contactPerson").hide();
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        $('#PurchaseOrderDate').datetimepicker({
            format: 'DD MMMM YYYY'
        });

        $("#PurchaseOrderDate").on("keydown", function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                return false;
            }
        })
        $("#btnShowList").unbind("click").on("click", function () {

            debugger;

            PurchaseInvoice.LoadListByPurchaseOrderType($('#PurchaseOrderType :selected').val());

        });
        // Create new record
        $('#CreatePurchaseInvoiceRecord').on("click", function () {
            //if (($('#VendorInvoiceNo').val() == null)||($('#VendorInvoiceNo').val() == "")){
            //    $("#displayErrorMessage p").text("Please Enter Vendor Invoice Number.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
            //    return false;
            //}
            //else {
                PurchaseInvoice.ActionName = "Create";
                PurchaseInvoice.GetXmlDataForAccountVoucher();
                PurchaseInvoice.AjaxCallPurchaseInvoice();
            //}
        });


        $('#ExpectedBillingAmount').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersOnly(e);
        });

        $("#AccountName").on("change", function (e) {

            if ($(this).val() != "") {
                $("#contactPerson").show();
            }
            else {
                $("#contactPerson").hide();
            }
        });

        //$("#AccountName").on("keydown keyup", function (e) {
        //    
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
             url: '/PurchaseInvoice/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        var PurchaseOrderType = $('#PurchaseOrderType :selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, PurchaseOrderType: PurchaseOrderType },
            url: '/PurchaseInvoice/List',
            success: function (data) {
                //Rebind Grid Data            
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);


                //$.ajax(
                //{
                //    cache: false,
                //    type: "POST",
                //    dataType: "html",
                //    data: {ID:PurchaseOrderID},
                //    url: '/PurchaseInvoice/Download',
                //});
            }
        });
    },

    LoadListByPurchaseOrderType: function (PurchaseOrderType) {
        debugger;
        $.ajax(
     {
         cache: false,
         type: "POST",
         data: { PurchaseOrderType: PurchaseOrderType},
         dataType: "html",
         url: '/PurchaseInvoice/List',
         success: function (result) {
             //Rebind Grid Data                
             $('#ListViewModel').html(result);
         }
     });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallPurchaseInvoice: function () {
        var PurchaseInvoiceData = null;
        if (PurchaseInvoice.ActionName == "Create") {
            debugger;
            $("#FormCreatePurchaseInvoice").validate();
            if ($("#FormCreatePurchaseInvoice").valid()) {
                debugger;
                debugger;
                PurchaseInvoiceData = null;
                PurchaseInvoiceData = PurchaseInvoice.GetPurchaseInvoice();
                ajaxRequest.makeRequest("/PurchaseInvoice/Create", "POST", PurchaseInvoiceData, PurchaseInvoice.Success, "CreatePurchaseInvoiceRecord");
            }


        }
        else if (PurchaseInvoice.ActionName == "Edit") {
            $("#FormEditPurchaseInvoice").validate();
            if ($("#FormEditPurchaseInvoice").valid()) {
                PurchaseInvoiceData = null;

                PurchaseInvoiceData = PurchaseInvoice.GetPurchaseInvoice();

                ajaxRequest.makeRequest("/PurchaseInvoice/Edit", "POST", PurchaseInvoiceData, PurchaseInvoice.Success);

            }
        }
        else if (PurchaseInvoice.ActionName == "Delete") {
            PurchaseInvoiceData = null;
            //$("#FormCreatePurchaseInvoice").validate();
            PurchaseInvoiceData = PurchaseInvoice.GetPurchaseInvoice();
            ajaxRequest.makeRequest("/PurchaseInvoice/Delete", "POST", PurchaseInvoiceData, PurchaseInvoice.Success);

        }
    },
    GetXmlDataForAccountVoucher: function () {
       
        var DataArray = [];
        $('#DivAddRowTable1 input').each(function () {
            DataArray.push($(this).val());
        });
       // alert(DataArray);
        var TotalRecord = DataArray.length;

        //alert(TotalRecord)
        var ParameterXml = "<rows>";
        var currentdate = new Date();
        var datetime =
                         currentdate.getUTCFullYear() + "-"
                        + (currentdate.getUTCMonth() + 1) + "-"
                        + currentdate.getUTCDate() + " "
                        + currentdate.getUTCHours() + ":"
                        + currentdate.getUTCMinutes() + ":"
                        + currentdate.getUTCSeconds() + "."
                        + currentdate.getUTCMilliseconds();
        //alert(datetime)

        for (var i = 0; i < TotalRecord; i = i + 4) {
            if (DataArray[i + 1] == 0 ) {
                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIVendorAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + DataArray[i + 0] + "</Amount><PersonID>" + DataArray[i + 3] + "</PersonID><PersonType>U</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIPurchase</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + DataArray[i + 0] + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";
                
            }
            else {

                ParameterXml = ParameterXml + "<row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIVendorAmount</ControlName><DebitCreditStatus>0</DebitCreditStatus><Amount>-" + DataArray[i + 0] + "</Amount><PersonID>" + $('#VendorID').val() + "</PersonID><PersonType>U</PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIPurchase</ControlName><DebitCreditStatus>1</DebitCreditStatus><Amount>" + parseFloat(parseFloat(DataArray[i + 0]) - parseFloat(DataArray[i + 1])).toFixed(2) + "</Amount><PersonID></PersonID><PersonType></PersonType><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row><row><GenericNumber>" + $('#VendorInvoiceNo').val() + "</GenericNumber><TransactionDate>" + datetime + "</TransactionDate><ControlName>txtPIFreight</ControlName><DebitCreditStatus>1</DebitCreditStatus><PersonID></PersonID><PersonType></PersonType><Amount>" + DataArray[i + 1] + "</Amount><CreatedBy>" + DataArray[i + 2] + "</CreatedBy><CreatedDate>" + datetime + "</CreatedDate></row>";

            }

        }

       // alert(ParameterXml)
        if (ParameterXml.length > 7) {
            PurchaseInvoice.XMLstringForVouchar = ParameterXml + "</rows>";

        }
        else {
            PurchaseInvoice.XMLstringForVouchar = "";
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetPurchaseInvoice: function () {

        var Data = {
        };
        if (PurchaseInvoice.ActionName == "Create") {
           
            Data.PurchaseRequisitionMasterID = $('input[name=PurchaseRequisitionMasterID]').val();
            Data.VendorID = $('input[name=VendorID]').val();
            Data.PurchaseOrderType = $('input[name=PurchaseOrderType]').val();
            Data.Freight = $('#Freight').val();
            Data.TotalTaxAmount = $('#TotalTaxAmount').val();
            Data.Discount = $('#Discount').val();
            Data.Amount = $('#Amount').val();
            Data.ShippingHandling = $('#ShippingHandling').val();
            Data.PurchaseGRNMasterID = $('input[name=PurchaseGRNMasterID]').val();
            Data.PurchaseOrderMasterID = $('input[name=PurchaseOrderMasterID]').val();
            Data.VendorInvoiceNo = $('#VendorInvoiceNo').val();
            Data.StorageLocationID = $('#StorageLocationID').val();
            Data.XMLstringForVouchar = PurchaseInvoice.XMLstringForVouchar;
        }

        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            PurchaseInvoice.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

