$(document).ready(function () {
    DataGetir();
});

function DataGetir() {
    $.ajax({
        type: "GET",
        url: "/HomePost/HomePostListData",
        success: function (result) {
            var data = result;
            $("#HomePostGenelTable").DataTable().destroy();
            var satirlar = "";

            for (var i = 0; i < data.length; i++) {
                satirlar += "<tr>\
                        <td>"+ data[i].tabloID + "</td>\
                        <td>"+ data[i].postSahibi + "</td>\
                        <td>"+ data[i].postAdi + "</td>\
                        <td>"+ data[i].postAciklamasi + "</td>\
                        <td><img src='"+ data[i].postMedyaUrl + "' alt='Referans Image' style='max-width: 50px; max-height: 50px;'></td>\
                        <td>"+ data[i].postYayindaMi + "</td>\
                        <td>"+ data[i].postGorulmeSayisi + "</td>\
                        <td>"+ data[i].postTiklanmaSayisi + "</td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-danger' onclick='SilmeSayfasinaGit(" + data[i].tabloID + ")'>Sil</button></td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-success' onclick='GuncelleSayfasinaGit(" + data[i].tabloID + ")'>Güncelle</button></td>\
                        </tr>";
            }
            $("#tbody").html(satirlar);

            $('#HomePostGenelTable').DataTable({
                "paging": true,
                "responsive": true,
                "language": {
                    "lengthMenu": "Sayfa başına _MENU_ kayıt göster",
                    "info": "_TOTAL_ kayıttan _START_ - _END_ arası gösteriliyor",
                    "searchPlaceholder": "Ara",
                    "zeroRecords": "Kayıt bulunamadı",
                    "infoEmpty": "Kayıt yok",
                    "paginate": {
                        "first": "İlk",
                        "last": "Son",
                        "next": "Sonraki",
                        "previous": "Önceki"
                    }
                }
            });

        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Veri getirilirken bir hata oluştu.");
        }
    });
}



function SilmeSayfasinaGit(id) {
    var silenkisiID = localStorage.getItem("TabloID");

    // localStorage'dan alınan değeri integer tipine çevirme
    var silenkisiIDInteger = parseInt(silenkisiID, 10);

    var deleteDto = {
        TabloID: id,
        SilenKisiID: silenkisiIDInteger
    };

    $.ajax({
        type: "POST",
        url: "/HomePost/HomePostSilme",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(deleteDto),
        success: function (result) {
            // Silme işlemi başarılı olduysa, listedeki sayfaya yönlendir
            location.href = "/HomePost/HomePostList";
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Silme işleminde hata ile karşılaştık");
        }
    });
}


function GuncelleSayfasinaGit(id) {
    location.href = "/HomePost/HomePostUpdate/" + id;
}