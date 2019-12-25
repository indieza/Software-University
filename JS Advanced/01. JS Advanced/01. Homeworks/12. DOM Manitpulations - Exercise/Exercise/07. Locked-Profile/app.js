function lockedProfile() {
    const profiles = Array.from(document.querySelectorAll("div")).filter(x => x.className === "profile");

    for (const profile of profiles) {
        const unlock = profile.getElementsByTagName("input")[1];
        const hiddenInfo = profile.getElementsByTagName("div")[0];
        const button = profile.getElementsByTagName("button")[0];

        button.addEventListener("click", function (e) {
            e.preventDefault();

            if (unlock.checked === true) {
                if (button.innerHTML === "Hide it") {
                    button.style.display = "block";
                    button.innerHTML = "Show more";
                    hiddenInfo.style.display = "none";
                } else {
                    button.style.display = "block";
                    button.innerHTML = "Hide it";
                    hiddenInfo.style.display = "block";
                }
            }
        })
    }
}