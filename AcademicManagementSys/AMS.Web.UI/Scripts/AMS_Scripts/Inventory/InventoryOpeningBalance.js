//this class contain methods related to nationality functionality
var InventoryOpeningBalance = {
    //Member variables
    ActionName: null,
    SelectedXmlData: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryOpeningBalance.constructor();
        //InventoryOpeningBalance.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#SelectedCentreCode').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');



        });

        // $('#CountryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#RateDecreaseByPercentage').focus();
            return false;
        });


        $('#btnShowList').click(function () {
            
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            //alert($('#CategoryCode :selected').val());
            var ValuCategoryCode = $('#CategoryCode :selected').val();
            var SelectedBalanceSheet = $("#selectedBalsheetID").val();
            var SessionID = $("#SessionID").val();

            if (valuCentreCode != "" && ValuCategoryCode!="") {
                InventoryOpeningBalance.LoadList(valuCentreCode, ValuCategoryCode, SessionID);
            }
            else if (valuCentreCode == "" ) {
                $('#SuccessMessage').html("Please select centre");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
               // $('#DivCreateNew').hide(true);
               
            }
            else if (ValuCategoryCode == "" || ValuCategoryCode == null) {
                $('#SuccessMessage').html("Please select Category");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
               // $('#DivCreateNew').hide(true);

            }

        });

        // Create new record
        $('#CreateInventoryOpeningBalanceRecord').on("click", function () {
            InventoryOpeningBalance.ActionName = "Create";
            InventoryOpeningBalance.GetSaleRateInXml();
            $('#CreateInventoryOpeningBalanceRecord').attr("disabled", true);
            InventoryOpeningBalance.AjaxCallInventoryOpeningBalance();
        });

        $('input[id^=RateDecreaseByPercentage]').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
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
    LoadList: function (SelectedCentreCode, CategoryCode) {
        var selectedText = $('#SelectedCenterID').text();
        var SelectedCentreCode = $("#SelectedCentreCode").val();
        var Balancesheet = $("#selectedBalsheetID").val();
        var CategoryCode = $('#CategoryCode').val();
        var SessionID = $('#SessionID').val();

        
        $.ajax(

         {

             cache: false,
             type: "GET",
             data: { selectedBalsheet: Balancesheet, centerCode: SelectedCentreCode, CategoryCode: CategoryCode, SessionID: SessionID },

             dataType: "html",
             url: '/InventoryOpeningBalance/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },


    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, CentreCode) {
        var selectedText = $('#SelectedCenterID').text();
        var SelectedCentreCode = $("#SelectedCentreCode").val();
        var Balancesheet = $("#selectedBalsheetID").val();
        var CategoryCode = $('#CategoryCode').val();
        var SessionID = $('#SessionID').val();

        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { selectedBalsheet: Balancesheet, centerCode: SelectedCentreCode, CategoryCode: CategoryCode, SessionID: SessionID },
            dataType: "html",
            url: '/InventoryOpeningBalance/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', colorCode);
            }
        });
    },



    //Fire ajax call to insert update and delete record
    AjaxCallInventoryOpeningBalance: function () {
        var InventoryOpeningBalanceData = null;
        if (InventoryOpeningBalance.ActionName == "Create") {
            InventoryOpeningBalanceData = null;
            InventoryOpeningBalanceData = InventoryOpeningBalance.GetInventoryOpeningBalance();
            ajaxRequest.makeRequest("/InventoryOpeningBalance/List", "POST", InventoryOpeningBalanceData, InventoryOpeningBalance.Success);
        }
    },

    GetSaleRateInXml: function () {
        
        var DataArray = [];
        var TotalRecord = 0;
        var table = $('#myDataTable').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        TotalRecord = DataArray.length;
       // alert(DataArray)
        var xmlParamList = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 4) {
            // String for Insert 
           
            if (DataArray[i + 3] > 0 && DataArray[i] == "False") {

                xmlParamList = xmlParamList + " <row><ID>0</ID><StockMasterID>" + DataArray[i + 2] + "</StockMasterID><ItemID>" + DataArray[i + 1] + "</ItemID><OpeningBalance>" + DataArray[i + 3] + "</OpeningBalance></row>";
            }
        }
     //   alert(xmlParamList);
        
        if (xmlParamList.length > 7)
            InventoryOpeningBalance.SelectedXmlData = xmlParamList + "</rows>";
        else
            InventoryOpeningBalance.SelectedXmlData = "";
     //   alert(InventoryOpeningBalance.SelectedXmlData);
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryOpeningBalance: function () {
        var Data = {
        };
        if (InventoryOpeningBalance.ActionName == "Create" || InventoryOpeningBalance.ActionName == "Edit") {

            Data.SelectedXml = InventoryOpeningBalance.SelectedXmlData;
            Data.SelectedCentreCode = $('#SelectedCentreCode').val();
            Data.BalanceSheetID = $("#selectedBalsheetID").val();
            Data.SessionID = $('#SessionID').val();
            Data.CategoryCode = $('#CategoryCode').val();

        }
        else if (InventoryOpeningBalance.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        $('#CreateInventoryOpeningBalanceRecord').attr("disabled", false);
        var CentreCode = data.SelectedCentreCode;//splitdata[1].split(":");
        var CategoryCode = data.CategoryCode
        //var splitData = data.errorMessage.split(',');


        var splitData = data.errorMessage.split(',');
        if (data != null) {
            InventoryOpeningBalance.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode,CategoryCode);
        }

    },

};

