// Login authentication
const Auth = async () => {
    var response = 0;
    let frmname = $("#login-form");

    // Initialize the form validation
    frmname.validate({
        rules: {
            username: "required",
            password: "required"
        },
        messages: {
            username: "Please enter your username",
            password: "Please enter your password"
        }
    });

    if (frmname.valid()) {
        debugger;
        var data = {
            CustomerName: $('#exampleInputEmail1').val(), 
            Password: $('#exampleInputPassword1').val()   
        };

        $.ajax({
            type: 'POST',
            url: "/Authenticate", 
            contentType: "application/json",
            data: JSON.stringify(data),
            async: false,
            success: function (data) {
                debugger;
                console.log('data', data);

                if (data != null && data.statusCode == 200) {
                    window.location.href = '/Vehicle/Vehicle';
                } else {
                    alert('Invalid user name and password...');
                }
                debugger;
            },
            error: function (error) {
               
            }
        });
    }
};


