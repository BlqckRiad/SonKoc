$(document).ready(function () {
    DataGetir();
});


function DataGetir() {
    $.ajax({
        type: "GET",
        url: "/PaketUyeTipleri/PaketUyeTipleriListeleData",
        success: function (result) {
            var data = result;
            $("#PaketUyeTipleriTable").DataTable().destroy(); // Mevcut DataTable'ı yok et
            var satirlar = "";
            for (var i = 0; i < data.length; i++) {
                satirlar += "<tr>\
                        <td>"+ data[i].tabloID + "</td>\
                        <td>"+ data[i].uyeTipiAdi + "</td>\
                        <td>"+ data[i].uyeTipiAciklamasi + "</td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-danger' onclick='SilmeSayfasinaGit(" + data[i].tabloID + ")'>Sil</button></td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-success' onclick='GuncelleSayfasinaGit(" + data[i].tabloID + ")'>Güncelle</button></td>\
                        </tr>";
            }
            $("#tbody").html(satirlar);

            // DataTable'ı yeniden initialize et
            $('#PaketUyeTipleriTable').DataTable({
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
    var deleteDto = {
        TabloID: id,
        SilenKisiID: silenkisiID
    };
    $.ajax({
        type: "POST",
        url: "/PaketUyeTipleri/PaketUyeTipleriDeleteData",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(deleteDto),
        success: function (result) {
            // Silme işlemi başarılı olduysa, listedeki sayfaya yönlendir
            location.href = "/PaketUyeTipleri/PaketUyeTipleriList";
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Silme işleminde hata ile karşılaştık");
        }
    });
}
function GuncelleSayfasinaGit(id) {
    location.href = "/PaketUyeTipleri/PaketUyeTipleriUpdate/" + id;
}

