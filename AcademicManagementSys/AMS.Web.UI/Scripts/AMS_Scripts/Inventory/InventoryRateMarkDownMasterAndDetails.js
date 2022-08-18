//this class contain methods related to nationality functionality
var InventoryRateMarkDownMasterAndDetails = {
    //Member variables
    ActionName: null,
    SelectedXmlData: null,
    flag: true,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryRateMarkDownMasterAndDetails.constructor();
        //InventoryRateMarkDownMasterAndDetails.initializeValidation();
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
            if (valuCentreCode != "" && ValuCategoryCode!="") {
                InventoryRateMarkDownMasterAndDetails.LoadList(valuCentreCode, ValuCategoryCode);
            }
            else if (valuCentreCode == "" ) {
                $('#SuccessMessage').html("Please select centre");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
            else if (ValuCategoryCode == "" || ValuCategoryCode == null) {
                $('#SuccessMessage').html("Please select Category");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                // $('#DivCreateNew').hide(true);

            }

        });

        // Create new record

        $('#CreateInventoryRateMarkDownMasterAndDetailsRecord').on("click", function () {
            InventoryRateMarkDownMasterAndDetails.ActionName = "Create";
            InventoryRateMarkDownMasterAndDetails.GetSaleRateInXml();
            if (InventoryRateMarkDownMasterAndDetails.flag == true) {
                InventoryRateMarkDownMasterAndDetails.AjaxCallInventoryRateMarkDownMasterAndDetails();
            }
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
    LoadList: function (SelectedCentreCode,CategoryCode) {
        var selectedText = $('#SelectedCenterID').text();
        //alert($('#CategoryCode').val())
        var CategoryCode = $('#CategoryCode').val();
               
        $.ajax({

             cache: false,
             type: "GET",
             data: { centerCode: SelectedCentreCode,CategoryCode:CategoryCode  },

             dataType: "html",
             url: '/InventoryRateMarkDownMasterAndDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },


    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, CentreCode, CategoryCode) {        
        var valuCentreCode = $('#SelectedCentreCode :selected').val();
        //var valuCategoryCode = $('#CategoryCode :selected').val();
               
        $.ajax({
             cache: false,
             type: "GET",
             data: { centerCode: valuCentreCode, CategoryCode: CategoryCode, actionMode: actionMode },
             dataType: "html",
             url: '/InventoryRateMarkDownMasterAndDetails/List',
             success: function (data) {
                
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 $('#SuccessMessage').html(message);
                 $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', colorCode);
             }         
        });
    },

    

    //Fire ajax call to insert update and delete record
    AjaxCallInventoryRateMarkDownMasterAndDetails: function () {
        var InventoryRateMarkDownMasterAndDetailsData = null;
        if (InventoryRateMarkDownMasterAndDetails.ActionName == "Create") {
            InventoryRateMarkDownMasterAndDetailsData = null;
            InventoryRateMarkDownMasterAndDetailsData = InventoryRateMarkDownMasterAndDetails.GetInventoryRateMarkDownMasterAndDetails();
            ajaxRequest.makeRequest("/InventoryRateMarkDownMasterAndDetails/List", "POST", InventoryRateMarkDownMasterAndDetailsData, InventoryRateMarkDownMasterAndDetails.Success);
        }
    },

    GetSaleRateInXml: function () {
        
        InventoryRateMarkDownMasterAndDetails.flag = true;
        var DataArray = [];
        var TotalRecord = 0;
        var table = $('#myDataTable').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        TotalRecord = DataArray.length;
        var xmlParamList = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 3) {
            // String for Insert 
            
            var aaa = DataArray[i].split('~');
            if (DataArray[i + 1] > 99){
                $('#SuccessMessage').html("Rate Mark down For Item " + DataArray[i + 2].replace(/~/g, ' ') + "  should not be  greater then 99%");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                InventoryRateMarkDownMasterAndDetails.flag = false;
                break;
                //InventoryRateMarkDownMasterAndDetails.SelectedXmlData = "";
            }
            else {
               
                if (aaa[2] != DataArray[i + 1] && aaa[1] > 0) {
                    xmlParamList = xmlParamList + "<row><ID>" + aaa[1] + "</ID><ItemID>" + aaa[0] + "</ItemID><RatePercentage>" + DataArray[i + 1] + "</RatePercentage></row>";
                }
                else if (DataArray[i + 1] > 0 && aaa[1] == 0) {
                    xmlParamList = xmlParamList + "<row><ID>" + aaa[1] + "</ID><ItemID>" + aaa[0] + "</ItemID><RatePercentage>" + DataArray[i + 1] + "</RatePercentage></row>";
                }
            }
            // x = x + 3;
        }
        if (xmlParamList.length > 6)
            InventoryRateMarkDownMasterAndDetails.SelectedXmlData = xmlParamList + "</rows>";
        else
            InventoryRateMarkDownMasterAndDetails.SelectedXmlData = "";
        //alert(InventoryRateMarkDownMasterAndDetails.SelectedXmlData);
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryRateMarkDownMasterAndDetails: function () {
        var Data = {
        };
        if (InventoryRateMarkDownMasterAndDetails.ActionName == "Create" || InventoryRateMarkDownMasterAndDetails.ActionName == "Edit") {

            Data.SelectedXml = InventoryRateMarkDownMasterAndDetails.SelectedXmlData;
            Data.SelectedCentreCode = $('#SelectedCentreCode').val();
            Data.CategoryCode = $('#CategoryCode').val();
        }
        else if (InventoryRateMarkDownMasterAndDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {        
        
        var CentreCode = data.CenterCode;
        var CategoryCode = data.CategoryCode
        //splitdata[1].split(":");
        //var splitData = data.errorMessage.split(',');

        var splitData = data.errorMessage.split(',');
        
        if (data != null) {            
            InventoryRateMarkDownMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode, CategoryCode);
        }

    },

};

