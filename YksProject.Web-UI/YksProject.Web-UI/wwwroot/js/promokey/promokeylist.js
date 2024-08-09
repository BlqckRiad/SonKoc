$(document).ready(function () {
    DataGetir();
});


function DataGetir() {
    var token = localStorage.getItem("Token");
    $.ajax({
        type: "GET",
        headers: { "Authorization": "Bearer " + token },
        url: "/PromoKey/PromoKeysListData",
        success: function (result) {
            var data = result;
            $("#PromoKeyGenelTable").DataTable().destroy(); // Mevcut DataTable'ı yok et
            var satirlar = "";
            for (var i = 0; i < data.length; i++) {
                
                satirlar += "<tr>\
                        <td>"+ data[i].tabloID + "</td>\
                        <td>"+ data[i].promoKod + "</td>\
                        <td>"+ data[i].promoKeyLimit + "</td>\
                        <td>"+ data[i].promoKeyKullanimSayisi + "</td>\
                        <td>"+ data[i].promoKeyYuzdeKacIndirim + "</td>\
                        <td>"+ data[i].promoKodNeİcin + "</td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-danger' onclick='SilmeSayfasinaGit(" + data[i].tabloID + ")'>Sil</button></td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-success' onclick='GuncelleSayfasinaGit(" + data[i].tabloID + ")'>Güncelle</button></td>\
                        </tr>";
            }
            $("#tbody").html(satirlar);

            // DataTable'ı yeniden initialize et
            $('#PromoKeyGenelTable').DataTable({
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
    var token = localStorage.getItem("Token");
    // localStorage'dan alınan değeri integer tipine çevirme
    var silenkisiIDInteger = parseInt(silenkisiID, 10);

    var deleteDto = {
        TabloID: id,
        SilenKisiID: silenkisiIDInteger,
        Token:token
    };

    $.ajax({
        type: "POST",
        url: "/Dersler/DersSilme",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(deleteDto),
        success: function (result) {
            // Silme işlemi başarılı olduysa, listedeki sayfaya yönlendir
            location.href = "/Dersler/DersListele";
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Silme işleminde hata ile karşılaştık");
        }
    });
}


function GuncelleSayfasinaGit(id) {
    location.href = "/Dersler/DersGuncelle/" + id;
}
