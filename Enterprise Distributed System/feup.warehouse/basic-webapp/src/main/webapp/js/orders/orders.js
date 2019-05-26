$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "restServices/testServices/orders",
        success: function (response) {
            if(response.success){
                response.information.forEach(order => {
                   $("#response").append(formOrderCard(order.id, order.email, order.bookID, order.state)); 
                   $("#button_"+order.id).click(function (e) {
                        $.ajax({
                            type: "DELETE",
                            url: "restServices/testServices/orders",
                            data: JSON.stringify({"order": {"id" : order.id}}),
                            contentType: "application/json; charset=utf-8",
                            success: function (response) {
                                console.log(response);
                               if(response.success){
                                    $("#button_"+id).remove();
                               }
                            }
                        });
                        e.preventDefault();
                    });
                });
            }
            else{
                $("#response").append(formErrorMessage(response.information));
            }
        }
    });
});

function formErrorMessage(information){
    return "<div>"+ information +"</div>"
}

function formOrderCard(id, email, bookID, state) {  
    return "<div class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + "Order number " + id + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + email + "</h6> <p class='card-text'> Book ordered was " + bookID + ". Current state is " + state +  "</p>" + "<button id='button_" + id +"' class='btn btn-primary'> Dispatch now </button>" + "</div> </div>"
}