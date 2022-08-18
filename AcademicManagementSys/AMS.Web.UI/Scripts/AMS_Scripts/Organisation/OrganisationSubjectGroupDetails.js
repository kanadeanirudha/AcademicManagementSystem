////this class contain methods related to nationality functionality
//var OrganisationSubjectGroupDetails = {
//    //Member variables
//    ActionName: null,
//    SubjectGrpCombinationIDs: null,
//    SubHoursGrpAllocationIDs: null,
//    SubjectGrpMarksIDs: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationSubjectGroupDetails.constructor();
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
//                    url: "/OrganisationSubjectGroupDetails/GetUniversityByCentreCode",

//                    data: { "SelectedCentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlUniversity.html('');
//                        $ddlUniversity.append('<option value="">--------Select University-------</option>');
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
//                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---------Select University---------</option>');
//                $('#btnCreate').hide();
//            }
//            $('#DivCreateNew').hide(true);
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });
//        $('#SelectedUniversityID').on("change", function () {
//            $('#DivCreateNew').hide(true);
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });
//        $("#OrgElectiveGrpID").change(function () {
//            var selectedItem = $(this).val();
//            var $ddlSubElectiveGrpID = $("#OrgSubElectiveGrpID");

//            if ($("#OrgElectiveGrpID").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/OrganisationSubjectGroupDetails/GetSubElectiveGroupByElectiveGrpID",

//                    data: { "OrgElectiveGrpID": selectedItem },
//                    success: function (data) {
//                        $ddlSubElectiveGrpID.html('');
//                        $ddlSubElectiveGrpID.append('<option value="">--Select Sub Elective Group--</option>');
//                        $.each(data, function (id, option) {

//                            $ddlSubElectiveGrpID.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $ddlSubElectiveGrpProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve University.');
//                        $ddlSubElectiveGrpProgress.hide();
//                    }
//                });
//            }
//            else {
//                $('#myDataTable tbody').empty();
//                $('#OrgSubElectiveGrpID').find('option').remove().end().append('<option value>--Sub Elective Group--</option>');
//                $('#btnCreate').hide();
//            }
//        });

//        if ($().val == true) {

//            $('#divoptional').hide(true);
//            $('#divoptional1').hide(true);
//        }

//        $('#IsActive').prop('checked', true);
//        //$('#IsActive').prop('disabled', true);
//        // For Show hide div Optional
//        if ($('input[name=ID]').val() == 0) {
//            $('#IsCompulsory').prop('checked', true);
//        }
//        //if ($('input[name=ID]').val() > 0) {
//        //    $('#IsCompulsory').prop('checked', false);
//        //}
//        var IsCompulsory = $('input[name=IsCompulsory]:checked').val() ? true : false;
//        if (IsCompulsory == true) {

//            $('#divoptional').hide(true);
//            $('#divoptional1').hide(true);
//        }
//        if (IsCompulsory == false) {

//            $('#divoptional').show(true);
//            $('#divoptional1').show(true);
//        }
//        $('#IsCompulsory').change(function () {
//            if (this.checked) {
//                $('#divoptional').fadeOut('slow');
//                $('#divoptional1').fadeOut('slow');
              

//            }
//            else {
//                $('#divoptional').fadeIn('slow');
//                $('#divoptional1').fadeIn('slow');
//                $('#OrgElectiveGrpID').val('');
//                $('#OrgSubElectiveGrpID').val('');
//            }

//        });

//        // For Active/ Inactive Row
//        $('.abc').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $this.closest("tr").find(":input.form-control_Internal_Row").attr("disabled", false);
//                $this.closest("tr").find(":input.form-control_External_Row").attr("disabled", false);
//                $this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", false);
//                $this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", false);

//            } else {
//                $this.closest("tr").find(":input.form-control_Internal_Row").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_External_Row").attr("disabled", true);

//                $this.closest("tr").find(":input.form-control_Internal_Row").attr("checked", false);
//                $this.closest("tr").find(":input.form-control_External_Row").attr("checked", false);

//                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").val(0);

//                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").val(0);


//                $this.closest("tr").find(":input.form-control_External_Passing_Marks").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_External_Passing_Marks").val(0);

//                $this.closest("tr").find(":input.form-control_External_Max_Marks").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_External_Max_Marks").val(0);

//                $this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").val(0);
//                $this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_ExamHours").val(0);

//                $this.closest("tr").find(":input.form-control_External_Group_Max_Marks").val(0);
//                $this.closest("tr").find(":input.form-control_External_Group_Min_Marks").val(0);


//            }
//            $this.attr("disabled", false);
//        });

//        // For Active/Inactive TextBox of Internal Checkbox
//        $('.form-control_Internal_Row').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").attr("disabled", false);
//                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").attr("disabled", false);
//                //$this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", false);
//                //$this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", false);

//                $('.form-control_Internal_Max_Marks').on("keydown", function (e) {
//                    AMSValidation.AllowNumbersOnly(e);
//                });

//                $('.form-control_Internal_Passing_Marks').on("keydown", function (e) {
//                    AMSValidation.AllowNumbersOnly(e);
//                });

//                $('.form-control_WeeklyPeriodAllocation').on("keydown", function (e) {
//                    AMSValidation.AllowNumbersOnly(e);
//                });


//            } else {
//                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").val(0);

//                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").val(0);

//                //$this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", true);
//                //$this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", true);


//                var $this = $(this);
//                var rowId = $this.closest("tr").attr("id");
//                // alert(rowId); //return false;
//                var Internal_Max_Marks = parseInt($("#Internal_Max_Marks_" + rowId).val());
//                var External_Max_Marks = parseInt($("#External_Max_Marks_" + rowId).val());
//                var External_Group_Max_Marks = parseInt(Internal_Max_Marks + External_Max_Marks);
//                if ($.isNumeric(External_Group_Max_Marks)) {
//                    $("#External_Group_Max_Marks_" + rowId).val(parseInt(External_Group_Max_Marks));
//                }



