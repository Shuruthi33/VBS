const GetFeedbackDetails = async () => {
    var Response;

    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/Feedback/GetFeedbackDetailsAsync",
            contentType: "application/json",
            data: {},
            async: true,
            success: function (data) {
                if (data != null && data.statusCode == 200) {
                    if (data.resultData.length > 0) {
                        var tbodydata = '';
                        $.each(data.resultData, function (key, value) {
                            tbodydata += '<tr>';
                            tbodydata += '<td>' + value.feedbackId + '</td>';
                            tbodydata += '<td>' + value.rating + '</td>';
                            tbodydata += '<td>' + value.comment + '</td>';
                            tbodydata += '<td>' + value.bookingId + '</td>';
                            tbodydata += '<td>' + value.customerId + '</td>';
                            tbodydata += '<td>' + value.customerName + '</td>';
                            tbodydata += '<td>' + value.make + '</td>';
                            tbodydata += '<td>' + value.model + '</td>';
                            tbodydata += '<td> <a href = "/AddCandidate?feedbackId=' + value.feedbackId + '"><span <i class="mdi mdi-border-color"></i> type="button" title="Edit"></span></a><a href = "#"onclick="DeleteCustomerById(' + value.feedbackId + ')"><span <i class="mdi mdi-delete-forever"></i> type="button" title="Delete"></span></a></td>';
                            tbodydata += '</tr>';
                        });
                        console.log(tbodydata);

                        $("#tblFeedback tbody").empty();
                        $("#tblFeedback tbody").append(tbodydata);
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

const SaveOrUpdateFeedback = async (Id) => {
    var Response = 0;
    alert(Id);
    var data = {
        feedbackId: feedbackId,
        bookingId: $('#customerId').val(),
        rating: $('#vehicleId').val(),
        comment: $('#bookingDate').val(),
       
    }
    console.log('data', data);
    alert()
    $.ajax({
        type: 'POST',
        url: "https://localhost:7011/api/Feedback/SaveFeedbackDetailsAsync",
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

const DeleteCustomerById = async (Id) => {
    var Response = 0;

    alert("ok");
    try {
        await $.ajax({
            type: 'DELETE',
            url: 'https://localhost:7011/api/Feedback/DeleteFeedbackDetailsAsync?Id=' + Id + '',
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
