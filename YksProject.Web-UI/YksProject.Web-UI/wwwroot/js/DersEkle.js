$(document).ready(function () {
    BolumDataGetir();
});

function BolumDataGetir() {
    $.ajax({
        type: "GET",
        url: "/Bolumler/BolumListeleData",
        data:null,
        success: function (result) {
            var sinavDropdown = $('#bolum'); // dropdown'a erişim

            // Önce mevcut seçenekleri temizleyelim
            sinavDropdown.empty();

            // "Seçiniz" seçeneğini ekleyelim
            sinavDropdown.append('<option value="0">Seçiniz</option>');

            // Her bir sınav için dropdown'a bir seçenek ekleyelim
            result.forEach(function (sınav) {
                sinavDropdown.append('<option value="' + sınav.tabloID + '">' + sınav.bolumAdi + '</option>');
            });
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Giriş işleminde karşılaştık");
        }
    });
}


function DersEkle() {
    // Input değerlerini al
    var dersAd = $('#dersAdi').val();
    
    var bolumtipi = document.getElementById("bolum").value;
    var olusturanKisiID = localStorage.getItem('TabloID');
    // Veri objesini oluştur
    var veri = {
        DersAdi: dersAd,
        DersBolumID: bolumtipi,
        OlusturanKisiID: olusturanKisiID
    };

    // AJAX isteği gönder
    $.ajax({
        url: '/Dersler/DersAdd',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(veri),
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Ders başarıyla eklendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/Dersler/DersListele";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Ders eklenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}

function ListelemeyeDon() {
    location.href = "/Dersler/DersListele";
}