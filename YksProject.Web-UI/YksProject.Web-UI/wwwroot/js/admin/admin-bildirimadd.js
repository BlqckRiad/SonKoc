function ListelemeyeDon() {
    location.href = "/Admin/BildirimList";
}

function BildirimEkle() {
    var k1 = $('#bildirimbasligi').val();
    var k2 = $('#bildirimaciklamasi').val();
    var k3 = $('#aliciid').val();
    var olusturanKisiID = localStorage.getItem('TabloID');
    // Veri objesini oluştur
    var veri = {
        BildirimBasligi: k1,
        BildirimAciklamasi: k2,
        AliciKisiID: k3,
        GonderenKisiID: olusturanKisiID,
        OlusturanKisiID: olusturanKisiID
    };

    // Verileri JSON formatına dönüştür
    var jsonData = JSON.stringify(veri);

    // AJAX isteği gönder
    $.ajax({
        url: '/Admin/SenNotifToFirebase',
        type: 'POST',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı olduğunda bildirim göster
            showNotification('Başarıyla eklendi!', 'success');
            setTimeout(function () {
                location.href = "/Admin/BildirimList";
            }, 750);
        },
        error: function (xhr, status, error) {
            // Hata durumunda bildirim göster
            showNotification('Eklenemedi, bir hatayla karşılaştık.', 'error');
            // Ekleme sayfasında kal
        }
    });
}

function showNotification(message, type) {
    var bgColor;
    if (type === 'success') {
        bgColor = '#43a889'; // Yeşil
    } else if (type === 'error') {
        bgColor = '#ff6b6b'; // Kırmızı
    }
    var notification = $('<div></div>', {
        text: message,
        css: {
            position: 'fixed',
            top: '20px',
            right: '20px',
            padding: '20px',
            color: '#fff',
            backgroundColor: bgColor,
            borderRadius: '5px',
            zIndex: 1000
        }
    });
    $('body').append(notification);
    setTimeout(function () {
        notification.fadeOut(500, function () {
            $(this).remove();
        });
    }, 750);
}
