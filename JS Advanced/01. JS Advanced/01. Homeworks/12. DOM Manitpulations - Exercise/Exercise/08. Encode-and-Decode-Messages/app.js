function encodeAndDecodeMessages() {
    const send = document.getElementsByTagName("button")[0];
    const read = document.getElementsByTagName("button")[1];

    send.addEventListener("click", function (e) {
        e.preventDefault();

        const text = document.getElementsByTagName("textarea")[0].value;


        document.getElementsByTagName("textarea")[1].value = [...text].
        map((_, i) =>
            text[i] = String.fromCharCode(text[i].charCodeAt(0) + 1)).
        join("");

        document.getElementsByTagName("textarea")[0].value = "";
    });

    read.addEventListener("click", function (e) {
        e.preventDefault();

        const text = document.getElementsByTagName("textarea")[1].value;


        document.getElementsByTagName("textarea")[1].value = [...text].
        map((_, i) =>
            text[i] = String.fromCharCode(text[i].charCodeAt(0) - 1)).
        join("");
    });
}