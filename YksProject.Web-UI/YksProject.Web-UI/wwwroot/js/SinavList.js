$(document).ready(function () {
    SinavListeleDataGetir();
});

function SinavListeleDataGetir() {
    $.ajax({
        type: "GET",
        url: "/Sinav/SinavListeleData",
        success: function (result) {
            var data = result;
            $("#SinavGenelTable").DataTable().destroy();
            var satirlar = "";

            for (var i = 0; i < data.length; i++) {
                var sinavBittiDegeri = data[i].sinaviKurumMuEkledi ? "Sınavı Kurum Eklemiştir." : "Sınavı Sistem Eklemiştir.";
                satirlar += "<tr>\
                        <td>"+ data[i].tabloID + "</td>\
                        <td>"+ data[i].sinavAdi + "</td>\
                        <td>"+ data[i].sinavKodu + "</td>\
                        <td>"+ data[i].sinavTipiID + "</td>\
                        <td>"+ data[i].sinavSüresi + "</td>\
                        <td>"+ sinavBittiDegeri + "</td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-danger' onclick='SinavSil(" + data[i].tabloID + ")'>Sil</button></td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-success' onclick='SinavGuncelle(" + data[i].tabloID + ")'>Güncelle</button></td>\
                        </tr>";
            }
            $("#tbody").html(satirlar);

            $('#SinavGenelTable').DataTable({
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
            alert("Veri alınırken bir hata oluştu.");
        }
    });
}
function SinavSil(id) {
    var silenkisiID = localStorage.getItem("TabloID");

    // localStorage'dan alınan değeri integer tipine çevirme
    var silenkisiIDInteger = parseInt(silenkisiID, 10);

    var deleteDto = {
        TabloID: id,
        SilenKisiID: silenkisiIDInteger
    };

    $.ajax({
        type: "POST",
        url: "/Sinav/SinavSilme",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(deleteDto),
        success: function (result) {
            // Silme işlemi başarılı olduysa, listedeki sayfaya yönlendir
            location.href = "/Sinav/SinavListeleme";
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Silme işleminde hata ile karşılaştık");
        }
    });
}

function SinavGuncelle(id) {
    location.href = "/Sinav/SinavGuncelleme/" + id;
}
