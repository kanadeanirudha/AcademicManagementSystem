//////////////////////////////////////////////////////////////////////
////////////////-- Page load --//////////////////
//////////////////////////////////////////////////////////////////////
$(function () {
    LoadList();
});

//////////////////////////////////////////////////////////////////////
////////////////-- Load List by Get() method --//////////////////
//////////////////////////////////////////////////////////////////////
function LoadList() {

    $.ajax(
        {
            cache: false,
            type: "POST",
            data: { centerCode: 1 },
            dataType: "html",
            url: '/AccountBalancesheetMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
}

///////////////////////////////////////////////////////////////////////////
//////////////-- load List According to Centre Code by Ajax--//////////////
///////////////////////////////////////////////////////////////////////////



//$('#Centre_Name').on("change", function (e) {

//    alert("Mohit Kumar Modi");
//    LoadListByCentreCode($('#Centre_Name :selected').val());
//});

function LoadListByCentreCode(SelectedCentreCode) {

    $.ajax(
        {
            cache: false,
            type: "POST",
            data: { centerCode: SelectedCentreCode },
            dataType: "html",
            url: '/AccountBalancesheetMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
}





//////////////////////////////////////////////////////////////////////
//////////////-- Reload List by Ajax--//////////////////////////////
//////////////////////////////////////////////////////////////////////

function ReloadList1(message) {
    location.reload();
}

function ReloadList(message) {
    var selectedCentreCode = $('#SelectedCentreCode').val();
    $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { centerCode: selectedCentreCode },
            url: '/AccountBalancesheetMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#commonMessage').html(message).css('color', '#FFFFFF');
                $('#commonMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', '#5C8AE6');
            }
        });
}

//////////////////////////////////////////////////////////////////////
//////-- Show Success Message after Add New Record --//////
//////////////////////////////////////////////////////////////////////
function createSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dailogPopUp').dialog('close');

        //alert("Message called");
        //Reload List
        ReloadList("Balance Sheet Created Sucessfully.");

    } else {
        $("#update-message").show();
    }
}

//////////////////////////////////////////////////////////////////////
//////-- Show Success Message after Edit Record --///////////
//////////////////////////////////////////////////////////////////////
function editSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#dialog-edit').dialog('close');

        //Reload List
        ReloadList("Balance Sheet Updated Sucessfully.");

    } else {
        $("#update-message").show();
    }
}


////////////////////////////////////////////////////////////////////////
////////-- Show Success Message after Edit Record --///////////
////////////////////////////////////////////////////////////////////////

function deleteSuccess() {

    if ($("#update-message").html() == "True") {

        //now we can close the dialog
        $('#delete-dialog').dialog('close');

        //Reload List
        ReloadList("Balance Sheet Deleted Sucessfully.");

    } else {
        $("#update-message").show();
    }
}



//var accBalanceSheetMaster = {
//    myGlobalVariable: null,
//    initialize: function () {
//        accBalanceSheetMaster.attachEvents();
//        //accBalanceSheetMaster.clearInsertView();
//        //accBalanceSheetMaster.initializeValidation();
//        alert("This is Called JSON formated js");
//    },
//    attachEvents: function () {
//        oTable = $('#myDataTable').dataTable();
//        $('#myDataTable thead th').click(function () {
//            /* Get the position of the current data from the node */
//            var aPos = oTable.fnGetPosition(this);
//            alert(aPos);
//            /* Get the data array for this row */
//            var aData = oTable.fnGetData(aPos[0]);
//            alert(aData);
//            /* Update the data array and return the value */
//            aData[aPos[1]] = 'clicked';
//            this.innerHTML = 'clicked';
//        });



//        var $mDT = $('#myDataTable thead');
//        $('#myDataTable thead .sorting_asc').click(function () {
//            debugger;
//            alert($('#myDataTable thead .sorting_asc').html());
//        });
//    }

//};

