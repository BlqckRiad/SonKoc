

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
        },
        error: function (xhr, status, error) {
            console.error('Sinav tipi gelirken bir hata oluştu:', error);
            // Optionally, show an error message to the user
        }
    });
}




function Ekle() {
    // Input değerlerini al
    var sinavAdi = $('#sAdi').val();
    var sinavKodu = $('#sKodu').val();
    var sinavTipi = $('#sTipi').val();
    var sinavSuresi = document.getElementById("sSüresi").value;


    olusurankisi = localStorage.getItem("TabloID");
    kisi = parseInt(olusurankisi, 10);
    
   
    // Veri objesini oluştur
    var veri = {
        SinavAdi: sinavAdi,
        SinavKodu: sinavKodu,
        SinavSüresi: sinavSuresi,
        SinavTipiID: sinavTipi,
        OlusturanKisiID:kisi
    };
    var jsonData = JSON.stringify(veri);
    // AJAX isteği gönder
    $.ajax({
        url: '/Sinavlar/SinavlarAdd',
        type: 'POST',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {

            location.href = "/Sinav/SinavListeleme";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Sinav eklenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}

function ListelemeyeDon() {
    location.href = "/Sinav/SinavListeleme";
}