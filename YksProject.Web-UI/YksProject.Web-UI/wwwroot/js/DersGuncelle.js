$(document).ready(function () {
    BolumDataGetir();
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGoreDersGetir(id);
});

function BolumDataGetir() {
    $.ajax({
        type: "GET",
        url: "/Bolumler/BolumListeleData",
        data: null,
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

function idyeGoreDersGetir(id) {
    $.ajax({
        url: '/Dersler/DersGetir/' + id,
        type: 'GET',
        success: function (data) {
       
            $('#dersAdi').val(data.dersAdi);

            // Dropdown'da dersBolumID değerini seçili hale getir
            $('#bolum').val(data.dersBolumID);
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Ders getirilirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}


function ListelemeyeDon() {
    location.href = "/Dersler/DersListele";
}

function DersGuncelle() {
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];
    var dersAd = $('#dersAdi').val();
    var bolumTipi = document.getElementById("bolum").value;
    var guncelleyenkisiid = localStorage.getItem("TabloID");
    // Veri objesini oluştur
    var veri = {
        TabloID : id,
        DersAdi: dersAd,
        DersBolumID: bolumTipi,
        GuncelleyenKisiID: guncelleyenkisiid
    };

    // AJAX isteği gönder
    $.ajax({
        url: '/Dersler/DersUpdate',
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(veri),
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Ders başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/Dersler/DersListele";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Sinav güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}