//                var Internal_Passing_Marks = parseInt($("#Internal_Passing_Marks_" + rowId).val());
//                var External_Passing_Marks = parseInt($("#External_Passing_Marks_" + rowId).val());
//                var External_Group_Min_Marks = parseInt(Internal_Passing_Marks + External_Passing_Marks);
//                if ($.isNumeric(External_Group_Min_Marks)) {
//                    $("#External_Group_Min_Marks_" + rowId).val(parseInt(External_Group_Min_Marks));
//                }
//            }
//            $this.attr("disabled", false);
//        });

//        // For Active/Inactive TextBox of External Checkbox
//        $('.form-control_External_Row').click(function (event) {
//            var $this = $(this);
//            if ($this.is(":checked")) {
//                $this.closest("tr").find(":input.form-control_External_Passing_Marks").attr("disabled", false);
//                $this.closest("tr").find(":input.form-control_External_Max_Marks").attr("disabled", false);
//                $this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", false);
//                $this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", false);

//                $('.form-control_External_Passing_Marks').on("keydown", function (e) {
//                    AMSValidation.AllowNumbersOnly(e);
//                });

//                $('.form-control_External_Max_Marks').on("keydown", function (e) {
//                    AMSValidation.AllowNumbersOnly(e);
//                });

//                $('.form-control_WeeklyPeriodAllocation').on("keydown", function (e) {
//                    AMSValidation.AllowNumbersOnly(e);
//                });

//            } else {
//                $this.closest("tr").find(":input.form-control_External_Passing_Marks").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_External_Passing_Marks").val(0);
//                $this.closest("tr").find(":input.form-control_External_Max_Marks").attr("disabled", true);
//                $this.closest("tr").find(":input.form-control_External_Max_Marks").val(0);
//                //$this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", true);
//                //$this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", true);



//                var $this = $(this);
//                var rowId = $this.closest("tr").attr("id");

//                var Internal_Max_Marks = parseInt($("#Internal_Max_Marks_" + rowId).val());
//                var External_Max_Marks = parseInt($("#External_Max_Marks_" + rowId).val());
//                var External_Group_Max_Marks = parseInt(Internal_Max_Marks + External_Max_Marks);
//                if ($.isNumeric(External_Group_Max_Marks)) {
//                    $("#External_Group_Max_Marks_" + rowId).val(parseInt(External_Group_Max_Marks));
//                }


//                var Internal_Passing_Marks = parseInt($("#Internal_Passing_Marks_" + rowId).val());
//                var External_Passing_Marks = parseInt($("#External_Passing_Marks_" + rowId).val());
//                var External_Group_Min_Marks = parseInt(Internal_Passing_Marks + External_Passing_Marks);
//                if ($.isNumeric(External_Group_Min_Marks)) {
//                    $("#External_Group_Min_Marks_" + rowId).val(parseInt(External_Group_Min_Marks));
//                }
//            }
//            $this.attr("disabled", false);
//        });


//        // For calculate Max Group Mark on click event
//        $('.form-control_Internal_Max_Marks').change(function (event) {

//            var $this = $(this);
//            var rowId = $this.closest("tr").attr("id");
//            // alert(rowId); //return false;
//            var Internal_Max_Marks = parseInt($("#Internal_Max_Marks_" + rowId).val());
//            var External_Max_Marks = parseInt($("#External_Max_Marks_" + rowId).val());
//            var External_Group_Max_Marks = parseInt(Internal_Max_Marks + External_Max_Marks);
//            if ($.isNumeric(External_Group_Max_Marks)) {
//                $("#External_Group_Max_Marks_" + rowId).val(parseInt(External_Group_Max_Marks));
//            }
//        });


//        // For calculate Max Group Mark on click event
//        $('.form-control_External_Max_Marks').change(function (event) {

//            var $this = $(this);
//            var rowId = $this.closest("tr").attr("id");
//            // alert(rowId); //return false;
//            var Internal_Max_Marks = parseInt($("#Internal_Max_Marks_" + rowId).val());
//            var External_Max_Marks = parseInt($("#External_Max_Marks_" + rowId).val());
//            var External_Group_Max_Marks = parseInt(Internal_Max_Marks + External_Max_Marks);
//            if ($.isNumeric(External_Group_Max_Marks)) {
//                $("#External_Group_Max_Marks_" + rowId).val(parseInt(External_Group_Max_Marks));
//            }

//        });
//        // For calculate Min Group Mark on click event
//        $('.form-control_Internal_Passing_Marks').change(function (event) {

//            var $this = $(this);
//            var rowId = $this.closest("tr").attr("id");
//            var Internal_Passing_Marks = parseInt($("#Internal_Passing_Marks_" + rowId).val());
//            var External_Passing_Marks = parseInt($("#External_Passing_Marks_" + rowId).val());
//            var External_Group_Min_Marks = parseInt(Internal_Passing_Marks + External_Passing_Marks);
//            if ($.isNumeric(External_Group_Min_Marks)) {
//                $("#External_Group_Min_Marks_" + rowId).val(parseInt(External_Group_Min_Marks));
//            }
//        });
//        // For calculate Min Group Mark on click event
//        $('.form-control_External_Passing_Marks').change(function (event) {

//            var $this = $(this);
//            var rowId = $this.closest("tr").attr("id");
//            var Internal_Passing_Marks = parseInt($("#Internal_Passing_Marks_" + rowId).val());
//            var External_Passing_Marks = parseInt($("#External_Passing_Marks_" + rowId).val());
//            var External_Group_Min_Marks = parseInt(Internal_Passing_Marks + External_Passing_Marks);
//            if ($.isNumeric(External_Group_Min_Marks)) {
//                $("#External_Group_Min_Marks_" + rowId).val(parseInt(External_Group_Min_Marks));
//            }
//        });

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#SubjectID').focus();
//            var dt = new Date();
//            $('#SubjectID').val("");
//            $('#CreateOrganisationSubjectGroupDetailsRecord').val("Submit");
//            $('#reset').val("Reset");
//            $('#IsCompulsory').prop('checked', true);
//            $('#divoptional').fadeOut('slow');
//            $('#IsCompulsory').prop('checked', true);

//            return false;
//        });


//        //$('#example tbody').on('click', 'tr', function () {
//        //    $(this).toggleClass('selected');
//        //});

//        $('#btnShowList').click(function () {
            
