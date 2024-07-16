$(document).ready(function () {
    DataGetir();
});

function DataGetir() {
    $.ajax({
        type: "GET",
        url: "/UyelikPaketi/UyelikPaketiListData",
        success: function (result) {
            var data = result;
            $("#PaketGenelTable").DataTable().destroy(); // Mevcut DataTable'ı yok et
            var satirlar = "";

            for (var i = 0; i < data.length; i++) {
                satirlar += "<tr>\
                        <td>"+ data[i].tabloID + "</td>\
                        <td>"+ data[i].paketAdi + "</td>\
                        <td>"+ data[i].paketAciklamasi + "</td>\
                        <td><img src='"+ data[i].paketImageUrl + "' alt='Paket Resmi' style='max-width: 50px; max-height: 50px;'></td>\
                        <td>"+ data[i].paketUcreti + "</td>\
                        <td>"+ data[i].paketIndirimOrani + "</td>\
                        <td>"+ indirimliFiyat(data[i].paketUcreti, data[i].paketIndirimOrani) + "</td>\
                        <td>"+ idyeGorePaketGetir(data[i].paketUyeTipiID) + "</td>\
                        <td>"+ data[i].paketUyeSayısı + "</td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-danger' onclick='SilmeSayfasinaGit(" + data[i].tabloID + ")'>Sil</button></td>\
                        <td class='text-center'> <button type='button' class='btn mb-1 btn-rounded btn-success' onclick='GuncelleSayfasinaGit(" + data[i].tabloID + ")'>Güncelle</button></td>\
                        </tr>";
            }
            $("#tbody").html(satirlar);

            // DataTable'ı yeniden initialize et
            $('#PaketGenelTable').DataTable({
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
        url: "/UyelikPaketi/UyelikPaketiSilme",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(deleteDto),
        success: function (result) {
            // Silme işlemi başarılı olduysa, listedeki sayfaya yönlendir
            location.href = "/UyelikPaketi/UyelikPaketiList";
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Silme işleminde hata ile karşılaştık");
        }
    });
}



function GuncelleSayfasinaGit(id) {
    location.href = "/UyelikPaketi/UyelikPaketiGuncelleme/" + id;
}

function indirimliFiyat(hamFiyat, indirimOrani) {
    var indirimMiktari = hamFiyat * (indirimOrani / 100);
    var indirimliFiyat = hamFiyat - indirimMiktari;
    return indirimliFiyat;
}

function idyeGorePaketGetir(id) {
    var veri = null;
    $.ajax({
        type: "GET",
        url: "/PaketUyeTipleri/PaketUyeTipleriGetData/" + id,
        async: false, // Ajax isteğini senkron hale getirir (dikkat: performans sorunlarına yol açabilir)
        success: function (data) {
            veri = data.uyeTipiAdi;
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('PaketUyeTipleri getirilirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
    return veri;
}
