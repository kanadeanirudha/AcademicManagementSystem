//this class contain methods related to nationality functionality
var InventoryItemMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryItemMaster.constructor();
        //InventoryItemMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        
        $('#ItemFamily').focus();

        //Search ItemFamily
        $("#ItemFamily").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/InventoryItemMaster/GetItemFamilySearchList",
                    type: "POST",
                    dataType: "json",
                    data: { "term": request.term, },
                    success: function (data) {
                        
                        response($.map(data, function (item) {
                            return { label: item.name, value: item.name, id: item.id };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);
                $("#ItemFamilyMasterID").val(ui.item.id);
            }
        });

        //Search PackingUnit
        $("#PackingUnit").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/InventoryItemMaster/GetItemPackingUnitSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { "term": request.term, },
                    success: function (data) {
                        
                        response($.map(data, function (item) {
                            return { label: item.name, value: item.name, id: item.id };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);
                $("#ItemPackingUnitMasterID").val(ui.item.id);
            }
        });

        //Search PackingType
        $("#PackingType").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/InventoryItemMaster/GetItemPackingTypeSearchList",
                    type: "POST",
                    dataType: "json",
                    data: { "term": request.term, },
                    success: function (data) {
                        
                        response($.map(data, function (item) {
                            return { label: item.name, value: item.name, id: item.id };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);
                $("#ItemPackingTypeMasterID").val(ui.item.id);
            }
        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GenTaxGroupMasterID').val("");
            $('#ItemCategoryCode').val("");
            $('#UnitID').val("");
            
            
            $('#CountryName').focus();
            return false;
        });

        $("#ItemCategoryCode").change(function () {           
            var CategoryCode = $("#ItemCategoryCode :selected").val();
            if (CategoryCode == "" || CategoryCode == null || CategoryCode == "-----Select Category-----") {
                $("#UnitID").attr("disabled", true);
            }
            else {
                $("#UnitID").attr("disabled", false);
            }
            $("#UnitID").val("");
            $("#ItemName").val("");
            $("#ItemCode").val("");
        });
        $("#UnitID").change(function () {           
            var CategoryCode = $("#ItemCategoryCode :selected").val();
            var UnitId = $("#UnitID :selected").val();
            if (CategoryCode == "" || CategoryCode == null || CategoryCode == "-----Select Category-----" || UnitId == "") {
                CategoryCode = "";
                $("#ItemName").val("");
                $("#ItemCode").val("");
            }
            else {
                var ItemName = $("#ItemFamily").val() + $("#PackingUnit").val() + $("#PackingType").val() + "_" + $("#UnitID :selected").text();
                var ItemCode = CategoryCode + $("#ItemFamily").val().substring(0, 2);
                $.ajax(
                       {
                           cache: false,
                           type: "POST",
                           dataType: "json",
                           data: { "ItemCode": ItemCode },
                           url: '/InventoryItemMaster/GetItemCode',
                           success: function (data) {
                               $("#ItemCode").val(data);
                               $("#ItemName").val(ItemName);
                           }
                       });
            }
           
        });
        var IsSaleRateDependOnPuchase = $('input[name=IsSaleRateDependOnPuchase]:checked').val() ? true : false;
        if (IsSaleRateDependOnPuchase == true) {

            $('#Div_SaleRateDependOnPuchase').show(true);

        }
        if (IsSaleRateDependOnPuchase == false) {
            $('#Div_SaleRateDependOnPuchase').hide(true);
            $('#SaleRateFactorInPercentage').val("");
            $('#RetailRateFactorInPercentage').val("");

        }

        $('#IsSaleRateDependOnPuchase').change(function () {
            if (this.checked) {
                $('#Div_SaleRateDependOnPuchase').fadeIn('slow');
                $('#SaleRateFactorInPercentage').val("");
                $('#RetailRateFactorInPercentage').val("");


            }
            else {
                $('#Div_SaleRateDependOnPuchase').fadeOut('slow');
                $('#SaleRateFactorInPercentage').val("");
                $('#RetailRateFactorInPercentage').val("");
            }

        });
        // Create new record
        $('#CreateInventoryItemMasterRecord').on("click", function () {
            
            InventoryItemMaster.ActionName = "Create";         
            InventoryItemMaster.AjaxCallInventoryItemMaster();
        });

        $('#EditInventoryItemMasterRecord').on("click", function () {

            InventoryItemMaster.ActionName = "Edit";
            InventoryItemMaster.AjaxCallInventoryItemMaster();
        });

        $('#DeleteInventoryItemMasterRecord').on("click", function () {

            InventoryItemMaster.ActionName = "Delete";
            InventoryItemMaster.AjaxCallInventoryItemMaster();
        });
        $('#ItemFamily').on("keydown", function (e) {
            //AMSValidation.AllowCharacterOnly(e);            
            $("#ItemCategoryCode").val("")
            $("#UnitID").val("")
            $("#UnitID").attr("disabled", true);
            $("#ItemName").val("");
            $("#ItemCode").val("");
        });
        $('#PackingUnit').on("keydown", function (e) {
            //AMSValidation.AllowCharacterOnly(e);
            $("#ItemCategoryCode").val("")
            $("#UnitID").val("")
            $("#UnitID").attr("disabled", true);
            $("#ItemName").val("");
            $("#ItemCode").val("");
        });
        $('#PackingType').on("keydown", function (e) {
            //AMSValidation.AllowCharacterOnly(e);
            $("#ItemCategoryCode").val("")
            $("#UnitID").val("")
            $("#UnitID").attr("disabled", true);
            $("#ItemName").val("");
            $("#ItemCode").val("");
        });
        $('#ItemCode').on("keydown", function (e) {
            //AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#MinIndentLevel').on("keydown", function (e) {
              AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#RetailRate').on("keydown keypress", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);

            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }

            //  var aaa = $('#RetailRate').val();
            //  alert(aaa.length);
            //if (aaa.length >= 3)
            //    if (/\d*\.\d\d$/.test(aaa))
            //          return true;
            //      else {
            //          alert("Only two decimal places allowed");
            //          return false;
            //      }

        });

        $('#WholeSaleRate').on("keydown keypress", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#SpecialRate').on("keydown keypress", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#MaximumRetialPrice').on("keydown keypress", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#SaleRateFactorInPercentage').on("keydown keypress", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $('#RetailRateFactorInPercentage').on("keydown keypress", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersWithDecimalOnly(e);
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
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

        $("#ItemFamily").focusout(function () {
            var data = $("#ItemFamily").val();            
            InventoryItemMaster.FocusOut("ItemFamily", data);           
        });

        $("#PackingUnit").focusout(function () {
            var data = $("#PackingUnit").val();
            InventoryItemMaster.FocusOut("PackingUnit", data);
        });

        $("#PackingType").focusout(function () {
            var data = $("#PackingType").val();
            InventoryItemMaster.FocusOut("PackingType", data);
        });

        $("#MinIndentLevel").on("keypress", function (e) {
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 45 || inputKeyCode == 95) {
                return false;
            }
        });

        $(".ajax").colorbox();
    },

    //Check On Focus Out.
    FocusOut: function (actionOn, data) {        
        $.ajax({
             cache: false,
             type: "POST",
             dataType: "html",
             data: { "actionOn": actionOn, "data": data },
             url: '/InventoryItemMaster/CheckFocusOnAction',
             success: function (data) {
                 //Rebind Grid Data
                 if (actionOn == "ItemFamily")
                 {
                     $("#ItemFamilyMasterID").val(data);                     
                 }
                 else if(actionOn == "PackingUnit")
                 {
                     $("#ItemPackingUnitMasterID").val(data);                    
                 }
                 else if (actionOn == "PackingType") {
                     $("#ItemPackingTypeMasterID").val(data);                     
                 }
             }
        });        
    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax({
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/InventoryItemMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/InventoryItemMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                //$('#CreateInventoryItemMasterRecord').attr("disabled", false);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallInventoryItemMaster: function () {
        var InventoryItemMasterData = null;
        if (InventoryItemMaster.ActionName == "Create") {
            $("#FormCreateInventoryItemMaster").validate();
            if ($("#FormCreateInventoryItemMaster").valid()) {
                $('#CreateInventoryItemMasterRecord').attr("disabled", true);
                InventoryItemMasterData = null;
                InventoryItemMasterData = InventoryItemMaster.GetInventoryItemMaster();
                ajaxRequest.makeRequest("/InventoryItemMaster/Create", "POST", InventoryItemMasterData, InventoryItemMaster.Success);
            }
        }
        else if (InventoryItemMaster.ActionName == "Edit") {
            $("#FormEditInventoryItemMaster").validate();
            if ($("#FormEditInventoryItemMaster").valid()) {
                InventoryItemMasterData = null;
                InventoryItemMasterData = InventoryItemMaster.GetInventoryItemMaster();
                ajaxRequest.makeRequest("/InventoryItemMaster/Edit", "POST", InventoryItemMasterData, InventoryItemMaster.Success);
            }
        }
        else if (InventoryItemMaster.ActionName == "Delete") {
            InventoryItemMasterData = null;
            //$("#FormCreateInventoryItemMaster").validate();
            InventoryItemMasterData = InventoryItemMaster.GetInventoryItemMaster();
            ajaxRequest.makeRequest("/InventoryItemMaster/Delete", "POST", InventoryItemMasterData, InventoryItemMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryItemMaster: function () {        
        var Data = {
        };
        if (InventoryItemMaster.ActionName == "Create" || InventoryItemMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.ItemName = $('#ItemName').val();
            Data.ItemCode = $('#ItemCode').val();
            Data.ItemCategoryCode = $('#ItemCategoryCode').val();
            Data.UnitID = $('#UnitID').val();
            Data.RetailRate = $('#RetailRate').val();
            Data.WholeSaleRate = $('#WholeSaleRate').val();
            Data.SpecialRate = $('#SpecialRate').val();
            Data.MaximumRetialPrice = $('#MaximumRetialPrice').val();
            Data.CurrencyCode = $('#CurrencyCode').val();
            Data.GenTaxGroupMasterID = $('#GenTaxGroupMasterID').val();
            Data.IsSaleRateDependOnPuchase = $('input[name=IsSaleRateDependOnPuchase]:checked').val() ? true : false;
            if (Data.IsSaleRateDependOnPuchase == true) {
                Data.SaleRateFactorInPercentage = $('#SaleRateFactorInPercentage').val();
                Data.RetailRateFactorInPercentage = $('#RetailRateFactorInPercentage').val();
            }
            Data.ItemFamily = $('#ItemFamily').val();
            Data.PackingUnit = $('#PackingUnit').val();
            Data.PackingType = $('#PackingType').val();
            //alert($('input[name=IsExpiry]:checked').val());
            Data.IsExpiry = $('input[name=IsExpiry]:checked').val() ? true : false;
            Data.IsTaxInclusive = $('input[name=IsTaxInclusive]:checked').val() ? true : false;
            Data.ItemFamilyMasterID = $('#ItemFamilyMasterID').val();
            Data.ItemPackingUnitMasterID = $('#ItemPackingUnitMasterID').val();
            Data.ItemPackingTypeMasterID = $('#ItemPackingTypeMasterID').val();
            Data.MinIndentLevel = $('#MinIndentLevel').val();
        }
        else if (InventoryItemMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {       
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            InventoryItemMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
           
        }

    },

};

