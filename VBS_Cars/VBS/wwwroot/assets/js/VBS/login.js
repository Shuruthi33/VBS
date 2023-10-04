// Login authentication
const Login = async () => {
    var Response = 0;
    let frmname = $("#signin-form");
    var data = {
        customerName: $('#txtusername').val(),
        password: $('#txtpassword').val()
    }
    if (frmname.valid() === true) {

        $.ajax({
            type: 'POST',
            url: "https://localhost:7011/api/UserAuthentication/Authenticate",
            contentType: "application/json",
            data: JSON.stringify(data),
            async: false,
            success: function (data) {
             
                console.log('data', data);
                if (data != null) {

                    alert("save success");

                    window.location.href = "/Vehicle/ViewVehicle";

                }
                else {
                    alert('Invalid User Name and Password...');
                }
            },
            error: function (error) {
                alert('Invalid User Name and Password...');
            }
        });
    }
}


const Register = async () => {
    var Response = 0;
    let frmname = $("#frmRegister");
    var data = {
        CustomerId: 0,
        CustomerName: $('#txtuserName').val(),
        Email: $('#txtemail').val(),
        Password: $('#txtaddress').val(),
        Address: $('#txtaddress').val(),
        PhoneNo: $('#txtphoneno').val(),
    }
    if (frmname.valid() === true) {
        console.log('data', data);
        $.ajax({
            type: 'POST',
            url: "https://localhost:7011/api/User/SaveUserDetailsAsync",
            contentType: "application/json",
            data: JSON.stringify(data),
            async: false,
            success: function (data) {
                console.log('data', data);
                alert("save success")
                if (data != null && data.statusCode == 200) {
                    alert("Registration Success")
                    window.location.href = "/Login/Login"; 

                }
            }
        });
    }
}