//            var valuCentreCode = $('#SelectedCentreCode :selected').val();
//            var valuUniversityID = $('#SelectedUniversityID').val();
//            if (valuCentreCode != "" && valuUniversityID > 0) {
//                OrganisationSubjectGroupDetails.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
//            }
//            else if (valuCentreCode != "" && valuUniversityID <= 0) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select university");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#DivCreateNew').hide(true);
//            }
//            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select university");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#DivCreateNew').hide(true);
//            }
//        });

//        $('#Internal_Max_Marks').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

//        // Create new record
//        $('#CreateOrganisationSubjectGroupDetailsRecord').on("click", function () {
//            OrganisationSubjectGroupDetails.ActionName = "Create";

//            OrganisationSubjectGroupDetails.getDataFromDataTable();
//            OrganisationSubjectGroupDetails.AjaxCallOrganisationSubjectGroupDetails();
//        });

//        $('#EditOrganisationSubjectGroupDetailsRecord').on("click", function () {

//            OrganisationSubjectGroupDetails.ActionName = "Edit";
//            OrganisationSubjectGroupDetails.AjaxCallOrganisationSubjectGroupDetails();
//        });

//        $('#DeleteOrganisationSubjectGroupDetailsRecord').on("click", function () {

//            OrganisationSubjectGroupDetails.ActionName = "Delete";
//            OrganisationSubjectGroupDetails.AjaxCallOrganisationSubjectGroupDetails();
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
//             url: '/OrganisationSubjectGroupDetails/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode, UniversityID, CentreCode) {


//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            data: { centerCode: CentreCode, universityID: UniversityID, actionMode: actionMode },
//            dataType: "html",
//            url: '/OrganisationSubjectGroupDetails/List',
//            success: function (result) {
//                //Rebind Grid Data                
//                $("#ListViewModel").empty().append(result);
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
//              url: '/OrganisationSubjectGroupDetails/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);

//              }
//          });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationSubjectGroupDetails: function () {
//        var OrganisationSubjectGroupDetailsData = null;
//        if (OrganisationSubjectGroupDetails.ActionName == "Create") {
//            $("#FormCreateOrganisationSubjectGroupDetails").validate();
//            if ($("#FormCreateOrganisationSubjectGroupDetails").valid()) {
//                OrganisationSubjectGroupDetailsData = null;
//                OrganisationSubjectGroupDetailsData = OrganisationSubjectGroupDetails.GetOrganisationSubjectGroupDetails();

//                ajaxRequest.makeRequest("/OrganisationSubjectGroupDetails/Create", "POST", OrganisationSubjectGroupDetailsData, OrganisationSubjectGroupDetails.createSuccess);
//            }
//        }
//        else if (OrganisationSubjectGroupDetails.ActionName == "Edit") {
//            $("#FormEditOrganisationSubjectGroupDetails").validate();
//            if ($("#FormEditOrganisationSubjectGroupDetails").valid()) {
//                OrganisationSubjectGroupDetailsData = null;
//                OrganisationSubjectGroupDetailsData = OrganisationSubjectGroupDetails.GetOrganisationSubjectGroupDetails();
//                ajaxRequest.makeRequest("/OrganisationSubjectGroupDetails/Edit", "POST", OrganisationSubjectGroupDetailsData, OrganisationSubjectGroupDetails.editSuccess);
//            }
//        }
//        else if (OrganisationSubjectGroupDetails.ActionName == "Delete") {
//            OrganisationSubjectGroupDetailsData = null;
//            //$("#FormCreateOrganisationSubjectGroupDetails").validate();
//            OrganisationSubjectGroupDetailsData = OrganisationSubjectGroupDetails.GetOrganisationSubjectGroupDetails();

//            ajaxRequest.makeRequest("/OrganisationSubjectGroupDetails/Delete", "POST", OrganisationSubjectGroupDetailsData, OrganisationSubjectGroupDetails.deleteSuccess);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationSubjectGroupDetails: function () {

//        var Data = {
//        };
//        if (OrganisationSubjectGroupDetails.ActionName == "Create" || OrganisationSubjectGroupDetails.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.SubjectID = $('#SubjectID').val();
//            Data.ShortDescription = $('#ShortDescription').val();
//            Data.Description = $('#Description').val();
//            Data.OrgSemesterMstID = $('input[name=OrgSemesterMstID]').val();
//            Data.CourseYearDetailID = $('input[name=CourseYearDetailID]').val();
//            Data.SubjectRuleGrpNumber = $('input[name=SubjectRuleGrpNumber]').val();

//            Data.CentreCode = $('input[name=CentreCode]').val();
//            Data.UniversityID = $('input[name=UniversityID]').val();

//            Data.CompulsoryOptionalFlag = $('#CompulsoryOptionalFlag').val();
//            Data.SessionID = $('input[name=SessionID]').val();
//            Data.UniversityCode = $('#UniversityCode').val();
//            Data.Pattern = $('#Pattern').val();
//            Data.ElectiveGroupFlag = $('#ElectiveGroupFlag').val();

//            Data.ElectiveSubjectCompFlag = $('#ElectiveSubjectCompFlag').val();
//            Data.IsCompulsory = $('input[name=IsCompulsory]:checked').val() ? true : false;
//            if (Data.IsCompulsory == true) {
//                Data.OrgElectiveGrpID = '0';
//                Data.OrgSubElectiveGrpID = '0';
//            }
//            else {
//                Data.OrgElectiveGrpID = $('#OrgElectiveGrpID').val();
//                Data.OrgSubElectiveGrpID = $('#OrgSubElectiveGrpID').val();
//            }
//            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
//            Data.IsElectiveSubjectCompFlag = $('input[name=IsElectiveSubjectCompFlag]:checked').val() ? true : false;
//            Data.SubjectGrpCombinationIDs = OrganisationSubjectGroupDetails.SubjectGrpCombinationIDs;
//            Data.SubHoursGrpAllocationIDs = OrganisationSubjectGroupDetails.SubHoursGrpAllocationIDs;
//            Data.SubjectGrpMarksIDs = OrganisationSubjectGroupDetails.SubjectGrpMarksIDs;



//        }

//        return Data;
//    },



//    getDataFromDataTable: function () {

