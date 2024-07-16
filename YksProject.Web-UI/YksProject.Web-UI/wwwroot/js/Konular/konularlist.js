$(document).ready(function () {
    DataGetir();
});


function DataGetir() {
    $.ajax({
        type: "GET",
        url: "/Konular/KonularListeleData",
        success: function (result) {
            var data = result;
            $("#KonularGenelTable").DataTable().destroy(); // Mevcut DataTable'ı yok et
            var satirlar = "";

            for (var i = 0; i < data.length; i++) {
                satirlar += "<tr>\
                        <td>"+ data[i].tabloID + "</td>\
                        <td>"+ data[i].konuAdi + "</td>\
                        <td>"+ data[i].konuDersAdi + "</td>\
                        <td>"+ data[i].konu1SeneSoruSayisi + "</td>\
                        <td>"+ data[i].konu2SeneSoruSayisi + "</td>\
                        <td>"+ data[i].konu3SeneSoruSayisi + "</td>\
                        <td>"+ data[i].konuAciklamasi + "</td>\
                        <td>"+ data[i].konuAciklamasiYapanKisi + "</td>\
                        <td>"+ data[i].konuAciklamasiYapanKisiRolu + "</td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-danger' onclick='SilmeSayfasinaGit(" + data[i].tabloID + ")'>Sil</button></td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-success' onclick='GuncelleSayfasinaGit(" + data[i].tabloID + ")'>Güncelle</button></td>\
                        </tr>";
            }
            $("#tbody").html(satirlar);

            // DataTable'ı yeniden initialize et
            $('#KonularGenelTable').DataTable({
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
            alert("Giriş işleminde karşılaştık");
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
        url: "/Konular/KonularSilmeData",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(deleteDto),
        success: function (result) {
            // Silme işlemi başarılı olduysa, listedeki sayfaya yönlendir
            location.href = "/Konular/KonularList";
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Silme işleminde hata ile karşılaştık");
        }
    });
}


function GuncelleSayfasinaGit(id) {
    location.href = "/Konular/KonularUpdate/" + id;
}