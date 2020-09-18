'use strict'
let current_fs, next_fs, previous_fs; //fieldsets
let left, opacity, scale; //fieldset properties which we will animate
let animating; //flag to prevent quick multi-click glitches

$(".next").click(function () {
	if (animating) return false;
	animating = true;

	current_fs = $(this).parent();
	next_fs = $(this).parent().next();

	//activate next step on progressbar using the index of next_fs
	$(".progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

	//show the next fieldset
	next_fs.show();
	//hide the current fieldset with style
	current_fs.animate({ opacity: 0 }, {
		step: function (now, mx) {
			//as the opacity of current_fs reduces to 0 - stored in "now"
			//1. scale current_fs down to 80%
			scale = 1 - (1 - now) * 0.2;
			//2. bring next_fs from the right(50%)
			left = (now * 50) + "%";
			//3. increase opacity of next_fs to 1 as it moves in
			opacity = 1 - now;
			current_fs.css({
				'transform': 'scale(' + scale + ')',
				'position': 'absolute'
			});
			next_fs.css({ 'left': left, 'opacity': opacity });
		},
		duration: 800,
		complete: function () {
			current_fs.hide();
			animating = false;
		},
		//this comes from the custom easing plugin
		easing: 'easeInOutBack'
	});
});

$(".previous").click(function () {
	if (animating) return false;
	animating = true;

	current_fs = $(this).parent();
	previous_fs = $(this).parent().prev();

	//de-activate current step on progressbar
	$(".progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

	//show the previous fieldset
	previous_fs.show();
	//hide the current fieldset with style
	current_fs.animate({ opacity: 0 }, {
		step: function (now, mx) {
			//as the opacity of current_fs reduces to 0 - stored in "now"
			//1. scale previous_fs from 80% to 100%
			scale = 0.8 + (1 - now) * 0.2;
			//2. take current_fs to the right(50%) - from 0%
			left = ((1 - now) * 50) + "%";
			//3. increase opacity of previous_fs to 1 as it moves in
			opacity = 1 - now;
			current_fs.css({ 'left': left });
			previous_fs.css({ 'left': '50%', 'transform': 'scale(' + scale + ') translateX(-50%)', 'opacity': opacity });
		},
		duration: 800,
		complete: function () {
			current_fs.hide();
			animating = false;
		},
		//this comes from the custom easing plugin
		easing: 'easeInOutBack'
	});
});

$(".submit").click(function () {
	return false;
})



// to create more html inputs
var count = 1;
$(".addExperience").click(function () {
	//alert();
	if (count != 3) {
		count++;
		document.getElementById('genericBusinessExperience').innerHTML +='<br/>'
		'<div>'
		'< div class="row-form" >'
		'<div class="col-1-of-2">'
		'<div style="text-align:start !important;">'
		'<label class="custom-file-label m-0 p-0" style="font-size:small;">Company Worked with 1</label>'
		'</div>'
		'<input class="form-input" placeholder="Company Worked With" type="text" id="CompanyWorkedWith1" name="CompanyWorkedWith1" value="">'
		'<div id="validation"><span class="text-danger field-validation-valid" data-valmsg-for="CompanyWorkedWith1" data-valmsg-replace="true"></span></div>'
		'</div>'
		'<div class="col-1-of-2">'
		'<div style="text-align:start !important;">'
		'<label class="custom-file-label m-0 p-0" style="font-size:small;">Time Frame</label>'
		'</div>'
		'<input class="form-input" placeholder="Time Frame 1" type="text" id="TimeFrame1" name="TimeFrame1" value="">'
		'<div id="validation"><span class="text-danger field-validation-valid" data-valmsg-for="TimeFrame1" data-valmsg-replace="true"></span></div>'
		'</div>'

		'</div>'
		'<div class="row-form">'
		'<div class="col-1-of-2">'
		'<div style="text-align:start !important;">'
		'<label class="custom-file-label m-0 p-0" style="font-size:small;">Transaction Reference 1</label>'
		'</div>'
		'<div style="text-align:start !important;">'
		'<input class="form-input" placeholder="Transaction Reference" type="file" id="TransactionReference1" name="TransactionReference1">'
		'</div>'
		'<div id="validation"><span class="text-danger field-validation-valid" data-valmsg-for="TransactionReference1" data-valmsg-replace="true"></span></div>'
		'</div>'
		'<div class="col-1-of-2">'
		'<div style="text-align:start !important;">'
		'<label class="custom-file-label m-0 p-0" style="font-size:small;">Scope Covered 1</label>'
		'</div>'
		'<input class="form-input" placeholder="Customer Name" type="text" id="ScopeCovered1" name="ScopeCovered1" value="">'
		'<div id="validation"><span class="text-danger field-validation-valid" data-valmsg-for="ScopeCovered1" data-valmsg-replace="true"></span></div>'
		'</div>'

		'</div>'
		'</div><br/>';
		e.prventDefault();

	}
	else {
		alert("Cannot Create more than 3")

		e.prventDefault();
	}








});
	