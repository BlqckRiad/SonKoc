
$(document).ready(function () {
    dropdowndoldur();
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

function PaketEkle() {
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
          

            var data1 = $('#paketAd').val();
            var data2 = $('#paketDesc').val();
            var data3 = $('#paketucret').val();
            var data4 = $('#paketindirimorani').val();
            var data5 = $('#pakettipi').val();
            var data6 = $('#paketKisiSayisi').val();
            var olusturanKisiID = localStorage.getItem('TabloID');

            var veri = {
                PaketAdi: data1,
                PaketAciklamasi: data2,
                PaketImageID: responseimage.tabloID,
                PaketImageUrl: responseimage.medyaUrl,
                PaketUcreti: data3,
                PaketIndirimOrani: data4,
                PaketUyeTipiID: data5,
                PaketUyeSayısı: data6,
                OlusturanKisiID: olusturanKisiID
            };



    //Veri Gönderme 
    var jsonData = JSON.stringify(veri);
    // AJAX isteği gönder
    $.ajax({
        url: '/UyelikPaketi/UyelikPaketiEkle',
        type: 'POST',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Paket başarıyla eklendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/UyelikPaketi/UyelikPaketiList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Paket eklenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Dosya yükleme hatası:', status, error);
        }
    });
}
