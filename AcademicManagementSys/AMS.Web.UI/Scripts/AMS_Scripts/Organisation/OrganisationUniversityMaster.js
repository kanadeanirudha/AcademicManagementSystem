//var OrganisationUniversityMaster = {
//    ActionName: null,
//    Initialize: function () {
      
//        OrganisationUniversityMaster.constructor();
       
//    },
//    constructor: function (e) {
//        $('#UniversityFoundationDatetime').datepicker({
//            dateFormat: 'd-M-yy'
//        });

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#UniversityName').focus();
//            $('#CityID').val('');
//        });
        
//        $('#CreateOrganisationUniversityMasterRecord').on("click", function () {
//            OrganisationUniversityMaster.ActionName = "Create";
//            OrganisationUniversityMaster.AjaxCallOrganisationUniversityMaster();
//        });

//        $('#EditOrganisationUniversityMasterRecord').on("click", function () {
//            OrganisationUniversityMaster.ActionName = "Edit";
//            OrganisationUniversityMaster.AjaxCallOrganisationUniversityMaster();
//        });

//        $('#DeleteOrganisationUniversityMasterRecord').on("click", function () {
//            OrganisationUniversityMaster.ActionName = "Delete";
//            OrganisationUniversityMaster.AjaxCallOrganisationUniversityMaster();
//        });

//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });

//        $("#UserSearch").on("keyup", function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").on("click", function () {
//            $("#UserSearch").focus();
//        });

//        $("#showrecord").on("change", function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $('#Pincode').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

//        $('#Pincode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
//        $('#CellPhone').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#CellPhone').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });


//        $('#UniversityName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $("#UniversityFounderMember").on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        }); 

//        $('#FaxNumber').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#FaxNumber').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#StreetNumber').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#StreetNumber').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
//        $('#Extention').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        }); 
//        $('#Extention').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#EmailID').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
//        $('#Url').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
//    },
//    LoadList: function () {
        
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",
//             dataType: "html",
//             url: '/OrganisationUniversityMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    ReloadList: function (message, colorCode,actionMode) {
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: actionMode },
//            url: '/OrganisationUniversityMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message)
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },

//    AjaxCallOrganisationUniversityMaster: function () {
//        var OrganisationUniversityMasterData = null;
//        if (OrganisationUniversityMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationUniversityMaster").validate();
//            if ($("#FormCreateOrganisationUniversityMaster").valid()) {
//                OrganisationUniversityMasterData = null;
//                OrganisationUniversityMasterData = OrganisationUniversityMaster.GetOrganisationUniversityMaster();
//                ajaxRequest.makeRequest("/OrganisationUniversityMaster/Create", "POST", OrganisationUniversityMasterData, OrganisationUniversityMaster.Success);
//            }
//        }
//        else if (OrganisationUniversityMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationUniversityMaster").validate();
//            if ($("#FormEditOrganisationUniversityMaster").valid()) {
//                OrganisationUniversityMasterData = null;
//                OrganisationUniversityMasterData = OrganisationUniversityMaster.GetOrganisationUniversityMaster();
//                ajaxRequest.makeRequest("/OrganisationUniversityMaster/Edit", "POST", OrganisationUniversityMasterData, OrganisationUniversityMaster.Success);
//            }
//        }
//        else if (OrganisationUniversityMaster.ActionName == "Delete") {
//            OrganisationUniversityMasterData = null;
//            //$("#FormCreateOrganisationUniversityMaster").validate();
//            OrganisationUniversityMasterData = OrganisationUniversityMaster.GetOrganisationUniversityMaster();
//            ajaxRequest.makeRequest("/OrganisationUniversityMaster/Delete", "POST", OrganisationUniversityMasterData, OrganisationUniversityMaster.Success);

//        }
//    },




//    GetOrganisationUniversityMaster: function () {
//        var Data = {
//        };
//        if (OrganisationUniversityMaster.ActionName == "Create" || OrganisationUniversityMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.CityID = $('#CityID').val();
//            Data.SelectedCityID = $('#SelectedCityID').val();
//            Data.UniversityName = $('#UniversityName').val();
//            Data.UniversityFoundationDatetime = $('#UniversityFoundationDatetime').val();
//            Data.UniversityFounderMember = $('#UniversityFounderMember').val();
//            Data.UniversityAddress1 = $('#UniversityAddress1').val();
//            Data.UniversityAddress2 = $('#UniversityAddress2').val();
//            Data.PlotNumber = $('#PlotNumber').val();
//            Data.StreetNumber = $('#StreetNumber').val();
//            Data.Pincode = $('#Pincode').val();
//            Data.FaxNumber = $('#FaxNumber').val();
//            Data.PhoneNumberOffice = $('#PhoneNumberOffice').val();
//            Data.Extention = $('#Extention').val();
//            Data.CellPhone = $('#CellPhone').val();
//            Data.EmailID = $('#EmailID').val();
//            Data.Url = $('#Url').val();
//            Data.OfficeComment = $('#OfficeComment').val();
//            Data.MissionStatement = $('#MissionStatement').val();
//            Data.UniversityReportPath = $('#UniversityReportPath').val();
//            Data.UniversityShortName = $('#UniversityShortName').val();
//            Data.DefaultFlag = $('input[id=DefaultFlag]:checked').val();
//            Data.EstablishmentCode = $('#EstablishmentCode').val();
//            //Data.CreatedBy = $('#CreatedBy').val();
//        }
//        else if (OrganisationUniversityMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationUniversityMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationUniversityMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //editSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    var actionMode = "1";
//    //    OrganisationUniversityMaster.ReloadList("Record Updated Sucessfully.", actionMode);
//    //},
//    //deleteSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    OrganisationUniversityMaster.ReloadList("Record Deleted Sucessfully.");
//    //},
//};


