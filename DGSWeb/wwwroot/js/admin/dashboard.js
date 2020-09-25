// Chart.js scripts
// -- Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';
// -- Area Chart Example
var ctx = document.getElementById("myAreaChart");
var myLineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Mar 1", "Mar 2", "Mar 3", "Mar 4", "Mar 5", "Mar 6", "Mar 7", "Mar 8", "Mar 9", "Mar 10", "Mar 11", "Mar 12", "Mar 13"],
        datasets: [{
            label: "Sessions",
            lineTension: 0.3,
            backgroundColor: "rgba(2,117,216,0.2)",
            borderColor: "rgba(2,117,216,1)",
            pointRadius: 5,
            pointBackgroundColor: "rgba(2,117,216,1)",
            pointBorderColor: "rgba(255,255,255,0.8)",
            pointHoverRadius: 5,
            pointHoverBackgroundColor: "rgba(2,117,216,1)",
            pointHitRadius: 20,
            pointBorderWidth: 2,
            data: [10000, 30162, 26263, 18394, 18287, 28682, 31274, 33259, 25849, 24159, 32651, 31984, 38451]
        }]
    },


    options: {
        scales: {
            xAxes: [{
                time: {
                    unit: 'date'
                },

                gridLines: {
                    display: false
                },

                ticks: {
                    maxTicksLimit: 7
                }
            }],


            yAxes: [{
                ticks: {
                    min: 0,
                    max: 40000,
                    maxTicksLimit: 5
                },

                gridLines: {
                    color: "rgba(0, 0, 0, .125)"
                }
            }]
        },



        legend: {
            display: false
        }
    }
});



// -- Bar Chart Example
var ctx = document.getElementById("myBarChart");
var myLineChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["January", "February", "March", "April", "May", "June"],
        datasets: [{
            label: "Revenue",
            backgroundColor: "rgba(2,117,216,1)",
            borderColor: "rgba(2,117,216,1)",
            data: [4215, 5312, 6251, 7841, 9821, 14984]
        }]
    },


    options: {
        scales: {
            xAxes: [{
                time: {
                    unit: 'month'
                },

                gridLines: {
                    display: false
                },

                ticks: {
                    maxTicksLimit: 6
                }
            }],


            yAxes: [{
                ticks: {
                    min: 0,
                    max: 15000,
                    maxTicksLimit: 5
                },

                gridLines: {
                    display: true
                }
            }]
        },



        legend: {
            display: false
        }
    }
});



// -- Pie Chart Example
var ctx = document.getElementById("myPieChart");
var myPieChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ["Blue", "Red", "Yellow", "Green"],
        datasets: [{
            data: [12.21, 15.58, 11.25, 8.32],
            backgroundColor: ['#007bff', '#dc3545', '#ffc107', '#28a745']
        }]
    }
});




$(document).ready(function () {
    $('#dataTable').DataTable();
});

(function ($) {
    "use strict"; // Start of use strict
    // Configure tooltips for collapsed side navigation
    $('.navbar-sidenav [data-toggle="tooltip"]').tooltip({
        template: '<div class="tooltip navbar-sidenav-tooltip" role="tooltip" style="pointer-events: none;"><div class="arrow"></div><div class="tooltip-inner"></div></div>'
    });

    // Toggle the side navigation
    $("#sidenavToggler").click(function (e) {
        e.preventDefault();
        $("body").toggleClass("sidenav-toggled");
        $(".navbar-sidenav .nav-link-collapse").addClass("collapsed");
        $(".navbar-sidenav .sidenav-second-level, .navbar-sidenav .sidenav-third-level").removeClass("show");
    });
    // Force the toggled class to be removed when a collapsible nav link is clicked
    $(".navbar-sidenav .nav-link-collapse").click(function (e) {
        e.preventDefault();
        $("body").removeClass("sidenav-toggled");
    });
    // Prevent the content wrapper from scrolling when the fixed side navigation hovered over
    $('body.fixed-nav .navbar-sidenav, body.fixed-nav .sidenav-toggler, body.fixed-nav .navbar-collapse').on('mousewheel DOMMouseScroll', function (e) {
        var e0 = e.originalEvent,
            delta = e0.wheelDelta || -e0.detail;
        this.scrollTop += (delta < 0 ? 1 : -1) * 30;
        e.preventDefault();
    });
    // Scroll to top button appear
    $(document).scroll(function () {
        var scrollDistance = $(this).scrollTop();
        if (scrollDistance > 100) {
            $('.scroll-to-top').fadeIn();
        } else {
            $('.scroll-to-top').fadeOut();
        }
    });
    // Configure tooltips globally
    $('[data-toggle="tooltip"]').tooltip();
    // Smooth scrolling using jQuery easing
    $(document).on('click', 'a.scroll-to-top', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        },
            1000, 'easeInOutExpo');
        event.preventDefault();
    });
})(jQuery); // End of use strict
//# sourceURL=pen.js


/*To show modal*/
$(document).ready(function () {
    $('#confirmDisapproval').click(function (e) {
        e.preventDefault();
        $('#disapprovalModal').modal('show');

        target = e.target;
        var VendorId = $(target).data('id');

        $("#disapprovalHiddenVendorId").val(VendorId);


        //console.log(VendorId);

    });
})

