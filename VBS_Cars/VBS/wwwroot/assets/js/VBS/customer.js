const GetCustomerDetails = async () => {
    var Response;

    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/User/GetUserDetailsAsync",
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
                            tbodydata += '<td>' + value.customerName + '</td>';
                            tbodydata += '<td>' + value.email + '</td>';
                            tbodydata += '<td>' + value.address + '</td>';
                            tbodydata += '<td>' + value.phoneNo + '</td>';
                            tbodydata += '<td> <div> <a href = "/Customer/Edit?CustomerId=' + value.customerId + '"> ' +
                                '<span class="ti-pencil" type="button" title="Edit"></span></a> ' +
                                '<a href = "#" onclick="DeleteCustomerById(' + value.customerId + ')"/> ' +
                                '<span class="ti-trash" type="button" title="Delete"></span></a> ' +
                                '</div ></td>';
                            tbodydata += '</tr>';
                        });
                        console.log(tbodydata);

                        $("#tblCustomer tbody").empty();
                        $("#tblCustomer tbody").append(tbodydata);
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

const GetCustomerDetailsById = async (Id) => {

    var Response = 0;
    alert("okk")
    var data = { id : Id };
    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/User/GetUserDetailsByIdAsync?id=" + Id,
            contentType: "application/json",
            data: JSON.stringify(data),
            async: false,
            success: function (data) {
                if (data != null && data.statusCode == 200) {
                    $('#hdnCustomerId').val(data.resultData.customerId);
                    $('#name').val(data.resultData.customerName);
                    $('#email').val(data.resultData.email);
                    $('#address').val(data.resultData.address);
                    $('#phoneNo').val(data.resultData.phoneNo);
                }
            },
            error: function (error) {
                alert('server error');
            }

        });
    }
    catch (err) {
        await console.log(err);
    }

    return Response;
}

const SaveOrUpdateCustomer = async (Id) => {
    var Response = 0;

    alert("ok");
    alert(Id);

    var data = {
        customerId: Id,
        customerName: $('#name').val(),
        email: $('#email').val(),
        address: $('#address').val(),
        password: $('#password').val(),
        phoneNo: $('#phoneNo').val()

    };

    $.ajax({
        type: 'POST',
        url: "https://localhost:7011/api/User/InsertUserDetailsAsync",
        contentType: "application/json",
        data: JSON.stringify(data),
        async: true,
        success: function (data) {
            alert("save success")
            if (data != null && data.statusCode == 200) {
                window.location.href = "/Customer/GridCustomer";
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
            url: 'https://localhost:7011/api/User/DeleteUserDetailsAsync?Id=' + Id + '',
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
