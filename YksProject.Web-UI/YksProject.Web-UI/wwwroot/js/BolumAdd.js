function BolumEkle() {
    // Input değerlerini al
    var bolumAd = $('#BolumAd').val();
    var bolumKod = $('#BolumKod').val();
    var olusturanKisiID = localStorage.getItem('TabloID');
    // Veri objesini oluştur
    var veri = {
        BolumAdi: bolumAd,
        BolumAdKodu: bolumKod,
        OlusturanKisiID: olusturanKisiID
    };

    // Verileri JSON formatına dönüştür
    var jsonData = JSON.stringify(veri);

    // AJAX isteği gönder
    $.ajax({
        url: '/Bolumler/BolumAdd',
        type: 'POST',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Bölüm başarıyla eklendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/Bolumler/BolumListele";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Bölüm eklenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}
