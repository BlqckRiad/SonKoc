$(document).ready(function () {
    sinavtipigetir();
});

function sinavtipigetir() {
    $.ajax({
        type: "GET",
        url: "/SinavTipleri/SinavTipleriListeleData",
        success: function (response) {
            var dropdown = $('#sTipi');
            dropdown.empty(); // Clear any existing options

            // Assuming response is an array of objects with properties 'tabloID' and 'sinavTipiAdi'
            response.forEach(function (item) {
                var option = $('<option></option>').attr('value', item.tabloID).text(item.sinavTipiAdi);
                dropdown.append(option);
            });
            var currentURL = window.location.href;

            // URL'yi parçalara ayır
            var urlParts = currentURL.split('/');

            // ID değeri, son parça olacak
            var id = urlParts[urlParts.length - 1];
            idyeGoreSinavGetir(id);
        },
        error: function (xhr, status, error) {
            console.error('Sinav tipi gelirken bir hata oluştu:', error);
            // Optionally, show an error message to the user
        }
    });
}

function idyeGoreSinavGetir(id) {
    $.ajax({
        type: "GET",
        url: "/Sinavlar/SinavGetir/" + id,
        success: function (data) {


          
            $('#sAdi').val(data.sinavAdi);
            $('#sKodu').val(data.sinavKodu);
            $('#sSüresi').val(data.sinavSüresi);
            $('#sTipi').val(data.sinavTipiID);
      

        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Sinav getirilirken bir hata oluştu:', error);
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

    var sinavAdi = $('#sAdi').val();
    var sinavKodu = $('#sKodu').val();
    var sinavtipi = $('#sTipi').val();
    var sinavSuresi = document.getElementById("sSüresi").value;

    var kisi = localStorage.getItem("TabloID");
    var kisiid = parseInt(kisi, 10);
    

    // Veri objesini oluştur
    var veri = {
        TabloId: id,
        SinavAdi: sinavAdi,
        SinavKodu: sinavKodu,
        SinavSüresi: sinavSuresi,
        SinavTipiID: sinavtipi,
        GuncelleyenKisiID: kisiid
    };

    var jsonData = JSON.stringify(veri);
    // AJAX isteği gönder
    $.ajax({
        url: '/Sinavlar/SinavUpdate',
        type: 'PUT',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Sinav başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/Sinav/SinavListeleme";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Sinav güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}


function ListelemeyeDon() {
    location.href = "/Sinav/SinavListeleme";
}

