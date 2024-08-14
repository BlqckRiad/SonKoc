function Ekle() {
    var k1 = document.getElementById("promokod").value;
    var k2 = document.getElementById("promokodneicin").value;
    var k3 = document.getElementById("promokodlimit").value;
    var k4 = document.getElementById("promokodindirim").value;
    var olusturanKisiIDnoint = localStorage.getItem("TabloID");
    var olusturanKisiID = parseInt(olusturanKisiIDnoint, 10);
    var veri = {
        PromoKod: k1,
        PromoKodNeİcin: k2,
        PromoKeyLimit: k3,
        PromoKeyYuzdeKacIndirim: k4,
        OlusturanKisiID: olusturanKisiID,
    };
    var token = localStorage.getItem("Token");
    $.ajax({
        url: '/PromoKey/PromoKeyAddData',
        headers: { "Authorization": "Bearer " + token },
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(veri),
        success: function (response) {
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/PromoKey/PromoKeyList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Konu eklenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}
