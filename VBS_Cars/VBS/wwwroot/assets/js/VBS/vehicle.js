const GetVehicleDetails = async () => {
    try {
        var Response = await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/Vehicle/GetVehicleDetailsAsync",
            contentType: "application/json",
            //  headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
            data: {},
            async: false,
            success: function (data) {
                if (data != null && data.statusCode == 200) {
                    if (data.resultData.length > 0) {
                        var tbodydata = '';
                        $.each(data.resultData, function (key, value) {
                            tbodydata += '<tr>';
                            tbodydata += '<td> <a href = "/Vehicle/AddVehicle?VehicleId=' + value.vehicleId + '"><span class="mdi mdi-border-color" type="button" title="Edit"></span></a><a href = "#"onclick="DeleteVehicleById(' + value.vehicleId + ')"><span class="mdi mdi-delete-forever" type="button" title="Delete"></span></a></td>';

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

                        $("#tblVehicle tbody").empty();
                        $("#tblVehicle tbody").append(tbodydata);
                    }
                }
            }
        });

        return Response;
    } catch (err) {
        console.log(err);

        return Response; // or throw an error
    }
}

const GetVehicleDetailsForBooking = async () => {
    try {
        var Response = await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/Vehicle/GetVehicleDetailsAsync",
            contentType: "application/json",
            //headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
            data: {},
            async: false,
            success: function (data) {
                if (data != null && data.statusCode == 200) {
                    if (data.resultData.length > 0) {
                        var tbodydata = '';
                        $.each(data.resultData, function (key, value) {
                            var cardData = '<div class="card mb-4 mr-2">';
                            cardData += '<img src="/assets/images/elements/Highlander.jpeg" />';
                            cardData += '<div class="card-body">';
                            cardData += '<h5 class="card-title">' + value.make + ' ' + value.model + '</h5>';
                            cardData += '<p class="card-text">' + value.features + '</p>';
                            cardData += '<ul class="list-group list-group-flush">';
                            cardData += '<li class="list-group-item">Engine: ' + value.engineSize + '</li>';
                            cardData += '<li class="list-group-item">Color: ' + value.colour + '</li>';
                            cardData += '<li class="list-group-item">Fuel Type: ' + value.fuelType + '</li>';
                            cardData += '<li class="list-group-item">Fuel Tank: ' + value.fuelTank + '</li>';
                            cardData += '<li class="list-group-item">Mileage:' + value.mileage + '</li>';
                            cardData += '<li class="list-group-item">Engine Type:' + value.engineType + '</li>';
                            cardData += '<li class="list-group-item">Ex Showroom Price: $' + value.exShowroomPrice + '</li>';
                            cardData += '<li class="list-group-item">RTO: $' + value.rto + '</li>';
                            cardData += '<li class="list-group-item">Insurance: $' + value.insurance + '</li>';
                            cardData += '<li class="list-group-item">On-Road Price: $' + (value.exShowroomPrice + value.rto + value.insurance) + '</li>';
                            cardData += '</ul>';
                            cardData += '<a href="/booking/addbookingnew?VehicleId=' + value.vehicleId + '" class="btn btn-outline-primary btn-pill mt-3"> Book Now</a>';
                            cardData += '</div></div>';

                            $("#cardContainer").append(cardData); // Assuming you have a container with id "cardContainer"
                        });

                    }
                }
            }
        });

        return Response;
    } catch (err) {
        console.log(err);

        return Response; // or throw an error
    }
}

const GetVehicleDetailsById = async (Id) => {

    var Response = 0;

    var data = { id: Id };

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

const GetVehicleDetailsByIdForBooking = async (Id) => {

    var Response = 0;


    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7138/api/User/GetUserDetailsByIdAsync?id=" + Id,
            contentType: "application/json",
            data: { id: Id },
            async: false,
            success: function (data) {
                debugger;
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
        debugger;
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

        var dataaz = {
            vehicleId: $('#hdnVehicleId').val(),
            make: $('#carMakeDropdown').val(),
            model: $('#carModel').val(),
            year: $('#year').val(),
            price: $('#price').val(),
            mileage: $('#mileage').val(),
            licensePlate: $('#licensePlate').val(),
            colour: $('#colour').val(),
            vin: $('#vin').val(),
            engineType: $('#engineType').val(),
            engineSize: $('#engineSize').val(),
            fuelTank: $('#fuelTank').val(),
            fuelType: fueltype1,
            imageUrl: $('#image').val(),
            /*seatingCapacity: parseInt($('#seatingCapacity').val(),3),*/
            condition: $('#condition').val(),
            features: $('#features').val(),
            versionName: $('#versionName').val(),
            exShowroomPrice: $('#exShowroomPrice').val(),
            rto: $('#rto').val(),
            insurance: $('#insurance').val(),
            availability: $('#availability').val(),
        }

        //$.ajax({
        //    type: 'POST', // Assuming you want to use POST method
        //    url: "https://localhost:7011/api/Vehicle/SaveVehicleDetailsAsync",
        //    contentType: "application/json",
        //    data: JSON.stringify(data),
        //    async: false,
        //    success: function (data) {
        //        console.log('data', data);
        //        if (response != null && response.statusCode == 200) {
        //            alert("Add Sucess")
        //            window.location.href = "/";
        //        } else {
        //            $("#errmsg").text("Failed");
        //        }
        //    }
        //});
        $.ajax({
            type: 'POST',
            url: "https://localhost:7011/api/Vehicle/SaveVehicleDetailsAsync",
            data: JSON.stringify(dataaz),
            contentType: 'application/json',
            success: function (data) {
                console.log(data);
                if (data != null && data.statusCode == 200) {
                    alert("Save success");
                    window.location.href = "/Customer/GridCustomer";
                }
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
                alert("Error: " + status);
            }
        });
    } catch (err) {
        console.log(err);
    }

}

const DeleteVehicleById = async (Id) => {
    var Response = 0;


    try {
        await $.ajax({
            type: 'DELETE',
            url: 'https://localhost:7011/api/Vehicle/DeleteVehicleDetailsAsync?id=' + Id + '',
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

