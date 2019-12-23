function solve() {
    const correctAnswers = ["onclick", "JSON.stringify()", "A programming API for HTML and XML documents"];
    let count = 0;
    let i = 0

    Array.from(document.querySelectorAll(".answer-text"))
        .map((x) => x.addEventListener("click", function (e) {
            if (correctAnswers.includes(e.target.innerHTML)) {
                count++;
            }

            let currentSection = document.querySelectorAll("section")[i];
            currentSection.style.display = "none";

            if (document.querySelectorAll("section")[i + 1] !== undefined) {
                let nextSection = document.querySelectorAll("section")[i + 1];
                nextSection.style.display = "block";
                i++;
            } else {
                document.getElementById("results").style.display = "block";

                if (count != 3) {
                    document.getElementsByClassName("results-inner")[0].children[0].innerHTML =
                        `You have ${count} right answers`;
                } else {
                    document.getElementsByClassName("results-inner")[0].children[0].innerHTML =
                        "You are recognized as top JavaScript fan!";

                }
            }
        }));
}