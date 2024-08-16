$(document).ready(function () {

    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGoreDataGetir(id);
});

function idyeGoreDataGetir(id) {
    var token = localStorage.getItem("Token");
    $.ajax({
        type: "GET",
        url: "/GununSozu/GetGununSozuWithID/" + id,
        headers: { "Authorization": "Bearer " + token },
        dataType: "json", // JSON verisini beklediğinizi belirtin
        success: function (data) {
            // Veriyi input alanlarına yerleştirin
            $('#soz').val(data.soz);
  
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Data getirilirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}

function Guncelle() {
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];
    var k1 = document.getElementById("soz").value;

    var olusturanKisiIDnoint = localStorage.getItem("TabloID");
    var olusturanKisiID = parseInt(olusturanKisiIDnoint, 10);
    var veri = {
        TabloID: id,
        Soz: k1,

        GuncelleyenKisiID: olusturanKisiID,
    };
    var token = localStorage.getItem("Token");
    var jsonData = JSON.stringify(veri);
    $.ajax({
        url: '/GununSozu/GununSozuUpdateData',
        type: 'POST',
        headers: { "Authorization": "Bearer " + token },
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
           
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/GununSozu/GununSozuList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('GununSozu güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}