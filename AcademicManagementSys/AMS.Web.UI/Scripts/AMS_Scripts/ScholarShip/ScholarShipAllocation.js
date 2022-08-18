//this class contain methods related to nationality functionality
var ScholarShipAllocation = {
    //Member variables
    map: {},
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ScholarShipAllocation.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#StudentName").on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
          
            if (e.keyCode == 8 || e.keyCode == 46) {
                document.getElementById("imgStuPhoto").src = "Content/materialtheme/img/login.png";
                $("#StudentName").val('');
                $("#stuName").html('Student Name <small id="stuEmailID">Email -Id </small>');
                $("#stuAcadYear").text('');
                $("#stuCourse").text('');
                $("#stuSection").text('');
                $("#stuAdmissionPattern").text('');
                $("#stuGender").text('');
                $("#stuEnrollNumber").text('');
                $("#stuStdNumber").text('');
                $("#stuAdmitAcadYear").text('');
                $("#StudentAmissionDetailID").val('');
                $("#SectionDetailId").val('');
                $("#StandarNumber").val('');
                $("#LastSectionDetailID").val('');
                $("#StudentID").val('');
            }

        });
        $("#ScholarSheepDocumentNumber").on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });
      

        $("#CreateScholarShipAllocationRecord").on("click", function () {
            
            ScholarShipAllocation.ActionName = "Create";
            ScholarShipAllocation.AjaxCallScholarShipAllocation();            
        });



        $("#RejectFeeStructureApproval").on("click", function () {
            ScholarShipAllocation.ActionName = "FeeStructureReject";
        });


    },

    //Get Data For Fee Approval in XML.
    GetFeeApprovalXmlData: function () {
        
        var DataArray = [];
        $('#tblFeeStructure tbody tr td input[type="text"]').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        var FeeApprovalXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            if (DataArray[i] > 0) {
                var CrDrflag = 'D'

                if (DataArray[i + 1] == "False") {
                    CrDrflag = 'C'
                }
                FeeApprovalXml = FeeApprovalXml
                                    + "<row>"
               		                + "<TransactionSubID>0</TransactionSubID>"
               		                + "<AccountID>" + DataArray[i + 0] + "</AccountID>"
               		                + "<DebitCreditFlag>" + CrDrflag + "</DebitCreditFlag>"
               		                + "<TransactionAmount>" + DataArray[i + 2] + "</TransactionAmount>"
               		                + "<ChequeNo></ChequeNo>"
               		                + "<ChequeDatetime></ChequeDatetime>"
               		                + "<NarrationDescription>Fee receivable</NarrationDescription>"
               		                + "<BankName></BankName>"
               		                + "<BranchName></BranchName>"
               		                + "<PersonID>" + DataArray[i + 3] + "</PersonID>"
               		                + "<PersonType>S</PersonType>"
               		                + "<IsActive>1</IsActive>"
               	                    + "</row>";
            }
        }
        if (FeeApprovalXml.length > 10) {
            ScholarShipAllocation.FeeApprovalXmlstring = FeeApprovalXml + "</rows>";
        }
        else {
            ScholarShipAllocation.FeeApprovalXmlstring = "";
        }
    },

    InitAndValidateCentreList: function () {
        $("#CentreCode").change(function () {
            $("#divCardHeader").hide();
            $('#myDataTable').empty().append('<tbody><tr class="odd"><td valign="top" colspan="4" class="dataTables_empty">No data available in table</td></tr></tbody>');
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });

        $('#btnShowList').click(function () {
            var centreCode = $('#CentreCode :selected').val();
            if (centreCode != '' && centreCode != null) {
                ScholarShipAllocation.LoadList(centreCode);
                $("#divCardHeader li a").attr("href", "/ScholarShipAllocation/Create?centreCode=" + centreCode);
                $("#divCardHeader").show();
            }
            else {
                notify("Please select centre", "warning");
            }
        });
    },



    //LoadList method is used to load List page
    LoadList: function (centreCode) {
        $.ajax({
            cache: false,
            type: "POST",
            data: { centreCode: centreCode },
            dataType: "html",
            url: '/ScholarShipAllocation/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var centreCode = $('input[id="CentreCode"]').val();
        $.ajax({
            cache: false,
            type: "POST",
            data: { centreCode: centreCode, actionMode: actionMode },
            dataType: "html",
            url: '/ScholarShipAllocation/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },



    CommonMethodsForScholarShipAllocation: function () {

        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;
                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                if ($("#BranchID").val() != "") {
                    $.ajax({
                        url: "/ScholarShipAllocation/GetStudentDetails",
                        type: "POST",
                        dataType: "json",
                        data: { query: q, centreCode: $("#SelectedCentreCode").val(), branchID: $("#BranchID").val() },
                        success: function (data) {

                            // iterate through the pool of strings and for any string that
                            // contains the substring `q`, add it to the `matches` array
                            $.each(data, function (i, response) {
                                if (substrRegex.test(response.studentName)) {
                                    ScholarShipAllocation.map[response.studentName] = response;
                                    matches.push(response.studentName);
                                }
                            });
                        },
                        async: false
                    })
                    cb(matches);
                }
                else {
                    $("#displayErrorMessage p").text("Course must be selected").closest('div').fadeIn().closest('div').addClass('alert-warning');
                }

            };
        };


        $('.typeahead').typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        },
        {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            if (String(ScholarShipAllocation.map[item].studentPhoto) != "") {
                document.getElementById("imgStuPhoto").src = "data:" + ScholarShipAllocation.map[item].studentPhotoType + ";base64," + ScholarShipAllocation.map[item].studentPhoto;
            }
            else {
                document.getElementById("imgStuPhoto").src = "Content/materialtheme/img/login.png";
            }
            $("#stuName").html(ScholarShipAllocation.map[item].studentName + '<small id="stuEmailID">' + ScholarShipAllocation.map[item].studentEmailID + '</small>');
            $("#stuAcadYear").text(ScholarShipAllocation.map[item].sessionName);
            $("#stuCourse").text(ScholarShipAllocation.map[item].branchDescription);
            $("#stuSection").text(ScholarShipAllocation.map[item].sectionDetailsDesc);
            $("#stuAdmissionPattern").text(ScholarShipAllocation.map[item].admissionPattern);
            $("#stuGender").text(ScholarShipAllocation.map[item].gender);
            $("#stuEnrollNumber").text(ScholarShipAllocation.map[item].enrollmentNumber);
            $("#stuStdNumber").text(ScholarShipAllocation.map[item].standardNumber);
            $("#stuAdmitAcadYear").text(ScholarShipAllocation.map[item].admitAcademicYear);
            $("#StudentAmissionDetailID").val(ScholarShipAllocation.map[item].studentAmissionDetailID);
            $("#SectionDetailId").val(ScholarShipAllocation.map[item].sectionDetailID);
            $("#StandarNumber").val(ScholarShipAllocation.map[item].standardNumber);
            $("#LastSectionDetailID").val(ScholarShipAllocation.map[item].oldSectionDetailID);
            $("#StudentID").val(ScholarShipAllocation.map[item].studentId);
        });

        InitAnimatedBorder();

        CloseAlert();
    },



    //Fire ajax call to insert update and delete record
    AjaxCallScholarShipAllocation: function () {
        var ScholarShipAllocationData = null;
        if (ScholarShipAllocation.ActionName == "Create") {
            if ($("#FormCreateScholarShipAllocation").valid()) {
                ScholarShipAllocationData = null;
                ScholarShipAllocationData = ScholarShipAllocation.GetScholarShipAllocation();
                ajaxRequest.makeRequest("/ScholarShipAllocation/Create", "POST", ScholarShipAllocationData, ScholarShipAllocation.Success, "CreateScholarShipAllocationRecord");
            }
        }
        if (ScholarShipAllocation.ActionName == "FeeStructureRequestApproval") {
            
            if ($("#FormFeeStructureRequestAppronal").valid()) {
                ScholarShipAllocationData = null;
                ScholarShipAllocationData = ScholarShipAllocation.GetScholarShipAllocation();
                ajaxRequest.makeRequest("/ScholarShipAllocation/CreateFeeStructureRequestApproval", "POST", ScholarShipAllocationData, ScholarShipAllocation.success, "");
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetScholarShipAllocation: function () {
        var Data = {
        };
        if (ScholarShipAllocation.ActionName == "Create") {
            Data.CentreCode = $('input[name=SelectedCentreCode]').val();
            Data.StudentID = $('input[name=StudentID]').val();
            Data.StudentAmissionDetailID = $('input[name=StudentAmissionDetailID]').val();
            Data.SectionDetailId = $('input[id=SectionDetailId]').val();            
            Data.StandarNumber = $('input[id=StandarNumber]').val();
            Data.LastSectionDetailID = $('input[id=LastSectionDetailID]').val();
            Data.ScholarShipMasterID = $('#ScholarShipMasterID :selected').val();
            Data.ScholarSheepDocumentNumber = $('#ScholarSheepDocumentNumber').val();
        }
        if (ScholarShipAllocation.ActionName == "FeeStructureRequestApproval") {
            Data.FeeApprovalXmlstring = ScholarShipAllocation.FeeApprovalXmlstring;
            Data.FeeStructureMasterID = $('input[name=FeeStructureMasterID]').val();
            Data.AccBalanceSheetID = $('input[name=AccBalanceSheetID]').val();
            Data.AccountSessionID = $('input[name=AccountSessionID]').val();
            Data.ScholarShipAllocationHistoryID = $('input[name=ScholarShipAllocationHistoryID]').val();
            Data.StudentID = $('input[name=StudentID]').val();

            Data.PersonID = $('input[name=PersonID]').val();
            Data.StageSequenceNumber = $('input[name=StageSequenceNumber]').val();
            Data.TaskNotificationMasterID = $('input[name=TaskNotificationMasterID]').val();
            Data.TaskNotificationDetailsID = $('input[name=TaskNotificationDetailsID]').val();
            Data.GeneralTaskReportingDetailsID = $('input[name=GeneralTaskReportingDetailsID]').val();
            Data.IsLastRecord = $('input[name=IsLastRecord]').val();
        }
        return Data;
    },

    IsValidInstallmentXml: function () {
        var DataArray = [];
        $('#tblData2 tbody tr td input').each(function () {
            DataArray.push($(this).val());
        });
        TotalRecord = DataArray.length;
        ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            if (DataArray[i + 2].length >= 10 && DataArray[i + 3].length >= 10) {
                ParameterXml = ParameterXml + "<row><ID>0</ID><FeeStructureInstallmentMasterID>" + DataArray[i + 1] + "</FeeStructureInstallmentMasterID><InstallmentFromDate>" + DataArray[i + 2] + "</InstallmentFromDate><InstallmentToDate>" + DataArray[i + 3] + "</InstallmentToDate></row>";
            }
            else {
                ParameterXml = "";
                break;
            }
        }
        if (ParameterXml.length > 6) {
            ScholarShipAllocation.XMLstring = ParameterXml + "</rows>";
            return true;
        }
        else {
            ScholarShipAllocation.XMLstring = "";
            return false;
        }
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            ScholarShipAllocation.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
        var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
        var splitData = data.errorMessage.split(',');
        ScholarShipAllocation.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
    },

    deleteSuccess: function (data) {
        var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
        var splitData = data.errorMessage.split(',');
        ScholarShipAllocation.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
        parent.$.colorbox.close();
    },


};

