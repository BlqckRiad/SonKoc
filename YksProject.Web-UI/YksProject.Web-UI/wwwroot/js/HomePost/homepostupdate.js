var genelPostMedyaID;
$(document).ready(function () {
    // Mevcut sayfanın URL'sini al
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];

    idyeGorePostGetir(id);

});
function idyeGorePostGetir(id) {
    $.ajax({
        type: "GET",
        url: "/HomePost/PostGetir/" + id,
        success: function (data) {
        
            // Gelen veriyi ilgili input alanlarına doldur
            $('#HomePostSahibi').val(data.postSahibi);
            $('#HomePostAdi').val(data.postAdi);
            $('#HomePostAciklamasi').val(data.postAciklamasi);
            $('#PostYayindaMi').val(data.postYayindaMi.toString());
            var imgElementi = document.getElementById("postikon");
            imgElementi.src = data.postMedyaUrl;
            genelPostMedyaID = data.postImageID;
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Post getirilirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}

function HomePostGuncelle() {
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    var id = urlParts[urlParts.length - 1];
    var PostAdi = $('#HomePostAdi').val();
    var PostAciklamasi = $('#HomePostAciklamasi').val();
    var PostSahibi = $('#HomePostSahibi').val();
    var selectedValue = document.getElementById("PostYayindaMi").value;
    var PostYayindaMi = (selectedValue === 'true'); // Boolean'a dönüştürme

    var guncelleyenkisi = localStorage.getItem('TabloID');
    var imgElement = document.getElementById('postikon');
    var PostImageUrl = imgElement.src;
    var input = document.getElementById('PostImage');
    if (input.value) {
        ResimSil(PostImageUrl);
        var file = $('#PostImage').prop('files')[0];
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
                    PostAdi: PostAdi,
                    PostAciklamasi: PostAciklamasi,
                    PostSahibi: PostSahibi,
                    PostYayindaMi: PostYayindaMi,
                    PostMedyaUrl: responseimage.medyaUrl,
                    PostMedyaID: responseimage.tabloID,
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
            PostAdi: PostAdi,
            PostAciklamasi: PostAciklamasi,
            PostSahibi: PostSahibi,
            PostYayindaMi: PostYayindaMi,
            PostMedyaUrl: PostImageUrl,
            PostMedyaID: genelPostMedyaID,
            GuncelleyenKisiID: guncelleyenkisi
        };
        var jsonData = JSON.stringify(veri);
        Guncelle2(jsonData);
    }
}

function Guncelle2(jsonData) {
    $.ajax({
        url: '/HomePost/HomePostUpdate',
        type: 'PUT',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Referans başarıyla güncellendi:', response);
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/HomePost/HomePostList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Referans güncellenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}

function ListelemeyeDon() {
    location.href = "/HomePost/HomePostList";
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