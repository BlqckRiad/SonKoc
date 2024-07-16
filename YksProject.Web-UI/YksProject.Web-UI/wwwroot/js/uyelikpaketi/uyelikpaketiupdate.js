var suankiPaketid;
$(document).ready(function () {
    dropdowndoldur();
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGoreDataGetir(id);

});
function dropdowndoldur() {
    $.ajax({
        type: "GET",
        url: "/PaketUyeTipleri/PaketUyeTipleriListeleData",
        success: function (result) {
            var select = $('#pakettipi'); // Dropdown'u seç

            // Her bir veri için döngü
            for (var i = 0; i < result.length; i++) {
                // Option elementini oluştur
                var option = $('<option></option>').attr('value', result[i].tabloID).text(result[i].uyeTipiAdi);

                // Oluşturulan option'u dropdown'a ekle
                select.append(option);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Giriş işleminde karşılaştık");
        }
    });
}

function idyeGoreDataGetir(id) {
    $.ajax({
        type: "GET",
        url: "/UyelikPaketi/UyelikPaketiGetir/" + id,
        success: function (data) {
            console.log(data);
            // Gelen veriyi ilgili input alanlarına doldur
            $('#paketAd').val(data.paketAdi);
            $('#paketDesc').val(data.paketAciklamasi);
            $('#paketucret').val(data.paketUcreti);
            $('#paketindirimorani').val(data.paketIndirimOrani);
            $('#pakettipi').val(data.paketUyeTipiID);
            $('#paketKisiSayisi').val(data.paketUyeSayısı);
            var imgElementi = document.getElementById("paketIkonu");
            imgElementi.src = data.paketImageUrl;
            suankiPaketid = data.paketImageID;
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
    var PaketAdi = $('#paketAd').val();
    var PaketAciklamasi = $('#paketDesc').val();
    var PaketUcreti = document.getElementById("paketucret").value;
    var PaketIndirimOrani = document.getElementById("paketindirimorani").value;
    var PaketUyeTipiID = document.getElementById("pakettipi").value;
    var PaketUyeSayısı = document.getElementById("paketKisiSayisi").value;
    var PaketImageID = suankiPaketid;
    var imgElement = document.getElementById('paketIkonu');
    var PaketImageUrl = imgElement.src;
    var input = document.getElementById('paketImage');

    var guncelleyenkisi = localStorage.getItem('TabloID');
    if (input.value) {
        SilmeSayfasinaGit(suankiPaketid);
        var file = $('#paketImage').prop('files')[0];
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
                    PaketAdi: PaketAdi,
                    PaketAciklamasi: PaketAciklamasi,
                    PaketUcreti: PaketUcreti,
                    PaketIndirimOrani: PaketIndirimOrani,
                    PaketUyeTipiID: PaketUyeTipiID,
                    PaketUyeSayısı: PaketUyeSayısı,
                    PaketImageID: responseimage.tabloID,
                    PaketImageUrl: responseimage.medyaUrl,
                    GuncelleyenKisiID: guncelleyenkisi
                };

                var jsonData = JSON.stringify(veri);
                // AJAX isteği gönder
                Guncelle2(jsonData);
            }

        });
    } else {
        var veri = {
            TabloID: id,
            PaketAdi: PaketAdi,
            PaketAciklamasi: PaketAciklamasi,
            PaketUcreti: PaketUcreti,
            PaketIndirimOrani: PaketIndirimOrani,
            PaketUyeTipiID: PaketUyeTipiID,
            PaketUyeSayısı: PaketUyeSayısı,
            PaketImageID: PaketImageID,
            PaketImageUrl: PaketImageUrl,
            GuncelleyenKisiID: guncelleyenkisi
        };

        var jsonData = JSON.stringify(veri);
        // AJAX isteği gönder
        Guncelle2(jsonData);
    }

}

function SilmeSayfasinaGit(id) {
    $.ajax({
        type: "GET",
        url: "/File/DeleteFile/" + id,
        dataType: "json",
        data: null,
        success: function (response) {
            console.log("Silme işlemi başarılı: ", response);
           
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Silme işleminde hata ile karşılaştık");
        }
    });
}
function Guncelle2(jsonData) {
    $.ajax({
        url: '/UyelikPaketi/UyelikPaketiUpdate',
        type: 'PUT',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Paket başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/UyelikPaketi/UyelikPaketiList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Paket güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}