function create(words) {
    const content = document.getElementById("content");

    for (const word of words) {
        const div = document.createElement("div");
        const paragraph = document.createElement("p");

        paragraph.innerHTML = word;
        paragraph.style.display = "none";

        div.appendChild(paragraph);

        div.addEventListener("click", function (e) {
            e.preventDefault();

            paragraph.style.display = "block";
        })

        content.appendChild(div);
    }
}