$('#Disapprove').click(function () {
    var venId = $("#disapprovalHiddenVendorId").val();
    var actionLink = "/Admin/DisapproveVendor?id=" + venId

    window.location.href = actionLink;

    //$.get(actionLink).done((result) => {
    //    window.location.href = 'https://localhost:44366/admin/vendorlist';
    //    $("#disapprovalModal").modal('hide');
    //});
})




$(document).ready(function () {
    $('#confirmApproval').click(function (e) {
        e.preventDefault();
        $('#approvalModal').modal('show');

        target = e.target;
        var VendorId = $(target).data('id');

        $("#approvalHiddenVendorId").val(VendorId);


        //console.log(VendorId);

    });
})

$('#Approve').click(function () {
    var venId = $("#approvalHiddenVendorId").val();
    var actionLink = "/Admin/ApproveVendor?id=" + venId

    //console.log(actionLink);

    window.location.href = actionLink;

    //$.get(actionLink).done((result) => {
    //    window.location.href = 'https://localhost:44366/admin/vendorlist';
    //    $("#approvalModal").modal('hide');
    //});
})



$(document).ready(function () {
    $('#query').click(function (e) {
        e.preventDefault();
        $('#queryModal').modal('show');

        target = e.target;
        var VendorEmail = $(target).data('id');

        $("#queryVendorEmail").val(VendorEmail);


        console.log(VendorEmail);

    });
})


$('#SendQuery').click(function () {
    var VendorEmail = $("#queryVendorEmail").val();
    var queryString = $(".queryTextarea").val();
    var vendorFormID = $("#queryVendorFormID").val();

    //console.log(VendorEmail);
    //console.log(queryString);


    if (VendorEmail != null && queryString != "" && vendorFormID != null)
    {
        var actionLink = "/Admin/QueryVendor" +
            '?email=' + VendorEmail +
            '&query=' + queryString +
            '&id=' + vendorFormID;

        //console.log(actionLink);

        window.location.href = actionLink;

    }

    else {
        alert("You have to supply query Message!")
    }
   
    //$.get(actionLink).done((result) => {
    //    window.location.href = 'https://localhost:44366/admin/vendorlist';
    //    $("#approvalModal").modal('hide');
    //});
})





// jQuery time
var current_fs, next_fs, previous_fs; // fieldsets
var left, opacity, scale; // fieldset properties which we will animate
var animating; // flag to prevent quick multi-click glitches

jQuery(".next").click(
    function () {
        if (animating) {
            return false;
        }
        animating = true;

        current_fs = jQuery(this).parent();
        next_fs = jQuery(this).parent().next();

        // activate next step on progressbar using the index of next_fs
        jQuery(".progressbar li").eq(jQuery("fieldset").index(next_fs)).addClass("active");

        // show the next fieldset
        next_fs.show();
        // hide the current fieldset with style
        current_fs.animate(
            { opacity: 0 },
            {
                step: function (now, mx) {
                    // as the opacity of current_fs reduces to 0 - stored in "now"
                    // 1. scale current_fs down to 80%
                    scale = 1 - (1 - now) * 0.2;
                    // 2. bring next_fs from the right(50%)
                    left = (now * 50) + "%";
                    // 3. increase opacity of next_fs to 1 as it moves in
                    opacity = 1 - now;
                    current_fs.css(
                        {
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        }
                    );
                    next_fs.css({ 'left': left, 'opacity': opacity });
                },
                duration: 800,
                complete: function () {
                    current_fs.hide();
                    current_fs.css({ 'position': 'relative' });
                    next_fs.css({ 'position': 'relative' });
                    animating = false;
                },
                // this comes from the custom easing plugin
                easing: 'easeInOutBack'
            }
        );
    }
);

jQuery(".previous").click(
    function () {
        if (animating) {
            return false;
        }
        animating = true;

        current_fs = jQuery(this).parent();
        previous_fs = jQuery(this).parent().prev();

        // de-activate current step on progressbar
        jQuery(".progressbar li").eq(jQuery("fieldset").index(current_fs)).removeClass("active");

        // show the previous fieldset
        previous_fs.show();
        previous_fs.css({ 'position': 'absolute' });

        // hide the current fieldset with style
        current_fs.animate(
            { opacity: 0 },
            {
                step: function (now, mx) {
                    // as the opacity of current_fs reduces to 0 - stored in "now"
                    // 1. scale previous_fs from 80% to 100%
                    scale = 0.8 + (1 - now) * 0.2;
                    // 2. take current_fs to the right(50%) - from 0%
                    left = ((1 - now) * 50) + "%";
                    // 3. increase opacity of previous_fs to 1 as it moves in
                    opacity = 1 - now;
                    current_fs.css({ 'left': left });
                    previous_fs.css({ 'transform': 'scale(' + scale + ')', 'opacity': opacity });
                },
                duration: 800,
                complete: function () {
                    current_fs.hide();
                    previous_fs.css({ 'position': 'relative' });
                    animating = false;
                },
                // this comes from the custom easing plugin
                easing: 'easeInOutBack'
            }
        );
    }
);

jQuery(".submit").click(
    function () {
        return false;
    }
);


