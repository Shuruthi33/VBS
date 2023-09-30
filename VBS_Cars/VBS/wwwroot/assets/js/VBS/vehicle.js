const GetVehicleDetails = async () => {
    var Response;

    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/Vehicle/GetVehicleDetailsAsync",
            contentType: "application/json",
            headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
            /// localStorage.setItem('token',(res.token))
            data: {},
            async: false,
            success: function (data) {
                if (data != null && data.statusCode == 200) {
                    if (data.resultData.length > 0) {
                        var tbodydata = '';
                        $.each(data.resultData, function (key, value) {
                            tbodydata += '<tr>';
                            tbodydata += '<td>' + value.make + '</td>';
                            tbodydata += '<td>' + value.model + '</td>';
                            tbodydata += '<td>' + value.year + '</td>';
                            tbodydata += '<td>' + value.price + '</td>';
                            tbodydata += '<td>' + value.mileage + '</td>';
                            tbodydata += '<td>' + value.licensePlate + '</td>';
                            tbodydata += '<td>' + value.colour + '</td>';
                            tbodydata += '<td>' + value.vin + '</td>';
                            tbodydata += '<td>' + value.engineType + '</td>';
                            tbodydata += '<td>' + value.engineSize + '</td>';
                            tbodydata += '<td>' + value.fuelType + '</td>';
                            tbodydata += '<td>' + value.fuelTank + '</td>';
                            tbodydata += '<td>' + value.seatingCapacity + '</td>';
                            tbodydata += '<td>' + value.condition + '</td>';
                            tbodydata += '<td>' + value.features + '</td>';
                            tbodydata += '<td>' + value.versionName + '</td>';
                            tbodydata += '<td>' + value.exShowroomPrice + '</td>';
                            tbodydata += '<td>' + value.rto + '</td>';
                            tbodydata += '<td>' + value.insurance + '</td>';
                            tbodydata += '<td>' + value.availability + '</td>';
                          

                            tbodydata += '</tr>';
                        });
                        console.log(tbodydata);

                        $("#tblVehicle tbody").empty();
                        $("#tblVehicle tbody").append(tbodydata);
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