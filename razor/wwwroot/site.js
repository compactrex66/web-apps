let clickMeBtn = document.getElementById("clickMeBtn");
let counter = 1;

clickMeBtn.addEventListener("click", () => {
    clickMeBtn.innerText = `You clicked me ${counter} times`;
    counter++;
});
