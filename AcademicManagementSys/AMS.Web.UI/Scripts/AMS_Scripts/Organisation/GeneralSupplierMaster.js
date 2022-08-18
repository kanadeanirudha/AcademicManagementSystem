//this class contain methods related to nationality functionality
var GeneralSupplierMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        GeneralSupplierMaster.attachEvents();
    },
    //Attach all event of page
    attachEvents: function () {

        //Reset button click event function to reset all controls of form

        $('#CreateGeneralSupplierMasterRecord').on("click", function () {
            
            GeneralSupplierMaster.ActionName = "Create";
            GeneralSupplierMaster.AjaxCallGeneralSupplierMaster();
        });

        $('#EditGeneralSupplierMasterRecord').on("click", function () {
            
            GeneralSupplierMaster.ActionName = "Edit";
            GeneralSupplierMaster.AjaxCallGeneralSupplierMaster();
        });

        $('#DeleteGeneralSupplierMasterRecord').on("click", function () {
            
            GeneralSupplierMaster.ActionName = "Delete";
            GeneralSupplierMaster.AjaxCallGeneralSupplierMaster();
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

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
            return false;
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {
        
        $.ajax(
         {
             cache: false,
             type: "GET",
             dataType: "html",
             url: '/GeneralSupplierMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/GeneralSupplierMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#commonMessage').html(message);
                $('#commonMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', '#5C8AE6');
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallGeneralSupplierMaster: function () {
        var GeneralSupplierMasterData = null;
        if (GeneralSupplierMaster.ActionName == "Create") {
            $("#FormCreateGeneralSupplierMaster").validate();
            if ($("#FormCreateGeneralSupplierMaster").valid()) {
                GeneralSupplierMasterData = null;
                GeneralSupplierMasterData = GeneralSupplierMaster.GetGeneralSupplierMaster();
                ajaxRequest.makeRequest("/GeneralSupplierMaster/Create", "POST", GeneralSupplierMasterData, GeneralSupplierMaster.createSuccess);
            }
        }
        else if (GeneralSupplierMaster.ActionName == "Edit") {
            $("#FormEditGeneralSupplierMaster").validate();
            if ($("#FormEditGeneralSupplierMaster").valid()) {
                GeneralSupplierMasterData = null;
                GeneralSupplierMasterData = GeneralSupplierMaster.GetGeneralSupplierMaster();
                ajaxRequest.makeRequest("/GeneralSupplierMaster/Edit", "POST", GeneralSupplierMasterData, GeneralSupplierMaster.editSuccess);
            }
        }
        else if (GeneralSupplierMaster.ActionName == "Delete") {
            GeneralSupplierMasterData = null;
            GeneralSupplierMasterData = GeneralSupplierMaster.GetGeneralSupplierMaster();
            ajaxRequest.makeRequest("/GeneralSupplierMaster/Delete", "POST", GeneralSupplierMasterData, GeneralSupplierMaster.deleteSuccess);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralSupplierMaster: function () {
        var Data = {
        };
        if (GeneralSupplierMaster.ActionName == "Create" || GeneralSupplierMaster.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.Vender = $('input[name=Vender]').val();
            Data.FirstName = $('input[name=FirstName]').val();
            Data.MiddleName = $('input[name=MiddleName]').val();
            Data.LastName = $('input[name=LastName]').val();
            Data.Sex = $('input[name=Sex]:checked').val();
            Data.AddressFirst = $('input[name=AddressFirst]').val();
            Data.AddressSecond = $('input[name=AddressSecond]').val();
            Data.PlotNumber = $('input[name=PlotNumber]').val();
            Data.StreetNumber = $('input[name=StreetNumber]').val();
            Data.TahsilID = $('input[name=TahsilID]').val();
            Data.PinCode = $('input[name=PinCode]').val();
            Data.PhoneNumber = $('input[name=PhoneNumber]').val();
            Data.ResiPhoneNumber = $('input[name=ResiPhoneNumber]').val();
            Data.CellPhoneNumber = $('input[name=CellPhoneNumber]').val();
            Data.FaxNumber = $('input[name=FaxNumber]').val();
            Data.Email = $('input[name=Email]').val();
            Data.WebUrl = $('input[name=WebUrl]').val();
            Data.VenderDescription = $('input[name=VenderDescription]').val();
            Data.CategoryId = $('input[name=CategoryId]').val();
            Data.VAT = $('input[name=VAT]').val();
            Data.CST = $('input[name=CST]').val();
            Data.Excise = $('input[name=Excise]').val();
            Data.StablishmentNumber = $('input[name=StablishmentNumber]').val();
            Data.RefNumber = $('input[name=RefNumber]').val();
            Data.IsActive = $('input[name=IsActive]').val();
        }
        else if (GeneralSupplierMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
        parent.$.colorbox.close();
        if (data == "True") {
            GeneralSupplierMaster.ReloadList("Record Created Sucessfully.");
        }
    },
    //this is used to for showing successfully record updation message and reload the list view
    editSuccess: function (data) {
        parent.$.colorbox.close();
        if (data == "True") {
            GeneralSupplierMaster.ReloadList("Record Updated Sucessfully.");
        }
    },
    //this is used to for showing successfully record deletion message and reload the list view
    deleteSuccess: function (data) {
        parent.$.colorbox.close();
        if (data == "True") {
            GeneralSupplierMaster.ReloadList("Record Deleted Sucessfully.");
        }
    },
};