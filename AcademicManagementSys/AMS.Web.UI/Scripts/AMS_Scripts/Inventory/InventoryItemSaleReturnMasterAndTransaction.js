
var InventoryItemSaleReturnMasterAndTransaction = {
    //Member variables
    ActionName: null,
    NetAmount : null,
    //Class intialisation method
    Initialize: function () {
        InventoryItemSaleReturnMasterAndTransaction.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#listDiv").show();
        $("#itemDetailDiv").hide();       

        //Return Item Record Submit.  
        $('#CreateInventorySalesAndTransaction').on("click", function () {           
            InventoryItemSaleReturnMasterAndTransaction.ActionName = "Create";
            InventoryItemSaleReturnMasterAndTransaction.GetXmlData();
            if (InventoryItemSaleReturnMasterAndTransaction.ReturnItemDetailxml != "" && InventoryItemSaleReturnMasterAndTransaction.ReturnItemDetailxml != null) {
                var result = true;
                $("#tbleData tbody tr").each(function (i) {
                    var qantity = ($(this).closest('tr').find('td input[id=Quantity]')).val();
                    var returnQuantity = ($(this).closest('tr').find('td input[id=returnQuantity]')).val();

                    if (parseFloat(qantity) < parseFloat(returnQuantity))
                    {
                        result = false;
                        $('#SuccessMessage').html("Please check return quantity.");
                        $('#SuccessMessage').delay(400).slideDown(400).delay(1000).slideUp(200).css('background-color', "#FFCC80");
                    }                    
                });
                if (result == true) {
                    $('#CreateInventorySalesAndTransaction').attr("disabled", true);
                    InventoryItemSaleReturnMasterAndTransaction.AjaxCallItemSaleReturnrAndTransaction();
                }                
            }
            else
            {
                result = false;
                $('#SuccessMessage').html("Please check value again.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(1000).slideUp(200).css('background-color', "#FFCC80");
            }
        });

        $('#Reset').on("click", function () {            
            $('#tbleData input').each(function () {                
                $(this).parents('tr').find('input[type="checkbox"]').attr('checked', false);
                $(this).closest('tr').find('td input[id^=returnQuantity]').val(0);
                $(this).closest('tr').find('td input[id=returnAmount]').hide();
                $(this).closest('tr').find('td input[id="returnQuantity"]').prop("disabled", true);
                InventoryItemSaleReturnMasterAndTransaction.TotalReturnAmount();
            });
        });

        $('#tbleData tbody').on('change keyup keypress', "tr td input[id^=returnQuantity]", function (e) {            
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#btnReload').on("click", function () {            
            InventoryItemSaleReturnMasterAndTransaction.LoadList();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        if ($("#InvSalesDetailsID").val() > 0 && $("#InvBufferSalesMasterID").val() > 0) {
            var date = $("#TransactionDate").val();
            var name = $("#CustomerName").val();  
       
            $("#billDate").text(date);
            $("#customer").text(name);
            $("#listDiv").hide();
            $("#itemDetailDiv").show();
        }

        //Disable CheckBox if qty <0
        $("#tbleData tbody tr").each(function (i) {           
            if (parseFloat(($(this).closest('tr').find('td input[id=Quantity]')).val()) <= 0)
            {              
                ($(this).closest('tr').find('td input[type=checkbox]')).attr('disabled', true);
            }
        });

        $('#tbleData tbody').on('change', "tr td input[type='checkbox']", function () {           
            if ($(this).is(':checked')) {
                $(this).closest('tr').find('td input[id="returnQuantity"]').removeAttr("disabled");
                $(this).closest('tr').find('td input[id="returnQuantity"]').focus();
            }
            else {
                $(this).closest('tr').find('td input[id^=returnAmount]').val(0);
                $(this).closest('tr').find('td input[id^=returnQuantity]').val(0);
                $(this).closest('tr').find('td input[id=returnAmount]').hide();
                InventoryItemSaleReturnMasterAndTransaction.TotalReturnAmount();
                $(this).closest('tr').find('td input[id="returnQuantity"]').prop("disabled", true);
            }
        });


        $('#tbleData tbody').on('change keyup', "tr td input[id^=returnQuantity]", function () {
            //$(this).closest('tr').find('td input[id=returnAmount]').show();

            var qantity = ($(this).closest('tr').find('td input[id=Quantity]')).val();
            var returnQuantity = ($(this).closest('tr').find('td input[id=returnQuantity]')).val();

            if (parseFloat(qantity) > parseFloat(returnQuantity) || parseFloat(qantity) == parseFloat(returnQuantity)) {
                $(this).closest('tr').find('td input[id=returnAmount]').show();
                var amount = (($(this).closest('tr').find('td input[id=Rate]')).val() * ($(this).closest('tr').find('td input[id=returnQuantity]')).val());
                var taxAmount = ((parseFloat(amount) * ($(this).closest('tr').find('td input[id=TaxInPercentage]')).val()) / 100);
                var discountAmount = ((parseFloat(amount) * ($(this).closest('tr').find('td input[id=DiscountInPercentage]')).val()) / 100);
                                 
                ($(this).closest('tr').find('td input[id=TaxAmount]')).val(taxAmount);
                ($(this).closest('tr').find('td input[id=DiscountAmount]')).val(discountAmount);

                if (amount > 0) {
                    var totalAmount = ((parseFloat(amount) + parseFloat(taxAmount)) - parseFloat(discountAmount));
                }
                else {
                    var totalAmount = 0;
                }
                $(this).closest('tr').find('td input[id=returnAmount]').val((totalAmount).toFixed(2));
                // InventoryItemSaleReturnMasterAndTransaction.TotalQantity();
                InventoryItemSaleReturnMasterAndTransaction.TotalReturnAmount();
            } else {
                $('#SuccessMessage').html("Return quantity should be less then sale quantity. Please check.");
                $('#SuccessMessage').delay(600).slideDown('slow').delay(1200).slideUp(2000).css('background-color', "#FFCC80");
                $(this).closest('tr').find('td input[id=returnAmount]').hide();

            }
        });
        
        $(".ajax").colorbox();
    },

    TotalReturnAmount: function () {
        var length = $("#tbleData tbody tr").length;
        var a = 0; var x = 0;
        $("#returnTotalAmount").val(0);       
        $("#tbleData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat($(this).find('td input[id^=returnAmount]').val());
                a += parseFloat(x);
            }
        });               
        $("#returnTotalAmount").val(a.toFixed(2));

    },
    
    TotalDiscountAmount: function () {
        var length = $("#tbleData tbody tr").length;
        var a = 0; var x = 0;
        $("#tbleData tbody tr").each(function (i) {
            if (i < length) {               
                x = parseFloat(($(this).closest('tr').find('td input[id^=DiscountAmount]')).val());
                a += parseFloat(x);
            }
        });
        return a.toFixed(2);
    },

    TotalTaxAmount: function () {
        var length = $("#tbleData tbody tr").length;
        var a = 0; var x = 0;
        $("#tbleData tbody tr").each(function (i) {
            if (i < length) {
                x = parseFloat(($(this).closest('tr').find('td input[id^=TaxAmount]')).val());               
                a += parseFloat(x);
            }
        });
        return a.toFixed(2);
    },

    NetAmount: function () {        
        var length = $("#tbleData tbody tr").length;
        var a = 0; var x = 0; z = 0;
        var CheckBoxArray = [];
        // Dynamically get checkbox check or not
        $('#tbleData input[type=checkbox]').each(function () {
            if (this.checked == true) {
                CheckBoxArray.push("1");
            }
            else if (this.checked == false) {
                CheckBoxArray.push("0");
            }
        });                

        $("#tbleData tbody tr").each(function (i) {            
            if (CheckBoxArray[z] == 1) {
                var rate = ($(this).closest('tr').find('td input[id^=Rate]')).val();
                var quantity = ($(this).closest('tr').find('td input[id^=returnQuantity]')).val()
                x = (rate * quantity);
                a += parseFloat(x);                
            }
            z++;
        });        
        return a.toFixed(2);
    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax({
            cache: false,
            type: "GET",
            datatype: "html",
            url: '/InventoryItemSaleReturnMasterAndTransaction/List',
            data: { "actionMode": null, "invBufferSalesMasterID": 0, "selectedBalsheet": 0 },
            success: function (data) {
                //Rebind Grid Data.
                $('#ListViewModel').html(data);
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { "actionMode": null, "invBufferSalesMasterID": 0, "selectedBalsheet": 0 },
            dataType: "html",
            url: '/InventoryItemSaleReturnMasterAndTransaction/List',
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
        var CheckArray = [];
        // Dynamically get checkbox check or not
        $('#tbleData input[type=checkbox]').each(function () {
            if (this.checked == true) {
                CheckArray.push("1");
            }
            else if (this.checked == false) {
                CheckArray.push("0");
            }
        });        
        var DataArray = [];        
        var data = $('#tbleData tbody tr td input[type="text"]').each(function () {
            DataArray.push($(this).val());
        });
     
        var TotalRecord = DataArray.length;
        var x = 0;
        var ReturnItemDetailxml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 23) {

            if (CheckArray[x] == 1) 
            {
                if (DataArray[i] > 0){
                // ReturnItemDetailxml = ReturnItemDetailxml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i] + "</ItemID><Quantity>" + DataArray[i + 1] + "</Quantity><Rate>" + DataArray[i + 2] + "</Rate></row>";
                ReturnItemDetailxml = ReturnItemDetailxml + "<row><ID>" + 0 + "</ID><ItemID>" + DataArray[i + 2] +
                                                            "</ItemID><Quantity>" + DataArray[i] + "</Quantity><Rate>" + DataArray[i + 4] +
                                                            "</Rate><GenTaxGroupMasterID>" + DataArray[i + 5] + "</GenTaxGroupMasterID><TaxAmount>" + DataArray[i + 6] +
                                                            "</TaxAmount><DiscountAmount>" + DataArray[i + 7] + "</DiscountAmount><DiscountInPercentage>" + DataArray[i + 8] +
                                                            "</DiscountInPercentage><TaxInPercentage>" + DataArray[i + 9] + "</TaxInPercentage><BatchNumber>" + DataArray[i + 19] +
                                                            "</BatchNumber><ExpiryDate>" + DataArray[i + 20] + "</ExpiryDate></row>";                
                }
            
            else {

                $('#SuccessMessage').html("Please check Return quantity");
                $('#SuccessMessage').delay(600).slideDown('slow').delay(1200).slideUp(2000).css('background-color', "#FFCC80");
                ReturnItemDetailxml = "";
                break;
                //return false;

                }
            }
            x++;
            
        }       
        if (ReturnItemDetailxml.length > 12)
            InventoryItemSaleReturnMasterAndTransaction.ReturnItemDetailxml = ReturnItemDetailxml + "</rows>";
        else
            InventoryItemSaleReturnMasterAndTransaction.ReturnItemDetailxml = "";

    },

    //Fire ajax call to insert update and delete record
    AjaxCallItemSaleReturnrAndTransaction: function () {
        var InventoryItemSaleReturnMasterAndTransactionData = null;
        if (InventoryItemSaleReturnMasterAndTransaction.ActionName == "Create") {
            InventoryItemSaleReturnMasterAndTransactionData = null;
            InventoryItemSaleReturnMasterAndTransactionData = InventoryItemSaleReturnMasterAndTransaction.GetItemSaleReturnrAndTransaction();
            ajaxRequest.makeRequest("/InventoryItemSaleReturnMasterAndTransaction/Create", "POST", InventoryItemSaleReturnMasterAndTransactionData, InventoryItemSaleReturnMasterAndTransaction.Success);

        }
    },

    //Get properties data from the Create, Update and Delete page
    GetItemSaleReturnrAndTransaction: function () {       
        var Data = {
        };
        if (InventoryItemSaleReturnMasterAndTransaction.ActionName == "Create") {            
            var a = $("#returnTotalAmount").val();
            var b = Math.ceil($("#returnTotalAmount").val());

            Data.LocationID = $("#LocationID").val();
            Data.AccountSessionID = 0;
            Data.BalanceSheetID = $("#BalanceSheetID").val();
            Data.CounterLogID = $("#CounterLogID").val();
            Data.SalesReturnAmount = (b).toFixed(2);
            Data.TotalTaxAmount = InventoryItemSaleReturnMasterAndTransaction.TotalTaxAmount();
            Data.RoundUpAmount = (b - a).toFixed(2);
            Data.TotalDiscountAmount = InventoryItemSaleReturnMasterAndTransaction.TotalDiscountAmount();
            Data.CustomerID = $("#CustomerID").val();
            Data.CustomerName = $("#CustomerName").val();
            Data.BillNumber = $("#BillNumber").val();
            Data.NetAmount = InventoryItemSaleReturnMasterAndTransaction.NetAmount();
            Data.DeliveryCharge = $("#DeliveryCharge").val();
            Data.CustomerType = $("#CustomerType").val();

            Data.ReturnItemDetailxml = InventoryItemSaleReturnMasterAndTransaction.ReturnItemDetailxml;
        }
        return Data;
    },
    
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        $('#CreateInventorySalesAndTransaction').attr("disabled", false);
        InventoryItemSaleReturnMasterAndTransaction.ReloadList(splitData[0], splitData[1], splitData[2]);
    }
};