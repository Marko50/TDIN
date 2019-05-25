var url = document.URL;
$(document).ready(function () {
    var url_parsed = new URL(url);
    var id = url_parsed.searchParams.get("id");
    if (id) {
        $("#catalogue").css("display", "none");
        $("#checkout").css("display", "block");
        $("#append").append(hiddenInput(id));
        $("#purchase").click(function (e) { 
        let email = $("#email").val();
        $.ajax({
            type: "POST",
            url: "../restServices/orders",
            data: JSON.stringify({"order" : {"bookID" : id, "email" : email}}),
            contentType: "application/json; charset=utf-8",
          }).done(function (msg) {
              if(msg.success){
                window.location.replace(window.location.origin + "/orders?id=" + msg.id);
              }
              else{
                window.location.replace(window.location.origin + "/error?message=" + msg.information);
              }
          });
          e.preventDefault();     
        });
        $.ajax({
            type: "GET",
            url: "../restServices/books/" + id
          }).done(function (msg) {
            if (msg.success) {
              msg.information.forEach(book => {
                $("#checkout").append(formBookCardCheckout(book.id, book.title, book.author, book.price, book.stock));
              });
            }
            else{
              $("#checkout").append(formErrorMessage(msg.information ));
            }
          });  
    }
    else{
        $("#checkout").css("display", "none");
        $("#catalogue").css("display", "block");
        $.ajax({
            type: "GET",
            url: "../restServices/books"
          }).done(function (msg) {
            if (msg.success) {
              msg.information.forEach(book => {
                $("#response").append(formBookCard(book.id, book.title, book.author, book.price, book.stock));
              });
            }
            else{
              $("#response").append(formErrorMessage(msg.information ));
            }
          });  
    }  
});

function formBookCard(id, title, author, price, stock) {  
    return "<div class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + title + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + author + "</h6> <p class='card-text'> Very fancy book. Costs only " + price + "€. Current stock is " + stock +  "</p> <a href='" + document.URL +"?id="+ id + " 'class='btn btn-primary'>Buy now</a> </div> </div>"
}

function formBookCardCheckout(id, title, author, price, stock) {  
    return "<div class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + title + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + author + "</h6> <p class='card-text'> Very fancy book. Costs only " + price + "€. Current stock is " + stock +  "</p>  </div> </div>"
}

function formErrorMessage(information){
    return "<div>"+ information +"</div>"
}

function hiddenInput(id){
  return "<input type='hidden' class='form-control' id='bookID' name='bookID' value='" + id + "'>"
}