////////new code///////////////


var OrganisationUniversityMaster = {
    ActionName: null,
    Initialize: function () {

        OrganisationUniversityMaster.constructor();

    },
    constructor: function (e) {
        //$('#UniversityFoundationDatetime').datepicker({
        //    dateFormat: 'd-M-yy'
        //});

        $('#UniversityFoundationDatetime').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#UniversityName').focus();
            $('#CityID').val('');
        });

        $('#CreateOrganisationUniversityMasterRecord').on("click", function () {
            OrganisationUniversityMaster.ActionName = "Create";
            OrganisationUniversityMaster.AjaxCallOrganisationUniversityMaster();
        });

        $('#EditOrganisationUniversityMasterRecord').on("click", function () {
            OrganisationUniversityMaster.ActionName = "Edit";
            OrganisationUniversityMaster.AjaxCallOrganisationUniversityMaster();
        });

        $('#DeleteOrganisationUniversityMasterRecord').on("click", function () {
            OrganisationUniversityMaster.ActionName = "Delete";
            OrganisationUniversityMaster.AjaxCallOrganisationUniversityMaster();
        });

        $('#closeBtn').on("click", function () {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#Pincode').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#Pincode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });
        $('#CellPhone').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#CellPhone').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });


        $('#UniversityName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $("#UniversityFounderMember").on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#FaxNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#FaxNumber').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#StreetNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#StreetNumber').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });
        $('#Extention').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Extention').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#EmailID').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });
        $('#Url').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });
    },
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OrganisationUniversityMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/OrganisationUniversityMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message)
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },

    AjaxCallOrganisationUniversityMaster: function () {
        var OrganisationUniversityMasterData = null;
        if (OrganisationUniversityMaster.ActionName == "Create") {
            $("#FormCreateOrganisationUniversityMaster").validate();
            if ($("#FormCreateOrganisationUniversityMaster").valid()) {
                OrganisationUniversityMasterData = null;
                OrganisationUniversityMasterData = OrganisationUniversityMaster.GetOrganisationUniversityMaster();
                ajaxRequest.makeRequest("/OrganisationUniversityMaster/Create", "POST", OrganisationUniversityMasterData, OrganisationUniversityMaster.Success);
            }
        }
        else if (OrganisationUniversityMaster.ActionName == "Edit") {
            $("#FormEditOrganisationUniversityMaster").validate();
            if ($("#FormEditOrganisationUniversityMaster").valid()) {
                OrganisationUniversityMasterData = null;
                OrganisationUniversityMasterData = OrganisationUniversityMaster.GetOrganisationUniversityMaster();
                ajaxRequest.makeRequest("/OrganisationUniversityMaster/Edit", "POST", OrganisationUniversityMasterData, OrganisationUniversityMaster.Success);
            }
        }
        else if (OrganisationUniversityMaster.ActionName == "Delete") {
            OrganisationUniversityMasterData = null;
            //$("#FormCreateOrganisationUniversityMaster").validate();
            OrganisationUniversityMasterData = OrganisationUniversityMaster.GetOrganisationUniversityMaster();
            ajaxRequest.makeRequest("/OrganisationUniversityMaster/Delete", "POST", OrganisationUniversityMasterData, OrganisationUniversityMaster.Success);

        }
    },




    GetOrganisationUniversityMaster: function () {
        var Data = {
        };
        if (OrganisationUniversityMaster.ActionName == "Create" || OrganisationUniversityMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CityID = $('#CityID').val();
            Data.SelectedCityID = $('#SelectedCityID').val();
            Data.UniversityName = $('#UniversityName').val();
            Data.UniversityFoundationDatetime = $('#UniversityFoundationDatetime').val();
            Data.UniversityFounderMember = $('#UniversityFounderMember').val();
            Data.UniversityAddress1 = $('#UniversityAddress1').val();
            Data.UniversityAddress2 = $('#UniversityAddress2').val();
            Data.PlotNumber = $('#PlotNumber').val();
            Data.StreetNumber = $('#StreetNumber').val();
            Data.Pincode = $('#Pincode').val();
            Data.FaxNumber = $('#FaxNumber').val();
            Data.PhoneNumberOffice = $('#PhoneNumberOffice').val();
            Data.Extention = $('#Extention').val();
            Data.CellPhone = $('#CellPhone').val();
            Data.EmailID = $('#EmailID').val();
            Data.Url = $('#Url').val();
            Data.OfficeComment = $('#OfficeComment').val();
            Data.MissionStatement = $('#MissionStatement').val();
            Data.UniversityReportPath = $('#UniversityReportPath').val();
            Data.UniversityShortName = $('#UniversityShortName').val();
            Data.DefaultFlag = $('input[id=DefaultFlag]:checked').val();
            Data.EstablishmentCode = $('#EstablishmentCode').val();
            //Data.CreatedBy = $('#CreatedBy').val();
        }
        else if (OrganisationUniversityMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationUniversityMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationUniversityMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};



