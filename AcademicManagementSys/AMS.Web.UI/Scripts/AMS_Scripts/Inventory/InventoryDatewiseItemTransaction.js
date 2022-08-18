//this class contain methods related to nationality functionality
var InventoryDatewiseItemTransaction = {
    //Member variables
    ActionName: null,
    SelectedXmlData : null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        InventoryDatewiseItemTransaction.constructor();
        //InventoryDatewiseItemTransaction.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        $('#CategoryCode').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $('#btnShowList').click(function () {           
            var ValuCategoryCode = $('#CategoryCode :selected').val();
            if (ValuCategoryCode != "") {
                InventoryDatewiseItemTransaction.LoadList(ValuCategoryCode);
            }
            else if (ValuCategoryCode == "") {
                $('#SuccessMessage').html("Please select Category");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
        });

        // Create new record
        $('#CreateInventoryDatewiseItemTransactionRecord').on("click", function () {
            
            InventoryDatewiseItemTransaction.ActionName = "Create";
            InventoryDatewiseItemTransaction.GetSaleRateInXml();
            if (InventoryDatewiseItemTransaction.SelectedXmlData != null && InventoryDatewiseItemTransaction.SelectedXmlData != "") {
                InventoryDatewiseItemTransaction.AjaxCallInventoryDatewiseItemTransaction();
            }
        });
       
        $('#ItemName').on("keydown", function (e) {
            //AMSValidation.AllowCharacterOnly(e);
        });
        $('#ItemCode').on("keydown", function (e) {
            //AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('input[id^=saleRate]').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $(".ajax").colorbox();

    },
    //LoadList method is used to load List page
    LoadList: function (CategoryCode) {
        var CategoryCode = $('#CategoryCode').val();
        $.ajax({
             cache: false,
             type: "GET",
             data: {CategoryCode: CategoryCode },
             dataType: "html",
             url: '/InventoryDatewiseItemTransaction/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, CategoryCode) {
        
        var CategoryCode = $('#CategoryCode').val();
        $.ajax({
            cache: false,
            type: "GET",
            dataType: "html",       
            data: { CategoryCode: CategoryCode, actionMode: actionMode },
            url: '/InventoryDatewiseItemTransaction/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallInventoryDatewiseItemTransaction: function () {
        
        var InventoryDatewiseItemTransactionData = null;
        if (InventoryDatewiseItemTransaction.ActionName == "Create") {
            InventoryDatewiseItemTransactionData = null;
            InventoryDatewiseItemTransactionData = InventoryDatewiseItemTransaction.GetInventoryDatewiseItemTransaction();
            ajaxRequest.makeRequest("/InventoryDatewiseItemTransaction/List", "POST", InventoryDatewiseItemTransactionData, InventoryDatewiseItemTransaction.Success);
        }
    },

    GetSaleRateInXml: function () {       
        var DataArray = [];
        var table = $('#myDataTable').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        
       
        var xmlParamList = "<rows>";
        var aa = [];
        var x = 0;
        var Count = DataArray.length / 5;
        for (var i = 0; i < Count; i++) {
            if(DataArray[ x + 3] > 1){
            if (DataArray[x + 3] != DataArray[x + 4]) {
                // String for Insert 
                xmlParamList = xmlParamList + "<row><ID>" + DataArray[x] + "</ID><ItemID>" + DataArray[x + 1] + "</ItemID><SaleRate>" + DataArray[x + 3] + "</SaleRate><Quantity>" + 0.00 + "</Quantity></row>";

            }
            x = x + 5;
            }
            else {
                $('#SuccessMessage').html("Sale Rate For Item " + DataArray[x + 2].replace(/~/g, ' ') + "should not be 0");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                return false;

            }
        }      
        if (xmlParamList.length > 6)
            InventoryDatewiseItemTransaction.SelectedXmlData = xmlParamList + "</rows>";
        else
            InventoryDatewiseItemTransaction.SelectedXmlData = "";
       
    },

    //Get properties data from the Create, Update and Delete page
    GetInventoryDatewiseItemTransaction: function () {
        var Data = {
        };
        if (InventoryDatewiseItemTransaction.ActionName == "Create" || InventoryDatewiseItemTransaction.ActionName == "Edit") {
            Data.SelectedXml = InventoryDatewiseItemTransaction.SelectedXmlData;
            Data.CategoryCode = $('#CategoryCode').val();
        }
        else if (InventoryDatewiseItemTransaction.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        if (data != null) {           
            InventoryDatewiseItemTransaction.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
};

