function register() {
    // Input değerlerini al
    var name = $('#exampleInputName1').val().trim();
    var surname = $('#exampleInputName2').val().trim();
    var userName = $('#exampleInputName3').val().trim();
    var email = $('#exampleInputEmail1').val().trim();
    var password = $('#exampleInputPassword1').val();

    // Hata mesajlarını sıfırla
    $('.text-danger').text('');

    // Boş alan kontrolü
    if (name === '') {
        $('#exampleInputName1').next('.text-danger').text('İsim alanı boş olamaz');
        return;
    }
    if (surname === '') {
        $('#exampleInputName2').next('.text-danger').text('Soyisim alanı boş olamaz');
        return;
    }
    if (userName === '') {
        $('#exampleInputName3').next('.text-danger').text('Kullanıcı adı alanı boş olamaz');
        return;
    }
    if (email === '') {
        $('#exampleInputEmail1').next('.text-danger').text('Email alanı boş olamaz');
        return;
    }
    if (password === '') {
        $('#exampleInputPassword1').next('.text-danger').text('Şifre alanı boş olamaz');
        return;
    }

    // Email formatı kontrolü
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        $('#exampleInputEmail1').next('.text-danger').text('Geçerli bir email adresi girin');
        return;
    }

    // Şifre uzunluğu kontrolü
    if (password.length < 8) {
        $('#exampleInputPassword1').next('.text-danger').text('Şifre en az 8 karakter olmalıdır');
        return;
    }

     
    var veri = {
        KisiAdi: name,
        KisiSoyAdi: surname,
        KisiKullaniciAdi: userName,
        KisiEmail: email,
        KisiPassword: password
    };

    var jsonData = JSON.stringify(veri);

    // AJAX isteği gönder
    $.ajax({
        url: '/Account/Register',
        type: 'POST',
        contentType: 'application/json',
        data: jsonData, 
        success: function (response) {
            // Başarılı bir şekilde eklendiğinde yapılacak işlemler
            console.log('Başarıyla kayıt yapıldı:', response);
            location.href = "/Account/Login"; // Başarılı girişte yönlendirme yap
        },
        error: function (xhr, status, error) {

            console.error('Kayıt yapılırken bir hata oluştu:', error);

        }
    });
}
