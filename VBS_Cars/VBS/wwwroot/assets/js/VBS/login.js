// Login authentication
const Login = async () => {
    debugger;
    var Response = 0;
    let frmname = $("#signin-form");
   
    var data = {
        customerName: $('#txtusername').val(),
        password: $('#txtpassword').val()
    }
    if (frmname.valid() === true) {

        alert("-hiiii");
        $.ajax({
            type: 'POST',
            url: "https://localhost:7011/api/UserAuthentication/Authenticate",
            contentType: "application/json",
            data: JSON.stringify(data),
            async: false,
            success: function (data) {
                debugger;
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




//const Register = async () => {
//    debugger;

//    var data = {
//        CustomerId: Id,
//        CustomerName: $('#txtusername').val(),
//        Email: $('#txtemail').val(),
//        Password: $('#txtpassword').val(),
//        Address: $('#txtaddress').val(),
//        PhoneNo: $('#txtphoneno').val()
//    }
//        console.log('data', data);
//        alert("OKKK");
//        $.ajax({
//            type: 'POST',
//            url: 'https://localhost:7011/api/User/SaveUserDetailsAsync',
//            contentType: "application/json",
//            data: JSON.stringify(data),
//            async: true,
//            success: function (data) {
//                alert("SUCESS");
//                console.log('data', data);

//                if (data != null && data.statusCode == 200) {
//                    alert("save success")
//                    window.location.href = "/Login/Login";
//                }
//            },
//            error: function (error) {
//                alert('server error');
//            }
//        });


//}


//const Register = async () => {
//    debugger;

//    var data = {
//        CustomerId: Id, 
//        CustomerName: $('#txtuserName').val(),
//        Email: $('#txtemail').val(),
//        Password: $('#txtpassword').val(),
//        Address: $('#txtaddress').val(),
//        PhoneNo: $('#txtphoneno').val()
//    }

//    console.log('data', data);

//    $.ajax({
//        type: 'POST',
//        url: "https://localhost:7011/api/User/SaveUserDetailsAsync",
//        contentType: "application/json",
//        data: JSON.stringify(data),
//        async: true,
//        success: function (data) {
//            alert("SUCCESS");
//            console.log('data', data);

//            if (data != null && data.statusCode == 200) {
//                alert("save success")
//                window.location.href = "/Login/Login";
//            }
//        },
//        error: function (error) {
//            alert('server error');
//        }
//    });
//}

const Register = async () => {
    debugger;
    var Response = 0;
    var data = {
        CustomerId: 0,
        CustomerName: $('#txtuserName').val(),
        Email: $('#txtemail').val(),
        Password: $('#txtaddress').val(),
        Address: $('#txtaddress').val(),
        PhoneNo: $('#txtphoneno').val(),


    }
    console.log('data', data);
    alert("ULLA POO")
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

                debugger;
               window.location.href = "/Login";

               // window.location.href = "/Vehicle/ViewVehicle";

            }
        }
    });
}





