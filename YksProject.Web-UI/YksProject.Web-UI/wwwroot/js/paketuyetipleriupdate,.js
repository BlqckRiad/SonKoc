$(document).ready(function () {
    // Mevcut sayfanın URL'sini al
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGorePaketGetir(id);

});
function idyeGorePaketGetir(id) {
    $.ajax({
        type: "GET",
        url: "/PaketUyeTipleri/PaketUyeTipleriGetData/" + id,
        success: function (data) {
            console.log(data);
            // Gelen veriyi ilgili input alanlarına doldur
            $('#uyeTipiAdi').val(data.uyeTipiAdi);
            $('#uyeTipiAciklamasi').val(data.uyeTipiAciklamasi);
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('PaketUyeTipleri getirilirken bir hata oluştu:', error);
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
    var uyeTipiAdi = $('#uyeTipiAdi').val();
    var uyeTipiAciklamasi = $('#uyeTipiAciklamasi').val();
    var guncelleyenkisi = localStorage.getItem('TabloID');

    // Veri objesini oluştur
    var veri = {
        TabloID: id,
        UyeTipiAdi: uyeTipiAdi,
        UyeTipiAciklamasi: uyeTipiAciklamasi,
        GuncelleyenKisiID: guncelleyenkisi
    };

    // AJAX isteği gönder
    var jsonData = JSON.stringify(veri);
    // AJAX isteği gönder
    $.ajax({
        url: '/PaketUyeTipleri/PaketUyeTipleriUpdateData',
        type: 'PUT',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('PaketUyeTipleri başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/PaketUyeTipleri/PaketUyeTipleriList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('PaketUyeTipleri güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}
function ListelemeyeDon() {
    location.href = "/PaketUyeTipleri/PaketUyeTipleriList";
}