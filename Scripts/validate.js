

  

    function IsValid(){
        $("#form").validate({
            rules: {
                fname: "required",
                lname: "required",
                email: "required"
            },
            messages: {
                lname: "Last name is required",
                fname: "First Name is required",
                email: "Email is required"
            },
            submitHandler: function (form) {
                // $("#buy").attr("type", "submit");
                callWebService();
                
            }

        });
    }
   



function callWebService() {
    var user = {
        "FirstName": $("#fname").val(),
        "LastName": $("#lname").val(),
        "Email": $("#email").val()
    }
    $.support.cors = true;
    $.ajax({
        type: "POST",
        url: '/Home/Orders',
        data: user,
        crossDomain: true,
        
        dataType: "json",
       
        success: function (data, status, jqXHR) {
             window.location.href = '/Home/Orders';
            // alert(jqXHR.responseText);
            //alert(status);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            window.location.href = '/Home/Orders';
        }

    });
}

   

 