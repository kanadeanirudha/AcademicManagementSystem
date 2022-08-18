var InventorySalesMasterAndTransaction = {
    //Member variablesRe
    ActionName: null,
    XMLstring: null,
    RateDecreaseByPercentage: 0,
    RoundUpAmount1: 0,
    DocumentLoadCount: 0,
    //Class intialisation method
    Initialize: function () {
        InventorySalesMasterAndTransaction.constructor();
    },
    //Attach all event of page
    constructor: function () {
        InventorySalesMasterAndTransaction.DocumentLoadCount = parseInt(InventorySalesMasterAndTransaction.DocumentLoadCount) + 1;



        $("#LocationID").on("change", function () {

            InventorySalesMasterAndTransaction.ResetTableList();
        });



        //Reset button click event function to reset all controls of form
        // $("#TotalItem").val(0);

        $("#CustomerName").focus();
        $("#listDiv").hide();
        $("#openSale").on("click", function () {
            $("#salesDiv").show();
            $("#listDiv").hide();
            $("#ItemName").focus();
        });
        InventorySalesMasterAndTransaction.RoundUpAmount1 = $('input[name=RoundUpAmount]').val();
        var LoginUserCount = $('input[name=LoginUserCount]').val();
        // alert(LoginUserCount);
        if (LoginUserCount == '1') {
            $('#CounterLoginDiv').hide(true);
            $('#salesDiv').show(true);
        }
        else if (LoginUserCount == '0') {
            $('#CounterLoginDiv').show(true);
            $('#salesDiv').hide(true);
        }

        $("#closeSale").on("click", function () {
            $("#salesDiv").hide();
            $("#listDiv").show();
        });
        $("#Quantity").on("change keyup", function () {
            
            
            if ($('#PolicyDefaultAnswer').val() == "0") {
                var discount = 0, discountRate = 0, quantity = 0;
                if ($("#Quantity").val() != 0) {
                    quantity = $("#Quantity").val();
                }
                if ($("#Discount").val() != "" && $("#Discount").val() != 0 && $("#Discount").val() <= 100) {
                    discount = $("#Discount").val();
                    discountRate = (parseFloat($("#Rate").val()).toFixed(2) * parseFloat(quantity)) * (parseFloat(discount) / 100);
                }
                var amount = parseFloat(parseFloat($("#Rate").val()).toFixed(2) * parseFloat(quantity).toFixed(3)).toFixed(2);
                $("#BillAmount").val(amount - discountRate);
            }
            else {
                var discount = 0, discountRate = 0, quantity = 0;
                if ($("#Quantity").val() != 0) {
                    quantity = $("#Quantity").val();
                }
                if ($("#Discount").val() != "" && $("#Discount").val() != 0 && $("#Discount").val() <= 100) {
                    discount = $("#Discount").val();
                    discountRate = (parseFloat($("#Rate").val()).toFixed(2) * parseFloat(quantity)) * (parseFloat(discount) / 100);
                }
                var amount = parseFloat(parseFloat($("#RateIncludingtax").val()).toFixed(2) * parseFloat(quantity).toFixed(3)).toFixed(2);
                $("#BillAmount").val(amount - discountRate);

            }



        });
        $("#Discount").on("change keyup", function () {
            
            
            var discount = 0, discountRate = 0, quantity = 0;
            if ($("#Quantity").val() != 0) {
                quantity = $("#Quantity").val();
            }
            if ($("#Discount").val() != "" && $("#Discount").val() != 0 && $("#Discount").val() <= 100 && $("#Quantity").val() > 0) {
                discount = $("#Discount").val();
                discountRate = (parseFloat($("#Rate").val()).toFixed(2) * parseFloat(quantity)) * (parseFloat(discount) / 100);
            }
            else if ($("#Discount").val() > 100) {
                $("#Discount").val(0);
                $('#SuccessMessage').html("Please enter discount less than 100.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

            }
            var amount = parseFloat($("#Rate").val()).toFixed(2) * parseFloat($("#Quantity").val()).toFixed(3);
            //$("#BillAmount").val(amount - discountRate);
        });
        $("#SelectedCounterID").change(function () {

            var selectedItem = $("#SelectedCounterID").val();
            var CounterID = "";
            if (selectedItem != "" && selectedItem != null) {
                var bbb = selectedItem.split('~');
                CounterID = bbb[0];
            }
            if (CounterID != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/InventorySalesMasterAndTransaction/GetInventoryCounterLog_OpeningCash_TotalSaleAmount",
                    data: { "SelectedCounterID": CounterID },
                    success: function (data) {
                        var aaa = data.split('~');
                        if (aaa[0] != "0.00" || LoginUserCount != '0') {
                            $("#CounterOpeningCash").attr("disabled", true);
                        }
                        $("#CounterOpeningCash").val(aaa[0]);
                        $("#CounterClosingCash").val(aaa[1]);
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Data.');
                    }
                });
            }
            else {
                $("#CounterOpeningCash").attr("disabled", false);
                $("#CounterOpeningCash").val("0.00");
                $("#CounterClosingCash").val("0.00");
            }
        });

        //Get Quantity of selected item
        $("#getQuantity").on("click", function () {
            if ($("#UnitCode").val().toString() == 'KG' || $("#UnitCode").val().toString() == 'kg') {
                $.ajax({
                    url: "/InventorySalesMasterAndTransaction/GetInventoryItemQuantity",
                    type: "POST",
                    dataType: "json",
                    success: function (data) {
                        $("#Quantity").val(parseFloat(data).toFixed(3));
                        var amount = parseFloat($("#Rate").val()).toFixed(2) * parseFloat($("#Quantity").val()).toFixed(3);
                        $("#BillAmount").val(parseFloat(amount).toFixed(2));

                    }
                })
                $('#addItem').focus();
                $("#Quantity").prop("disabled", true);

            }
            else {
                $('#addItem').focus();
                $("#Quantity").prop("disabled", false);

            }

        });


        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
        $("#ItemName").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/InventorySalesMasterAndTransaction/GetItemSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term, locationID: $("#LocationID").val(), BalanceSheetID: $("#selectedBalsheetID").val(), PolicyDefaultAnswer: $("#PolicyDefaultAnswer").val() },
                    success: function (data) {
                        response($.map(data, function (item) {

                            return {

                                label: item.name,
                                value: item.name,
                                id: item.id,
                                rate: item.rate,
                                itemCode: item.itemCode,
                                picture: item.picture,
                                currencyCode: item.currencyCode,
                                currentStockQty: item.currentStockQty,
                                unitID: item.unitID,
                                unitCode: item.unitCode,
                                rateDecreaseByPercentage: item.rateDecreaseByPercentage,
                                genTaxGroupMasterID: item.genTaxGroupMasterID,
                                isExpiry: item.isExpiry,
                                isTaxInclusive: item.isTaxInclusive,
                                taxRatePercentage: item.taxRatePercentage,
                                TaxAmount: item.TaxAmount,
                                SaleRateExcludingtax: item.SaleRateExcludingtax
                            };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);                                             // display the selected text
                // $("#createSales").show();
                
                
                var taxAmount = parseFloat(ui.item.TaxAmount).toFixed(2);
                var rate = parseFloat(ui.item.rate).toFixed(2);
                $("#RateIncludingtax").val(parseFloat(taxAmount) + parseFloat(rate));
                if (($("#PolicyDefaultAnswer").val()) == 1 && ui.item.taxRatePercentage > 0 && ui.item.isTaxInclusive == false) {

                    var abc = parseFloat(ui.item.SaleRateExcludingtax)
                    var abc1 = ((parseFloat(ui.item.SaleRateExcludingtax) * ui.item.taxRatePercentage) / 100)
                    var abc2 = Math.round((parseFloat(ui.item.rate)) - (parseFloat(abc1)), 2);
                    $("#Rate").val(abc2);
                }
                else {
                    $("#Rate").val(parseFloat(ui.item.rate).toFixed(2));
                }
                $("#ItemID").val(parseInt(ui.item.id));
                $("#UnitCode").val(ui.item.unitCode);
                $("#UnitID").val(ui.item.unitID);
                $("#AvailableStock").val(ui.item.currentStockQty);
                $("#Discount").val(0);
                $("#BillAmount").val(0);
                $("#IsExpiry").val(ui.item.isExpiry);
                $("#GeneralTaxGroupID").val(ui.item.genTaxGroupMasterID);
                if (ui.item.rateDecreaseByPercentage == 0) {
                    $("#Discount").prop("disabled", true);
                }
                else {
                    $("#Discount").prop("disabled", false);
                }
                if (ui.item.isExpiry) {
                    $("#BatchNumber").prop("disabled", false);
                    $("#BatchNumber").focus();
                }
                else {
                    $("#BatchNumber").prop("disabled", true);
                }
                if (ui.item.genTaxGroupMasterID > 0) {
                    $("#Tax").val(ui.item.taxRatePercentage);
                }
                else {
                    $("#Tax").val(0);
                }
                InventorySalesMasterAndTransaction.RateDecreaseByPercentage = ui.item.rateDecreaseByPercentage;

                if (ui.item.unitCode == 'KG' || ui.item.unitCode == 'kg') {
                    $.ajax({
                        url: "/InventorySalesMasterAndTransaction/GetInventoryItemQuantity",
                        type: "POST",
                        dataType: "json",
                        success: function (data) {
                            //if Apply tax inclusive printing template PolicyDefaultAnswer=1 else 0
                            if ($("#PolicyDefaultAnswer").val() == '0') {
                                $("#Quantity").val(parseFloat(data).toFixed(3));
                                var amount = parseFloat($("#Rate").val()).toFixed(2) * parseFloat($("#Quantity").val()).toFixed(3);
                                $("#BillAmount").val(amount.toFixed(2));
                            }
                            else {
                                //Tax Printing Template Applicable
                                $("#Quantity").val(parseFloat(data).toFixed(3));
                                var amount = parseFloat($("#RateIncludingtax").val()).toFixed(2) * parseFloat($("#Quantity").val()).toFixed(3);
                                $("#BillAmount").val(amount.toFixed(2));
                            }

                        }
                    })
                    if (ui.item.isExpiry) {
                        $('#BatchNumber').focus();
                    }
                    else {
                        $('#addItem').focus();
                    }

                    $("#Quantity").prop("disabled", true);

                }
                else {
                    if (ui.item.isExpiry) {
                        $('#BatchNumber').focus();
                    }
                    else {
                        $("#Quantity").focus();
                    }

                    $("#Quantity").prop("disabled", false);
                    $("#Quantity").val('')
                }
            }
        });

        // Create new record
        $('#addItem').on("click", function () {
            //if Apply tax inclusive printing template PolicyDefaultAnswer=1 else 0
            if ($('#PolicyDefaultAnswer').val() == "0") {

                if ((($('#FieldValue').val() == "1") || ($('#FieldValue').val() == "0" && parseInt($('#AvailableStock').val()) >= parseFloat($('#Quantity').val()))) && (($('#IsExpiry').val() == "false" && parseInt($('#BatchID').val()) == 0) || ($('#IsExpiry').val() == "true" && parseInt($('#BatchID').val()) > 0 && parseFloat($('#BatchQuantity').val()) > parseFloat($('#Quantity').val()))) && $('#ItemName').val() != "" && $('#Quantity').val() != "" && $('#Quantity').val() > 0 && $("#LocationID").val() > 0 && $("#ItemID").val() > 0 && (InventorySalesMasterAndTransaction.RateDecreaseByPercentage >= parseFloat($('#Discount').val()) && $('#Discount').val() != "")) {

                    var taxAmount = ((parseFloat($('#Tax').val()) * parseFloat($("#BillAmount").val())) / 100).toFixed(2);
                    var itemDiscount = ((parseFloat($('#Discount').val()) * parseFloat($("#BillAmount").val())) / 100).toFixed(2);
                    var billAmount = parseFloat($('#BillAmount').val());
                    var quantity = parseFloat($('#Quantity').val());
                    var rate = parseFloat($('#Rate').val());
                    var billAmountWithTax = parseFloat(billAmount) + parseFloat(taxAmount);

                    $("#tblData tbody").append(
                      "<tr style='font-size:11px;'>" +
                       "<td ><input type='text' value=" + $('#ItemID').val() + " style='display:none' /> " + $('#ItemName').val() + "</td>" +
                       "<td ><input value=" + $('#BatchID').val() + "   type='hidden' />  " + $('#BatchNumber').val() + "</td>" +
                       "<td><input type='text' value=" + rate + " style='display:none' /> " + rate + "</td>" +
                       "<td>" + $('#UnitCode').val() + "</td>" +
                       "<td><input id='itemQuantity' maxlength='8' type='text' value=" + quantity.toFixed(3) + " style='width:60%;height:15px;text-align:right;font-size:12px;'/></td>" +
                       "<td style='text-align:left'> " + itemDiscount + "</td>" +
                       "<td style='text-align:left'> " + taxAmount + " </td>" +
                       "<td style='text-align:left;' >" + billAmount + "</td>" +
                       "<td style='text-align:left;' >" + parseFloat(billAmountWithTax - itemDiscount).toFixed(2) + "</td>" +
                       "<td  style='text-align:center; '> <i class='icon-trash' style='cursor:pointer' title = Delete> <input type='hidden' id='itemDiscount' value=" + $('#Discount').val() + "  /> <input type='hidden' id='itemTax' value=" + $('#Tax').val() + "  /> <input type='hidden' id='itemDiscountAmount' value=" + itemDiscount + "  /><input type='hidden' id='itemTaxAmount' value=" + taxAmount + "  /><input type='hidden' id='itemBillAmount' value=" + billAmount + "  /><input type='hidden' id='itemGrossAmount' value=" + parseFloat(billAmountWithTax - itemDiscount).toFixed(2) + "  /><input type='hidden' id='itemGeneralTaxGroupID' value=" + $("#GeneralTaxGroupID").val() + "  /><input  type='hidden' value=" + $('#ExpiryDate').val().replace(/ /g, '~') + "  /><input type='hidden'  value=" + $('#BatchNumber').val() + "   /><input type='hidden'  value=" + $('#AvailableStock').val() + " id='availableStcok'   /><input type='hidden'  value=" + $('#Rate').val() + " id='rate'   />  </td>" +
                       "</tr>"
                      );

                    $("#ItemName").val("");
                    $("#Rate").val(0);
                    $("#UnitCode").val("");
                    $("#Quantity").val(0);
                    $("#BillAmount").val(0);
                    $("#ItemID").val(0);
                    $("#Discount").val(0);
                    $("#AvailableStock").val(0);
                    $("#BatchNumber").val('');
                    $("#BatchID").val(0);
                    $("#Tax").val(0);
                    $("#BatchQuantity").val(0);
                    $("#ExpiryDate").val('');
                    $('#ItemName').focus();
                    $('input[id*=itemQuantity]').on("keydown", function (e) {
                        AMSValidation.AllowNumbersWithDecimalOnly(e);
                    });
                    $('input[id*=itemQuantity]').on("keyup", function (e) {
                        parseFloat($(this).val()).toFixed(3);
                    });
                    InventorySalesMasterAndTransaction.TotalItem();
                    InventorySalesMasterAndTransaction.TotalBillAmount();
                    InventorySalesMasterAndTransaction.TotalDiscountAmount();
                    InventorySalesMasterAndTransaction.TotalTaxAmount();
                    InventorySalesMasterAndTransaction.TotalGrossAmount();
                    $("#Quantity").prop("disabled", true);
                    $("#Discount").prop("disabled", true);
                    $("#BatchNumber").prop("disabled", true);
                }
                else if (($('#FieldValue').val() == "0" && parseFloat($('#AvailableStock').val()) <= 0)) {
                    $('#SuccessMessage').html("Please Check Available Stock");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#LocationID").val() == 0) {
                    $('#SuccessMessage').html("Please Select Location Name.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#ItemID").val() == 0) {
                    $('#SuccessMessage').html("Invalid item selected");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#ItemName").val() == "") {
                    $('#SuccessMessage').html("Please Enter Item Name.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {
                    $('#SuccessMessage').html("Please Enter Quantity.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#IsExpiry").val() == "true" && $("#BatchID").val() == 0) {
                    $('#SuccessMessage').html("Batch Number is mandatory");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
                else if (parseFloat($('#AvailableStock').val()) < parseFloat($('#Quantity').val())) {
                    $('#SuccessMessage').html("Quantity limit exceeds");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#Discount").val() == "") {
                    $('#SuccessMessage').html("Please enter discount.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }

                else if (parseFloat($("#Discount").val()) > parseFloat(InventorySalesMasterAndTransaction.RateDecreaseByPercentage)) {
                    $('#SuccessMessage').html("Maximum discount is " + InventorySalesMasterAndTransaction.RateDecreaseByPercentage + " %.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
                else if ($('#IsExpiry').val() == "true" && $('#BatchQuantity ').val() < $('#Quantity').val()) {
                    $('#SuccessMessage').html("Quantity exceeds BatchQuantity");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else {
                //Tax Printing Template Applicable
                if ((($('#FieldValue').val() == "1") || ($('#FieldValue').val() == "0" && parseInt($('#AvailableStock').val()) >= parseFloat($('#Quantity').val()))) && (($('#IsExpiry').val() == "false" && parseInt($('#BatchID').val()) == 0) || ($('#IsExpiry').val() == "true" && parseInt($('#BatchID').val()) > 0 && parseFloat($('#BatchQuantity').val()) > parseFloat($('#Quantity').val()))) && $('#ItemName').val() != "" && $('#Quantity').val() != "" && $('#Quantity').val() > 0 && $("#LocationID").val() > 0 && $("#ItemID").val() > 0 && (InventorySalesMasterAndTransaction.RateDecreaseByPercentage >= parseFloat($('#Discount').val()) && $('#Discount').val() != "")) {
                    
                    

                    // var taxAmount = ((parseFloat($('#Tax').val()) * parseFloat($("#BillAmount").val())) / 100).toFixed(2);
                    var itemDiscount = ((parseFloat($('#Discount').val()) * parseFloat($("#BillAmount").val())) / 100).toFixed(2);
                    var billAmount = parseFloat($('#BillAmount').val());
                    var quantity = parseFloat($('#Quantity').val());

                    var rate = parseFloat($('#RateIncludingtax').val()); //Rate + Tax 
                    var rate1 = parseFloat($('#Rate').val()); //Rate
                    var amount1 = parseFloat(rate1 * quantity).toFixed(2);
                    var taxAmount = ((parseFloat($('#Tax').val()) * parseFloat(amount1) / 100).toFixed(2));
                    var itemDiscount1 = ((parseFloat($('#Discount').val()) * parseFloat(amount1) / 100).toFixed(2));
                    var billAmountWithTax = parseFloat(billAmount);

                    $("#tblData tbody").append(
                      "<tr style='font-size:11px;'>" +
                       "<td ><input type='text' value=" + $('#ItemID').val() + " style='display:none' /> " + $('#ItemName').val() + "</td>" +
                       "<td ><input value=" + $('#BatchID').val() + "   type='hidden' />  " + $('#BatchNumber').val() + "</td>" +
                       "<td><input type='text' value=" + rate + " style='display:none' /> " + rate + "</td>" +

                        "<td style='display:none'><input type='text' id='rate1' value=" + rate1 + " style='display:none' />  " + rate1 + " </td>" +
                       "<td>" + $('#UnitCode').val() + "</td>" +
                       "<td><input id='itemQuantity' maxlength='8' type='text' value=" + quantity.toFixed(3) + " style='width:60%;height:15px;text-align:right;font-size:12px;'/></td>" +
                       "<td style='text-align:left'> " + itemDiscount + "</td>" +
                        "<td style='display:none'> " + taxAmount + " </td>" +
                       "<td style= 'text-align:left;' >" + billAmount + "</td>" +
                       "<td style='display:none' >" + amount1 + "</td>" +
                       "<td style='text-align:left;' >" + parseFloat(billAmountWithTax - itemDiscount).toFixed(2) + "</td>" +
                       "<td  style='text-align:center; '> <i class='icon-trash' style='cursor:pointer' title = Delete> <input type='hidden' id='itemDiscount' value=" + $('#Discount').val() + "  /> <input type='hidden' id='itemTax' value=" + $('#Tax').val() + "  /> <input type='hidden' id='itemDiscountAmount' value=" + itemDiscount + "  /><input type='hidden' id='itemTaxAmount' value=" + taxAmount + "  /><input type='hidden' id='itemBillAmount' value=" + billAmount + "  /><input type='hidden' id='itemGrossAmount' value=" + parseFloat(billAmountWithTax - itemDiscount).toFixed(2) + "  /><input type='hidden' id='itemGeneralTaxGroupID' value=" + $("#GeneralTaxGroupID").val() + "  /><input  type='hidden' value=" + $('#ExpiryDate').val().replace(/ /g, '~') + "  /><input type='hidden'  value=" + $('#BatchNumber').val() + "   /><input type='hidden'  value=" + $('#AvailableStock').val() + " id='availableStcok'   /></td>" +
                       "</tr>"
                      );


                    $("#ItemName").val("");
                    $("#Rate").val(0);
                    $("#UnitCode").val("");
                    $("#Quantity").val(0);
                    $("#BillAmount").val(0);
                    $("#ItemID").val(0);
                    $("#Discount").val(0);
                    $("#AvailableStock").val(0);
                    $("#BatchNumber").val('');
                    $("#BatchID").val(0);
                    $("#Tax").val(0);
                    $("#BatchQuantity").val(0);
                    $("#RateIncludingtax").val(0);
                    $("#ExpiryDate").val('');
                    $('#ItemName').focus();
                    $('input[id*=itemQuantity]').on("keydown", function (e) {
                        AMSValidation.AllowNumbersWithDecimalOnly(e);
                    });
                    $('input[id*=itemQuantity]').on("keyup", function (e) {
                        parseFloat($(this).val()).toFixed(3);
                    });
                    InventorySalesMasterAndTransaction.TotalItem();
                    InventorySalesMasterAndTransaction.TotalBillAmount();
                    InventorySalesMasterAndTransaction.TotalDiscountAmount();
                    InventorySalesMasterAndTransaction.TotalTaxAmount();
                    InventorySalesMasterAndTransaction.TotalGrossAmount();
                    InventorySalesMasterAndTransaction.TotalBillAmountIncludeTaxTemplate();

                    $("#Quantity").prop("disabled", true);
                    $("#Discount").prop("disabled", true);
                    $("#BatchNumber").prop("disabled", true);
                }
                else if (($('#FieldValue').val() == "0" && parseFloat($('#AvailableStock').val()) <= 0)) {
                    $('#SuccessMessage').html("Please Check Available Stock");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#LocationID").val() == 0) {
                    $('#SuccessMessage').html("Please Select Location Name.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#ItemID").val() == 0) {
                    $('#SuccessMessage').html("Invalid item selected");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#ItemName").val() == "") {
                    $('#SuccessMessage').html("Please Enter Item Name.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#Quantity").val() == "" || $("#Quantity").val() == 0 || $("#Quantity").val() == '.') {
                    $('#SuccessMessage').html("Please Enter Quantity.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($("#IsExpiry").val() == "true" && $("#BatchID").val() == 0) {
                    $('#SuccessMessage').html("Batch Number is mandatory");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }

                else if ($("#Discount").val() == "") {
                    $('#SuccessMessage').html("Please enter discount.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }

                else if (parseFloat($("#Discount").val()) > parseFloat(InventorySalesMasterAndTransaction.RateDecreaseByPercentage)) {
                    $('#SuccessMessage').html("Maximum discount is " + InventorySalesMasterAndTransaction.RateDecreaseByPercentage + " %.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
                else if (parseFloat($('#AvailableStock').val()) < parseFloat($('#Quantity').val())) {
                    $('#SuccessMessage').html("Quantity limit exceeds");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");

                }
                else if ($('#IsExpiry').val() == "true" && $('#BatchQuantity ').val() < $('#Quantity').val()) {
                    $('#SuccessMessage').html("Quantity exceeds BatchQuantity");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }

            }

        });

        //On Quantity Change
        $("#tblData tbody").on("keyup", "tr td input[id^=itemQuantity]", function () {


            var quantity = $(this).closest('tr').find('td input[id^=itemQuantity]').val();
            var availableStcok = $(this).closest('tr').find('td input[id^=availableStcok]').val();
            if ($('#PolicyDefaultAnswer').val() == "0") {
                var Fieldvalue = $('#FieldValue').val();
                if ($('#FieldValue').val() == "0" && (parseFloat(quantity) > parseFloat(availableStcok))) {
                    $('#SuccessMessage').html("Quantity limit exceeds than " + availableStcok + "");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    $(this).closest('tr').find('td input[id^=itemQuantity]').val(0);
                    quantity = 0;
                    var discount = $(this).closest('tr').find('td input[id^=itemDiscount]').val();
                    var Tax = $(this).closest('tr').find('td input[id^=itemTax]').val();
                    var rate = $(this).closest('tr').find('td').eq(2).text();
                    var billAmount = parseFloat(rate * quantity);
                    var itemDiscount = 0;
                    var itemTax = 0;

                    $(this).closest('tr').find('td').eq(7).text(parseFloat(billAmount).toFixed(2));
                    $(this).closest('tr').find('td input[id^=itemBillAmount]').val(parseFloat(billAmount).toFixed(2));
                    if (discount > 0) {
                        itemDiscount = parseFloat((billAmount * discount) / 100);
                        $(this).closest('tr').find('td').eq(5).text(parseFloat(itemDiscount).toFixed(2));
                        $(this).closest('tr').find('td input[id^=itemDiscountAmount]').val(parseFloat(itemDiscount).toFixed(2));
                    }
                    if (Tax > 0) {
                        itemTax = parseFloat((billAmount * Tax) / 100);
                        $(this).closest('tr').find('td').eq(6).text(parseFloat(itemTax).toFixed(2));
                        $(this).closest('tr').find('td input[id^=itemTaxAmount]').val(parseFloat(itemTax).toFixed(2));
                    }
                    var grossBillAmount = parseFloat(billAmount + itemTax - itemDiscount);
                    $(this).closest('tr').find('td').eq(8).text(parseFloat(grossBillAmount).toFixed(2));
                    $(this).closest('tr').find('td input[id^=itemGrossAmount]').val(parseFloat(grossBillAmount).toFixed(2));
                }

                else {
                    
                    
                    var discount = $(this).closest('tr').find('td input[id^=itemDiscount]').val();
                    var Tax = $(this).closest('tr').find('td input[id^=itemTax]').val();
                    var rate = $(this).closest('tr').find('td').eq(2).text();
                    var billAmount = parseFloat(rate * quantity);
                    var itemDiscount = 0;
                    var itemTax = 0;

                    $(this).closest('tr').find('td').eq(7).text(parseFloat(billAmount).toFixed(2));
                    $(this).closest('tr').find('td input[id^=itemBillAmount]').val(parseFloat(billAmount).toFixed(2));
                    if (discount > 0) {
                        itemDiscount = parseFloat((billAmount * discount) / 100);
                        $(this).closest('tr').find('td').eq(5).text(parseFloat(itemDiscount).toFixed(2));
                        $(this).closest('tr').find('td input[id^=itemDiscountAmount]').val(parseFloat(itemDiscount).toFixed(2));
                    }
                    if (Tax > 0) {
                        itemTax = parseFloat((billAmount * Tax) / 100);
                        $(this).closest('tr').find('td').eq(6).text(parseFloat(itemTax).toFixed(2));
                        $(this).closest('tr').find('td input[id^=itemTaxAmount]').val(parseFloat(itemTax).toFixed(2));
                    }
                    var grossBillAmount = parseFloat(billAmount + itemTax - itemDiscount);
                    $(this).closest('tr').find('td').eq(8).text(parseFloat(grossBillAmount).toFixed(2));
                    $(this).closest('tr').find('td input[id^=itemGrossAmount]').val(parseFloat(grossBillAmount).toFixed(2));
                }
                InventorySalesMasterAndTransaction.TotalBillAmount();
                InventorySalesMasterAndTransaction.TotalDiscountAmount();
                InventorySalesMasterAndTransaction.TotalTaxAmount();
                InventorySalesMasterAndTransaction.TotalGrossAmount();
            }

            else {
                
                
                //Tax Printing Template Applicable
                var Fieldvalue = $('#FieldValue').val();
                if ($('#FieldValue').val() == "0" && (parseFloat(quantity) > parseFloat(availableStcok))) {
                    $('#SuccessMessage').html("Quantity limit exceeds than " + availableStcok + "");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    $(this).closest('tr').find('td input[id^=itemQuantity]').val(0);
                    quantity = 0;
                    var discount = $(this).closest('tr').find('td input[id^=itemDiscount]').val();
                    var Tax = $(this).closest('tr').find('td input[id^=itemTax]').val();
                    var rate = $(this).closest('tr').find('td').eq(2).text();
                    var rate1 = $(this).closest('tr').find('td input[id^=rate1]').val();

                    var billAmount = parseFloat(rate * quantity);
                    var billAmount1 = parseFloat(rate1 * quantity);

                    var itemDiscount = 0;
                    var itemTax = 0;

                    $(this).closest('tr').find('td').eq(8).text(parseFloat(billAmount).toFixed(2));
                    $(this).closest('tr').find('td').eq(9).text(parseFloat(billAmount1).toFixed(2));
                    $(this).closest('tr').find('td input[id^=itemBillAmount]').val(parseFloat(billAmount).toFixed(2));
                    if (discount > 0) {
                        itemDiscount = parseFloat((billAmount * discount) / 100);
                        $(this).closest('tr').find('td').eq(6).text(parseFloat(itemDiscount).toFixed(2));
                        $(this).closest('tr').find('td input[id^=itemDiscountAmount]').val(parseFloat(itemDiscount).toFixed(2));
                    }
                    if (Tax > 0) {
                        itemTax = parseFloat((billAmount1 * Tax) / 100);
                        $(this).closest('tr').find('td').eq(7).text(parseFloat(itemTax).toFixed(2));
                        $(this).closest('tr').find('td input[id^=itemTaxAmount]').val(parseFloat(itemTax).toFixed(2));
                    }
                    var grossBillAmount = parseFloat(billAmount - itemDiscount);
                    $(this).closest('tr').find('td').eq(10).text(parseFloat(grossBillAmount).toFixed(2));
                    $(this).closest('tr').find('td input[id^=itemGrossAmount]').val(parseFloat(grossBillAmount).toFixed(2));
                }

                else {
                    
                    
                    var discount = $(this).closest('tr').find('td input[id^=itemDiscount]').val();
                    var Tax = $(this).closest('tr').find('td input[id^=itemTax]').val();
                    var rate = $(this).closest('tr').find('td').eq(2).text();
                    var rate1 = $(this).closest('tr').find('td input[id^=rate1]').val();

                    var billAmount = parseFloat(rate * quantity);
                    var billAmount1 = parseFloat(rate1 * quantity);

                    var itemDiscount = 0;
                    var itemTax = 0;

                    $(this).closest('tr').find('td').eq(8).text(parseFloat(billAmount).toFixed(2));
                    $(this).closest('tr').find('td').eq(9).text(parseFloat(billAmount1).toFixed(2));
                    $(this).closest('tr').find('td input[id^=itemBillAmount]').val(parseFloat(billAmount).toFixed(2));
                    if (discount > 0) {
                        itemDiscount = parseFloat((billAmount * discount) / 100);
                        $(this).closest('tr').find('td').eq(6).text(parseFloat(itemDiscount).toFixed(2));
                        $(this).closest('tr').find('td input[id^=itemDiscountAmount]').val(parseFloat(itemDiscount).toFixed(2));
                    }
                    if (Tax > 0) {
                        itemTax = parseFloat((billAmount1 * Tax) / 100);
                        $(this).closest('tr').find('td').eq(7).text(parseFloat(itemTax).toFixed(2));
                        $(this).closest('tr').find('td input[id^=itemTaxAmount]').val(parseFloat(itemTax).toFixed(2));
                    }
                    var grossBillAmount = parseFloat(billAmount - itemDiscount);
                    $(this).closest('tr').find('td').eq(10).text(parseFloat(grossBillAmount).toFixed(2));
                    $(this).closest('tr').find('td input[id^=itemGrossAmount]').val(parseFloat(grossBillAmount).toFixed(2));
                }
                InventorySalesMasterAndTransaction.TotalBillAmount();
                InventorySalesMasterAndTransaction.TotalDiscountAmount();
                InventorySalesMasterAndTransaction.TotalTaxAmount();
                InventorySalesMasterAndTransaction.TotalGrossAmount();
                InventorySalesMasterAndTransaction.TotalBillAmountIncludeTaxTemplate();
            }
        });

        //On Delevery Charge Change
        $("#DeliveryCharge").on("keyup", function () {
            InventorySalesMasterAndTransaction.TotalGrossAmount();
        }),

        //Delete
        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
            InventorySalesMasterAndTransaction.TotalItem();
            InventorySalesMasterAndTransaction.TotalBillAmount();
            InventorySalesMasterAndTransaction.TotalDiscountAmount();
            InventorySalesMasterAndTransaction.TotalTaxAmount();
            InventorySalesMasterAndTransaction.TotalGrossAmount();
            InventorySalesMasterAndTransaction.TotalBillAmountIncludeTaxTemplate();
        });





        $('#CreateFeeSubTypeRecord').on("click", function () {

            InventorySalesMasterAndTransaction.ActionName = "CreateFeeSubType";
            InventorySalesMasterAndTransaction.AjaxCallInventorySalesMasterAndTransaction();
        });
        $('#DeleteFeeSubTypeMasterRecord').on("click", function () {

            InventorySalesMasterAndTransaction.ActionName = "DeleteFeeSubType";

        });
        //$('#OperatorSaleReport').on("click", function () {

        //    InventorySalesMasterAndTransaction.ActionName = "OperatorSaleReport";
        //    InventorySalesMasterAndTransaction.AjaxCallInventorySalesMasterAndTransaction();
        //});


        $('#CounterLogin').on("click", function () {

            InventorySalesMasterAndTransaction.ActionName = "CounterLogin";
            InventorySalesMasterAndTransaction.AjaxCallInventorySalesMasterAndTransaction();
        });
        $('#CounterLogOut').on("click", function () {

            InventorySalesMasterAndTransaction.ActionName = "CounterLogOut";
            InventorySalesMasterAndTransaction.AjaxCallInventorySalesMasterAndTransaction();
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

        //FOLLOWING FUNCTION IS SEARCHLIST OF Batch list
        $("#BatchNumber").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/InventorySalesMasterAndTransaction/GetBatchNumberOfItem",
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
                // alert(ui.item.batchQuantity);
                $("#BatchID").val(parseInt(ui.item.id));
                $("#ExpiryDate").val(ui.item.expiryDate);
                $("#BatchQuantity").val(parseFloat(ui.item.batchQuantity));
                $('#addItem').focus();
            }
        });

        //FOLLOWING FUNCTION IS SEARCHLIST OF Customer list
        $("#CustomerName").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/InventorySalesMasterAndTransaction/GetCustomerNameSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {

                            return { label: item.name, value: item.name, id: item.id, contactNumber: item.contactNumber, address: item.address };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);                                             // display the selected text
                $("#CustomerID").val(parseInt(ui.item.id));
                $("#CustomerContactNo").val(ui.item.contactNumber);
                $("#CustomerAddress").val(ui.item.address);
            }
        });

        $("#CustomerContactNo").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/InventorySalesMasterAndTransaction/GetCustomerNameSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {

                            return { label: item.contactNumber, value: item.contactNumber, id: item.id, name: item.name, contactNumber: item.contactNumber, address: item.address };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                //  $(this).val(ui.item.label);                                             // display the selected text
                $("#CustomerID").val(parseInt(ui.item.id));
                $("#CustomerName").val(ui.item.name);
                $("#CustomerContactNo").val(ui.item.contactNumber);
                $("#CustomerAddress").val(ui.item.address);
            }
        });


        $("#reset").click(function () {
            InventorySalesMasterAndTransaction.ResetTableList();

        });


        $('#DeliveryCharge').on("keydown keypress", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#Discount').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#CustomerName').on("keydown", function (e) {

            //  $("#CustomerID").val(0);reseet
            // $("#CustomerName").val(ui.item.name);
            //$("#CustomerContactNo").val("");
            //$("#CustomerAddress").val("");

        });
        $('#CustomerContactNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
            //  $("#CustomerID").val(0);
            //$("#CustomerName").val("");
            ////   $("#CustomerContactNo").val("");
            //$("#CustomerAddress").val("");
        });
        $('#Quantity').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });


        $('#CounterOpeningCash').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);

        });


        $('#ItemName').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
            if (e.keyCode == 8 || e.keyCode == 46) {
                $("#ItemName").val("");
                $("#Quantity").val("");
                $("#Rate").val("");
                $("#BillAmount").val("");
                $("#BatchNumber").val("");
                $("#ExpiryDate").val("");
                $("#UnitCode").val("");
                $("#Tax").val("0");
                $("#AvailableStock").val("");
                $("#ItemName").focus();
                $("#RateIncludingtax").val("");
                $("#Discount").val(0);

            }
        });

        if (InventorySalesMasterAndTransaction.DocumentLoadCount == 1) {
            InventorySalesMasterAndTransaction.ShortCutKeysInitialization();
        }

        $("#ItemName").focus();

        $("#tblData tbody").on("keypress", "tr td input[id^=itemQuantity]", function (e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });
    },

    ShortCutKeysInitialization: function () {
        $(document).keyup(function (e) {

            if (e.altKey && (e.which === 65 || e.which === 97)) {
                //alt+A
                $("#salesDiv").show();
                $("#listDiv").hide();
                $("#ItemName").focus();
            }
            if (e.altKey && (e.which === 76 || e.which === 108)) {
                //alt+l
                $("#salesDiv").hide();
                $("#listDiv").show();
            }
            if (e.altKey && (e.which === 80 || e.which === 112)) {
                //alt+p
                $("#btnPayment").click();
            }
            if (e.altKey && (e.which === 82 || e.which === 114)) {
                //alt+R
                $("#btnHold").click();
            }
            if (e.altKey && (e.which === 88 || e.which === 120)) {
                //Alt+X
                $("#reset").click();
            }
            if (e.shiftKey && (String.fromCharCode(e.which) === 'o' || String.fromCharCode(e.which) === 'O')) {
                $("#btnOpenBill").click();
            }
            ///ASCII codes for F series keys - F1: 112 , F2: 113 , F3: 114 , F4: 115 , F5: 116 , F6: 117 , F7: 118 , F8: 119 , F9: 120 ,F10: 121 , F11: 122 ,F12: 123
            if (e.shiftKey && e.ctrlKey && e.keyCode == 112) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(1)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(1);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 113) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(2)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(2);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 114) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(3)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(3);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 115) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(4)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(4);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 116) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(5)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(5);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 117) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(6)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(6);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 118) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(7)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(7);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 119) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(8)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(8);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 120) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(9)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(9);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 121) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(10)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(10);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 122) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(11)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(11);
                }
            }
            if (e.shiftKey && e.ctrlKey && e.keyCode == 123) {
                if (InventorySalesMasterAndTransaction.ValidateHoldBill(12)) {
                    InventorySalesMasterAndTransaction.LoadHoldBill(12);
                }
            }
        });
    },

    TotalDiscountAmount: function () {

        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalDiscount").val(0);
        if ($('#PolicyDefaultAnswer').val() == "0") {
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(5).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        else {
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(6).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        //InventorySalesMasterAndTransaction.RoundUpAmount1 = Math.round(a.toFixed(2)) - a.toFixed(2);

        // $("#TotalDiscount").val(Math.round(a.toFixed(2)));
        $("#TotalDiscount").val((a.toFixed(2)));
    },
    TotalTaxAmount: function () {
        /////
        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalTaxAmount").val(0);
        if ($('#PolicyDefaultAnswer').val() == "0") {
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(6).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        else {
            //Tax Printing Template Applicable
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(7).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });


        }
        //InventorySalesMasterAndTransaction.RoundUpAmount1 = Math.round(a.toFixed(2)) - a.toFixed(2);

        // $("#TotalTaxAmount").val(Math.round(a.toFixed(2)));
        $("#TotalTaxAmount").val((a.toFixed(2)));
    },

    TotalBillAmount: function () {

        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmount").val(0);
        if ($('#PolicyDefaultAnswer').val() == "0") {
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(7).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        else {
            //Tax Printing Template Applicable
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(8).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        InventorySalesMasterAndTransaction.RoundUpAmount1 = Math.round(a.toFixed(2)) - a.toFixed(2);

        // $("#TotalBillAmount").val(Math.round(a.toFixed(2)));
        $("#TotalBillAmount").val((a.toFixed(2)));
    },

    TotalBillAmountIncludeTaxTemplate: function () {

        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalBillAmountIncludeTaxTemplate").val(0);
        if ($('#PolicyDefaultAnswer').val() == "0") {
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(7).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        else {
            //Tax Printing Template Applicable
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(9).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        InventorySalesMasterAndTransaction.RoundUpAmount1 = Math.round(a.toFixed(2)) - a.toFixed(2);

        // $("#TotalBillAmount").val(Math.round(a.toFixed(2)));
        $("#TotalBillAmountIncludeTaxTemplate").val((a.toFixed(2)));
    },

    TotalGrossAmount: function () {

        var length = $("#tblData tbody tr").length;
        var a = 0; var x = 0;
        $("#TotalGrossAmount").val(0);
        if ($('#PolicyDefaultAnswer').val() == "0") {
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(8).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        else {
            //Tax Printing Template Applicable
            $("#tblData tbody tr").each(function (i) {
                if (i < length) {
                    x = parseFloat($(this).find('td').eq(10).text()).toFixed(2);
                    a += parseFloat(x);
                }

            });
        }
        a = parseFloat(a) + parseFloat($("#DeliveryCharge").val() == "" || $("#DeliveryCharge").val() == null ? 0 : $("#DeliveryCharge").val());
        InventorySalesMasterAndTransaction.RoundUpAmount1 = Math.round(a.toFixed(2)) - a.toFixed(2);

        $("#TotalGrossAmount").val(Math.round(a.toFixed(2)));
        //$("#TotalGrossAmount").val((a.toFixed(2)));
    },

    TotalItem: function () {
        var length = $("#tblData tbody tr").length;
        $("#TotalItem").val(length);
    },

    ResetTableList: function () {
        $("#tblData tbody tr").remove();
        $('#Quantity').val("");
        $('#Rate').val("");
        $('#RateIncludingtax').val("");
        $('#BillAmount').val("");
        $("#TotalItem").val(0);
        $('#ItemName').val("");
        $('#ItemID').val("");
        $('#UnitCode').val("");
        $('#TotalBillAmount').val(0);
        $('#Discount').val(0);
        $('#CustomerName').val("");
        $('#CustomerType').val("WI");
        $('#ID').val(0);
        $('#DeliveryCharge').val("");
        $('#AvailableStock').val("");
        $('#BatchNumber').val("");
        $('#TotalBillAmountIncludeTaxTemplate').val(0);
        
        $('#Tax').val("");


        InventorySalesMasterAndTransaction.RoundUpAmount1 = 0;
        InventorySalesMasterAndTransaction.TotalItem();
        InventorySalesMasterAndTransaction.TotalBillAmount();
        InventorySalesMasterAndTransaction.TotalDiscountAmount();
        InventorySalesMasterAndTransaction.TotalTaxAmount();
        InventorySalesMasterAndTransaction.TotalGrossAmount();
        return false;
    },


    ValidateHoldBill: function (keyPressNumber) {

        if (parseInt($("input[id=OpenBillCount]").val()) >= keyPressNumber) {
            if (parseInt($("#tblData tbody tr").length) == 0) {
                return true;
            }
            else {
                $("#btnHold").click();
                return false;
            }
        }
        else {
            $('#SuccessMessage').html("Hold bill count is " + parseInt($("input[id=OpenBillCount]").val()) + "");
            $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            return false;
        }


    },

    LoadHoldBill: function (keyPressNumber) {

        var balancesheet = $("#selectedBalsheetID").val();
        var locationID = $("#LocationID :selected").val();
        var PolicyDefaultAnswer = $("#PolicyDefaultAnswer").val();
        if (balancesheet != null && balancesheet != "") {
            $.ajax(
           {
               cache: false,
               type: "GET",
               data: { "selectedBalsheet": balancesheet, "keyPressNumber": keyPressNumber, "locationID": locationID, "PolicyDefaultAnswer": PolicyDefaultAnswer },
               dataType: "html",
               url: '/InventorySalesMasterAndTransaction/List',
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
               url: '/InventorySalesMasterAndTransaction/List',
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
            url: '/InventorySalesMasterAndTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                ////twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', colorCode);
            }
        });
    },
    //Method to create xml
    GetXmlData: function () {

        var DataArray = [];
        $('#DivAddRowTable input[type=text]').each(function () {

            DataArray.push($(this).val());
        });
        TotalRecord = DataArray.length;
        ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 6) {
            var EQuantity = parseFloat(DataArray[i + 5] - DataArray[i + 2]).toFixed(3)
            ParameterXml = ParameterXml + "<row><ID>" + DataArray[i + 4] + "</ID><ItemID>" + DataArray[i] + "</ItemID><Quantity>" + parseFloat(DataArray[i + 2]).toFixed(3) + "</Quantity><EQuantity>" + parseFloat(EQuantity).toFixed(3) + "</EQuantity><Rate>" + parseFloat(DataArray[i + 1]).toFixed(3) + "</Rate><Discount>" + parseFloat(DataArray[i + 3]).toFixed(2) + "</Discount></row>";
        }
        if (ParameterXml.length > 6)
            InventorySalesMasterAndTransaction.XMLstring = ParameterXml + "</rows>";
        else
            InventorySalesMasterAndTransaction.XMLstring = "";

        //  alert(InventorySalesMasterAndTransaction.XMLstring);
    },

    //Method to create xml for Hold Bill
    CreateItemDetailsXML: function () {


        var DataArray = [];
        $('#DivAddRowTable input').each(function () {

            DataArray.push($(this).val());
        });
        var abc = 0;
        
        
        
        TotalRecord = DataArray.length;

        //  alert(DataArray);
        ParameterXml = "<rows>";
        if ($('#PolicyDefaultAnswer').val() == "0") {
            for (var i = 0; i < TotalRecord; i = i + 15) {
                //if Apply tax inclusive printing template PolicyDefaultAnswer=1 else 0

                if (DataArray[i + 1] == 0) {
                    ParameterXml = ParameterXml + "<row><ID>0</ID><ItemID>" + DataArray[i] + "</ItemID><BatchID>" + DataArray[i + 1] + "</BatchID><Quantity>" + parseFloat(DataArray[i + 3]).toFixed(3) + "</Quantity><Rate>" + DataArray[i + 2] + "</Rate><DiscountAmount>" + DataArray[i + 6] + "</DiscountAmount><DiscountInPercentage>" + parseFloat(DataArray[i + 4]).toFixed(2) + "</DiscountInPercentage><GenTaxGroupMasterID>" + DataArray[i + 10] + "</GenTaxGroupMasterID><TaxAmount>" + DataArray[i + 7] + "</TaxAmount><TaxInPercentage>" + DataArray[i + 5] + "</TaxInPercentage><BatchNumber></BatchNumber><ExpiryDate></ExpiryDate></row>";
                }
                else {
                    ParameterXml = ParameterXml + "<row><ID>0</ID><ItemID>" + DataArray[i] + "</ItemID><BatchID>" + DataArray[i + 1] + "</BatchID><Quantity>" + parseFloat(DataArray[i + 3]).toFixed(3) + "</Quantity><Rate>" + DataArray[i + 2] + "</Rate><DiscountAmount>" + DataArray[i + 6] + "</DiscountAmount><DiscountInPercentage>" + parseFloat(DataArray[i + 4]).toFixed(2) + "</DiscountInPercentage><GenTaxGroupMasterID>" + DataArray[i + 10] + "</GenTaxGroupMasterID><TaxAmount>" + DataArray[i + 7] + "</TaxAmount><TaxInPercentage>" + DataArray[i + 5] + "</TaxInPercentage><BatchNumber>" + DataArray[i + 12] + "</BatchNumber><ExpiryDate>" + DataArray[i + 11].replace(/~/g, ' ') + "</ExpiryDate></row>";
                }
            }
        }
        else {
            for (var i = 0; i < TotalRecord; i = i + 15) {
                //Tax Printing Template Applicable
                if (DataArray[i + 1] == 0) {
                    ParameterXml = ParameterXml + "<row><ID>0</ID><ItemID>" + DataArray[i] + "</ItemID><BatchID>" + DataArray[i + 1] + "</BatchID><Quantity>" + parseFloat(DataArray[i + 4]).toFixed(3) + "</Quantity><Rate>" + DataArray[i + 3] + "</Rate><DiscountAmount>" + DataArray[i + 7] + "</DiscountAmount><DiscountInPercentage>" + parseFloat(DataArray[i + 5]).toFixed(2) + "</DiscountInPercentage><GenTaxGroupMasterID>" + DataArray[i + 11] + "</GenTaxGroupMasterID><TaxAmount>" + DataArray[i + 8] + "</TaxAmount><TaxInPercentage>" + DataArray[i + 6] + "</TaxInPercentage><BatchNumber></BatchNumber><ExpiryDate></ExpiryDate></row>";
                    // abc = parseFloat(parseFloat(abc) + parseFloat(DataArray[i + 7]));
                }
                else {
                    ParameterXml = ParameterXml + "<row><ID>0</ID><ItemID>" + DataArray[i] + "</ItemID><BatchID>" + DataArray[i + 1] + "</BatchID><Quantity>" + parseFloat(DataArray[i + 4]).toFixed(3) + "</Quantity><Rate>" + DataArray[i + 3] + "</Rate><DiscountAmount>" + DataArray[i + 7] + "</DiscountAmount><DiscountInPercentage>" + parseFloat(DataArray[i + 5]).toFixed(2) + "</DiscountInPercentage><GenTaxGroupMasterID>" + DataArray[i + 11] + "</GenTaxGroupMasterID><TaxAmount>" + DataArray[i + 8] + "</TaxAmount><TaxInPercentage>" + DataArray[i + 6] + "</TaxInPercentage><BatchNumber>" + DataArray[i + 13] + "</BatchNumber><ExpiryDate>" + DataArray[i + 12].replace(/~/g, ' ') + "</ExpiryDate></row>";
                    // abc = parseFloat(parseFloat(abc) + parseFloat(DataArray[i + 7]));
                }

            }
        }

        if (ParameterXml.length > 6) {
            InventorySalesMasterAndTransaction.XMLstring = ParameterXml + "</rows>";
            if ($('#PolicyDefaultAnswer').val() == "1") {
                InventorySalesMasterAndTransaction.TotalTaxAmounts = abc;
            }
            else {
                abc = 0;
            }
        }
        else
            InventorySalesMasterAndTransaction.XMLstring = "";


    },

    HoldBill: function () {
        //Create Hold Bill
        $('#CreateHoldBill').on("click", function () {

            InventorySalesMasterAndTransaction.ActionName = "Hold";
            InventorySalesMasterAndTransaction.CreateItemDetailsXML();
            if (InventorySalesMasterAndTransaction.XMLstring != null && InventorySalesMasterAndTransaction.XMLstring != "") {
                InventorySalesMasterAndTransaction.AjaxCallInventorySalesMasterAndTransaction();
            }
            else {
                $('#SuccessMessage').html("No data available in table");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }
        });
    },

    CustomerControlInitialization: function () {
        //FOLLOWING FUNCTION IS SEARCHLIST OF Customer list
        $("#CustomerName").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/InventorySalesMasterAndTransaction/GetCustomerNameSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {

                            return { label: item.name, value: item.name, id: item.id, contactNumber: item.contactNumber, address: item.address };
                        }))
                    }
                })
            },
            select: function (event, ui) {

                $(this).val(ui.item.label);                                             // display the selected text
                $("input[id=CustomerID]").val(parseInt(ui.item.id));
                $("#CustomerContactNo").val(ui.item.contactNumber);
                $("#CustomerAddress").val(ui.item.address);
                $("#PaymentByCustomer").focus();
            }
        });

        $("#CustomerContactNo").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/InventorySalesMasterAndTransaction/GetCustomerNameSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {

                            return { label: item.contactNumber, value: item.contactNumber, id: item.id, name: item.name, contactNumber: item.contactNumber, address: item.address };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                //  $(this).val(ui.item.label);                                             // display the selected text
                $("#CustomerID").val(parseInt(ui.item.id));
                $("#CustomerName").val(ui.item.name);
                $("#CustomerContactNo").val(ui.item.contactNumber);
                $("#CustomerAddress").val(ui.item.address);
            }
        });

    },

    //Check On Focus Out.
    FocusOut: function (actionOn, data) {
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionOn": actionOn, "data": data },
            url: '/InventorySalesMasterAndTransaction/CheckFocusOnAction',
            success: function (data) {
                //Rebind Grid Data
                if (actionOn == "CustomerName") {

                    var abc = data.split('~');
                    $("#CustomerID").val(abc[0].replace('"', ''));
                    $("#CustomerAddress").val(abc[1].replace('"', ''));
                    $("#CustomerContactNo").val(abc[2].replace('"', ''));
                    $("#CustomerContactNo").focus();

                }
            }
        });
    },


    PaymentFormInitialization: function () {
        $(document).ready(function () {
            $("#PaymentByCustomer").on("keyup", function () {

                if (parseFloat($("#PaymentByCustomer").val()) > 0) {
                    $("#ReturnChange").val(parseFloat($("#PaymentByCustomer").val()) - parseFloat($("#TotalGrossAmount").val()));
                }
                else {
                    $("#ReturnChange").val("0");
                }
            });
            $("#totalPayment").val($("#TotalGrossAmount").val());

            $('#CustomerContactNo').on("keydown", function (e) {
                AMSValidation.AllowNumbersOnly(e);
                AMSValidation.NotAllowSpaces(e);
            });
            $('#PaymentByCustomer').on("keydown", function (e) {
                AMSValidation.AllowNumbersWithDecimalOnly(e);
                AMSValidation.NotAllowSpaces(e);
            });

            $("#CustomerName").focusout(function () {
                var data = $("#CustomerName").val();
                InventorySalesMasterAndTransaction.FocusOut("CustomerName", data);
            });

            $('#CustomerName').on("keydown", function (e) {
                AMSValidation.AllowAlphaNumericOnly(e);
                if (e.keyCode == 8 || e.keyCode == 46) {
                    $("#CustomerName").val("");
                    $("#CustomerContactNo").val("");
                    $("#CustomerAddress").val("");
                    $("#CustomerName").focus();
                }
            });


            //Create Sale Bill
            $('#CreateInventorySaleMaster').on("click", function () {
               
                if (parseFloat($("#TotalGrossAmount").val()) == 0) {
                    $('#SuccessMessagediv').html("Your Bill Amount is 0 Rs");
                    $('#SuccessMessagediv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
                else if ($("#CustomerName").val() == "" || $("#CustomerName").val() == null) {
                    $('#SuccessMessagediv').html(" Please Enter Customer Name");
                    $('#SuccessMessagediv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }
                else if (parseFloat($("#PaymentByCustomer").val()) >= parseFloat($("#TotalGrossAmount").val())) {
                    InventorySalesMasterAndTransaction.ActionName = "Create";
                    InventorySalesMasterAndTransaction.CreateItemDetailsXML();
                    if (InventorySalesMasterAndTransaction.XMLstring != null && InventorySalesMasterAndTransaction.XMLstring != "") {
                        $('#CreateInventorySaleMaster').attr("disabled", true);
                        InventorySalesMasterAndTransaction.AjaxCallInventorySalesMasterAndTransaction();


                    }
                    else {
                        $('#SuccessMessagediv').html("No data available in table");
                        $('#SuccessMessagediv').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

                    }
                }
                else {

                    $('#SuccessMessagediv').html("Payment Amount Is Less Then paid Amount ");
                    $('#SuccessMessagediv').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    return false;
                }

            });

            $('#ClosePayment').on("click", function () {
                parent.$.colorbox.close();
            });
        });

        $('#PaymentByCustomer').on("keypress", function (e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallInventorySalesMasterAndTransaction: function () {
        var InventorySalesMasterAndTransactionData = null;
        if (InventorySalesMasterAndTransaction.ActionName == "Create") {
            $("#FormCreateInventorySaleMaster").validate();
            if ($("#FormCreateInventorySaleMaster").valid()) {
                InventorySalesMasterAndTransactionData = null;
                InventorySalesMasterAndTransactionData = InventorySalesMasterAndTransaction.GetInventorySalesMasterAndTransaction();
                ajaxRequest.makeRequest("/InventorySalesMasterAndTransaction/List", "POST", InventorySalesMasterAndTransactionData, InventorySalesMasterAndTransaction.Success);
            }
        }

        else if (InventorySalesMasterAndTransaction.ActionName == "CounterLogin") {
            if ($("#SelectedCounterID").val() != "" && $("#CounterOpeningCash").val() != "" && $("#selectedBalsheetID").val() != "") {
                InventoryCounterLogAndLockDetailsData = null;
                InventoryCounterLogAndLockDetailsData = InventorySalesMasterAndTransaction.GetCounterLogin();
                ajaxRequest.makeRequest("/InventorySalesMasterAndTransaction/CounterLogin", "POST", InventoryCounterLogAndLockDetailsData, InventorySalesMasterAndTransaction.SuccessCounterLogin);
            }
            else if ($("#selectedBalsheetID").val() == "") {
                $('#SuccessMessage').html("Please select balancesheet.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }
            else if ($("#SelectedCounterID").val() == "") {
                $('#SuccessMessage').html("Please select Counter.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }
            else if ($("#CounterOpeningCash").val() == "") {
                $('#SuccessMessage').html("Please enter counter opening balance.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }

        }

        else if (InventorySalesMasterAndTransaction.ActionName == "CounterLogOut") {
            InventoryCounterLogAndLockDetailsData = null;
            ajaxRequest.makeRequest("/InventorySalesMasterAndTransaction/CounterLogOut", "POST", InventoryCounterLogAndLockDetailsData, InventorySalesMasterAndTransaction.SuccessCounterLogOut);
        }

        else if (InventorySalesMasterAndTransaction.ActionName == "Hold") {
            $("#FormCreateHoldBillMaster").validate();
            if ($("#FormCreateHoldBillMaster").valid()) {
                InventorySalesMasterAndTransactionData = null;
                InventorySalesMasterAndTransactionData = InventorySalesMasterAndTransaction.GetInventorySalesMasterAndTransaction();
                ajaxRequest.makeRequest("/InventorySalesMasterAndTransaction/HoldBill", "POST", InventorySalesMasterAndTransactionData, InventorySalesMasterAndTransaction.SuccessHoldBill);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventorySalesMasterAndTransaction: function () {
        var Data = {
        };
        
        Data.ID = $('input[name=ID]').val();
        //Data.BillAmount = $('#TotalBillAmount').val();
        Data.TotalGrossAmount = $('#TotalGrossAmount').val();
        if ($('#PolicyDefaultAnswer').val() == "0") {
            Data.BillAmount = $('#TotalBillAmount').val();
        }
        else {
            Data.BillAmount = $('#TotalBillAmountIncludeTaxTemplate').val();
        }
        Data.TotalTaxAmount = $('#TotalTaxAmount').val();
        Data.TotalTaxAmount = $('#TotalTaxAmount').val();
        Data.TotalDiscount = $('#TotalDiscount').val();
        Data.DeliveryCharge = $('#DeliveryCharge').val();
        Data.PaymentByCustomer = $('#PaymentByCustomer').val();
        Data.ReturnChange = $('#ReturnChange').val();
        Data.HoldBillReference = $('#HoldBillReference').val();

        Data.CustomerID = $('input[name=CustomerID]').val();
        Data.CustomerName = $('#CustomerName').val();
        Data.CustomerContactNo = $('#CustomerContactNo').val();
        Data.CustomerAddress = $('#CustomerAddress').val();
        Data.CustomerType = $("#CustomerType").val();

        Data.BalanceSheetID = $("#selectedBalsheetID").val();
        Data.LocationID = $("#LocationID").val();
        Data.CounterID = $('input[name=CounterID]').val();
        Data.CounterLogID = $('input[name=CounterLogID]').val();

        Data.PolicyDefaultAnswer = $('input[name=PolicyDefaultAnswer]').val();

        Data.XMLstring = InventorySalesMasterAndTransaction.XMLstring;
        Data.RoundUpAmount = InventorySalesMasterAndTransaction.RoundUpAmount1;
        return Data;
    },


    GetCounterLogin: function () {
        var Data = {
        };
        var bbb = $("#SelectedCounterID").val().split('~');
        Data.CounterID = bbb[0];
        Data.InvCounterApplicableDetailsID = bbb[1];
        Data.CounterOpeningCash = $('#CounterOpeningCash').val();
        Data.CounterClosingCash = $('#CounterClosingCash').val();
        Data.BalanceSheetID = $("#selectedBalsheetID").val();
        Data.PolicyDefaultAnswer = $("#PolicyDefaultAnswer").val();
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        $('#CreateInventorySaleMaster').attr("disabled", false);
        //if Apply tax inclusive printing template PolicyDefaultAnswer=1 else 0
        if ($('#PolicyDefaultAnswer').val() == "0") {
            if (data != null) {
                parent.$.colorbox.close();
                var frame1 = $('<iframe />');
                frame1[0].name = "frame1";
                frame1.css({ "position": "absolute", "top": "-1000000px" });
                $("body").append(frame1);
                var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
                frameDoc.document.open();
                //Create a new HTML document.
                frameDoc.document.write('<html><head><meta charset="utf-8"><title>Bill</title>');
                //Append the external CSS .
                frameDoc.document.write('<style media="all" type="text/css">body { max-width: 300px;text-transform: uppercase; margin:0 auto; text-align:center; color:#000; font-family: Arial, Helvetica, sans-serif; font-size:12px; }#wrapper { min-width: 250px; margin: 0 auto; }#wrapper img { max-width: 300px; width: auto; }h2, h3, p { margin: 5px 0; }.left { width:60%; float:left; text-align:left; margin-bottom: 3px; }.right { width:40%; float:right; text-align:right; margin-bottom: 3px; }.table, .totals { width: 100%; margin:10px 0; }.table th { border-bottom: 1px solid #000; }.table td { padding:0; }.totals td { width: 24%; padding:0; }.table td:nth-child(2) { overflow:hidden; }@media print {body { text-transform: uppercase; }#buttons { display: none; }#wrapper { width: 100%; margin: 0; font-size:9px; }#wrapper img { max-width:300px; width: 80%; }#header,#footer {display:none}}</style>');
                frameDoc.document.write('</head><body>');
                //Append the DIV contents.
                //frameDoc.document.write(contents);
                frameDoc.document.write('<div id="wrapper"><img src="../Content/images/surbhifruitsfinallogo.jpg" style="width:50%;"><p>' + data[0].PrintingLine1 + '<br>' + data[0].PrintingLine2 + '</p>    	<span class="left">' + data[0].PrintingLine4 + '</span> <span class="right" style="text-overflow: ellipsis;">Bill No.: ' + data[0].BillNumber + '</span><span class="left">Customer:' + data[0].CustomerName + ' </span> <span class="right">Date: ' + data[0].TransactionDate.split(' ')[0] + '</br>' + data[0].TransactionDate.split(' ')[1] + '</span>    <div style="clear:both;"></div><table cellspacing="0"  border="0" class="table"> <thead> <tr style="font-size:11px">  <th>Items</th> <th>Qty</th><th>Rate</th><th>Amount</th> </tr> </thead> <tbody style="font-size:11px">');
                var strCollection1 = '';
                for (var i = 0; i < data.length; i++) {
                    strCollection1 = strCollection1 + '<tr>' +
                                                    '<td style="text-align:left; width:180px;">' + data[i].ItemName + '</td>' +
                                                    '<td style="text-align:center; width:70px;">' + parseFloat(data[i].Quantity).toFixed(3) + '' + data[i].UnitCode + '</td>' +
                                                    '<td style="text-align:center; width:70px;">' + parseFloat(data[i].Rate).toFixed(2) + '</td>' +
                                                    '<td style="text-align:right; width:70px; ">' + parseFloat(parseFloat(data[i].Rate).toFixed(3) * parseFloat(data[i].Quantity)).toFixed(2) + '</td>' +
                                                    '</tr>'
                }
                frameDoc.document.write(strCollection1);
                frameDoc.document.write('</tbody></table> <table cellspacing="0" border="0" style="margin-bottom:5px;" class="totals"><tbody style="font-size:10px"><tr><td style="text-align:left;"></td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + " " + '</td><td style="text-align:left; padding-left:1.5%;">Net Amt.</td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].NetAmount).toFixed(2) + '</td></tr><tr><td style="text-align:left;"></td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + " " + '</td><td style="text-align:left; padding-left:1.5%;">Tax </td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].TotalTaxAmount).toFixed(2) + '</td></tr><tr><td style="text-align:left;"></td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + " " + '</td><td style="text-align:left; padding-left:1.5%;">Delivery</td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].DeliveryCharge).toFixed(2) + '</td></tr><tr><td style="text-align:left;">Total Items</td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + data.length + '</td><td style="text-align:left; padding-left:1.5%;">Discount </td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].TotalDiscount).toFixed(2) + '</td></tr><tr><td style="text-align:left; font-weight:bold; border-top:1px solid #000; padding-top:5px;" colspan="2">Grand Total</td><td style="border-top:1px solid #000; padding-top:5px; text-align:right; font-weight:bold;" colspan="2">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].BillAmount).toFixed(2) + '</td></tr></tbody></table><div style="border-top:1px solid #000; padding-top:10px;"><p>Thank You Visit Again !</p>    </div></div>');//oRIG
                frameDoc.document.write('</body></html>');
                frameDoc.document.close();
                setTimeout(function () {
                    window.frames["frame1"].focus();
                    window.frames["frame1"].print();
                    frame1.remove();
                }, 500);
                InventorySalesMasterAndTransaction.ReloadList("Record created successfully", "#9FEA7A", "0");

            }
        }
        else {
            //Tax Printing Template Applicable
            if (data != null) {
                parent.$.colorbox.close();
                var frame1 = $('<iframe />');
                frame1[0].name = "frame1";
                frame1.css({ "position": "absolute", "top": "-1000000px" });
                $("body").append(frame1);
                var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
                frameDoc.document.open();
                //Create a new HTML document.
                frameDoc.document.write('<html><head><meta charset="utf-8"><title>Bill</title>');
                //Append the external CSS .
                frameDoc.document.write('<style media="all" type="text/css">body { max-width: 300px;text-transform: uppercase; margin:0 auto; text-align:center; color:#000; font-family: Arial, Helvetica, sans-serif; font-size:12px; }#wrapper { min-width: 250px; margin: 0 auto; }#wrapper img { max-width: 300px; width: auto; }h2, h3, p { margin: 5px 0; }.left { width:60%; float:left; text-align:left; margin-bottom: 3px; }.right { width:40%; float:right; text-align:right; margin-bottom: 3px; }.table, .totals { width: 100%; margin:10px 0; }.table th { border-bottom: 1px solid #000; }.table td { padding:0; }.totals td { width: 24%; padding:0; }.table td:nth-child(2) { overflow:hidden; }@media print {body { text-transform: uppercase; }#buttons { display: none; }#wrapper { width: 100%; margin: 0; font-size:9px; }#wrapper img { max-width:300px; width: 80%; }#header,#footer {display:none}}</style>');
                frameDoc.document.write('</head><body>');
                //Append the DIV contents.
                //frameDoc.document.write(contents);
                frameDoc.document.write('<div id="wrapper"><img src="../Content/images/surbhifruitsfinallogo.jpg" style="width:50%;"><p>' + data[0].PrintingLine1 + '<br>' + data[0].PrintingLine2 + '</p>    	<span class="left">' + data[0].PrintingLine4 + '</span> <span class="right" style="text-overflow: ellipsis;">Bill No.: ' + data[0].BillNumber + '</span><span class="left">Customer:' + data[0].CustomerName + ' </span> <span class="right">Date: ' + data[0].TransactionDate.split(' ')[0] + '</br>' + data[0].TransactionDate.split(' ')[1] + '</span>    <div style="clear:both;"></div><table cellspacing="0"  border="0" class="table"> <thead> <tr style="font-size:11px">  <th>Items</th> <th>Qty</th><th>Rate</th><th>Amount</th> </tr> </thead> <tbody style="font-size:11px">');
                var strCollection1 = '';
                for (var i = 0; i < data.length; i++) {
                    strCollection1 = strCollection1 + '<tr>' +
                                                    '<td style="text-align:left; width:180px;">' + data[i].ItemName + '</td>' +
                                                    '<td style="text-align:center; width:70px;">' + parseFloat(data[i].Quantity).toFixed(3) + '' + data[i].UnitCode + '</td>' +
                                                    '<td style="text-align:center; width:70px;">' + parseFloat(data[i].Rate).toFixed(2) + '</td>' +
                                                    '<td style="text-align:right; width:70px; ">' + parseFloat(parseFloat(data[i].Rate).toFixed(3) * parseFloat(data[i].Quantity)).toFixed(2) + '</td>' +
                                                    '</tr>'
                }
                frameDoc.document.write(strCollection1);
                frameDoc.document.write('</tbody></table> <table cellspacing="0" border="0" style="margin-bottom:5px;" class="totals"><tbody style="font-size:10px"><tr><td style="text-align:left;"></td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + " " + '</td><td style="text-align:left; padding-left:1.5%;">Net Amt.</td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].NetAmount).toFixed(2) + '</td></tr><tr><td style="text-align:left;"></td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + " " + '</td></tr><tr><td style="text-align:left;"></td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + " " + '</td></tr><tr><td style="text-align:left;">Total Items</td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">' + data.length + '</td><td style="text-align:left; padding-left:1.5%;">Discount </td><td style="text-align:right;">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].TotalDiscount).toFixed(2) + '</td></tr><tr><td style="text-align:left; font-weight:bold; border-top:1px solid #000; padding-top:5px;" colspan="2">Grand Total</td><td style="border-top:1px solid #000; padding-top:5px; text-align:right; font-weight:bold;" colspan="2">' + data[0].CurrencyCode + ' ' + parseFloat(data[0].BillAmount).toFixed(2) + '</td></tr></tbody></table><div style="border-top:1px solid #000; padding-top:10px;"><p>Thank You Visit Again !</p>    </div></div>');//oRIG
                frameDoc.document.write('</body></html>');
                frameDoc.document.close();
                setTimeout(function () {
                    window.frames["frame1"].focus();
                    window.frames["frame1"].print();
                    frame1.remove();
                }, 500);
                InventorySalesMasterAndTransaction.ReloadList("Record created successfully", "#9FEA7A", "0");

            }
        }
    },


    //this is used to for showing successfully record creation message and reload the list view
    SuccessCounterLogin: function (data) {
        var splitData = data.InventorySalesMasterAndTransactionDTO.errorMessage.split(',');
        $('#SuccessMessage').html(splitData[0]);
        $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', splitData[1]);
        $("#CounterLogID").val(data.CounterLogID);
        if (splitData[2] == "1") {
            $('#CounterLoginDiv').hide(true);
            $('#salesDiv').show(true);
        }

    },
    SuccessCounterLogOut: function (data) {
        var splitData = data.split(',');
        $('#SuccessMessage').html(splitData[0]);
        $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', splitData[1]);
        $("#CounterLogID").val(0);
        if (splitData[2] == "1") {
            $('#CounterLoginDiv').hide(true);
            $('#salesDiv').hide(true);
        }

    },
    SuccessHoldBill: function (data) {

        if (data != null) {
            parent.$.colorbox.close();
            InventorySalesMasterAndTransaction.ResetTableList();
            $("input[id=OpenBillCount]").val(parseInt($("input[id=OpenBillCount]").val()) + 1)
            $("#btnDisplayHoldBillCount").val('Hold Bill : ' + $("input[id=OpenBillCount]").val());
            var splitData = data.split(',');
            $('#SuccessMessage').html(splitData[0]);
            $('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', splitData[1]);
        }

    },


    //PrintBill: function () {

    //    // var contents = $("#dvContents").html();
    //    //var contents = $("#dvContents").html();
    //        var frame1 = $('<iframe />');
    //        frame1[0].name = "frame1";
    //        frame1.css({ "position": "absolute", "top": "-1000000px" });
    //        $("body").append(frame1);
    //        var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
    //        frameDoc.document.open();
    //        //Create a new HTML document.
    //        frameDoc.document.write('<html><head><meta charset="utf-8"><title>Bill</title>');
    //         //Append the external CSS .
    //        frameDoc.document.write('<style media="all" type="text/css">body { max-width: 300px; margin:0 auto; text-align:center; color:#000; font-family: Arial, Helvetica, sans-serif; font-size:12px; }#wrapper { min-width: 250px; margin: 0 auto; }#wrapper img { max-width: 300px; width: auto; }h2, h3, p { margin: 5px 0; }.left { width:60%; float:left; text-align:left; margin-bottom: 3px; }.right { width:40%; float:right; text-align:right; margin-bottom: 3px; }.table, .totals { width: 100%; margin:10px 0; }.table th { border-bottom: 1px solid #000; }.table td { padding:0; }.totals td { width: 24%; padding:0; }.table td:nth-child(2) { overflow:hidden; }@media print {body { text-transform: uppercase; }#buttons { display: none; }#wrapper { width: 100%; margin: 0; font-size:9px; }#wrapper img { max-width:300px; width: 80%; }#header,#footer {display:none}}</style>');
    //        frameDoc.document.write('</head><body>');
    //        //Append the DIV contents.
    //        //frameDoc.document.write(contents);
    //        frameDoc.document.write('<div id="wrapper"><h2><strong>Surbhi Fresh</strong></h2><p>Reg.60,West Balaji Nagar,<br>Manewada Road,Nagpur-440027</p>    	<span class="left">Tel: 2347036463485</span> <span class="right">Sale No.: 428</span><span class="left">Customer: </span> <span class="right">Date: 14/09/2015 17:59:59</span>    <div style="clear:both;"></div><table cellspacing="0"  border="0" class="table"> <thead> <tr style="font-size:11px"> <th>SN</th> <th>Items</th> <th>Quantity</th><th>Rate</th> </tr> </thead> <tbody style="font-size:11px">');

    //        var DataArray = [];
    //        $('#DivAddRowTable input[type=text])').each(function () {

    //            DataArray.push($(this).val());
    //        });

    //        TotalRecord = DataArray.length;
    //        ParameterXml = "<rows>";
    //        for (var i = 0; i < TotalRecord; i = i + 3) {
    //            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i] + "</ItemID><Rate>" + DataArray[i + 1] + "</Rate><Quantity>" + DataArray[i + 2] + "</Quantity></row>";
    //        }
    //        '<tr>'
    //        '<td style="text-align:center; width:30px;">1</td>'
    //        '<td style="text-align:left; width:180px;">Papas Fritas</td>'
    //        '<td style="text-align:center; width:50px;">1</td>'
    //        '<td style="text-align:right; width:70px; ">300.00</td>'
    //        '</tr> '
    //        '<tr><td style="text-align:center; width:30px;">2</td><td style="text-align:left; width:180px;">Perfume</td><td style="text-align:center; width:50px;">1</td><td style="text-align:right; width:70px; ">60.00</td></tr> <tr><td style="text-align:center; width:30px;">3</td><td style="text-align:left; width:180px;">ABHAYARISHTAM 450ML</td><td style="text-align:center; width:50px;">1</td><td style="text-align:right; width:70px; ">80.00</td></tr> </tbody> </table> <table cellspacing="0" border="0" style="margin-bottom:5px;" class="totals"><tbody style="font-size:13px"><tr><td style="text-align:left;">Total Items</td><td style="text-align:right; padding-right:1.5%; border-right: 1px solid #000;font-weight:bold;">3</td><td style="text-align:left; padding-left:1.5%;">Total</td><td style="text-align:right;font-weight:bold;">440.00</td></tr><tr><td style="text-align:left; font-weight:bold; border-top:1px solid #000; padding-top:5px;" colspan="2">Grand Total</td><td style="border-top:1px solid #000; padding-top:5px; text-align:right; font-weight:bold;" colspan="2">435.00</td></tr></tbody></table><div style="border-top:1px solid #000; padding-top:10px;"><p>Thank you for your business!</p>    </div></div>'
    //        frameDoc.document.write('</body></html>');
    //        frameDoc.document.close();
    //        setTimeout(function () {
    //            window.frames["frame1"].focus();
    //            window.frames["frame1"].print();
    //            frame1.remove();
    //        }, 500);

    //},
    ////this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        InventorySalesMasterAndTransaction.ReloadList("Record Updated Sucessfully.")
    //    }
    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    if (data == "True") {
    //        InventorySalesMasterAndTransaction.ReloadList("Record Deleted Sucessfully.")
    //    }
    //},
};

