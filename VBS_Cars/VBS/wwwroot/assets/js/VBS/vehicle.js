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

const GetVehicleDetailsById = async (Id) => {

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
                    $('#hdnVehicleId').val(data.resultData.VehicleId);
                    $('#carMakeDropdown').val(data.resultData.make);
                    $('#carModel').val(data.resultData.year);
                    $('#year').val(data.resultData.price);
                    $('#mileage').val(data.resultData.mileage);
                    $('#licensePlate').val(data.resultData.licensePlate);
                    $('#colour').val(data.resultData.colour);
                    $('#fuelTank').val(data.resultData.fuelTank);
                    $('#engineType').val(data.resultData.engineType);
                    $('#engineSize').val(data.resultData.engineSize);
                    $('image').val(data.resultData.image);
                    $('seatingCapacity').val(data.resultData.seatingCapacity);
                    $('condition').val(data.resultData.condition);
                    $('features').val(data.resultData.features);
                    $('versionName').val(data.resultData.versionName);
                    $('exShowroomPrice').val(data.resultData.exShowroomPrice);
                    $('rto').val(data.resultData.roleId);
                    $('insurance').val(data.resultData.insurance);
                    $('availability').val(data.resultData.availability);


                }
            }

        });
    }
    catch (err) {
        await console.log(err);
    }

    return Response;
}

const AddVehicleDetails = async () => {
    try {
        var fueltype1;
        if ($("#customRadio1").prop("checked")) {
            fueltype1 = "Petrol";
        }
        if ($("#customRadio2").prop("checked")) {
            fueltype1 = "Diesel";
        }
        if ($("#customRadio3").prop("checked")) {
            fueltype1 = "Electric";
        }

       // var datas = new FormData();

        //datas.append("VehicleId", $('#hdnVehicleId').val());

        var data = {
            VehicleId: $('#hdnVehicleId').val(),
            Make: $('#carMakeDropdown').val(),
            model: $('#carModel').val(),
            Year: $('#year').val(),
            Price: $('#price').val(),
            Mileage: $('#mileage').val(),
            LicensePlate: $('#licensePlate').val(),
            Colour: $('#colour').val(),
            VIN: $('#vin').val(),
            EngineType: $('#engineType').val(),
            EngineSize: $('#engineSize').val(),
            FuelTank: $('#fuelTank').val(),
            FuelType: fueltype1,
            imageUrl: $('#image').val(),
            seatingCapacity: $('#seatingCapacity').val(),
            condition: $('#condition').val(),
            features: $('#features').val(),
            versionName: $('#versionName').val(),
            exShowroomPrice: $('#exShowroomPrice').val(),
            rto: $('#rto').val(),
            insurance: $('#insurance').val(),
            availability: $('#availability').val(),
        }

        var response = await $.ajax({
            type: 'POST', // Assuming you want to use POST method
            url: "https://localhost:7011/api/Vehicle/SaveVehicleDetailsAsync",
            processData: false,
            contentType: false,
            headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
            data: datas,
            async: false,
            dataType: "json"
        });

        if (response != null && response.statusCode == 200) {
            $("#errmsg").text("Success");
        } else {
            $("#errmsg").text("Failed");
        }
    } catch (err) {
        console.log(err);
    }
}

const DeleteVehicleById = async (Id) => {
    var Response = 0;


    try {
        await $.ajax({
            type: 'DELETE',
            url: 'https://localhost:7138/api/User/DeleteUserDetailsByIdAsync?id=' + Id + '',
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



