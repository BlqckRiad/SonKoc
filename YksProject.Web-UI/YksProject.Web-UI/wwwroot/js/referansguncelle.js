$(document).ready(function () {
    // Mevcut sayfanın URL'sini al
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGoreReferansGetir(id);

});
function idyeGoreReferansGetir(id) {
    $.ajax({
        type: "GET",
        url: "/Referanslarimiz/ReferansGetir/" + id,
        success: function (data) {
            console.log(data);
            // Gelen veriyi ilgili input alanlarına doldur
            $('#ReferansAdi').val(data.referansAdi);
            $('#ReferansAciklamasi').val(data.referansAciklamasi);
            $('#ReferansRolu').val(data.referansRolu);
            $('#ReferansPuani').val(data.referansPuani);
            var imgElementi = document.getElementById("referansIkonu");
            imgElementi.src = data.referansImage;
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Referans getirilirken bir hata oluştu:', error);
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
    var ReferansAdi = $('#ReferansAdi').val();
    var ReferansAciklamasi = $('#ReferansAciklamasi').val();
    var ReferansRolu = $('#ReferansRolu').val();
    var ReferansPuani = document.getElementById("ReferansPuani").value;
    
    var guncelleyenkisi = localStorage.getItem('TabloID');
    var imgElement = document.getElementById('referansIkonu');
    var ReferansImageUrl = imgElement.src;
    var input = document.getElementById('ReferansImage');
    if (input.value) {
        ResimSil(ReferansImageUrl);
        var file = $('#ReferansImage').prop('files')[0];
        var formData = new FormData();
        formData.append('file', file);

        $.ajax({
            url: '/File/AddFile',
            type: 'POST',
            data: formData,
            processData: false, // FormData işleme işlemini jQuery'ye bırak
            contentType: false, // İçerik türünü otomatik olarak ayarla
            success: function (responseimage) {

                var veri = {
                    TabloID: id,
                    ReferansAdi: ReferansAdi,
                    ReferansAciklamasi: ReferansAciklamasi,
                    ReferansRolu: ReferansRolu,
                    ReferansPuani: ReferansPuani,
                    ReferansImage: responseimage.medyaUrl,
                    GuncelleyenKisiID: guncelleyenkisi
                };

                var jsonData = JSON.stringify(veri);
                // AJAX isteği gönder
                Guncelle2(jsonData);
            }

        });
    }
    else {
        var veri = {
            TabloID: id,
            ReferansAdi: ReferansAdi,
            ReferansAciklamasi: ReferansAciklamasi,
            ReferansRolu: ReferansRolu,
            ReferansPuani: ReferansPuani,
            ReferansImage: ReferansImageUrl,
            GuncelleyenKisiID: guncelleyenkisi
        };
        var jsonData = JSON.stringify(veri);
        Guncelle2(jsonData);
    }
}

function Guncelle2(jsonData)
{
    $.ajax({
        url: '/Referanslarimiz/ReferansUpdate',
        type: 'PUT',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Referans başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/Referanslarimiz/ReferansListeleme";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Referans güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}

function ListelemeyeDon() {
    location.href = "/Referanslarimiz/ReferansListeleme";
}
function ResimSil(url) {
    $.ajax({
        type: "GET",
        url: "/File/DeleteFileWithUrl/" + encodeURIComponent(url),
        dataType: "json",
        success: function (response) {
            console.log("Silme işlemi başarılı: ", response);
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Silme işleminde hata ile karşılaştık");
        }
    });
}
