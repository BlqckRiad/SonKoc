function Ekle() {
    // Input değerlerini al
    var Sad = $('#sad').val();
    
    var olusturanKisiID = localStorage.getItem('TabloID');
    // Veri objesini oluştur
    var veri = {
        SinavTipiAdi: Sad,
        OlusturanKisiID: olusturanKisiID
    };

    // Verileri JSON formatına dönüştür
    var jsonData = JSON.stringify(veri);

    // AJAX isteği gönder
    $.ajax({
        url: '/SinavTipleri/SinavTipleriAdd',
        type: 'POST',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            
            showNotification('Başarıyla eklendi!', 'success');
            location.href = "/SinavTipleri/SinavTipiListele";
        },
        error: function (xhr, status, error) {
            showNotification('Eklenemedi, bir hatayla karşılaştık.', 'error');
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
