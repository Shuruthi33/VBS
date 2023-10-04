const GetCustomerDetails = async () => {
    var Response;
    
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
                            tbodydata += '<td> <a href = "/Customer/AddOrUpdateCustomer?CustomerId=' + value.customerId + '"> &nbsp <span class="mdi mdi-border-color" type="button" title="Edit"></span></a><a href = "#"onclick="DeleteCustomerById(' + value.customerId + ')"><span class="mdi mdi-delete-forever" type="button" title="Delete"></span></a></td>';

                            //tbodydata += '<td>' + value.customerId + '</td>';
                            tbodydata += '<td>' + value.customerName + '</td>';
                            tbodydata += '<td>' + value.email + '</td>';
                            tbodydata += '<td>' + value.address + '</td>';
                            tbodydata += '<td>' + value.phoneNo + '</td>';
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

function AddOrUpdateCustomer() {
    
    //var formData = new FormData();
    //formData.append('customerId', $('#hdnCustomerId').val());
    //formData.append('customerName', $('#name').val());
    //formData.append('email', $('#email').val());
    //formData.append('address', $('#address').val());
    //formData.append('phoneNo', $('#phoneNo').val()); 

    //var imageFile = $('#image')[0].files[0];
    //formData.append('imagePath', imageFile);
    //console.log(formData); 
    //$.ajax({
    //    type: 'POST',
    //    url: "https://localhost:7011/api/User/SaveUserDetailsAsync",
    //    data: JSON.stringify(formData), // Assuming formData is a JSON object
    //    contentType: 'application/json', // Set content type to JSON
    //    success: function (data) {
    //        alert("Save success");
    //        if (data != null && data.statusCode == 200) {
    //            window.location.href = "/Customer/GridCustomer";
    //        }
    //    },
    //    error: function (xhr, status, error) {
    //        console.error(xhr.responseText);
    //        alert("Error: " + status);
    //    }
    //});
    //var imageFile = $('#image')[0].files[0];
    var userDetails = {
        customerId: $('#hdnCustomerId').val(),
        customerName: $('#name').val(),
        email: $('#email').val(),
        address: $('#address').val(),
        phoneNo: $('#phoneNo').val(),
        imagePath: ""// Assuming this is a string path to the image
    };

    $.ajax({
        type: 'POST',
        url: "https://localhost:7011/api/User/SaveUserDetailsAsync",
        data: JSON.stringify(userDetails),
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
