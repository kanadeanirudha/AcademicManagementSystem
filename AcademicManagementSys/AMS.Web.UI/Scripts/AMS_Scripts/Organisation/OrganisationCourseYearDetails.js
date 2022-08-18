////this class contain methods related to nationality functionality
//var OrganisationCourseYearDetails = {
//    //Member variables
//    ActionName: null,
//    NumberOfSemester: null,
//    SelectedSemesterIDs: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationCourseYearDetails.constructor();
//        //generalCountryMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#SelectedCentreCode").change(function () {
//            var selectedItem = $(this).val();
//            var $ddlUniversity = $("#SelectedUniversityID");
//            var $UniversityProgress = $("#states-loading-progress");
//            $UniversityProgress.show();
//            if ($("#SelectedCentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/OrganisationCourseYearDetails/GetUniversityByCentreCode",

//                    data: { "SelectedCentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlUniversity.html('');
                      
//                        $ddlUniversity.append('<option value="">-------Select University------</option>');
//                        $.each(data, function (id, option) {

//                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $UniversityProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve University.');
//                        $UniversityProgress.hide();
//                    }
//                });
//            }
//            else {
//                $('#myDataTable tbody').empty();
//                $('#SelectedUniversityID').find('option').remove().end().append('<option value>--------Select University--------</option>');
//                $('#btnCreate').hide();
//            }
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });

//        $("#reset").click(function () {

//            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('#DegreeName').val("");
//            $('#Description').val("");
//            $('#CourseYearCode').val("");
//            $('#SectionCapacity').val("");
//            $('#Duration').val("");
          
//            $('#StreamID').focus();
            
//            $('#StreamID').val("");
//            $('#MediumID').val("");
//            $('#StandardID').val("");
//            $('#StreamID').val("");
//            $('#ExamApplicable').val("N");
//            $('input:checkbox,input:radio').removeAttr('checked');

//            return false;
//        });

       
//        if ($('input[name=ExamPattern]:checked').val() == 'Y') {
//            $("#checkboxlist").hide();
//            $("label[for=SemesterApplicable]").hide();
//        }
//        else {
//            $("#checkboxlist").show();
//            $("label[for=SemesterApplicable]").show();
//        }
        
        
//        $('input[name=ExamPattern]').on("change", function () {
//            if ($(this).val()=='Y') {
//                $("#checkboxlist").hide();
//                $("label[for=SemesterApplicable]").hide();
//            }
//            else {
//                $("#checkboxlist").show();
//                $("label[for=SemesterApplicable]").show();
//            }
//        });

//        $('#SelectedUniversityID').on("change", function () {

//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });

//        $("#btnShowList").on("click", function () {

//            var valuCentreCode = $('#SelectedCentreCode :selected').val();
//            var valuUniversityID = $('#SelectedUniversityID :selected').val();
//            if (valuCentreCode != "" && valuUniversityID > 0) {
//                OrganisationCourseYearDetails.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
//            }
//            else if (valuCentreCode != "" && valuUniversityID <= 0) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select university");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//            }
//            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//            }
//        });

        
       
//        $('#CourseYearCode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
//        $('#SectionCapacity').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#Duration').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#PresentIntake').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        // Create new record
//        $('#CreateOrganisationCourseYearDetailsRecord').on("click", function () {
//            OrganisationCourseYearDetails.ActionName = "Create";
//            // getValueUsingClass();
            
//            /* Get the checkboxes values based on the parent div id */
//            OrganisationCourseYearDetails.getValueUsingParentTag();
          
//            OrganisationCourseYearDetails.AjaxCallOrganisationCourseYearDetails();
//        });
      
//        $('#EditOrganisationCourseYearDetailsRecord').on("click", function () {
            
             
//            OrganisationCourseYearDetails.ActionName = "Edit";
            
//            if ($('input[name=ExamPattern]').val() == 'S') {
//                OrganisationCourseYearDetails.CountValueUsingParentTag();
//                OrganisationCourseYearDetails.getValueUsingParentTag_Check_UnCheck();
//            }
           
//            OrganisationCourseYearDetails.AjaxCallOrganisationCourseYearDetails();
//        });

//        $('#DeleteOrganisationCourseYearDetailsRecord').on("click", function () {

//            OrganisationCourseYearDetails.ActionName = "Delete";
//            OrganisationCourseYearDetails.AjaxCallOrganisationCourseYearDetails();
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();
        

//    },



