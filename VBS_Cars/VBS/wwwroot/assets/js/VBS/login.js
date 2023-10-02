// Login authentication
const Login = async () => {
    debugger;
    var Response = 0;
    let frmname = $("#frmLogin");
   
    var data = {
        CustomerName: $('#txtusername').val(),
        Password: $('#txtpassword').val()
    }
    if (frmname.valid() === true) {
        alert("-hiiii");
        $.ajax({
            type: 'POST',
            url: "Authenticate",
            data: JSON.stringify(data),
            async: false,
            success: function (data) {
                debugger;
                console.log('data', data);
                if (data != null && data.statusCode == 200) {

                    alert("save success");
                    // document.login_form.action = "https://localhost:7170/Vehicle/AddVehicle";
                    window.location.href = "~/Vehicle/GridVehicle";
                    // document.getElementById("login-form").formAction = "https://localhost:7170/Vehicle/AddVehicle";
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




const Register = async (Id) => {
    debugger;
    var Response = 0;
    let frmname = $("#frmLogin");
    alert(Id);
    var data = {
        CustomerId: Id,
        CustomerName: $('#txtfullname').val(),
        Email: $('#txtemail').val(),
        Password: $('#txtpassword').val(),
        Address: $('#txtaddress').val(),
        PhoneNo: $('#txtnumber').val()
    }
    if (frmname.valid() === true) {
        console.log('data', data);
        alert("OKKK");
        $.ajax({
            type: 'POST',
            url: "https://localhost:7011/api/User/SaveUserDetailsAsync",
            contentType: "application/json",
            data: JSON.stringify(data),
            async: true,
            success: function (data) {
                alert("SUCESS");
                console.log('data', data);

                if (data != null && data.statusCode == 200) {
                    alert("save success")
                    window.location.href = "/Login/Login";
                }
            },
            error: function (error) {
                alert('server error');
            }
        });

    }
}




