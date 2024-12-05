const offcanvas = document.getElementById('body-kal');
const daySpan = document.getElementById('daySpan');
const dayInput = document.getElementById('inputDay');

function klik(day) {
    daySpan.innerHTML = day;
    dayInput.value = day;
}