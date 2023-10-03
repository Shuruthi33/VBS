const GetCustomerDetails = async () => {
    var Response;
    debugger;
    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/User/GetUserDetailsAsync",
            contentType: "application/json",
            data: {},
            async: false,
            success: function (data) {
                if (data != null && data.statusCode == 200) {
                    if (data.resultData.length > 0) {
                        var tbodydata = '';
                        $.each(data.resultData, function (key, value) {
                            tbodydata += '<tr>';
                            //tbodydata += '<td>' + value.customerId + '</td>';
                            tbodydata += '<td>' + value.customerName + '</td>';
                            tbodydata += '<td>' + value.email + '</td>';
                            tbodydata += '<td>' + value.address + '</td>';
                            tbodydata += '<td>' + value.phoneNo + '</td>';
                            tbodydata += '<td> <a href = "/Customer/AddOrUpdateCustomer?CustomerId=' + value.customerId + '"><span class="mdi mdi-border-color" type="button" title="Edit"></span></a><a href = "#"onclick="DeleteCustomerById(' + value.customerId + ')"><span class="mdi mdi-delete-forever" type="button" title="Delete"></span></a></td>';
                            tbodydata += '</tr>';
                        });

                        $("#tblCustomer tbody").empty();
                        $("#tblCustomer tbody").append(tbodydata);
                    }
                }
            }
        });
    } catch (err) {
        console.log(err);
    }

    return Response;
}

const GetCustomerDetailsById = async (Id) => {
    debugger;
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
                debugger;
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

function AddOrUpdateCustomer() {
    debugger;

   

    var formData = new FormData();
    formData.append('customerId', $('#hdnCustomerId').val());
    formData.append('customerName', $('#name').val());
    formData.append('email', $('#email').val());
    formData.append('address', $('#address').val());
    formData.append('phoneNo', $('#phoneNo').val());
    formData.append('image', $('#image').val());
   /* formData.append('image', $('#image')[0].files[0]);*/

        alert('step1')
        $.ajax({
            type: 'POST',
            url: "https://localhost:7011/api/User/InsertUserDetailsAsync",
            data: formData,
            contentType: false,
            processData: false,
            success: function (data) {
                alert("Save success");
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
                    GetCustomerDetails();
                }
            }
        });
    }
    catch (err) {
        await console.log(err);
    }

    return Response;

}
