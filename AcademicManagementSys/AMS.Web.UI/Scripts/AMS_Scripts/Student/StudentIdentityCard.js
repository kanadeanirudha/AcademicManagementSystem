//this class contain methods related to nationality functionality
var StudentIdentityCard = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentIdentityCard.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        //$("#DateOfBirth").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd-MM-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()'
        //});

        $('#DateOfBirth').attr("readonly", true);

        $('#DateOfBirth').datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
            //yearRange: '1950:document.write(currentYear.getFullYear()'

        });

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            //alert(selectedItem);
          
            var $ddlCurrentSessionDetails = $("#SelectedAcademicYear");
            var $CurrentSessionDetailsProgress = $("#states-loading-progress");
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            $CurrentSessionDetailsProgress.show();




            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCard/GetUniversityByCentreCode",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University--</option>');
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
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
                $('#btnCreate').hide();
            }
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCard/GetCurrentSessionDetails",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlCurrentSessionDetails.html('');
                        //   $ddlCurrentSessionDetails.append('<option value="">--Select Session--</option>');
                        $.each(data, function (id, option) {

                            $ddlCurrentSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $CurrentSessionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Session.');
                        $CurrentSessionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedAcademicYear').find('option').remove().end().append('<option value>---Select Session---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#SelectedBranchID").change(function () {
            var selectedItem1 = $(this).val();
            var selectedItem2 = $("#SelectedCentreCode").val();
            var selectedItem3 = $("#SelectedUniversityID").val();

            var $ddlSectionDetails = $("#SelectedSectionDetailID");
            var $SectionDetailsProgress = $("#states-loading-progress");
            $SectionDetailsProgress.show();
            if ($("#SelectedBranchID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCard/GetSectionDetails",
                    data: { "SelectedBranchID": selectedItem1, "CentreCode": selectedItem2, "UniversityID": selectedItem3 },
                    success: function (data) {
                        $ddlSectionDetails.html('');
                        $ddlSectionDetails.append('<option value="">--Select Section--</option>');
                        $.each(data, function (id, option) {
                            $ddlSectionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $SectionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Section.');
                        $SectionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedSectionDetailID').find('option').remove().end().append('<option value>---Select Section---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#SelectedSectionDetailID").change(function () {
            var selectedItem1 = $(this).val();
            if (selectedItem1 != "") {
                $("#ShowStudentList").fadeIn(1000);

            }
            else {
                $("#DivStudentListInfo").fadeOut(1000);
                $("#ShowStudentList").fadeOut(1000);
            }
        });

        // Create new record



        $("#SelectedUniversityID").change(function () {
          
            var selectedItem1 = $(this).val();
            var selectedItem = $("#SelectedCentreCode").val();

            var $ddlBranchDetails = $("#SelectedBranchID");
            var $BranchDetailsProgress = $("#states-loading-progress");
            $BranchDetailsProgress.show();
            if ($("#SelectedUniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCard/GetBranchDetails",

                    data: { "CentreCode": selectedItem, "UniversityID": selectedItem1 },
                    success: function (data) {
                        $ddlBranchDetails.html('');
                        $ddlBranchDetails.append('<option value="">--Select Course--</option>');
                        $.each(data, function (id, option) {

                            $ddlBranchDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $BranchDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Branch.');
                        $BranchDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedBranchID').find('option').remove().end().append('<option value>---Select Branch---</option>');
                $('#btnCreate').hide();
            }
        });
        $('#ShowStudentList').on("click", function () {

          
            var selectedItem1 = $("#SelectedSectionDetailID").val();
            var selectedItem2 = $("#SelectedCentreCode").val();
            var selectedItem3 = $("#SelectedAcademicYear").val();
            var selectedItem4 = $("#SelectedUniversityID").val();
            var selectedItem5 = $("#SelectedBranchID").val();
            StudentIdentityCard.LoadList111(selectedItem1, selectedItem2, selectedItem3, selectedItem4, selectedItem5);

            //$('#myDataTable').load('/StudentIdentityCard/AjaxHandler?sectionDetailsID=' + selectedItem1 + '&centreCode=' + selectedItem2 + '&AcademicYear=' + selectedItem3,);
            //$.ajax({
            //    cache: false,
            //    type: "GET",
            //    data: { "sectionDetailsID": selectedItem1, "CentreCode": selectedItem2, "AcademicYear": selectedItem3 },
            //    dataType: "html",
            //    url: "/StudentIdentityCard/List",
                
            //    success: function (data) {
            //        alert(data);
            //        ('#ListViewModel').html(data);
            //    },

            //});

        });


        //$('#SaveStudentIdentityCardRecord').on("click", function () {
        //    
        //    StudentIdentityCard.ActionName = "Edit";
        //    StudentIdentityCard.AjaxCallStudentIdentityCard();
        //});

        $('#SaveStudentIdentityCardRecord').on("click", function () {
            
            StudentIdentityCard.ActionName = "Save";
            StudentIdentityCard.AjaxCallStudentIdentityCard();
        });

       

        // Create new record
        //$('#CreateStudentIdentityCardRecord').on("click", function () {
        //    StudentIdentityCard.ActionName = "Create";

        //    StudentIdentityCard.getDataFromDataTable();
        //    StudentIdentityCard.AjaxCallStudentIdentityCard();
        //});

        //$('#EditStudentIdentityCardRecord').on("click", function () {

        //    StudentIdentityCard.ActionName = "Edit";
        //    StudentIdentityCard.AjaxCallStudentIdentityCard();
        //});

        //$('#DeleteStudentIdentityCardRecord').on("click", function () {

        //    StudentIdentityCard.ActionName = "Delete";
        //    StudentIdentityCard.AjaxCallStudentIdentityCard();
        //});

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

        InitAnimatedBorder();
        CloseAlert();
        //$(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/StudentIdentityCard/List',
          //   data: { "sectionDetailsID": selectedItem1, "centreCode": selectedItem2, "AcademicYear": selectedItem3 },
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
            url: '/StudentIdentityCard/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadList111: function (SelectedSectionDetailID, SelectedCentreCode, SelectedAcademicYear, SelectedUniversityID, SelectedBranchID) {

        //var selectedText = $('#SelectedUniversityID').text();
        //var selectedVal = $('#SelectedUniversityID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centreCode: SelectedCentreCode, sectionDetailsID: SelectedSectionDetailID, AcademicYear: SelectedAcademicYear, UniversityID: SelectedUniversityID,BranchID: SelectedBranchID },

              dataType: "html",
              url: '/StudentIdentityCard/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
                  $("#StudentList_Div").show(true);


              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallStudentIdentityCard: function () {
        var StudentIdentityCardData = null;
        if (StudentIdentityCard.ActionName == "Save") {
            //$("#FormEditStudentIdentityCard").validate();
            //if ($("#FormEditStudentIdentityCard").valid()) {
                StudentIdentityCardData = null;
                StudentIdentityCardData = StudentIdentityCard.GetStudentIdentityCard();
                ajaxRequest.makeRequest("/StudentIdentityCard/StudentInfoSave", "POST", StudentIdentityCardData, StudentIdentityCard.createSuccess);
            //}
        }
        //else if (StudentIdentityCard.ActionName == "Edit") {
        //    $("#FormEditStudentIdentityCard").validate();
        //    if ($("#FormEditStudentIdentityCard").valid()) {
        //        StudentIdentityCardData = null;
        //        StudentIdentityCardData = StudentIdentityCard.GetStudentIdentityCard();
        //        ajaxRequest.makeRequest("/StudentIdentityCard/StudentInfo", "POST", StudentIdentityCardData, StudentIdentityCard.editSuccess);
        //    }
        //}
        else if (StudentIdentityCard.ActionName == "Delete") {
            StudentIdentityCardData = null;
            //$("#FormCreateStudentIdentityCard").validate();
            StudentIdentityCardData = StudentIdentityCard.GetStudentIdentityCard();

            ajaxRequest.makeRequest("/StudentIdentityCard/Delete", "POST", StudentIdentityCardData, StudentIdentityCard.deleteSuccess);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetStudentIdentityCard: function () {
        
        var Data = {
        };
        if (StudentIdentityCard.ActionName == "Save") {
            //Student upload
            //For Image
            var StudentPhotoFileSize = null;
            var StudentPhotoType = null;
            var StudentPhotoFilename = null;
            var StudentPhotoFileWidth = null;
            var StudentPhotoFileHeight = null;
            
            var img = document.getElementById('previewStudentPhoto');
            if ($("#StudentPhotoFile").val() != "") {
                if (typeof ($("#StudentPhotoFile")[0].files) != "undefined") {
                    StudentPhotoFileSize =$("#StudentPhotoFile")[0].files[0].size;
                  //  StudentPhotoFileSize = parseFloat($("#StudentPhotoFile")[0].files[0].size / 1024).toFixed(2);
                    StudentPhotoType = $('#StudentPhotoFile')[0].files[0].type;
                    StudentPhotoFilename = $('#StudentPhotoFile')[0].files[0].name;
                    StudentPhotoFileWidth = img.width;
                    StudentPhotoFileHeight = img.height;
                }

                
                if (StudentPhotoType == "image/jpeg") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/jpeg;base64,/g, '');
                }
                else if (StudentPhotoType == "image/png") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/png;base64,/g, '');
                }
                else if (StudentPhotoType == "image/gif") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/gif;base64,/g, '');
                }
                else if (StudentPhotoType == "image/jpg") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/jpg;base64,/g, '');
                }
                else if (StudentPhotoType == "image/bmp") {
                    Data.StudentPhoto = $('#previewStudentPhoto').attr('src').replace(/data:image\/bmp;base64,/g, '');
                }

                Data.StudentPhotoType = StudentPhotoType;
                Data.StudentPhotoFilename = StudentPhotoFilename;
                Data.StudentPhotoFileWidth = StudentPhotoFileWidth;
                Data.StudentPhotoFileHeight = StudentPhotoFileHeight;
                Data.StudentPhotoFileSize = StudentPhotoFileSize;
            }

            var StudentSignatureFileSize = null;
            var StudentSignatureType = null;
            var StudentSignatureFilename = null;
            var StudentSignatureFileWidth = null;
            var StudentSignatureFileHeight = null;

            var img = document.getElementById('previewStudentSignature');
            if ($("#StudentSignatureFile").val() != "") {
                if (typeof ($("#StudentSignatureFile")[0].files) != "undefined") {
                    StudentSignatureFileSize = $("#StudentSignatureFile")[0].files[0].size;
                    //StudentSignatureFileSize = parseFloat($("#StudentSignatureFile")[0].files[0].size / 1024).toFixed(2);
                    StudentSignatureType = $('#StudentSignatureFile')[0].files[0].type;
                    StudentSignatureFilename = $('#StudentSignatureFile')[0].files[0].name;

                    StudentSignatureFileWidth = img.width;
                    StudentSignatureFileHeight = img.height;
                }

                
                if (StudentSignatureType == "image/jpeg") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/jpeg;base64,/g, '');
                }
                else if (StudentSignatureType == "image/png") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/png;base64,/g, '');
                }
                else if (StudentSignatureType == "image/gif") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/gif;base64,/g, '');
                }
                else if (StudentSignatureType == "image/jpg") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/jpg;base64,/g, '');
                }
                else if (StudentSignatureType == "image/bmp") {
                    Data.StudentSignature = $('#previewStudentSignature').attr('src').replace(/data:image\/bmp;base64,/g, '');
                }

                Data.StudentSignatureType = StudentSignatureType;
                Data.StudentSignatureFilename = StudentSignatureFilename;
                Data.StudentSignatureFileWidth = StudentSignatureFileWidth;
                Data.StudentSignatureFileHeight = StudentSignatureFileHeight;
                Data.StudentSignatureFileSize = StudentSignatureFileSize;
            }

            Data.StudentId = $('input[name=StudentId]').val();
            Data.PermanentAddressLine1 = $("#PermanentAddressLine1").val();
            Data.PermanentAddressLine2 = $("#PermanentAddressLine2").val();
            Data.CorrespondenceAddressLine1 = $("#CorrespondenceAddressLine1").val();
            Data.CorrespondenceAddressLine2 = $("#CorrespondenceAddressLine2").val();
            Data.Bloodgroup = $("#Bloodgroup").val();
            Data.StudentMobileNumber = $("#StudentMobileNumber").val();
            Data.ParentMobileNumber = $("#ParentMobileNumber").val();
            Data.StudentCode = $("#StudentCode").val();
            Data.DateOfBirth = $("#DateOfBirth").val();
            Data.StudentIdentificationMark = $("#StudentIdentificationMark").val();
        }

        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
        var splitData = data.split(',');
        //$('#SuccessMessage').html(splitData[0]);
        //$('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', splitData[1]);
        notify(splitData[0],"success");
    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    var splitdata = data.split("::");
    //    var splitCentreCode = splitdata[1].split(":");
    //    var splitUniversityID = splitdata[2].split(":");
    //    parent.$.colorbox.close();
    //    StudentIdentityCard.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List

    //    var splitdata = data.split("::");
    //    var splitCentreCode = splitdata[1].split(":");
    //    var splitUniversityID = splitdata[2].split(":");
    //    parent.$.colorbox.close();
    //    // StudentIdentityCard.ReloadList("Record Deleted Sucessfully.");
    //    StudentIdentityCard.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
};

