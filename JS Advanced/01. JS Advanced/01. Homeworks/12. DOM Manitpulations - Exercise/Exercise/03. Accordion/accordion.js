function toggle() {
    const button = document.getElementsByClassName("button")[0];
    const moreText = document.getElementById("extra");

    if (button.innerHTML === "Less") {
        button.style.display = "block";
        button.innerHTML = "More";
        moreText.style.display = "none";
    } else {
        button.style.display = "block";
        button.innerHTML = "Less";
        moreText.style.display = "block";
    }
}