//        var DataArray = [];
//        var table = $('#example').DataTable();
//        var data = table.$('input').each(function () {
//            DataArray.push($(this).val());
//        });
//        var DatatableData, TotalRecord, TotalRow;
//        TotalRecord = DataArray.length;
//        // TotalRow = TotalRecord / 11;
//        //DatatableData = DataArray.join(',') + ",";


//        var CheckArray = []; var UnCheckArray = [];
//        $('#example input[type=checkbox]').each(function () {
//            if (this.checked == true) {
//                var aaa = [];
//                aaa = $(this).val().split('~');
//                if (aaa[0] == "Select_Row")
//                    CheckArray.push($(this).val());


//            }
//            else if (this.checked == false) {
//                var aa = [];
//                aa = $(this).val().split('~');
//                if (aa[0] == "Select_Row")
//                    CheckArray.push("0");
//            }
//        });
//        //var CheckArrayList, UnCheckArrayList;
//        //CheckArrayList = CheckArray.join(',') + ",";
//        //UnCheckArrayList = UnCheckArray.join(',') + ",";
//        SubjectGrpCombinationIDs = "<rows>";
//        SubHoursGrpAllocationIDs = "<rows>";
//        SubjectGrpMarksIDs = "<rows>";
//        var x = 0;
//        var y = 9;
//        var z = 1;

//        for (var i = 0; i < TotalRecord; i = i + 11) {
//            var a = [];

//            a = DataArray[i].split('~');
//            //  WeeklyData = DataArray[y].split('~');
//            if (DataArray[i] != CheckArray[x]) {
//                if (a[2] == "checked")
//                    // FOR Update SubjectGrpCombination
//                    SubjectGrpCombinationIDs = SubjectGrpCombinationIDs + "<row><ID>" + a[3] + "</ID><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber><ActiveFlag>0</ActiveFlag></row>";
//            }

//            else if (DataArray[i] == CheckArray[x]) {

//                if (a[2] != "checked") {
//                    //FOR Create SubjectGrpCombination
//                    SubjectGrpCombinationIDs = SubjectGrpCombinationIDs + "<row><ID>" + a[3] + "</ID><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber><ActiveFlag>1</ActiveFlag></row>";
//                    //FOR Create SubjectGrpAllocation
//                    SubHoursGrpAllocationIDs = SubHoursGrpAllocationIDs + "<row><ID>" + a[4] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><PeriodTypeID>1</PeriodTypeID><TotalNumberOfHours>" + DataArray[y] + "</TotalNumberOfHours><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber></row>";
//                    //FOR Create SubjectGrpMarks
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<row><ID>" + a[5] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber>";
//                    if (DataArray[z + 1] > 0 || DataArray[z + 2] > 0)
//                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<Internal>I</Internal>";
//                    else
//                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<Internal>" + null + "</Internal>";

//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxMarksInt>" + DataArray[z + 1] + "</MaxMarksInt>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<PassingMarksInt>" + DataArray[z + 2] + "</PassingMarksInt>";
//                    if (DataArray[z + 4] > 0 || DataArray[z + 5] > 0)
//                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExternalFlag>E</ExternalFlag>";
//                    else
//                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExternalFlag>" + null + "</ExternalFlag>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxMarksExt>" + DataArray[z + 4] + "</MaxMarksExt>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<PassingMarksExt>" + DataArray[z + 5] + "</PassingMarksExt>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<GroupPassingMarks>" + DataArray[z + 6] + "</GroupPassingMarks>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxGroupMarks>" + DataArray[z + 7] + "</MaxGroupMarks>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<TotalMarks>" + DataArray[z + 7] + "</TotalMarks>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<TotalPassingMarks>" + DataArray[z + 6] + "</TotalPassingMarks>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExamHours>" + DataArray[z + 9] + "</ExamHours></row>";



//                }
//                else {
//                    //FOR Create SubHoursGrpAllocation
//                    SubHoursGrpAllocationIDs = SubHoursGrpAllocationIDs + "<row><ID>" + a[4] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><PeriodTypeID>1</PeriodTypeID><TotalNumberOfHours>" + DataArray[y] + "</TotalNumberOfHours><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber></row>";
//                    //FOR Create SubjectGrpAllocation
//                    SubHoursGrpAllocationIDs = SubHoursGrpAllocationIDs + "<row><ID>" + a[4] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><PeriodTypeID>1</PeriodTypeID><TotalNumberOfHours>" + DataArray[y] + "</TotalNumberOfHours><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber></row>";
//                    //FOR Create SubjectGrpMarks
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<row><ID>" + a[5] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber>";
//                    if (DataArray[z + 1] > 0 || DataArray[z + 2] > 0)
//                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<Internal>I</Internal>";
//                    else
//                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<Internal>" + null + "</Internal>";

//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxMarksInt>" + DataArray[z + 1] + "</MaxMarksInt>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<PassingMarksInt>" + DataArray[z + 2] + "</PassingMarksInt>";
//                    if (DataArray[z + 4] > 0 || DataArray[z + 5] > 0)
//                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExternalFlag>E</ExternalFlag>";
//                    else
//                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExternalFlag>" + null + "</ExternalFlag>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxMarksExt>" + DataArray[z + 4] + "</MaxMarksExt>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<PassingMarksExt>" + DataArray[z + 5] + "</PassingMarksExt>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<GroupPassingMarks>" + DataArray[z + 6] + "</GroupPassingMarks>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxGroupMarks>" + DataArray[z + 7] + "</MaxGroupMarks>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<TotalMarks>" + DataArray[z + 7] + "</TotalMarks>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<TotalPassingMarks>" + DataArray[z + 6] + "</TotalPassingMarks>";
//                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExamHours>" + DataArray[z + 9] + "</ExamHours></row>";
//                }

//            }
//            x++;
//            y = y + 11;
//            z = z + 11;
//        }
//        OrganisationSubjectGroupDetails.SubjectGrpCombinationIDs = SubjectGrpCombinationIDs + "</rows>";
//        OrganisationSubjectGroupDetails.SubHoursGrpAllocationIDs = SubHoursGrpAllocationIDs + "</rows>";
//        OrganisationSubjectGroupDetails.SubjectGrpMarksIDs = SubjectGrpMarksIDs + "</rows>";

