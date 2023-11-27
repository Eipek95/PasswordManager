document.getElementById("generatePassword").addEventListener("change", function () {
    var passwordInput = document.getElementById("password");
    var passwordConfirmInput = document.getElementById("passwordConfirm");
    var element = document.getElementById('passwordConfirm-error');
    if (this.checked) {
        var newPassword = generatePassword();
        passwordInput.value = newPassword;
        passwordConfirmInput.value = newPassword;
        passwordConfirmInput.classList.add("disable-pointer-events");
    } else {
        passwordInput.value = "";
        passwordConfirmInput.value = "";
        passwordConfirmInput.classList.remove("disable-pointer-events");
    }
});

function generatePassword() {
    var length = 12;
    var charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>?";
    var password = "";
    password += getRandomCharacter("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");  // En az bir harf
    password += getRandomCharacter("0123456789"); // En az bir sayı
    password += getRandomCharacter("!@#$%^&*()_-+=<>?"); // En az bir özel karakter


    // Geri kalan karakterler
    for (var i = password.length; i < length; i++) {
        var randomIndex = Math.floor(Math.random() * charset.length);
        password += charset[randomIndex];
    }

    // Karakterleri karıştır
    password = password.split('').sort(function () { return 0.5 - Math.random() }).join('');

    return password;
}

function getRandomCharacter(charset) {
    var randomIndex = Math.floor(Math.random() * charset.length);
    return charset[randomIndex];
}

function togglePasswordVisibility() {
    var passwordInput = document.getElementById("password");
    var passwordConfirmInput = document.getElementById("passwordConfirm");
    var showPasswordCheckbox = document.getElementById("showPassword");

    // Eğer checkbox işaretli ise, input'un tipini "text" yap, değilse "password" yap.
    passwordInput.type = showPasswordCheckbox.checked ? "text" : "password";
    passwordConfirmInput.type = showPasswordCheckbox.checked ? "text" : "password";
}