//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/OrganisationCourseYearDetails/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message,colorCode,actionMode, UniversityID, CentreCode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { centerCode: CentreCode, universityID: UniversityID, actionMode: actionMode },
//            url: '/OrganisationCourseYearDetails/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },
//    //ReloadList method is used to load List page
//    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {
        
//        var selectedText = $('#SelectedUniversityID').text();
//        var selectedVal = $('#SelectedUniversityID').val();
//        $.ajax(
//          {
//              cache: false,
//              type: "POST",
//              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

//              dataType: "html",
//              url: '/OrganisationCourseYearDetails/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);

//              }
//          });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationCourseYearDetails: function () {
//        var OrganisationCourseYearDetailsData = null;
//        if (OrganisationCourseYearDetails.ActionName == "Create") {
//            $("#FormCreateOrganisationCourseYearDetails").validate();
//            if ($("#FormCreateOrganisationCourseYearDetails").valid()) {
//                OrganisationCourseYearDetailsData = null;
//                OrganisationCourseYearDetailsData = OrganisationCourseYearDetails.GetOrganisationCourseYearDetails();
            
//                ajaxRequest.makeRequest("/OrganisationCourseYearDetails/Create", "POST", OrganisationCourseYearDetailsData, OrganisationCourseYearDetails.Success);
//            }


//        }
//        else if (OrganisationCourseYearDetails.ActionName == "Edit") {
//            $("#FormEditOrganisationCourseYearDetails").validate();
//            if ($("#FormEditOrganisationCourseYearDetails").valid()) {
//                OrganisationCourseYearDetailsData = null;
             
//                OrganisationCourseYearDetailsData = OrganisationCourseYearDetails.GetOrganisationCourseYearDetails();
                
//                ajaxRequest.makeRequest("/OrganisationCourseYearDetails/Edit", "POST", OrganisationCourseYearDetailsData, OrganisationCourseYearDetails.Success);

//            }
//        }
//        else if (OrganisationCourseYearDetails.ActionName == "Delete") {
//            OrganisationCourseYearDetailsData = null;
//            //$("#FormCreateOrganisationCourseYearDetails").validate();
//            OrganisationCourseYearDetailsData = OrganisationCourseYearDetails.GetOrganisationCourseYearDetails();
//            ajaxRequest.makeRequest("/OrganisationCourseYearDetails/Delete", "POST", OrganisationCourseYearDetailsData, OrganisationCourseYearDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationCourseYearDetails: function () {
        
//        var Data = {
//        };
//        if (OrganisationCourseYearDetails.ActionName == "Create" || OrganisationCourseYearDetails.ActionName == "Edit") {
            
//            Data.ID = $('input[name=ID]').val();
            
//            Data.BranchID = $('#BranchID').val();
//            Data.StreamID = $('#StreamID').val();
//            Data.StandardID = $('#StandardID').val();
//            Data.MediumID = $('#MediumID').val();
//            Data.CourseYearCode = $('#CourseYearCode').val();
//            Data.DegreeName = $('#DegreeName').val();
//            Data.BranchActive = $('#BranchActive').val();
//            Data.Duration = $('#Duration').val();
//            // Data.NextCourseYearDetailID = $('#NextCourseYearDetailID').val();
//            //Data.ExamPattern = $('input[name=ExamPattern]:checked').val() ? true : false;
//            //$("#ExamPattern").change(function () {
//            //    var aa = $(this).val();
//            //    alert(aa);
//            //});
//            Data.CentreCode = $("#CentreCode").val();
//            Data.UniversityIDWithName = $("#SelectedUniversityID").val();
//            Data.ExamPattern = $('input[name=ExamPattern]:checked').val();    //"input[name='gender']:checked"
          
//            Data.SectionCapacity = $('#SectionCapacity').val();
//            Data.Description = $('#Description').val();
//            Data.ExamApplicable = $('#ExamApplicable').val();
           
//            Data.selectItemSemesterIDs = OrganisationCourseYearDetails.SelectedSemesterIDs;

//            if (OrganisationCourseYearDetails.ActionName == "Create") {

//            }
//            if (OrganisationCourseYearDetails.ActionName == "Edit") {

//                //Data.SelectedStreamID = $('#SelectedStreamID').val();
//                Data.NumberOfSemester = OrganisationCourseYearDetails.NumberOfSemester;
//                Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
//                Data.UniversityIdWithName = $('input[name=SelectedUniversityID]').val();

//            }
//        }
//        else if (OrganisationCourseYearDetails.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();

//        }
       
//      return Data;
//    },

//    CountValueUsingParentTag: function () {
//        var chkArray = [];
//        var SemesterArray = [];

