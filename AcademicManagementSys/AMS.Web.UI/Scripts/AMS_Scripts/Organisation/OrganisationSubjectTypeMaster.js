var OrganisationSubjectTypeMaster = {
    variable: null,
    StatusFlag: null,
    Initialize: function () {
        OrganisationSubjectTypeMaster.constructor();
    },
    constructor: function () {

        $('#CreateOrganisationSubjectTypeMasterRecord').on("click", function () {    
            OrganisationSubjectTypeMaster.ActionName = "Create";
            OrganisationSubjectTypeMaster.AjaxCallOrganisationSubjectTypeMaster();
        });
        $('#EditOrganisationSubjectTypeMasterRecord').on("click", function () {
            OrganisationSubjectTypeMaster.ActionName = "Edit";
            OrganisationSubjectTypeMaster.AjaxCallOrganisationSubjectTypeMaster();
        });
        $('#DeleteOrganisationSubjectTypeMasterRecord').on("click", function () {
            OrganisationSubjectTypeMaster.ActionName = "Delete";
            OrganisationSubjectTypeMaster.AjaxCallOrganisationSubjectTypeMaster();
        });
        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
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

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#TypeName').focus();
            
        });

        $('#TypeName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
    },
    LoadList: function () {
        
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/OrganisationSubjectTypeMaster/List',
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
           data: { "actionMode": actionMode },
           dataType: "html",
           url: '/OrganisationSubjectTypeMaster/List',
           success: function (data) {
               //Rebind Grid Data
               $("#ListViewModel").empty().append(data);
               //twitter type notification
               //$('#SuccessMessage').html(message);
               //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
               notify(message,colorCode);
           }
       });
    },

    AjaxCallOrganisationSubjectTypeMaster: function () {
        var OrganisationSubjectTypeMasterMasterData = null;
        if (OrganisationSubjectTypeMaster.ActionName == "Create") {
            $("#FormCreateOrganisationSubjectTypeMaster").validate();
            if ($("#FormCreateOrganisationSubjectTypeMaster").valid()) {

                OrganisationSubjectTypeMasterMasterData = OrganisationSubjectTypeMaster.GetOrganisationSubjectTypeMasterMaster();
                ajaxRequest.makeRequest("/OrganisationSubjectTypeMaster/Create", "POST", OrganisationSubjectTypeMasterMasterData, OrganisationSubjectTypeMaster.Success);
            }
        }
        else if (OrganisationSubjectTypeMaster.ActionName == "Edit") {
            $("#FormEditOrganisationSubjectTypeMasterMaster").validate();
            if ($("#FormEditOrganisationSubjectTypeMasterMaster").valid()) {

                OrganisationSubjectTypeMasterMasterData = OrganisationSubjectTypeMaster.GetOrganisationSubjectTypeMasterMaster();
                ajaxRequest.makeRequest("/OrganisationSubjectTypeMaster/Edit", "POST", OrganisationSubjectTypeMasterMasterData, OrganisationSubjectTypeMaster.Success);
            }
        }
        else if (OrganisationSubjectTypeMaster.ActionName == "Delete") {

            OrganisationSubjectTypeMasterMasterData = OrganisationSubjectTypeMaster.GetOrganisationSubjectTypeMasterMaster();
            ajaxRequest.makeRequest("/OrganisationSubjectTypeMaster/Delete", "POST", OrganisationSubjectTypeMasterMasterData, OrganisationSubjectTypeMaster.Success);
        }
    },

    GetOrganisationSubjectTypeMasterMaster: function () {
        var Data = {
        };
        if (OrganisationSubjectTypeMaster.ActionName == "Create" || OrganisationSubjectTypeMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.TypeName = $('#TypeName').val();
            Data.TypeShortCode = $('#TypeShortCode').val();
        }
        else if (OrganisationSubjectTypeMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            $.magnificPopup.close();
            OrganisationSubjectTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            OrganisationSubjectTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List
        
    //    OrganisationSubjectTypeMaster.ReloadList("Record Updated Sucessfully.");
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List
    //    OrganisationSubjectTypeMaster.ReloadList("Record Deleted Sucessfully.");
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
};


