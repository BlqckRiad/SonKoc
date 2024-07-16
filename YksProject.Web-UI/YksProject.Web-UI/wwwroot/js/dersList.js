$(document).ready(function () {
    DataGetir();
});


function DataGetir() {
    $.ajax({
        type: "GET",
        url: "/Dersler/DersListeleData",
        success: function (result) {
            var data = result;
            $("#DerslerGenelTable").DataTable().destroy(); // Mevcut DataTable'ı yok et
            var satirlar = "";
            for (var i = 0; i < data.length; i++) {
                var bolum = idyeGoreBolumGetir(data[i].dersBolumID);
                satirlar += "<tr>\
                        <td>"+ data[i].tabloID + "</td>\
                        <td>"+ data[i].dersAdi + "</td>\
                        <td>"+ bolum + "</td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-danger' onclick='SilmeSayfasinaGit(" + data[i].tabloID + ")'>Sil</button></td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-success' onclick='GuncelleSayfasinaGit(" + data[i].tabloID + ")'>Güncelle</button></td>\
                        </tr>";
            }
            $("#tbody").html(satirlar);

            // DataTable'ı yeniden initialize et
            $('#DerslerGenelTable').DataTable({
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

function idyeGoreBolumGetir(id) {
    var sinavKodu = "Bulunamadı"; // Default value
    $.ajax({
        url: '/Bolumler/BolumGetir/' + id,
        type: 'GET',
        async: false, // Make the call synchronous
        success: function (data) {
            sinavKodu = data.bolumAdi;
        },
    });
    return sinavKodu;
}
