//const GetCustomerDetails = async () => {
//    var Response;
//    debugger;
//    try {
//        await $.ajax({
//            type: 'GET',
//            url: "https://localhost:7011/api/User/GetUserDetailsAsync",
//            contentType: "application/json",
//            data: {},
//            async: false,
//            success: function (data) {
//                if (data != null && data.statusCode == 200) {
//                    if (data.resultData.length > 0) {
//                        var tbodydata = '';
//                        $.each(data.resultData, function (key, value) {
//                            tbodydata += '<tr>';
//                            //tbodydata += '<td>' + value.customerId + '</td>';
//                            tbodydata += '<td>' + value.customerName + '</td>';
//                            tbodydata += '<td>' + value.email + '</td>';
//                            tbodydata += '<td>' + value.address + '</td>';
//                            tbodydata += '<td>' + value.phoneNo + '</td>';
//                            tbodydata += '<td> <a href = "/Customer/AddOrUpdateCustomer?CustomerId=' + value.customerId + '"><span class="mdi mdi-border-color" type="button" title="Edit"></span></a><a href = "#"onclick="DeleteCustomerById(' + value.customerId + ')"><span class="mdi mdi-delete-forever" type="button" title="Delete"></span></a></td>';
//                            tbodydata += '</tr>';
//                        });

//                        $("#tblCustomer tbody").empty();
//                        $("#tblCustomer tbody").append(tbodydata);
//                    }
//                }
//            }
//        });
//    } catch (err) {
//        console.log(err);
//    }

//    return Response;
//}

const GetCustomerDetails = async () => {
    debugger;

    var Sample = "";
    try {
        $.ajax({
            url: "https://localhost:7011/api/User/GetUserDetailsAsync", // Replace this with the actual API endpoint URL
            type: "GET", // Use the appropriate HTTP method (POST, GET, PUT, DELETE, etc.)
            //data: JSON.stringify(data), // Include input data if required
            headers: {
                "Content-Type": "application/json"
            },
            success: function (data) {

                if (data != null && data.statusCode == 200) {
                    if ($.fn.DataTable.isDataTable('#tblCustomer')) {
                        $('#tblCustomer').DataTable().destroy();
                    }

                    $("#tblCustomer").DataTable({
                        data: data.resultData,
                        "responsive": true,
                        "ordering": true,
                        "bLengthChange": true, //thought this line could hide the LengthMenu
                        "bInfo": true,
                        "bAutoWidth": false,
                        "columnDefs": [{
                            "orderable": false,
                            "targets": [0]
                        },
                        { "width": "100px", "targets": 0 }
                        ],
                        "order": [
                            [1, 'asc']
                        ],
                        "language": {
                            "emptyTable": ''
                        },
                        columns: [{
                            'data': function (data) {

                                return '<td> <a href = "/Customer/AddOrUpdateCustomer?CustomerId=' + value.customerId + '"><span class="mdi mdi-border-color" type="button" title="Edit"></span></a><a href = "#"onclick="DeleteCustomerById(' + value.customerId + ')"><span class="mdi mdi-delete-forever" type="button" title="Delete"></span></a></td>';
                            }
                        },

                         { 'data': 'customerName', "name": "customerName" },
                        { 'data': 'email', "name": "email" },
                        { 'data': 'genderText', "name": "genderText" },
                        { 'data': 'address', "name": "address" },
                        { 'data': 'phoneNo', "name": "area" },
                        
                        ],
                        "lengthMenu": [
                            [25, 50, 75, -1],
                            [25, 50, 75, "All"] // change per page values here
                        ],
                        "pageLength": 25,
                    });




                }

            },
            error: function (error) {
                console.error("Error occurred:", error);
            },
        });
    }
    catch (err) {
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
    formData.append('image', $('#image')[0].files[0]);

 
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
