function loadRepos() {
    const div = document.getElementById("res");

    let url = "https://api.github.com/repos/testnakov/test-nakov-repo/issues/4/labels";

    const httpRequest = new XMLHttpRequest();

    httpRequest.addEventListener('readystatechange', function () {

        if (httpRequest.readyState == 4 && httpRequest.status == 200) {

            div.textContent = httpRequest.responseText;

        }

    });

    httpRequest.open("GET", url);
    httpRequest.send();
}