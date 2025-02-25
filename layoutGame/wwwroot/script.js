function validateData() {
    let result = document.getElementById("result");
    let gameTitle = document.form.gameTitle.value;
    let developer = document.form.developer.value;
    let price = document.form.price.value;
    let isAllDataCorrect = true;
    
    result.innerHTML = "";
    if(gameTitle == "") {
        result.innerHTML += `Nazwa gry jest wymagana<br>`;
        isAllDataCorrect = false;
    }
    if(developer == "") {
        result.innerHTML += `Deweloper jest wymagany<br>`;
        isAllDataCorrect = false;
    }
    if(price != "") {
        if(price < 0 || price > 9999.99) {
            result.innerHTML += `Cena musi być z przedziału 0 - 9999,99<br>`;
            isAllDataCorrect = false;
        }
    } else {
        result.innerHTML += `Cena jest wymagana<br>`;
        isAllDataCorrect = false;
    }

    if(isAllDataCorrect) {
        document.form.submit();
    }
}