//        /* look for all checkboes that have a parent id called 'checkboxlist' attached to it and check if it was checked */
//        $("#checkboxlist input:checked").each(function () {
//            chkArray.push($(this).val());
//        });

//        /* we join the array separated by the comma */
//        var selected;
//        selected = chkArray.join(',') + ",";
//        var count = chkArray.length;
//        /* check if there is selected checkboxes, by default the length is 1 as it contains one single comma */
//        OrganisationCourseYearDetails.NumberOfSemester = count;
       
//    },
//    getValueUsingParentTag: function () {
//        var chkArray = [];
//        var SemesterArray = [];
        
//        /* look for all checkboes that have a parent id called 'checkboxlist' attached to it and check if it was checked */
//        $("#checkboxlist input:checked").each(function () {
//            chkArray.push($(this).val());
//        });

//        /* we join the array separated by the comma */
//        var selected;
//        selected = chkArray.join(',') + ",";

//        /* check if there is selected checkboxes, by default the length is 1 as it contains one single comma */
//        OrganisationCourseYearDetails.NumberOfSemester = selected.length;
//        if (selected.length > 1) {
//            //alert("You have selected " + selected);
//            OrganisationCourseYearDetails.SelectedSemesterIDs = selected;

//        }
//    },
          

//    getValueUsingParentTag_Check_UnCheck: function () {
        
//        var sList = "";
//        var xmlParamList="<rows>"
//        $('#checkboxlist input[type=checkbox]').each(function () {
//            if ($(this).val() != "on") {
//                var sArray = [];
//                sArray = $(this).val().split("~");
//                if (this.checked==true && parseInt(sArray[2])==0)
//                     {
//                    //xmlInsert code here
//                    xmlParamList = xmlParamList + "<row>"  + "<ID>" + sArray[2] + "</ID>" + "<OrgSemesterMstID>" + sArray[0] + "</OrgSemesterMstID>" + "<SemesterActiveFlag>1</SemesterActiveFlag>" + "<SemesterType>" + sArray[1] + "</SemesterType>" + "</row>";
//                    }
//                else if (this.checked==false && parseInt(sArray[2])>0)  {
//                    //xmlUpdate code here
//                    xmlParamList=xmlParamList  + "<row>"  +  "<ID>" + sArray[2] + "</ID>" + "<OrgSemesterMstID>" +sArray[0] + "</OrgSemesterMstID>" +  "<SemesterActiveFlag>0</SemesterActiveFlag>" + "<SemesterType>" +sArray[1] + "</SemesterType>" + "</row>";

//                }
//            }
//            OrganisationCourseYearDetails.SelectedSemesterIDs = xmlParamList + "</rows>";
//        });
       
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var CentreCode = data.CentreCodeWithName;
//        var UniversityID = data.UniversityIDWithName;
//        var splitData = data.errorMessage.split(',');
       
//        OrganisationCourseYearDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
//        parent.$.colorbox.close();


//        //var splitdata = data.split("::");
//        //var dataSuccess = splitdata[0];
//        //var splitCentreCode = splitdata[1].split(":");
//        //var splitUniversityID = splitdata[2].split(":");
//        //parent.$.colorbox.close();

//        //if (dataSuccess == "True") {
//        //    // Reload List
//        //    OrganisationCourseYearDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
//        //} else {
//        //    $("#update-message").show();
//        //}
//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    OrganisationCourseYearDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
//    //},
//    //this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    // OrganisationCourseYearDetails.ReloadList("Record Deleted Sucessfully.");
//    //    OrganisationCourseYearDetails.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};

/////////////new js///////////////////////////////////////////////////////////////////

