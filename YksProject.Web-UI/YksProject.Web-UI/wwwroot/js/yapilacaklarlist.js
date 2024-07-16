var id;
var gunler = ["", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar"];
$(document).ready(function () {
    // Mevcut sayfanın URL'sini al
    var currentURL = window.location.href;

    // URL'yi parçalara ayır
    var urlParts = currentURL.split('/');

    // ID değeri, son parça olacak
    id = urlParts[urlParts.length - 1];

    // Gün adlarını içeren bir dizi oluştur
   

    // Hedef elementi seç ve içeriğini güncelle
    var h2Element = $('[itemid="gün"]');
    if (h2Element.length > 0) {
        h2Element.text(gunler[id] + " Günü Programım");
    } else {
        console.log("Hedef element bulunamadı!");
    }


    listele();
});

function listele() {
    $.ajax({
        url: "http://localhost:3798/api/Yapilacaklar", // İstek yapılacak URL
        type: 'GET',
        success: function (result) {
            var data = result;
            $("#BolumGenelTable").DataTable().destroy();
            var satirlar = "";

            for (var i = 0; i < data.length; i++) {
                var text = "";
                // Check the condition
                if (data[i].yapilacakGorevGunNo === id) {
                    // Check the state of the checkbox
                    var checkedAttribute = data[i].yapildiMi == 1 ? "checked" : "";
                    if (checkedAttribute === "checked") {
                        text = " <td style='font-weight: bold; background-color: green; color : black;'>" + data[i].yapilacakGorevAdi + "</td>\
            <td class='text-center'> ";
                    } else {
                        text = "<td style='font-weight: bold;'>" + data[i].yapilacakGorevAdi + "</td>\
            <td class='text-center'>";
                    }

                    satirlar += "<tr>\ " + text + "\
                <div class='custom-checkbox'> \
                    <input type='checkbox' id='checkbox"+ data[i].tabloID + "' onclick='idyeGoreIslemYapildiYap(" + data[i].tabloID + ")' " + checkedAttribute + "> \
                    <label for='checkbox"+ data[i].tabloID + "'></label> \
                </div> \
            </td>\
        </tr>";
                }
            }


            $("#tbody").html(satirlar);

        },
        error: function (xhr, status, error) {
            // İstek başarısız olduğunda yapılacak işlemler
            console.error(error);
        }
    });
}


function idyeGoreIslemYapildiYap(tabloID) {
    // Checkbox'u kontrol et
    var checkbox = document.getElementById('checkbox' + tabloID);

    // Checkbox'u kontrol et
    if (checkbox) {
        var yapildiMiDegeriData = checkbox.checked ? 1 : 0;

        // Şu anki tarihi al
        // Şu anki zamanı uygun formata dönüştürme
        function getCurrentDateTime() {
            var now = new Date();
            var formattedDate = now.toISOString().split('T')[0] + " " + now.toLocaleTimeString('tr-TR', { hour12: false });
            return formattedDate;
        }

        var anlikZaman = getCurrentDateTime();


        var gorevYapilmaTarihiData = anlikZaman;



       

        
            $.ajax({
                url: 'http://localhost:3798/api/Yapilacaklar/' + tabloID,
                type: 'GET',
                success: function (data) {
                    var veri = {
                        TabloId: tabloID,
                        KisiID: data.kisiID,
                        YapilacakGorevAdi: data.yapilacakGorevAdi,
                        YapilacakGorevAciklamasi: data.yapilacakGorevAciklamasi,
                        YapilacakGorevIkon: data.yapilacakGorevIkon,
                        YapilacakGorevGun: data.yapilacakGorevGun,
                        YapilacakGorevGunNo: data.yapilacakGorevGunNo,
                        YapildiMi: yapildiMiDegeriData,
                        GorevEklenmeTarihi: data.gorevEklenmeTarihi
                    };
                    $.ajax({
                        url: 'http://localhost:3798/api/Yapilacaklar',
                        type: 'PUT',
                        contentType: 'application/json',
                        data: JSON.stringify(veri),
                        success: function (response) {
                            location.href = "/Yapilacaklar/YapilacaklarListele/" + id;
                        },
                        error: function (xhr, status, error) {
                            console.error('Görev güncellenirken bir hata oluştu:', error);
                        }
                    });

                },
                error: function (xhr, status, error) {
                    console.error('Görev getirilirken bir hata oluştu:', error);
                }
            });

        
    } else {
        console.error('Checkbox bulunamadı.');
    }
}




