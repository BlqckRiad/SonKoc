$(document).ready(function () {
    // Mevcut sayfanın URL'sini al
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGoreOgrGetir(id);

});
function idyeGoreOgrGetir(id) {
    $.ajax({
        type: "GET",
        url: "/Kurum/OgrenciGetByid/" + id,
        success: function (data) {
            console.log(data);
          

        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Veri getirilirken bir hata oluştu:', error);
         
        }
    });
}