//this class contain methods related to nationality functionality
var OrganisationCourseYearDetails = {
    //Member variables
    ActionName: null,
    NumberOfSemester: null,
    SelectedSemesterIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationCourseYearDetails.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OrganisationCourseYearDetails/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');

                        $ddlUniversity.append('<option value="">-------Select University------</option>');
                        $.each(data, function (id, option) {

                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $UniversityProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $UniversityProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>--------Select University--------</option>');
                $('#btnCreate').hide();
            }
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $("#reset").click(function () {

            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('#DegreeName').val("");
            $('#Description').val("");
            $('#CourseYearCode').val("");
            $('#SectionCapacity').val("");
            $('#Duration').val("");

            $('#StreamID').focus();

            $('#StreamID').val("");
            $('#MediumID').val("");
            $('#StandardID').val("");
            $('#StreamID').val("");
            $('#ExamApplicable').val("N");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });


        if ($('input[name=ExamPattern]:checked').val() == 'Y') {
            $("#checkboxlist").hide();
            $("label[for=SemesterApplicable]").hide();
        }
        else {
            $("#checkboxlist").show();
            $("label[for=SemesterApplicable]").show();
        }


        $('input[name=ExamPattern]').on("change", function () {
            if ($(this).val() == 'Y') {
                $("#checkboxlist").hide();
                $("label[for=SemesterApplicable]").hide();
            }
            else {
                $("#checkboxlist").show();
                $("label[for=SemesterApplicable]").show();
            }
        });

        $('#SelectedUniversityID').on("change", function () {

            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $("#btnShowList").on("click", function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID :selected').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationCourseYearDetails.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }
            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }
        });



        $('#CourseYearCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });
        $('#SectionCapacity').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Duration').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PresentIntake').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        // Create new record
        $('#CreateOrganisationCourseYearDetailsRecord').on("click", function () {
            OrganisationCourseYearDetails.ActionName = "Create";
            // getValueUsingClass();

            /* Get the checkboxes values based on the parent div id */
            OrganisationCourseYearDetails.getValueUsingParentTag();

            OrganisationCourseYearDetails.AjaxCallOrganisationCourseYearDetails();
        });

        $('#EditOrganisationCourseYearDetailsRecord').on("click", function () {


            OrganisationCourseYearDetails.ActionName = "Edit";

            if ($('input[name=ExamPattern]').val() == 'S') {
                OrganisationCourseYearDetails.CountValueUsingParentTag();
                OrganisationCourseYearDetails.getValueUsingParentTag_Check_UnCheck();
            }

            OrganisationCourseYearDetails.AjaxCallOrganisationCourseYearDetails();
        });

        $('#DeleteOrganisationCourseYearDetailsRecord').on("click", function () {

            OrganisationCourseYearDetails.ActionName = "Delete";
            OrganisationCourseYearDetails.AjaxCallOrganisationCourseYearDetails();
        });

        $("#UserSearch").keyup(function () {
            //var oTable = $("#myDataTable").dataTable();
            //oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        InitAnimatedBorder();
        CloseAlert();


    },



    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/OrganisationCourseYearDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, UniversityID, CentreCode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { centerCode: CentreCode, universityID: UniversityID, actionMode: actionMode },
            url: '/OrganisationCourseYearDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

        var selectedText = $('#SelectedUniversityID').text();
        var selectedVal = $('#SelectedUniversityID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

              dataType: "html",
              url: '/OrganisationCourseYearDetails/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationCourseYearDetails: function () {
        var OrganisationCourseYearDetailsData = null;
        if (OrganisationCourseYearDetails.ActionName == "Create") {
            $("#FormCreateOrganisationCourseYearDetails").validate();
            if ($("#FormCreateOrganisationCourseYearDetails").valid()) {
                OrganisationCourseYearDetailsData = null;
                OrganisationCourseYearDetailsData = OrganisationCourseYearDetails.GetOrganisationCourseYearDetails();

                ajaxRequest.makeRequest("/OrganisationCourseYearDetails/Create", "POST", OrganisationCourseYearDetailsData, OrganisationCourseYearDetails.Success);
            }


        }
        else if (OrganisationCourseYearDetails.ActionName == "Edit") {
            $("#FormEditOrganisationCourseYearDetails").validate();
            if ($("#FormEditOrganisationCourseYearDetails").valid()) {
                OrganisationCourseYearDetailsData = null;

                OrganisationCourseYearDetailsData = OrganisationCourseYearDetails.GetOrganisationCourseYearDetails();

                ajaxRequest.makeRequest("/OrganisationCourseYearDetails/Edit", "POST", OrganisationCourseYearDetailsData, OrganisationCourseYearDetails.Success);

            }
        }
        else if (OrganisationCourseYearDetails.ActionName == "Delete") {
            OrganisationCourseYearDetailsData = null;
            //$("#FormCreateOrganisationCourseYearDetails").validate();
            OrganisationCourseYearDetailsData = OrganisationCourseYearDetails.GetOrganisationCourseYearDetails();
            ajaxRequest.makeRequest("/OrganisationCourseYearDetails/Delete", "POST", OrganisationCourseYearDetailsData, OrganisationCourseYearDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationCourseYearDetails: function () {

        var Data = {
        };
        if (OrganisationCourseYearDetails.ActionName == "Create" || OrganisationCourseYearDetails.ActionName == "Edit") {

            Data.ID = $('input[name=ID]').val();

            Data.BranchID = $('#BranchID').val();
            Data.StreamID = $('#StreamID').val();
            Data.StandardID = $('#StandardID').val();
            Data.MediumID = $('#MediumID').val();
            Data.CourseYearCode = $('#CourseYearCode').val();
            Data.DegreeName = $('#DegreeName').val();
            Data.BranchActive = $('#BranchActive').val();
            Data.Duration = $('#Duration').val();
            // Data.NextCourseYearDetailID = $('#NextCourseYearDetailID').val();
            //Data.ExamPattern = $('input[name=ExamPattern]:checked').val() ? true : false;
            //$("#ExamPattern").change(function () {
            //    var aa = $(this).val();
            //    alert(aa);
            //});
            Data.CentreCode = $("#CentreCode").val();
            Data.UniversityIDWithName = $("#SelectedUniversityID").val();
            Data.ExamPattern = $('input[name=ExamPattern]:checked').val();    //"input[name='gender']:checked"

            Data.SectionCapacity = $('#SectionCapacity').val();
            Data.Description = $('#Description').val();
            Data.ExamApplicable = $('#ExamApplicable').val();

            Data.selectItemSemesterIDs = OrganisationCourseYearDetails.SelectedSemesterIDs;

            if (OrganisationCourseYearDetails.ActionName == "Create") {

            }
            if (OrganisationCourseYearDetails.ActionName == "Edit") {

                //Data.SelectedStreamID = $('#SelectedStreamID').val();
                Data.NumberOfSemester = OrganisationCourseYearDetails.NumberOfSemester;
                Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
                Data.UniversityIdWithName = $('input[name=SelectedUniversityID]').val();

            }
        }
        else if (OrganisationCourseYearDetails.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();

        }

        return Data;
    },

    CountValueUsingParentTag: function () {
        var chkArray = [];
        var SemesterArray = [];

        /* look for all checkboes that have a parent id called 'checkboxlist' attached to it and check if it was checked */
        $("#checkboxlist input:checked").each(function () {
            chkArray.push($(this).val());
        });

        /* we join the array separated by the comma */
        var selected;
        selected = chkArray.join(',') + ",";
        var count = chkArray.length;
        /* check if there is selected checkboxes, by default the length is 1 as it contains one single comma */
        OrganisationCourseYearDetails.NumberOfSemester = count;

    },
    getValueUsingParentTag: function () {
        var chkArray = [];
        var SemesterArray = [];

        /* look for all checkboes that have a parent id called 'checkboxlist' attached to it and check if it was checked */
        //$("#checkboxlist input:checked").each(function () {
        $('#checkboxlist :checked').each(function () {
            chkArray.push($(this).val());
        });

        /* we join the array separated by the comma */
        var selected;
        selected = chkArray.join(',') + ",";

        /* check if there is selected checkboxes, by default the length is 1 as it contains one single comma */
        OrganisationCourseYearDetails.NumberOfSemester = selected.length;
        if (selected.length > 1) {
            //alert("You have selected " + selected);
            OrganisationCourseYearDetails.SelectedSemesterIDs = selected;

        }
    },


    getValueUsingParentTag_Check_UnCheck: function () {

        var sList = "";
        var xmlParamList = "<rows>"
        //$('#checkboxlist input[type=checkbox]').each(function () {
        $('#checkboxlist option').each(function () {
            //alert("out");
            if ($(this).val() != "on") {
                var sArray = [];
                sArray = $(this).val().split("~");
                //alert(sArray);
                if (this.selected == true && parseInt(sArray[2]) == 0) {
                    //alert('in ==0');
                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[2] + "</ID>" + "<OrgSemesterMstID>" + sArray[0] + "</OrgSemesterMstID>" + "<SemesterActiveFlag>1</SemesterActiveFlag>" + "<SemesterType>" + sArray[1] + "</SemesterType>" + "</row>";
                }
                else if (this.selected == false && parseInt(sArray[2]) > 0) {
                    //alert('in >0');
                    //xmlUpdate code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[2] + "</ID>" + "<OrgSemesterMstID>" + sArray[0] + "</OrgSemesterMstID>" + "<SemesterActiveFlag>0</SemesterActiveFlag>" + "<SemesterType>" + sArray[1] + "</SemesterType>" + "</row>";

                }
            }
            OrganisationCourseYearDetails.SelectedSemesterIDs = xmlParamList + "</rows>";
        });

    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var CentreCode = data.CentreCodeWithName;
        var UniversityID = data.UniversityIDWithName;
        var splitData = data.errorMessage.split(',');

        OrganisationCourseYearDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
        $.magnificPopup.close();


        
    },
    
};

