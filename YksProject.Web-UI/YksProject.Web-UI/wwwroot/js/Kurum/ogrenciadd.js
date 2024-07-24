function OgrenciEkle() {
    // Form elemanlarının değerlerini al
    var ad = document.getElementById("isim").value;
    var soyad = document.getElementById("soyisim").value;
    var username = document.getElementById("username").value;
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var kurumidnotint = localStorage.getItem("TabloID");
    var kurumid = parseInt(kurumidnotint, 10);

    // Tarih verilerini al
    var gun = document.getElementById("Gun").value;
    var ay = document.getElementById("Ay").value;
    var yil = document.getElementById("Yil").value;
    var date = `${yil}-${ay}-${gun}`; // Tarih formatı YYYY-MM-DD (bunu ihtiyaca göre düzenleyin)

    // Cinsiyet seçimini al
    var cinsiyetid = document.querySelector('input[name="gender"]:checked')?.value;

    // Veriyi hazırlayın
    var veri = {
        KisiAdi: ad,
        KisiSoyAdi: soyad,
        KisiKullaniciAdi: username,
        KisiEmail: email,
        KisiPassword: password,
        KisiIlgiliKurumID: kurumid,
        KisiCinsiyetID: cinsiyetid,
        KisiDogumTarihi: date,
    };

    $.ajax({
        url: '/Kurum/OgrenciAdd',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(veri),
        success: function (response) {
            location.href = "/Kurum/Ogrenciler";
        },
        error: function (xhr, status, error) {
            console.error('Konu eklenirken bir hata oluştu:', error);
        }
    });
}

function getSelectedGenderId() {
    // Get all radio buttons with the name 'gender'
    const radios = document.getElementsByName('gender');

    // Iterate over the radio buttons
    for (let i = 0; i < radios.length; i++) {
        // Check if the radio button is checked
        if (radios[i].checked) {
            // Return the ID of the selected radio button
            return radios[i].id;
        }
    }

    // Return 0 if no radio button is selected
    return 0;
}
function getDateFromInputs() {
    // Get values from input fields
    var day = parseInt(document.getElementById("Gun").value, 10);
    var month = parseInt(document.getElementById("Ay").value, 10) - 1; // Months are 0-indexed in JavaScript Date
    var year = parseInt(document.getElementById("Yil").value, 10);

    // Validate the inputs
    if (isNaN(day) || isNaN(month) || isNaN(year)) {
        return null; // Return null if any value is not a number
    }

    // Create a Date object
    var date = new Date(year, month, day);

    // Check if the date is valid (e.g., handling invalid dates like April 31)
    if (date.getFullYear() !== year || date.getMonth() !== month || date.getDate() !== day) {
        return null; // Return null if the date is invalid
    }

    return date;
}