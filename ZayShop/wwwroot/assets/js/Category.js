$(function () {
    $('.categoryButton').on('click', function myFunction() {

        const categoryId = $(this).data('category-id');
        console.log("Selected CategoryId:", categoryId); 

        $.ajax({
            url: "/shop/getProductByCategory",
            method: "GET",
            data: { categoryId: categoryId }, 
            contentType: "application/json",
            success: function (response) {
                $('#productRow').html(response)
            }
        })
    })
})