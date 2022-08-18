/*==========================
TOUCHY SCROLL FOR SIDEBAR
==========================*/

$(function () {
    // load accordion menu src 
    $('.accordion_mnu').initMenu();

    // load nicescroll menu 
    $("#sidebar").niceScroll({
        cursorcolor: "#2f2e2e",
        cursoropacitymax: 0.7,
        boxzoom: false,
        touchbehavior: true
    });

   
    // Load check unckeck checkbox in listing
   // $('#selectAll').checkUnchekAll();

});




/*$(document).ajaxStart(function() {
	 $('#ajaxLoading').show();
});
$(document).ajaxStop(function() {
	$('#ajaxLoading').hide();	
	// load close	
	$.closeMsg();
	// Load check unckeck checkbox in listing
	$('#selectAll').checkUnchekAll();
});


$(function () {	
	// load accordion menu src 
	$('.accordion_mnu').initMenu();
	
	// load nicescroll menu 
	$("#sidebar").niceScroll({
	    cursorcolor: "#2f2e2e",
	    cursoropacitymax: 0.7,
	    boxzoom: false,
	    touchbehavior: true
	});
	
	// load close
	$.closeMsg();
	// Load check unckeck checkbox in listing
	$('#selectAll').checkUnchekAll();
	
});


$.closeMsg = function() {
	$("#close").click(function(){
		 $(this).parents("#closemessage").animate({ opacity: 'hide' }, "slow");
	});
};


$.fn.checkUnchekAll = function() {
	// check and uncheck all
	$('#selectAll').click(function(event) {  //on click
		//alert('in select all'); return false;
        if(this.checked) { // check select status
            $('.listRowCheckbox').each(function() { //loop through each checkbox
                this.checked = true;  //select all checkboxes with class "checkbox1"              
            });
        }else{
            $('.listRowCheckbox').each(function() { //loop through each checkbox
                this.checked = false; //deselect all checkboxes with class "checkbox1"                      
            });        
        }
    });
	
	$('.listRowCheckbox').click(function(event) {		
        if(this.checked == false) {
        	if($("#selectAll").is(':checked')) {
        		$("#selectAll").attr('checked', false);
        	}
        }
    });
};

//This is used to submit a search for on listing pages
$.fn.searchSubmit = function(options) {	
	var settings = $.extend({
		clickid: "",
		formname: ""
	}, options );	
	
	$("#"+settings.clickid).bind("click", function (event) {
		$.ajax({data:$("#"+settings.formname).serialize(), dataType:"html", success:function (data, textStatus) {$("#main-content").html(data);}, type:"post", url:$("#"+settings.formname).attr('action')});
		return false;
	});
};

// This is used to submit a bulk submit form on listing pages
$.fn.bulkSubmit = function(options) {	
	var settings = $.extend({
		bulkclick: "",
		formname: "",
		bulktype: "",
		confirm: ""
	}, options );
	
	$("#"+settings.bulkclick).bind("click", function (event) {
		$("#bulkType").val(parseInt(settings.bulktype));
		var _confirm = confirm("Are you sure? want to " +settings.confirm+" ?");
		if (!_confirm) {
			return false;
		}
		
		$.ajax({data:$("#"+settings.formname).serialize(), dataType:"html", success:function (data, textStatus) {$("#main-content").html(data);}, type:"post", url:$("#"+settings.formname).attr('action')});
		return false;
	});
};
	*/