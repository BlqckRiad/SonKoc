$(document).ready(function () {
    DersDataGetir();
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
function KonuEkle() {
    var k1 = $('#KonuAd').val();
    var k2 = $('#KonuDers').val();
    var k3 = $('#KonuAciklamasi').val();
    var k4 = $('#KonuKisiAdi').val();
    var k5 = $('#KonuKisiRolu').val();
    var k6 = $('#Soru2024').val();
    var k7 = $('#Soru2023').val();
    var k8 = $('#Soru2022').val();
    var olusturanKisiID = localStorage.getItem('TabloID');

    var veri = {
        KonuAdi:k1,
        OlusturanKisiID: olusturanKisiID,
        KonuDersID: k2,
        Konu1SeneSoruSayisi :k6,
        Konu2SeneSoruSayisi :k7,
        Konu3SeneSoruSayisi: k8,
        KonuAciklamasi: k3,
        KonuAciklamasiYapanKisi: k4,
        KonuAciklamasiYapanKisiRolu : k5
    };

    // AJAX isteği gönder
    $.ajax({
        url: '/Konular/KonularAddData',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(veri),
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Konu başarıyla eklendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/Konular/KonularList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Konu eklenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}