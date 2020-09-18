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

