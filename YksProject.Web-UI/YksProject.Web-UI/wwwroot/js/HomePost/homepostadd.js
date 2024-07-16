








var HomePostImageID;
var HomePostImageUrl;

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

        HomePostImageID = response.tabloID;
        HomePostImageUrl = response.medyaUrl;

    } catch (error) {
        console.error("Dosya yüklenirken bir hata oluştu:", error);
    }
}




async function HomePostEkle() {
    try {
        // Dosya yükleme işlemi başlatılıyor ve tamamlandığında ImageUrl güncellenecek
        await DosyaYukle(document.getElementById("PostImage").files[0]);

        // Dosya yükleme işlemi tamamlandıktan sonra diğer referans bilgileri alınıyor
        var PostAdi = $('#HomePostAdi').val();
        var PostAciklamasi = $('#HomePostAciklamasi').val();
        var PostSahibi = $('#HomePostSahibi').val();
        var PostImageUrl = HomePostImageUrl;
        var PostImageID = HomePostImageID;
        var olusturanKisiID = localStorage.getItem('TabloID');
        // Veri objesi oluşturuluyor
        var veri = {
            PostAdi: PostAdi,
            PostAciklamasi: PostAciklamasi,
            PostMedyaUrl: PostImageUrl,
            PostMedyaID: PostImageID,
            PostSahibi: PostSahibi,
            OlusturanKisiID: olusturanKisiID,
        };

        // AJAX isteği gönderiliyor
        const response = await $.ajax({
            url: '/HomePost/HomePostAddData',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(veri)
        });

        // Başarılı bir şekilde eklendiğinde yapılacak işlemler
        console.log('Referans başarıyla eklendi:', response);
        // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
        location.href = "/HomePost/HomePostList";

    } catch (error) {
        // Hata durumunda yapılacak işlemler
        console.error('HomePost eklenirken bir hata oluştu:', error);
        // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
    }
}
