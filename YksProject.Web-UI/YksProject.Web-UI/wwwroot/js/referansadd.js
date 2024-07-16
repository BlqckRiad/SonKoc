








var ReferansImageId;
var ReferansImageUrl;

async function DosyaYukle(file) {
    var formData = new FormData();
    formData.append("file", file);

    try {
        const response = await $.ajax({
            url: '/File/AddFile', // Sunucuya istek yapılacak URL
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false
        });

        ReferansImageId = response.tabloID;
        ReferansImageUrl = response.medyaUrl;

    } catch (error) {
        console.error("Dosya yüklenirken bir hata oluştu:", error);
    }
}




async function ReferansEkle() {
    try {
        // Dosya yükleme işlemi başlatılıyor ve tamamlandığında ReferansImageUrl güncellenecek
        await DosyaYukle(document.getElementById("ReferansImage").files[0]);

        // Dosya yükleme işlemi tamamlandıktan sonra diğer referans bilgileri alınıyor
        var ReferansAdi = $('#ReferansAdi').val();
        var ReferansAciklamasi = $('#ReferansAciklamasi').val();
        var ReferansRolu = $('#ReferansRolu').val();
        var ReferansPuani = document.getElementById("ReferansPuani").value;
        var ReferansImage = ReferansImageUrl;
        var olusturanKisiID = localStorage.getItem('TabloID');
        // Veri objesi oluşturuluyor
        var veri = {
            ReferansAdi: ReferansAdi,
            ReferansAciklamasi: ReferansAciklamasi,
            ReferansRolu: ReferansRolu,
            ReferansPuani: ReferansPuani,
            ReferansImage: ReferansImage,
            OlusturanKisiID: olusturanKisiID
        };

        // AJAX isteği gönderiliyor
        const response = await $.ajax({
            url: '/Referanslarimiz/ReferansAdd',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(veri)
        });

        // Başarılı bir şekilde eklendiğinde yapılacak işlemler
        console.log('Referans başarıyla eklendi:', response);
        // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
        location.href = "/Referanslarimiz/ReferansListeleme";

    } catch (error) {
        // Hata durumunda yapılacak işlemler
        console.error('Referans eklenirken bir hata oluştu:', error);
        // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
    }
}


    function ListelemeyeDon() {
        location.href = "/Referanslarimiz/ReferansListeleme";
    }
