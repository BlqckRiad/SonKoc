$(document).ready(function () {

    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGoreDataGetir(id);
});
function idyeGoreDataGetir(id) {
    $.ajax({
        type: "GET",
        url: "/SinavTipleri/SinavTipleriGetirData/" + id,
        success: function (data) {
            $('#sad').val(data.sinavTipiAdi);
        },
        error: function (xhr, status, error) {
            console.error('Data getirilirken bir hata oluştu:', error);          
        }
    });
}
function Guncelle() {

    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];
    var bolumAdi = $('#sad').val();

    var guncelleyenkisi = localStorage.getItem('TabloID');

    // Veri objesini oluştur
    var veri = {
        TabloID: id,
        SinavTipiAdi: bolumAdi,
        GuncelleyenKisiID: guncelleyenkisi
    };
    var jsonData = JSON.stringify(veri);
    // AJAX isteği gönder
    $.ajax({
        url: '/SinavTipleri/SinavTipiGuncelleData',
        type: 'PUT',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
           
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/SinavTipleri/SinavTipiListele";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Sinav güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}


   