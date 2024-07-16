$(document).ready(function () {
   
});



function Ekle() {
    // Input değerlerini al
    var üyetipiad = $('#uyeTipiAdi').val();
    var üyetipiaciklama = $('#uyeTipiAciklamasi').val();
    // Veri objesini oluştur
    var veri = {
        UyeTipiAdi: üyetipiad,
        UyeTipiAciklamasi: üyetipiaciklama,
    };

    // AJAX isteği gönder
    $.ajax({
        url: '/PaketUyeTipleri/PaketUyeTipleriAddData',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(veri),
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Üye Tipi başarıyla eklendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/PaketUyeTipleri/PaketUyeTipleriList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Üye Tipi eklenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}

function ListelemeyeDon() {
    location.href = "/PaketUyeTipleri/PaketUyeTipleriList";
}