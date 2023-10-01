const GetBookingDetails = async () => {
    var Response;

    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7138/api/User/GetUserDetails",
            contentType: "application/json",
            data: {},
            async: false,
            success: function (data) {
                if (data != null && data.statusCode == 200) {
                    if (data.resultData.length > 0) {
                        var tbodydata = '';
                        $.each(data.resultData, function (key, value) {
                            tbodydata += '<tr>';
                            tbodydata += '<td>' + value.customerName + '</td>';
                            tbodydata += '<td>' + value.make + '</td>';
                            tbodydata += '<td>' + value.model + '</td>';
                            tbodydata += '<td>' + value.year + '</td>';
                            tbodydata += '<td>' + value.price + '</td>';
                            tbodydata += '<td>' + value.bookingDate + '</td>';
                            tbodydata += '<td>' + value.deliveryDate + '</td>';
                            tbodydata += '<td>' + value.cancelBooking + '</td>';
                            tbodydata += '<td>' + value.returnStatus + '</td>';
                          
                            tbodydata += '</tr>';
                        });
                        console.log(tbodydata);

                        $("#tblCandidates tbody").empty();
                        $("#tblCandidates tbody").append(tbodydata);
                    }
                }
            }
        });
    }
    catch (err) {
        await console.log(err);
    }

    return Response;
}

const GetBookingDetailsById = async (Id) => {

    var Response = 0;


    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7138/api/User/GetUserDetailsByIdAsync?id=" + Id,
            contentType: "application/json",
            data: { id: Id },
            async: false,
            success: function (data) {

                if (data != null && data.statusCode == 200) {
                    $('#hdnUserId').val(data.resultData.UserId);
                    $('#customerName').val(data.resultData.customerName);
                    $('#make').val(data.resultData.make);
                    $('#model').val(data.resultData.model);
                    $('#year').val(data.resultData.year);
                    $('#price').val(data.resultData.price);
                    $('#bookingDate').val(data.resultData.bookingDate);
                    $('#deliveryDate').val(data.resultData.deliveryDate);
                    $('#cancelBooking').val(data.resultData.cancelBooking);
                    $('#specialization').val(data.resultData.specialization);
                    $('returnStatus').val(data.resultData.returnStatus);
                }
            }

        });
    }
    catch (err) {
        await console.log(err);
    }

    return Response;
}

const SaveOrUpdateBooking = async (Id) => {
    var Response = 0;
    // alert(Id);
    var data = {
        UserId: Id,
        UserName: $('#userName').val(),
        Email: $('#email').val(),
        Address: $('#address').val(),
        DOB: new Date($('#dob').val()),
        GenderId: $('#genderId').val(),
        MobileNo: $('#mobileNo').val(),
        Qualification: $('#qualification').val(),
        Specialization: $('#specialization').val(),


    }
    console.log('data', data);
    alert()
    $.ajax({
        type: 'POST',
        url: "https://localhost:7138/api/User/InsertUserDetailsAsync",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (data) {
            console.log('data', data);
            alert("save success")
            if (data != null && data.statusCode == 200) {
                window.location.href = "/Administrations/Administrations";
            }
        }
    });
}