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
        url: "/PromoKey/GetPromoKeyWithID/" + id,
        headers: { "Authorization": "Bearer " + token },
        dataType: "json", // JSON verisini beklediğinizi belirtin
        success: function (data) {
           

            // Veriyi input alanlarına yerleştirin
            $('#promokod').val(data.promoKod);
            $('#promokodneicin').val(data.promoKodNeİcin);
            $('#promokodlimit').val(data.promoKeyLimit);
            $('#promokodindirim').val(data.promoKeyYuzdeKacIndirim);
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
    var k1 = document.getElementById("promokod").value;
    var k2 = document.getElementById("promokodneicin").value;
    var k3 = document.getElementById("promokodlimit").value;
    var k4 = document.getElementById("promokodindirim").value;
    var olusturanKisiIDnoint = localStorage.getItem("TabloID");
    var olusturanKisiID = parseInt(olusturanKisiIDnoint, 10);
    var veri = {
        TabloID:id,
        PromoKod: k1,
        PromoKodNeİcin: k2,
        PromoKeyLimit: k3,
        PromoKeyYuzdeKacIndirim: k4,
        GuncelleyenKisiID: olusturanKisiID,
    };
    var token = localStorage.getItem("Token");
    var jsonData = JSON.stringify(veri);
    $.ajax({
        url: '/PromoKey/PromoKeyUpdateData',
        type: 'POST',
        headers: { "Authorization": "Bearer " + token },
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Konular başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/PromoKey/PromoKeyList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('PromoKey güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}