//        // alert(SubjectGrpCombinationIDs);
//        // alert(SubjectGrpMarksIDs);
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    createSuccess: function (data) {

//        //var splitdata = data.split("::");
//        //var dataSuccess = splitdata[0];
//        var CentreCode = data.CentreCodeWithName;//splitdata[1].split(":");
//        var UniversityID = data.UniversityIDWithName;//splitdata[2].split(":");
//        var splitData = data.errorMessage.split(',');
//        OrganisationSubjectGroupDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
//        parent.$.colorbox.close();
//        //if (dataSuccess == "True") {
//        //    //Reload List
//        //    OrganisationSubjectGroupDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
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
//    //    OrganisationSubjectGroupDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    // OrganisationSubjectGroupDetails.ReloadList("Record Deleted Sucessfully.");
//    //    OrganisationSubjectGroupDetails.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};

////////////////////new js///////////


//this class contain methods related to nationality functionality
var OrganisationSubjectGroupDetails = {
    //Member variables
    ActionName: null,
    SubjectGrpCombinationIDs: null,
    SubHoursGrpAllocationIDs: null,
    SubjectGrpMarksIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationSubjectGroupDetails.constructor();
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
                    url: "/OrganisationSubjectGroupDetails/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--------Select University-------</option>');
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
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---------Select University---------</option>');
                $('#btnCreate').hide();
            }
            $('#DivCreateNew').hide(true);
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });
        $('#SelectedUniversityID').on("change", function () {
            $('#DivCreateNew').hide(true);
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });
        $("#OrgElectiveGrpID").change(function () {
            var selectedItem = $(this).val();
            var $ddlSubElectiveGrpID = $("#OrgSubElectiveGrpID");

            if ($("#OrgElectiveGrpID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OrganisationSubjectGroupDetails/GetSubElectiveGroupByElectiveGrpID",

                    data: { "OrgElectiveGrpID": selectedItem },
                    success: function (data) {
                        $ddlSubElectiveGrpID.html('');
                        $ddlSubElectiveGrpID.append('<option value="">--Select Sub Elective Group--</option>');
                        $.each(data, function (id, option) {

                            $ddlSubElectiveGrpID.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ddlSubElectiveGrpProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $ddlSubElectiveGrpProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#OrgSubElectiveGrpID').find('option').remove().end().append('<option value>--Sub Elective Group--</option>');
                $('#btnCreate').hide();
            }
        });

        if ($().val == true) {

            $('#divoptional').hide(true);
            $('#divoptional1').hide(true);
        }

        $('#IsActive').prop('checked', true);
        //$('#IsActive').prop('disabled', true);
        // For Show hide div Optional
        if ($('input[name=ID]').val() == 0) {
            $('#IsCompulsory').prop('checked', true);
        }
        //if ($('input[name=ID]').val() > 0) {
        //    $('#IsCompulsory').prop('checked', false);
        //}
        //var IsCompulsory = $('input[name=IsCompulsory]:checked').val() ? true : false;
        var IsCompulsory = $('input[id=IsCompulsory]:checked').val() ? true : false;
        if (IsCompulsory == true) {

            $('#divoptional').hide(true);
            $('#divoptional1').hide(true);
        }
        if (IsCompulsory == false) {

            $('#divoptional').show(true);
            $('#divoptional1').show(true);
        }
        $('#IsCompulsory').change(function () {
            if (this.checked) {
                $('#divoptional').fadeOut('slow');
                $('#divoptional1').fadeOut('slow');


            }
            else {
                $('#divoptional').fadeIn('slow');
                $('#divoptional1').fadeIn('slow');
                $('#OrgElectiveGrpID').val('');
                $('#OrgSubElectiveGrpID').val('');
            }

        });

        // For Active/ Inactive Row
        $('.abc').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $this.closest("tr").find(":input.form-control_Internal_Row").attr("disabled", false);
                $this.closest("tr").find(":input.form-control_External_Row").attr("disabled", false);
                $this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", false);
                $this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", false);

            } else {
                $this.closest("tr").find(":input.form-control_Internal_Row").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_External_Row").attr("disabled", true);

                $this.closest("tr").find(":input.form-control_Internal_Row").attr("checked", false);
                $this.closest("tr").find(":input.form-control_External_Row").attr("checked", false);

                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").val(0);

                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").val(0);


                $this.closest("tr").find(":input.form-control_External_Passing_Marks").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_External_Passing_Marks").val(0);

                $this.closest("tr").find(":input.form-control_External_Max_Marks").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_External_Max_Marks").val(0);

                $this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").val(0);
                $this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_ExamHours").val(0);

                $this.closest("tr").find(":input.form-control_External_Group_Max_Marks").val(0);
                $this.closest("tr").find(":input.form-control_External_Group_Min_Marks").val(0);


            }
            $this.attr("disabled", false);
        });

        // For Active/Inactive TextBox of Internal Checkbox
        $('.form-control_Internal_Row').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").attr("disabled", false);
                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").attr("disabled", false);
                //$this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", false);
                //$this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", false);

                $('.form-control_Internal_Max_Marks').on("keydown", function (e) {
                    AMSValidation.AllowNumbersOnly(e);
                });

                $('.form-control_Internal_Passing_Marks').on("keydown", function (e) {
                    AMSValidation.AllowNumbersOnly(e);
                });

                $('.form-control_WeeklyPeriodAllocation').on("keydown", function (e) {
                    AMSValidation.AllowNumbersOnly(e);
                });


            } else {
                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_Internal_Max_Marks").val(0);

                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_Internal_Passing_Marks").val(0);

                //$this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", true);
                //$this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", true);


                var $this = $(this);
                var rowId = $this.closest("tr").attr("id");
                // alert(rowId); //return false;
                var Internal_Max_Marks = parseInt($("#Internal_Max_Marks_" + rowId).val());
                var External_Max_Marks = parseInt($("#External_Max_Marks_" + rowId).val());
                var External_Group_Max_Marks = parseInt(Internal_Max_Marks + External_Max_Marks);
                if ($.isNumeric(External_Group_Max_Marks)) {
                    $("#External_Group_Max_Marks_" + rowId).val(parseInt(External_Group_Max_Marks));
                }



                var Internal_Passing_Marks = parseInt($("#Internal_Passing_Marks_" + rowId).val());
                var External_Passing_Marks = parseInt($("#External_Passing_Marks_" + rowId).val());
                var External_Group_Min_Marks = parseInt(Internal_Passing_Marks + External_Passing_Marks);
                if ($.isNumeric(External_Group_Min_Marks)) {
                    $("#External_Group_Min_Marks_" + rowId).val(parseInt(External_Group_Min_Marks));
                }
            }
            $this.attr("disabled", false);
        });

        // For Active/Inactive TextBox of External Checkbox
        $('.form-control_External_Row').click(function (event) {
            var $this = $(this);
            if ($this.is(":checked")) {
                $this.closest("tr").find(":input.form-control_External_Passing_Marks").attr("disabled", false);
                $this.closest("tr").find(":input.form-control_External_Max_Marks").attr("disabled", false);
                $this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", false);
                $this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", false);

                $('.form-control_External_Passing_Marks').on("keydown", function (e) {
                    AMSValidation.AllowNumbersOnly(e);
                });

                $('.form-control_External_Max_Marks').on("keydown", function (e) {
                    AMSValidation.AllowNumbersOnly(e);
                });

                $('.form-control_WeeklyPeriodAllocation').on("keydown", function (e) {
                    AMSValidation.AllowNumbersOnly(e);
                });

            } else {
                $this.closest("tr").find(":input.form-control_External_Passing_Marks").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_External_Passing_Marks").val(0);
                $this.closest("tr").find(":input.form-control_External_Max_Marks").attr("disabled", true);
                $this.closest("tr").find(":input.form-control_External_Max_Marks").val(0);
                //$this.closest("tr").find(":input.form-control_WeeklyPeriodAllocation").attr("disabled", true);
                //$this.closest("tr").find(":input.form-control_ExamHours").attr("disabled", true);



                var $this = $(this);
                var rowId = $this.closest("tr").attr("id");

                var Internal_Max_Marks = parseInt($("#Internal_Max_Marks_" + rowId).val());
                var External_Max_Marks = parseInt($("#External_Max_Marks_" + rowId).val());
                var External_Group_Max_Marks = parseInt(Internal_Max_Marks + External_Max_Marks);
                if ($.isNumeric(External_Group_Max_Marks)) {
                    $("#External_Group_Max_Marks_" + rowId).val(parseInt(External_Group_Max_Marks));
                }


                var Internal_Passing_Marks = parseInt($("#Internal_Passing_Marks_" + rowId).val());
                var External_Passing_Marks = parseInt($("#External_Passing_Marks_" + rowId).val());
                var External_Group_Min_Marks = parseInt(Internal_Passing_Marks + External_Passing_Marks);
                if ($.isNumeric(External_Group_Min_Marks)) {
                    $("#External_Group_Min_Marks_" + rowId).val(parseInt(External_Group_Min_Marks));
                }
            }
            $this.attr("disabled", false);
        });


        // For calculate Max Group Mark on click event
        $('.form-control_Internal_Max_Marks').change(function (event) {

            var $this = $(this);
            var rowId = $this.closest("tr").attr("id");
            // alert(rowId); //return false;
            var Internal_Max_Marks = parseInt($("#Internal_Max_Marks_" + rowId).val());
            var External_Max_Marks = parseInt($("#External_Max_Marks_" + rowId).val());
            var External_Group_Max_Marks = parseInt(Internal_Max_Marks + External_Max_Marks);
            if ($.isNumeric(External_Group_Max_Marks)) {
                $("#External_Group_Max_Marks_" + rowId).val(parseInt(External_Group_Max_Marks));
            }
        });


        // For calculate Max Group Mark on click event
        $('.form-control_External_Max_Marks').change(function (event) {

            var $this = $(this);
            var rowId = $this.closest("tr").attr("id");
            // alert(rowId); //return false;
            var Internal_Max_Marks = parseInt($("#Internal_Max_Marks_" + rowId).val());
            var External_Max_Marks = parseInt($("#External_Max_Marks_" + rowId).val());
            var External_Group_Max_Marks = parseInt(Internal_Max_Marks + External_Max_Marks);
            if ($.isNumeric(External_Group_Max_Marks)) {
                $("#External_Group_Max_Marks_" + rowId).val(parseInt(External_Group_Max_Marks));
            }

        });
        // For calculate Min Group Mark on click event
        $('.form-control_Internal_Passing_Marks').change(function (event) {

            var $this = $(this);
            var rowId = $this.closest("tr").attr("id");
            var Internal_Passing_Marks = parseInt($("#Internal_Passing_Marks_" + rowId).val());
            var External_Passing_Marks = parseInt($("#External_Passing_Marks_" + rowId).val());
            var External_Group_Min_Marks = parseInt(Internal_Passing_Marks + External_Passing_Marks);
            if ($.isNumeric(External_Group_Min_Marks)) {
                $("#External_Group_Min_Marks_" + rowId).val(parseInt(External_Group_Min_Marks));
            }
        });
        // For calculate Min Group Mark on click event
        $('.form-control_External_Passing_Marks').change(function (event) {

            var $this = $(this);
            var rowId = $this.closest("tr").attr("id");
            var Internal_Passing_Marks = parseInt($("#Internal_Passing_Marks_" + rowId).val());
            var External_Passing_Marks = parseInt($("#External_Passing_Marks_" + rowId).val());
            var External_Group_Min_Marks = parseInt(Internal_Passing_Marks + External_Passing_Marks);
            if ($.isNumeric(External_Group_Min_Marks)) {
                $("#External_Group_Min_Marks_" + rowId).val(parseInt(External_Group_Min_Marks));
            }
        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SubjectID').focus();
            var dt = new Date();
            $('#SubjectID').val("");
            $('#CreateOrganisationSubjectGroupDetailsRecord').val("Submit");
            $('#reset').val("Reset");
            $('#IsCompulsory').prop('checked', true);
            $('#divoptional').fadeOut('slow');
            $('#IsCompulsory').prop('checked', true);

            return false;
        });


        //$('#example tbody').on('click', 'tr', function () {
        //    $(this).toggleClass('selected');
        //});

        $('#btnShowList').click(function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationSubjectGroupDetails.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }
            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
        });

        $('#Internal_Max_Marks').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        // Create new record
        $('#CreateOrganisationSubjectGroupDetailsRecord').on("click", function () {
            OrganisationSubjectGroupDetails.ActionName = "Create";

            OrganisationSubjectGroupDetails.getDataFromDataTable();
            OrganisationSubjectGroupDetails.AjaxCallOrganisationSubjectGroupDetails();
        });

        $('#EditOrganisationSubjectGroupDetailsRecord').on("click", function () {

            OrganisationSubjectGroupDetails.ActionName = "Edit";
            OrganisationSubjectGroupDetails.AjaxCallOrganisationSubjectGroupDetails();
        });

        $('#DeleteOrganisationSubjectGroupDetailsRecord').on("click", function () {

            OrganisationSubjectGroupDetails.ActionName = "Delete";
            OrganisationSubjectGroupDetails.AjaxCallOrganisationSubjectGroupDetails();
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

        //$(".ajax").colorbox();
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
             url: '/OrganisationSubjectGroupDetails/List',
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
            data: { centerCode: CentreCode, universityID: UniversityID, actionMode: actionMode },
            dataType: "html",
            url: '/OrganisationSubjectGroupDetails/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
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
              url: '/OrganisationSubjectGroupDetails/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationSubjectGroupDetails: function () {
        var OrganisationSubjectGroupDetailsData = null;
        if (OrganisationSubjectGroupDetails.ActionName == "Create") {
            $("#FormCreateOrganisationSubjectGroupDetails").validate();
            if ($("#FormCreateOrganisationSubjectGroupDetails").valid()) {
                OrganisationSubjectGroupDetailsData = null;
                OrganisationSubjectGroupDetailsData = OrganisationSubjectGroupDetails.GetOrganisationSubjectGroupDetails();

                ajaxRequest.makeRequest("/OrganisationSubjectGroupDetails/Create", "POST", OrganisationSubjectGroupDetailsData, OrganisationSubjectGroupDetails.createSuccess);
            }
        }
        else if (OrganisationSubjectGroupDetails.ActionName == "Edit") {
            $("#FormEditOrganisationSubjectGroupDetails").validate();
            if ($("#FormEditOrganisationSubjectGroupDetails").valid()) {
                OrganisationSubjectGroupDetailsData = null;
                OrganisationSubjectGroupDetailsData = OrganisationSubjectGroupDetails.GetOrganisationSubjectGroupDetails();
                ajaxRequest.makeRequest("/OrganisationSubjectGroupDetails/Edit", "POST", OrganisationSubjectGroupDetailsData, OrganisationSubjectGroupDetails.editSuccess);
            }
        }
        else if (OrganisationSubjectGroupDetails.ActionName == "Delete") {
            OrganisationSubjectGroupDetailsData = null;
            //$("#FormCreateOrganisationSubjectGroupDetails").validate();
            OrganisationSubjectGroupDetailsData = OrganisationSubjectGroupDetails.GetOrganisationSubjectGroupDetails();

            ajaxRequest.makeRequest("/OrganisationSubjectGroupDetails/Delete", "POST", OrganisationSubjectGroupDetailsData, OrganisationSubjectGroupDetails.deleteSuccess);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationSubjectGroupDetails: function () {

        var Data = {
        };
        if (OrganisationSubjectGroupDetails.ActionName == "Create" || OrganisationSubjectGroupDetails.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.SubjectID = $('#SubjectID').val();
            Data.ShortDescription = $('#ShortDescription').val();
            Data.Description = $('#Description').val();
            Data.OrgSemesterMstID = $('input[name=OrgSemesterMstID]').val();
            Data.CourseYearDetailID = $('input[name=CourseYearDetailID]').val();
            Data.SubjectRuleGrpNumber = $('input[name=SubjectRuleGrpNumber]').val();

            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.UniversityID = $('input[name=UniversityID]').val();

            Data.CompulsoryOptionalFlag = $('#CompulsoryOptionalFlag').val();
            Data.SessionID = $('input[name=SessionID]').val();
            Data.UniversityCode = $('#UniversityCode').val();
            Data.Pattern = $('#Pattern').val();
            Data.ElectiveGroupFlag = $('#ElectiveGroupFlag').val();

            Data.ElectiveSubjectCompFlag = $('#ElectiveSubjectCompFlag').val();
            //Data.IsCompulsory = $('input[name=IsCompulsory]:checked').val() ? true : false;
            Data.IsCompulsory = $('input[id=IsCompulsory]:checked').val() ? true : false;

            if (Data.IsCompulsory == true) {
                Data.OrgElectiveGrpID = '0';
                Data.OrgSubElectiveGrpID = '0';
            }
            else {
                Data.OrgElectiveGrpID = $('#OrgElectiveGrpID').val();
                Data.OrgSubElectiveGrpID = $('#OrgSubElectiveGrpID').val();
            }
            //Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
            Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;
            Data.IsElectiveSubjectCompFlag = $('input[name=IsElectiveSubjectCompFlag]:checked').val() ? true : false;
            Data.SubjectGrpCombinationIDs = OrganisationSubjectGroupDetails.SubjectGrpCombinationIDs;
            Data.SubHoursGrpAllocationIDs = OrganisationSubjectGroupDetails.SubHoursGrpAllocationIDs;
            Data.SubjectGrpMarksIDs = OrganisationSubjectGroupDetails.SubjectGrpMarksIDs;



        }

        return Data;
    },



    getDataFromDataTable: function () {

        var DataArray = [];
        var table = $('#example').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        var DatatableData, TotalRecord, TotalRow;
        TotalRecord = DataArray.length;
        // TotalRow = TotalRecord / 11;
        //DatatableData = DataArray.join(',') + ",";


        var CheckArray = []; var UnCheckArray = [];
        $('#example input[type=checkbox]').each(function () {
            if (this.checked == true) {
                var aaa = [];
                aaa = $(this).val().split('~');
                if (aaa[0] == "Select_Row")
                    CheckArray.push($(this).val());


            }
            else if (this.checked == false) {
                var aa = [];
                aa = $(this).val().split('~');
                if (aa[0] == "Select_Row")
                    CheckArray.push("0");
            }
        });
        //var CheckArrayList, UnCheckArrayList;
        //CheckArrayList = CheckArray.join(',') + ",";
        //UnCheckArrayList = UnCheckArray.join(',') + ",";
        SubjectGrpCombinationIDs = "<rows>";
        SubHoursGrpAllocationIDs = "<rows>";
        SubjectGrpMarksIDs = "<rows>";
        var x = 0;
        var y = 9;
        var z = 1;

        for (var i = 0; i < TotalRecord; i = i + 11) {
            var a = [];

            a = DataArray[i].split('~');
            //  WeeklyData = DataArray[y].split('~');
            if (DataArray[i] != CheckArray[x]) {
                if (a[2] == "checked")
                    // FOR Update SubjectGrpCombination
                    SubjectGrpCombinationIDs = SubjectGrpCombinationIDs + "<row><ID>" + a[3] + "</ID><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber><ActiveFlag>0</ActiveFlag></row>";
            }

            else if (DataArray[i] == CheckArray[x]) {

                if (a[2] != "checked") {
                    //FOR Create SubjectGrpCombination
                    SubjectGrpCombinationIDs = SubjectGrpCombinationIDs + "<row><ID>" + a[3] + "</ID><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber><ActiveFlag>1</ActiveFlag></row>";
                    //FOR Create SubjectGrpAllocation
                    SubHoursGrpAllocationIDs = SubHoursGrpAllocationIDs + "<row><ID>" + a[4] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><PeriodTypeID>1</PeriodTypeID><TotalNumberOfHours>" + DataArray[y] + "</TotalNumberOfHours><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber></row>";
                    //FOR Create SubjectGrpMarks
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<row><ID>" + a[5] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber>";
                    if (DataArray[z + 1] > 0 || DataArray[z + 2] > 0)
                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<Internal>I</Internal>";
                    else
                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<Internal>" + null + "</Internal>";

                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxMarksInt>" + DataArray[z + 1] + "</MaxMarksInt>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<PassingMarksInt>" + DataArray[z + 2] + "</PassingMarksInt>";
                    if (DataArray[z + 4] > 0 || DataArray[z + 5] > 0)
                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExternalFlag>E</ExternalFlag>";
                    else
                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExternalFlag>" + null + "</ExternalFlag>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxMarksExt>" + DataArray[z + 4] + "</MaxMarksExt>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<PassingMarksExt>" + DataArray[z + 5] + "</PassingMarksExt>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<GroupPassingMarks>" + DataArray[z + 6] + "</GroupPassingMarks>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxGroupMarks>" + DataArray[z + 7] + "</MaxGroupMarks>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<TotalMarks>" + DataArray[z + 7] + "</TotalMarks>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<TotalPassingMarks>" + DataArray[z + 6] + "</TotalPassingMarks>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExamHours>" + DataArray[z + 9] + "</ExamHours></row>";



                }
                else {
                    //FOR Create SubHoursGrpAllocation
                    SubHoursGrpAllocationIDs = SubHoursGrpAllocationIDs + "<row><ID>" + a[4] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><PeriodTypeID>1</PeriodTypeID><TotalNumberOfHours>" + DataArray[y] + "</TotalNumberOfHours><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber></row>";
                    //FOR Create SubjectGrpAllocation
                    SubHoursGrpAllocationIDs = SubHoursGrpAllocationIDs + "<row><ID>" + a[4] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><PeriodTypeID>1</PeriodTypeID><TotalNumberOfHours>" + DataArray[y] + "</TotalNumberOfHours><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber></row>";
                    //FOR Create SubjectGrpMarks
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<row><ID>" + a[5] + "</ID><SubjectCombgrpID>" + a[3] + "</SubjectCombgrpID><SubjectTypeNumber>" + a[1] + "</SubjectTypeNumber>";
                    if (DataArray[z + 1] > 0 || DataArray[z + 2] > 0)
                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<Internal>I</Internal>";
                    else
                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<Internal>" + null + "</Internal>";

                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxMarksInt>" + DataArray[z + 1] + "</MaxMarksInt>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<PassingMarksInt>" + DataArray[z + 2] + "</PassingMarksInt>";
                    if (DataArray[z + 4] > 0 || DataArray[z + 5] > 0)
                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExternalFlag>E</ExternalFlag>";
                    else
                        SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExternalFlag>" + null + "</ExternalFlag>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxMarksExt>" + DataArray[z + 4] + "</MaxMarksExt>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<PassingMarksExt>" + DataArray[z + 5] + "</PassingMarksExt>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<GroupPassingMarks>" + DataArray[z + 6] + "</GroupPassingMarks>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<MaxGroupMarks>" + DataArray[z + 7] + "</MaxGroupMarks>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<TotalMarks>" + DataArray[z + 7] + "</TotalMarks>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<TotalPassingMarks>" + DataArray[z + 6] + "</TotalPassingMarks>";
                    SubjectGrpMarksIDs = SubjectGrpMarksIDs + "<ExamHours>" + DataArray[z + 9] + "</ExamHours></row>";
                }

            }
            x++;
            y = y + 11;
            z = z + 11;
        }
        OrganisationSubjectGroupDetails.SubjectGrpCombinationIDs = SubjectGrpCombinationIDs + "</rows>";
        OrganisationSubjectGroupDetails.SubHoursGrpAllocationIDs = SubHoursGrpAllocationIDs + "</rows>";
        OrganisationSubjectGroupDetails.SubjectGrpMarksIDs = SubjectGrpMarksIDs + "</rows>";

        // alert(SubjectGrpCombinationIDs);
        // alert(SubjectGrpMarksIDs);
    },


    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {

        //var splitdata = data.split("::");
        //var dataSuccess = splitdata[0];
        var CentreCode = data.CentreCodeWithName;//splitdata[1].split(":");
        var UniversityID = data.UniversityIDWithName;//splitdata[2].split(":");
        var splitData = data.errorMessage.split(',');
        OrganisationSubjectGroupDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        
    },
    
};

