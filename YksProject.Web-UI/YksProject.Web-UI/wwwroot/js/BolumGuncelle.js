$(document).ready(function () {
    // Mevcut sayfanın URL'sini al
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGoreBolumGetir(id);

});
function idyeGoreBolumGetir(id) {
    $.ajax({
        type: "GET",
        url: "/Bolumler/BolumGetir/"+id,
        success: function (data) {
            console.log(data);
            // Gelen veriyi ilgili input alanlarına doldur
            $('#BolumAd').val(data.bolumAdi);
            $('#BolumKod').val(data.bolumAdKodu);

        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Sinav getirilirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}
function BolumGuncelle() {
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];
    var bolumAdi = $('#BolumAd').val();
    var bolumAdKodu = $('#BolumKod').val();
    var guncelleyenkisi = localStorage.getItem('TabloID');

    // Veri objesini oluştur
    var veri = {
        TabloId: id,
        BolumAdi: bolumAdi,
        BolumAdKodu: bolumAdKodu,
        GuncelleyenKisiID: guncelleyenkisi
    };
    var jsonData = JSON.stringify(veri);
    // AJAX isteği gönder
    $.ajax({
        url: '/Bolumler/BolumUpdate',
        type: 'PUT',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Bolum başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/Bolumler/BolumListele";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Sinav güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}
function ListelemeyeDon() {
    location.href = "/Bolumler/BolumListele";
}