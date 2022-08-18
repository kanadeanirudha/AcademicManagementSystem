//this class contain methods related to nationality functionality
var InventoryPurchaseMasterAndTransaction = {
    //Member variables
    ActionName: null,
    ParameterXml: null,
    GenTaxGroupMasterID: 0,
    RoundUpAmount1: 0,
    DocumentLoadCount: 0,
    flag: true,
    //Class intialisation method
    Initialize: function () {
        InventoryPurchaseMasterAndTransaction.constructor();
    },
    //Attach all event of page
    constructor: function () {
        InventoryPurchaseMasterAndTransaction.DocumentLoadCount = InventoryPurchaseMasterAndTransaction.DocumentLoadCount + 1;
        //alert(InventoryPurchaseMasterAndTransaction.DocumentLoadCount);
        //Reset button click event function to reset all controls of form
        $("#TotalItem").val(0);
        $("#openPurchase").on("click", function () {

            $("#purchaseDiv").show();
            $("#listDiv").hide();
            $("#SupplierName").focus();
        });
        InventoryPurchaseMasterAndTransaction.RoundUpAmount1 = $('input[name=RoundUpAmount]').val();
        $("#Quantity").val("");
        $("#Rate").val("");
        $("#BillAmount").val("");
        $("#BatchNumber").val("");
        $("#ExpiryDate").val("");
        
        $("#closePurchase").on("click", function () {
            $("#purchaseDiv").hide();
            $("#listDiv").show();
        });

        $("#Rate").on("change keyup", function () {            
            var amount = parseFloat($("#Rate").val() * $("#Quantity").val()).toFixed(2);
            $("#BillAmount").val(amount);

            var tax = ((parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#taxpercentage").val()) / 100);
            var tax1 = $("#taxpercentage").val();
            $("#TaxRate").val(tax1);
            var totalamounttax = (amount + tax);
            // $("#TotalAmmount").val(totalamounttax);
        });
        $("#Quantity").on("change keyup", function () {
            var amount = parseFloat($("#Rate").val() * $("#Quantity").val()).toFixed(2);
            $("#BillAmount").val(amount);

            var tax = ((parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#taxpercentage").val()) / 100);
            var tax1 = $("#taxpercentage").val();
            $("#TaxRate").val(tax1);
            var totalamounttax = (amount + tax);
            //    $("#TotalAmmount").val(totalamounttax);
        });

        $("#IsRateInclusiveTax").on("click", function () {           
            if ($("#IsRateInclusiveTax").is(':checked')) {
                $("#Rate").attr('readonly', 'readonly');
                var rate = $("#Rate").val();
                var tax1 = $("#taxpercentage").val();
                var abc = (rate * 100);
                var a1 = parseFloat(parseFloat(tax1) + parseFloat(100)).toFixed(2)
                var total = abc / a1;

                $("#RateID").val(rate);
                $("#Rate").val(total.toFixed(2));
                //$("#IsRateInclusiveTax").prop("disabled", true);
                var amount = parseFloat($("#Rate").val() * $("#Quantity").val()).toFixed(2);
                $("#BillAmount").val(amount);

                var tax = (parseFloat(parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#taxpercentage").val()) / 100).toFixed(2);
                var tax1 = $("#taxpercentage").val();
                $("#TaxRate").val(tax1);

                var totalamounttax = (amount + tax);
                //  $("#TotalAmmount").val(totalamounttax.toFixed(2));
            }
            else {
                $("#Rate").removeAttr('readonly');
                var rate = $("#RateID").val();
                $("#Rate").val(rate);

                var amount = parseFloat($("#Rate").val() * $("#Quantity").val());
                $("#BillAmount").val(amount);

                var tax = (parseFloat(parseFloat($("#Rate").val() * $("#Quantity").val()) * $("#taxpercentage").val()) / 100).toFixed(2);
                var tax1 = $("#taxpercentage").val();
                $("#TaxRate").val(tax1);
                var totalamounttax = (amount + tax);
            }
        });


        $('#ExpiryDate').datepicker({
            dateFormat: 'd M yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '1915:document.write(currentYear.getFullYear()',
            minDate: 0,

        })

        $("#Hamali").on("change keyup", function () {            
            InventoryPurchaseMasterAndTransaction.totalBillAmounttax();
        });
        $("#OtherExpenses").on("change keyup", function () {            
            InventoryPurchaseMasterAndTransaction.totalBillAmounttax();
        });

        //  FOLLOWING FUNCTION IS SEARCHLIST OF item list
        $("#ItemName").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/InventoryPurchaseMasterAndTransaction/GetItemSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term, locationID: $("#LocationID").val() },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.name, value: item.name, id: item.id, rate: item.rate, itemCode: item.itemCode, picture: item.picture, currencyCode: item.currencyCode, currentStockQty: item.currentStockQty, unitID: item.unitID, unitCode: item.unitCode, IsExpiry: item.IsExpiry, IsTaxInclusive: item.IsTaxInclusive, GenTaxGroupMasterID: item.GenTaxGroupMasterID, TaxRatePercentage: item.TaxRatePercentage };
                        }))
                    }
                })
            },
            select: function (event, ui) {               
                $(this).val(ui.item.label);                                             // display the selected text
                $("#ItemID").val(parseFloat(ui.item.id));
                $("#UnitCode").val(ui.item.unitCode);
                $("#UnitID").val(ui.item.unitID);
                $("#IsExpiry").val(ui.item.IsExpiry);
                $("#IsTaxInclusive").val(ui.item.IsTaxInclusive);
                $("#GenTaxGroupMasterID").val(ui.item.GenTaxGroupMasterID);
                $("#taxpercentage").val(ui.item.TaxRatePercentage);
                $("#BatchNumber").val();
                $("#ExpiryDate").val();

                if (ui.item.IsExpiry == 0) {
                    $("#BatchNumber").prop("disabled", true);
                    $("#ExpiryDate").prop("disabled", true);
                    $("#taxpercentage").val(ui.item.TaxRatePercentage);
                }
                else {
                    $("#BatchNumber").prop("disabled", false);
                    $("#ExpiryDate").prop("disabled", false);
                    // $("#TaxRate").val(10);
                }
                if (ui.item.GenTaxGroupMasterID == 0) {
                    $("#TaxRate").prop("disabled", true);
                    $("#TaxRate").val("");
                    $("#taxpercentage").val(ui.item.TaxRatePercentage);

                }
                else {
                    $("#TaxRate").prop("disabled", true);
                    $("#TaxRate").val("");
                    $("#TaxRate").val(ui.item.TaxRatePercentage);
                    $("#IsRateInclusiveTax").prop("disabled", false);
                }
                $("#Isexpiry").val(ui.item.IsExpiry);
                //InventoryPurchaseMasterAndTransaction.GenTaxGroupMasterID = ui.item.ui.item.GenTaxGroupMasterID;
            }
        });

        //FOLLOWING FUNCTION IS SEARCHLIST OF Batch list
        $("#BatchNumber").autocomplete({
            source: function (request, response) {                
                $.ajax({
                    url: "/InventoryPurchaseMasterAndTransaction/GetBatchNumberOfItem",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term, itemID: $("#ItemID").val() },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.name, value: item.name, id: item.id, expiryDate: item.expiryDate, batchQuantity: item.batchQuantity };
                        }))
                    }
                })
            },
            select: function (event, ui) {              
                $(this).val(ui.item.label);                                             // display the selected text
                $("#BatchID").val(parseInt(ui.item.id));
                $("#ExpiryDate").val(ui.item.expiryDate);
                $("#BatchQuantity").val(parseFloat(ui.item.batchQuantity));
                $("#ExpiryDate").prop("disabled", true);
            }
        });


        $('#ItemName').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
            if (e.keyCode == 8 || e.keyCode == 46) {
            //alert("hiii");
                // $("#ItemID").val(0); 
                $("#ItemName").val("");
                $("#UnitCode").val("");
                $("#Quantity").val("");
                $("#Rate").val("");
                $("#BillAmount").val("");
                $("#BatchNumber").val("");
                $("#ExpiryDate").val("");
                $("#TaxRate").val("0");
                $('#IsRateInclusiveTax').removeAttr('checked');
            }
        });
        $('#BatchNumber').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#BatchNumber").val("");
                $("#ExpiryDate").val("");
            }
        });


        //On Quantity Change
        $("#tblData tbody").on("keyup", "tr td input[id^=itemQuantity]", function () {            
            var quantity = $(this).closest('tr').find('td input[id^=itemQuantity]').val();
            var rate = $(this).closest('tr').find('td input[id^=itemRate]').val();
            if (parseFloat(quantity) == 0 || parseFloat(quantity) <= 0) {
                $('#SuccessMessage').html("Please enter Quantity.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }
           
            $(this).closest('tr').find('td').eq(8).text(parseFloat(quantity * rate).toFixed(2));
            InventoryPurchaseMasterAndTransaction.TotalBillAmount();

            var taxpercentage = $(this).closest('tr').find('td input[id^=taxPercentage]').val()
            var taxpercentage = $("#taxpercentage").val()
            $(this).closest('tr').find('td').eq(7).text((((parseFloat(quantity * rate).toFixed(2)) * taxpercentage) / 100).toFixed(2));
            InventoryPurchaseMasterAndTransaction.TotalBillAmountincludingTax();

            Amount = (parseFloat(quantity * rate).toFixed(2));
            tax = (parseFloat(((quantity * rate).toFixed(2)) * taxpercentage) / 100);

            $(this).closest('tr').find('td input[id=tax]').val(parseFloat(tax).toFixed(2));
            $(this).closest('tr').find('td').eq(9).text(parseFloat(parseFloat(tax)) + (parseFloat(Amount)));
            InventoryPurchaseMasterAndTransaction.totalBillAmounttax();
        });

        //On Rate Change
        $("#tblData tbody").on("keyup", "tr td input[id^=itemRate]", function () {
            var quantity = $(this).closest('tr').find('td input[id^=itemQuantity]').val();
            var rate = $(this).closest('tr').find('td input[id^=itemRate]').val();
            if (parseFloat(rate) == 0 || parseFloat(rate) <= 0) {
                $('#SuccessMessage').html("Please enter rate");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
               
            }
            $(this).closest('tr').find('td').eq(8).text(parseFloat(quantity * rate).toFixed(2));
            InventoryPurchaseMasterAndTransaction.TotalBillAmount();

            var taxpercentage = $(this).closest('tr').find('td input[id^=taxPercentage]').val()
            var taxpercentage = $("#taxpercentage").val()
            $(this).closest('tr').find('td').eq(7).text((((parseFloat(quantity * rate).toFixed(2)) * taxpercentage) / 100).toFixed(2));
            InventoryPurchaseMasterAndTransaction.TotalBillAmountincludingTax();

            Amount = (parseFloat(quantity * rate).toFixed(2));
            tax = (parseFloat(((quantity * rate).toFixed(2)) * taxpercentage) / 100);
            $(this).closest('tr').find('td input[id=tax]').val(parseFloat(tax).toFixed(2));
            $(this).closest('tr').find('td').eq(9).text(parseFloat(parseFloat(tax)) + (parseFloat(Amount)));
            InventoryPurchaseMasterAndTransaction.totalBillAmounttax();

        });
        //Delete
        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
            InventoryPurchaseMasterAndTransaction.TotalItem();
            InventoryPurchaseMasterAndTransaction.BillAmount();
            InventoryPurchaseMasterAndTransaction.TotalBillAmount();
            InventoryPurchaseMasterAndTransaction.TotalBillAmountincludingTax
            InventoryPurchaseMasterAndTransaction.totalBillAmounttax();
        });

        // Create new record
        $('#addItem').on("click", function () {
            InventoryPurchaseMasterAndTransaction.AddRow();
        });

        $('#DeleteFeeTypeMasterRecord').on("click", function () {            
            InventoryPurchaseMasterAndTransaction.ActionName = "DeleteFeeType";
            InventoryPurchaseMasterAndTransaction.AjaxCallInventoryPurchaseMasterAndTransaction();
        });
        $('#CreateInventoryPurchasesAndTransaction').on("click", function () {            
           
            if ($("#SupplierName").val() != "") {
                if ($("#BillNumber").val() != "") {
                    InventoryPurchaseMasterAndTransaction.CreatePurchase();
                } else {
                    $('#SuccessMessage').html("Please enter bill number.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else
            {
                $('#SuccessMessage').html("Please enter supplier name.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }
           
        });

        $("#UserSearch").on("keyup", function () {
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $(".ajax").colorbox();      

        $("#reset").click(function () {
            $('#SupplierName').val("");
            $("#tblData tbody tr").remove();
            $('#Quantity').val("");
            $('#Rate').val("");
            $('#BillAmount').val(0);
            $("#TotalItem").val(0);
            $('#ItemName').val("");
            $('#ItemID').val("");
            $('#UnitCode').val("");
            $('#TotalBillAmount').val(0);
            $("#BatchNumber").val("");
            $("#ExpiryDate").val("");
            $("#TaxRate").val("");
            $("#IsRateInclusiveTax").prop("disabled", true);
            $("#IsRateInclusiveTax").removeAttr('checked');
            $('#BillNumber').val("");
            $('#Hamali').val(0);
            $('#OtherExpenses').val(0);
            $('#TotalAmmount').val(0);
            // $('#LocationID').val("")
            InventoryPurchaseMasterAndTransaction.RoundUpAmount1 = 0;

            return false;
        });


        $(document).keyup(function (e) {
            if (e.altKey && (e.which === 65 || e.which === 97)) {
                //Alt+A
                $("#purchaseDiv").show();
                $("#listDiv").hide();
                $("#ItemName").focus();
                $("#ItemName").val("");
            }
            if (e.altKey && (e.which === 76 || e.which === 108)) {
                //Alt+L
                $("#purchaseDiv").hide();
                $("#listDiv").show();
            }

            //if (e.which === 13) {
            //    InventoryPurchaseMasterAndTransaction.CreatePurchase();
            //}
            if (e.altKey && (e.which === 88 || e.which === 120)) {
                InventoryPurchaseMasterAndTransaction.Reset();

            }

            if (e.altKey && (e.which === 82 || e.which === 114)) {                
                //alert("hiii");
                InventoryPurchaseMasterAndTransaction.AddRow();
            }
        });
        
        //InventoryPurchaseMasterAndTransaction.CreatePurchase();
        //InventoryPurchaseMasterAndTransaction.AddRow();

        $('#Quantity').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#Rate').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#Hamali').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#OtherExpenses').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#SupplierName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#BatchNumber").focusout(function () {
          
            var data = $("#BatchNumber").val() + '~' + $("#ItemID").val();

            InventoryPurchaseMasterAndTransaction.FocusOut("BatchNumber", data);
        });

        $("#tblData tbody").on("keypress", "tr td input[id^=itemRate]", function (e) {            
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95)
            {
                return false;
            }
        });       

        $('#Quantity').on("keypress", function (e) {
          
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#Rate').on("keypress", function (e) {            
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#Hamali').on("keypress", function (e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#OtherExpenses').on("keypress", function (e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $("#tblData tbody").on("keypress", "tr td input[id^=itemQuantity]", function (e) {            
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

    },


    Reset: function () {
        $('#SupplierName').val("");
        $("#tblData tbody tr").remove();
        $('#Quantity').val("");
        $('#Rate').val("");
        $('#BillAmount').val(0);
        $("#TotalItem").val(0);
        $('#ItemName').val("");
        $('#ItemID').val("");
        $('#UnitCode').val("");
        $('#TotalBillAmount').val(0);
        $("#BatchNumber").val("");
        $("#ExpiryDate").val("");
        $("#TaxRate").val("");
        $("#IsRateInclusiveTax").prop("disabled", true);
        $("#IsRateInclusiveTax").removeAttr('checked');
        $('#BillNumber').val("");
        $('#Hamali').val(0);
        $('#OtherExpenses').val(0);
        $('#TotalAmmount').val(0);
        // $('#LocationID').val("")
    },

    CreatePurchase: function () {       
        InventoryPurchaseMasterAndTransaction.ActionName = "Create";
        InventoryPurchaseMasterAndTransaction.GetXmlData();
        if (InventoryPurchaseMasterAndTransaction.flag == true) {
            if ($("#LocationID").val() >= 0 && $("#LocationID").val() != "" && InventoryPurchaseMasterAndTransaction.ParameterXml != null && InventoryPurchaseMasterAndTransaction.ParameterXml != "") {

                $('#CreateInventoryPurchasesAndTransaction').attr("disabled", true);
                InventoryPurchaseMasterAndTransaction.AjaxCallInventoryPurchaseMasterAndTransaction();
            }
                //else if ($('#SupplierName').val() == "") {
                //    $('#SuccessMessage').html("Please Enter Supplier Name.");
                //    $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                //}
            else if ($("#LocationID").val() <= 0 || $("#LocationID").val() == "") {
                $('#SuccessMessage').html("Please Select Location Name.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }
            else {
                $('#SuccessMessage').html("No data available in table.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

            }
        }
    },


    AddRow: function () {
        $("#Rate").attr('readonly', false);
        // code to calculate expiry date
        var d = new Date($("#ExpiryDate").val());
        var curr_date = d.getDate();
        var curr_month = d.getMonth() + 1; //Months are zero based
        var curr_year = d.getFullYear();
        if (curr_month != 10 || curr_month != 11 || curr_month != 12) {
            curr_month = "0" + curr_month;
        }
        if (curr_date == 1 || curr_date == 2 || curr_date == 3 || curr_date == 4 || curr_date == 5 || curr_date == 6 || curr_date == 7 || curr_date == 8 || curr_date == 9) {
            curr_date = "0" + curr_date;
        }
        var expirydate = (curr_year + "-" + curr_month + "-" + curr_date);

        var date = new Date(expirydate).toDateString("yyyy-MM-dd");
        if (date == null || date == "" || date == "Invalid Date") {
            var expirydate = "";
        }
        else {
            var expirydate = (curr_year + "-" + curr_month + "-" + curr_date);
        }
        // to check whether the batch no or expiry date is null..
        var batch = $('#BatchNumber').val();
        var Exdate = $('#ExpiryDate').val();
        if ((batch == "" || batch == null) && (Exdate == "" || Exdate == null)) {
            var aaaa = "<td ><input type='text' style='display:none'  value= '0' >" + "-" + "</td>"

        }
        else {            
            var aaaa = "<td ><input type='text' style='display:none'  value=" + $("#BatchID").val() + " />" + $('#BatchNumber').val() + "[" + $('#ExpiryDate').val() + "]" + "</td>"
        }
        //to show checkbox is checked or unchecked while adding a row
        var IsRateInclusiveTax = $('input[name=IsRateInclusiveTax]:checked').val() ? true : false;
        var aaa;
        if (IsRateInclusiveTax == true) {
            aaa = "<td> <input id='IsRateInclusiveTax' type='checkbox' checked='checked'  disabled='disabled' value='1' style='text-align:center' >" + " </td>"
        }
        else {
            aaa = "<td> <input id='IsRateInclusiveTax' type='checkbox'   disabled='disabled'  value='0'>" + " </td>"
        }

        if ($('input[name=Isexpiry]').val() == "true" && ($('#BatchNumber').val() == "" || $('#BatchNumber').val() == null)) {
            $('#SuccessMessage').html("Please Enter Batch Number.");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            return false
        }
        if ($('input[name=Isexpiry]').val() == "true" && ($('#ExpiryDate').val() == "" || $('#ExpiryDate').val() == null)) {
            $('#SuccessMessage').html("Please Enter Expiry Date.");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            return false
        }

        //to check duplication of item while adding the item        
        var DataArray = [];
        var data = $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
        TotalRecord = DataArray.length;
        var i = 0;
        for (var i = 0; i < TotalRecord; i = i + 10) {
            if (DataArray[i] == $('#ItemID').val()) {
                $('#SuccessMessage').html("You Cannot Enter the same item Twice");
                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                $("#ItemName").val("");
                $("#ItemID").val(0);
                $("#Quantity").val("");
                $("#UnitCode").val("");
                $("#Rate").val("");
                $("#BillAmount").val("");
                $("#BatchNumber").val("");
                $("#ExpiryDate").val("");
                $("#TaxRate").val(0);
                $("#IsRateInclusiveTax").prop("disabled", true);
                $("#IsRateInclusiveTax").removeAttr('checked');
                return false
            }
        }
        var taxAmount = parseFloat((parseFloat($('#BillAmount').val()).toFixed(2) * $('#TaxRate').val()).toFixed(2) / 100).toFixed(2);
        //End of code.


        if ($('#ItemName').val() != "" && $('#Quantity').val() != "" && $('#Quantity').val() > 0 && $('#Rate').val() != "" && $('#Rate').val() > 0 && $("#LocationID").val() > 0 && $("#ItemID").val() > 0) {
            $("#tblData tbody").append(
                "<tr>" +
                "<td ><input type='text' value=" + $('#ItemID').val() + " style='display:none' /> " + $('#ItemName').val() + "</td>" +
                "<td><input id='itemQuantity' type='text' maxlength='8' value=" + parseFloat($('#Quantity').val()).toFixed(2) + " style='width:60px;height:16px;text-align:right'/></td>" +
                "<td>" + $('#UnitCode').val() + "</td>" +
                "<td> <input id='itemRate' style='text-align: right;width: 60px;height:16px;text-align:right' type='text' maxlength='8' value =" + $('#Rate').val() + "> </td>" +
                aaaa +
              aaa +
              "<td style='display:none'> <input id='GenTaxGroupMasterID' type='text' value=" + $('#GenTaxGroupMasterID').val() + " /> <input id='ExpiryDate' type='text' value=" + expirydate + " >  </td>" +
              "<td style='text-align:left'> " + taxAmount + " </td>" +
               "<td  style='text-align:left; '>" + parseFloat($('#BillAmount').val()).toFixed(2) + "</td>" +
               "<td  style='text-align:right; '>" + parseFloat((parseFloat($('#BillAmount').val()).toFixed(2)) + parseFloat((parseFloat($('#BillAmount').val()).toFixed(2) * $('#TaxRate').val()).toFixed(2) / 100)).toFixed(2) + "</td>" +

               "<td  style='text-align:center; '> <i class='icon-trash' title = Delete><input id='tax' type='hidden' value=" + parseFloat((parseFloat($('#BillAmount').val()).toFixed(2) * $('#TaxRate').val()).toFixed(2) / 100).toFixed(2) + " /><input type='hidden'  value=" + $('#BatchNumber').val() + "><input id='taxPercentage' type='hidden' value=" + $('#TaxRate').val() + " /></td>" +


      "</tr>");
            $("#ItemName").val("");
            $("#ItemID").val(0);
            $("#Quantity").val("");
            $("#UnitCode").val("");
            $("#Rate").val("");
            $("#BillAmount").val("");
            $("#BatchNumber").val("");
            $("#ExpiryDate").val("");
            $("#TaxRate").val("");
            $("#IsRateInclusiveTax").prop("disabled", true);
            $("#IsRateInclusiveTax").removeAttr('checked');
            $("#BatchNumber").prop("disabled", true);
            $("#ExpiryDate").prop("disabled", true);

            $('#ItemName').focus();
            $('input[id*=itemRate]').on("keydown", function (e) {
                AMSValidation.AllowNumbersWithDecimalOnly(e);
                AMSValidation.NotAllowSpaces(e);
            });
            $('input[id*=itemRate]').on("keyup", function (e) {
                parseFloat($(this).val()).toFixed(2);
            });

            $('input[id*=itemQuantity]').on("keydown", function (e) {
                AMSValidation.AllowNumbersWithDecimalOnly(e);
                AMSValidation.NotAllowSpaces(e);
            });
            $('input[id*=itemQuantity]').on("keyup", function (e) {
                parseFloat($(this).val()).toFixed(3);
            });

            $('#tblData tbody').on('change keyup', "tr td input[id^=itemQuantity]", function (e) {
                AMSValidation.AllowNumbersWithDecimalOnly(e);
            });
           
            InventoryPurchaseMasterAndTransaction.TotalItem();
            InventoryPurchaseMasterAndTransaction.TotalBillAmount();
            InventoryPurchaseMasterAndTransaction.TotalBillAmountincludingTax();
            InventoryPurchaseMasterAndTransaction.totalBillAmounttax();
        }

        else if ($("#LocationID").val() == 0) {
            $('#SuccessMessage').html("Please Select Location Name.");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //$('#DivCreateNew').hide(true);
        }
        else if ($("#ItemID").val() == 0) {
            $('#SuccessMessage').html("Invalid item selected");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //$('#DivCreateNew').hide(true);
        }
        else if ($("#ItemName").val() == "") {
            $('#SuccessMessage').html("Please Enter Item Name.");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //$('#DivCreateNew').hide(true);
        }
        else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0) {
            $('#SuccessMessage').html("Please Enter Quantity.");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //$('#DivCreateNew').hide(true);
        }
        else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {
            $('#SuccessMessage').html("Please Enter Quantity.");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

        }
        else if ($("#Rate").val() == "" || $("#Rate").val() == 0) {
            $('#SuccessMessage').html("Please Enter Rate.");
            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            //$('#DivCreateNew').hide(true);
        }
    },

    BillAmount: function () {        
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#BillAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(7).text());
                a += parseFloat(x);
            }
        });
        $("#BillAmount").val(a.toFixed(2));
    },

    TotalBillAmount: function () {        
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(8).text());
                a += parseFloat(x);
            }
        });
        $("#TotalBillAmount").val(a.toFixed(2));
    },

    totalBillAmounttax: function () {       
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalAmmount").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(9).text());
                a += parseFloat(x);
            }
        });
        
        //  InventoryPurchaseMasterAndTransaction.RoundUpAmount1 = Math.round(a.toFixed(2)) - a.toFixed(2);

        $("#TotalAmmount").val(a.toFixed(2));
        //   $("#TotalAmmount").val(Math.round(a.toFixed(2)));

        var totalamount = $("#TotalAmmount").val();
        var hamali = $("#Hamali").val();
        var otherExpenses = $("#OtherExpenses").val();
        var total = parseFloat(parseFloat(totalamount) + parseFloat(hamali) + parseFloat(otherExpenses)).toFixed(2);
        InventoryPurchaseMasterAndTransaction.RoundUpAmount1 = Math.round(total) - total;
        $("#TotalAmmount").val(Math.round(total).toFixed(2));

    },
    TotalBillAmountincludingTax: function () {       
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmountincludingTax").val(0);
        $("#tblData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td').eq(7).text());
                a += parseFloat(x);
            }
        });
        $("#TotalBillAmountincludingTax").val(a.toFixed(2));

    },
    TotalItem: function () {
        var length = $("#tblData tbody tr").length;
        $("#TotalItem").val(length);
    },

    //Check On Focus Out.
    FocusOut: function (actionOn, data) {
      
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionOn": actionOn, "data": data },
            url: '/InventoryPurchaseMasterAndTransaction/CheckFocusOnAction',
            success: function (data) {
               
                //Rebind Grid Data
                if (actionOn == "BatchNumber") {
                    //$("#BatchID").val(data);
                    var abc = data.split('~');
                    $("#BatchID").val(abc[0].replace('"', ''));
                    $("#ExpiryDate").val(abc[1].replace('"', ''));
                    $("#ExpiryDate").prop("disabled", true);
                    if( $("#ExpiryDate").val()==""|| $("#ExpiryDate").val()==null)
                    {
                        $('#ExpiryDate').datepicker("show");
                    }
                    else {
                        $('#ExpiryDate').datepicker("hide");
                    }
                }
            }
        });
    },


    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null && Balancesheet != "") {
            $.ajax(
           {
               cache: false,
               type: "GET",
               data: { "selectedBalsheet": Balancesheet },
               dataType: "html",
               url: '/InventoryPurchaseMasterAndTransaction/List',
               success: function (data) {
                   //Rebind Grid Data
                   $('#ListViewModel').html(data);
               }
           });
        }
        else {
            $('#SuccessMessage').html("Please select balancesheet");
            $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
        }

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
            url: '/InventoryPurchaseMasterAndTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                ////twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },
    //Method to create xml
    GetXmlData: function () {
        InventoryPurchaseMasterAndTransaction.flag = true;
        var DataArray = [];
        //$('#DivAddRowTable input[type=text],input[type=checkbox]').each(function () {
        //    DataArray.push($(this).val());
        //});
        // var table = $('#tblData').DataTable();
        var data = $('#tblData tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
      
        TotalRecord = DataArray.length;
        //alert(DataArray);
        ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 10) {
            if (DataArray[i + 1] != 0 && DataArray[i + 2] != 0) {

            if (DataArray[i + 3] == 0 && DataArray[i + 6] == "") {
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i] + "</ItemID><Quantity>" + DataArray[i + 1] + "</Quantity><Rate>" + DataArray[i + 2] + "</Rate><TaxAmount>" + DataArray[i + 7] + "</TaxAmount><GenTaxGroupMasterID>" + DataArray[i + 5] + "</GenTaxGroupMasterID><IsRateInclusiveTax>" + DataArray[i + 4] + "</IsRateInclusiveTax><BatchNumber></BatchNumber><ExpiryDate></ExpiryDate><BatchID>" + DataArray[i + 3] + "</BatchID></row>";
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i] + "</ItemID><Quantity>" + DataArray[i + 1] + "</Quantity><Rate>" + DataArray[i + 2] + "</Rate><TaxAmount>" + DataArray[i + 7] + "</TaxAmount><GenTaxGroupMasterID>" + DataArray[i + 5] + "</GenTaxGroupMasterID><IsRateInclusiveTax>" + DataArray[i + 4] + "</IsRateInclusiveTax><BatchNumber>" + DataArray[i + 8] + "</BatchNumber><ExpiryDate>" + DataArray[i + 6] + "</ExpiryDate><BatchID>" + DataArray[i + 3] + "</BatchID></row>";
            }
            }
            else {
                $('#SuccessMessage').html("Please Enter Valid data");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                InventoryPurchaseMasterAndTransaction.flag = false;
                break;
            }
        }
        //alert(ParameterXml);
        if (ParameterXml.length > 13)
            InventoryPurchaseMasterAndTransaction.ParameterXml = ParameterXml + "</rows>";
        else
            InventoryPurchaseMasterAndTransaction.ParameterXml = "";

    },
    //Fire ajax call to insert update and delete record
    AjaxCallInventoryPurchaseMasterAndTransaction: function () {
        var InventoryPurchaseMasterAndTransactionData = null;
        if (InventoryPurchaseMasterAndTransaction.ActionName == "Create") {
            InventoryPurchaseMasterAndTransactionData = null;
            InventoryPurchaseMasterAndTransactionData = InventoryPurchaseMasterAndTransaction.GetInventoryPurchaseMasterAndTransaction();
            ajaxRequest.makeRequest("/InventoryPurchaseMasterAndTransaction/Create", "POST", InventoryPurchaseMasterAndTransactionData, InventoryPurchaseMasterAndTransaction.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryPurchaseMasterAndTransaction: function () {
        var Data = {
        };
        Data.ID = $('input[name=ID]').val();
        Data.SupplierName = $('#SupplierName').val();
        Data.BillNumber = $('#BillNumber').val();
        Data.LocationID = $("#LocationID").val();
        Data.BillAmount = $("#TotalAmmount").val();
        Data.BalanceSheetID = $("#selectedBalsheetID").val();
        Data.TotalBillAmountincludingTax = $("#TotalBillAmountincludingTax").val();
        Data.Hamali = $("#Hamali").val();
        Data.OtherExpenses = $("#OtherExpenses").val();
        Data.BatchID = $('#BatchID').val();
        Data.ParameterXml = InventoryPurchaseMasterAndTransaction.ParameterXml;
        Data.RoundUpAmount = InventoryPurchaseMasterAndTransaction.RoundUpAmount1;
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        parent.$.colorbox.close();
        InventoryPurchaseMasterAndTransaction.ReloadList(splitData[0], splitData[1], splitData[2]);
        $('#CreateInventoryPurchasesAndTransaction').attr("disabled", false);

    },
    ////this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        InventoryPurchaseMasterAndTransaction.ReloadList("Record Updated Sucessfully.")
    //    }
    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        InventoryPurchaseMasterAndTransaction.ReloadList("Record Deleted Sucessfully.")
    //    }
    //},
};