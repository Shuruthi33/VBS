const GetBookingDetails = async () => {
    var Response;

    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/Booking/GetBookingDetailsAsync",
            contentType: "application/json",
            data: {},
            async : true,
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
                            tbodydata += '<td> <a href = "/AddCandidate?UserId=' + value.bookingId + '"><span class="mdi mdi-border-color" type="button" title="Edit"></span></a><a href = "#"onclick="DeleteCandidateById(' + value.bookingId + ')"><span class="mdi mdi-delete-forever" type="button" title="Delete"></span></a></td>';
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
            url: "https://localhost:7011/api/Booking/GetBookingDetailsByIdAsync?id=" + Id,
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
     alert(Id);
    var data = {
        bookingId: bookingId,
        customerId: $('#customerId').val(),
        vehicleId: $('#vehicleId').val(),
        bookingDate: $('#bookingDate').val(),
        deliveryDate: $('#deliveryDate').val(),
        cancelBooking: $('#cancelBooking').val(),
        returnStatus: $('#returnStatus').val(),
    }
    console.log('data', data);
    alert()
    $.ajax({
        type: 'POST',
        url: "https://localhost:7011/api/Booking/SaveBookingDetailsAsync",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: false,
        success: function (data) {
            console.log('data', data);
            alert("save success")
            if (data != null && data.statusCode == 200) {
                window.location.href = "/Booking/GridBooking";
            }
        }
    });
}

const DeleteBookingById = async (Id) => {
    var Response = 0;

    alert("ok");
    try {
        await $.ajax({
            type: 'DELETE',
            url: 'https://localhost:7011/api/Booking/DeleteBookingDetailsAsync' + Id + '',
            contentType: "application/json",
            data: { id: Id },
            async: false,
            success: function (data) {
                if (data != null && data.statusCode == 200) {
                    alert("Deletd Sucessfully");
                    GetVehicleDetails();
                }
            }
        });
    }
    catch (err) {
        await console.log(err);
    }

    return Response;

}