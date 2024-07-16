$(document).ready(function () {
    DersDataGetir();

    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGoreDataGetir(id);
});

function DersDataGetir() {
    $.ajax({
        type: "GET",
        url: "/Dersler/DersListeleData",
        data: null,
        success: function (result) {
            var sinavDropdown = $('#KonuDers'); // dropdown'a erişim

            // Önce mevcut seçenekleri temizleyelim
            sinavDropdown.empty();

            // "Seçiniz" seçeneğini ekleyelim
            sinavDropdown.append('<option value="0">Seçiniz</option>');

            // Her bir sınav için dropdown'a bir seçenek ekleyelim
            result.forEach(function (sınav) {
                sinavDropdown.append('<option value="' + sınav.tabloID + '">' + sınav.dersAdi + '</option>');
            });
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Giriş işleminde karşılaştık");
        }
    });
}
function idyeGoreDataGetir(id) {
    $.ajax({
        type: "GET",
        url: "/Konular/KonuGetirData/" + id,
        success: function (data) {

            $('#KonuAd').val(data.konuAdi);
            $('#KonuDers').val(data.konuDersID);
            $('#KonuAciklamasi').val(data.konuAciklamasi);
            $('#KonuKisiAdi').val(data.konuAciklamasiYapanKisi);
            $('#KonuKisiRolu').val(data.konuAciklamasiYapanKisiRolu);
            $('#Soru2024').val(data.konu1SeneSoruSayisi);
            $('#Soru2023').val(data.konu2SeneSoruSayisi);
            $('#Soru2022').val(data.konu3SeneSoruSayisi);

     
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Data getirilirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}

function KonuGuncelle() {
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];
    var k1 = $('#KonuAd').val();
    var k2 = $('#KonuDers').val();
    var k3 = $('#KonuAciklamasi').val();
    var k4 = $('#KonuKisiAdi').val();
    var k5 = $('#KonuKisiRolu').val();
    var k6 = $('#Soru2024').val();
    var k7 = $('#Soru2023').val();
    var k8 = $('#Soru2022').val();
    var guncelleyenKisiID = localStorage.getItem('TabloID');

    var veri = {
        TabloID : id,
        KonuAdi: k1,
        GuncelleyenKisiID: guncelleyenKisiID,
        KonuDersID: k2,
        Konu1SeneSoruSayisi: k6,
        Konu2SeneSoruSayisi: k7,
        Konu3SeneSoruSayisi: k8,
        KonuAciklamasi: k3,
        KonuAciklamasiYapanKisi: k4,
        KonuAciklamasiYapanKisiRolu: k5
    };
    var jsonData = JSON.stringify(veri);
    $.ajax({
        url: '/Konular/KonuGuncelleData',
        type: 'PUT',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Konular başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/Konular/KonularList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Konular güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}