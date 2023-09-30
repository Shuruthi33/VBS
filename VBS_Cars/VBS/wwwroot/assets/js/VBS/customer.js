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


    try {
        await $.ajax({
            type: 'GET',
            url: "https://localhost:7011/api/User/GetUserDetailsByIdAsync?id=" + Id,
            contentType: "application/json",
            headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
            data: { id: Id },
            async: false,
            success: function (data) {

                if (data != null && data.statusCode == 200) {
                    $('#name').val(data.resultData.customerName);
                    $('#email').val(data.resultData.email);
                    $('#address').val(data.resultData.address);
                    $('#phoneNo').val(data.resultData.phoneNo);
                }
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
    // alert(Id);
    var data = {
        UserId: Id,
        customerName: $('#name').val(),
        email: $('#email').val(),
        address: $('#address').val(),

        phoneNo: $('#phoneNo').val(),
       

    }
    console.log('data', data);
    alert()
    $.ajax({
        type: 'POST',
        url: "https://localhost:7138/api/User/InsertUserDetailsAsync",
        contentType: "application/json",
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
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
