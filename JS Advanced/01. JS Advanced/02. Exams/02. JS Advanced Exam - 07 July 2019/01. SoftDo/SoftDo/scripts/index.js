function mySolution() {
    const sendButton = document.getElementsByTagName("button")[0];
    const pendingQuestions = document.getElementById("pendingQuestions");
    const openQuestions = document.getElementById("openQuestions");

    sendButton.addEventListener("click", function () {
        const question = document.getElementsByTagName("textarea")[0].value;
        const name = document.getElementsByTagName("input")[0].value;

        if (question !== "") {
            const pendingQuestion = document.createElement("div");
            pendingQuestion.classList.add("pendingQuestion");

            const archiveButton = document.createElement("button");
            archiveButton.innerHTML = "Archive";
            archiveButton.classList.add("archive");

            archiveButton.addEventListener("click", function () {
                this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
            });

            const openButton = document.createElement("button");
            openButton.innerHTML = "Open";
            openButton.classList.add("open");

            createPendingQuestion(name, question, archiveButton, openButton, pendingQuestion);

            openButton.addEventListener("click", function () {
                this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);

                const replySection = createReplySection();

                const openQuestion = document.createElement("div");
                openQuestion.classList.add("openQuestion");

                const actions = document.createElement("div");
                actions.classList.add("actions");

                const replyButton = document.createElement("button");
                replyButton.innerHTML = "Reply";
                replyButton.classList.add("reply");

                replyButton.addEventListener("click", function () {
                    if (replySection.style.display === "block") {
                        replySection.style.display = "none";
                        replyButton.innerHTML = "Reply";
                    } else {
                        replySection.style.display = "block";
                        replyButton.innerHTML = "Back";

                    }
                })

                actions.appendChild(replyButton);

                createQuestion(name, question, openQuestion, actions);

                openQuestion.appendChild(replySection);

                openQuestions.appendChild(openQuestion);
            });
        }
    });

    function createReplySection() {
        const div = document.createElement("div");
        div.classList.add("replySection");
        div.style.display = "none";

        const input = document.createElement("input");
        input.classList.add("replyInput");
        input.type = "text";
        input.placeholder = "Reply to this question here...";

        const sendButton = document.createElement("button");
        sendButton.innerHTML = "Send";
        sendButton.classList.add("replyButton");

        const ol = document.createElement("ol");
        ol.classList.add("reply");
        ol.type = "1";

        sendButton.addEventListener("click", function () {
            const answer = input.value;

            const li = document.createElement("li");
            li.innerHTML = answer;
            ol.appendChild(li);
        });

        div.appendChild(input);
        div.appendChild(sendButton);
        div.appendChild(ol);

        return div;
    }

    function createPendingQuestion(name, question, archiveButton, openButton, pendingQuestion) {

        const actions = document.createElement("div");
        actions.classList.add("actions");
        actions.appendChild(archiveButton);
        actions.appendChild(openButton);

        createQuestion(name, question, pendingQuestion, actions);

        pendingQuestions.appendChild(pendingQuestion);
    }

    function createQuestion(name, question, pendingOrOpenQuestion, actions) {
        const image = document.createElement("img");
        image.src = "./images/user.png";
        image.width = "32";
        image.height = "32";

        const span = document.createElement("span");
        span.innerHTML = name === "" ? "Anonymous" : name;

        const p = document.createElement("p");
        p.innerHTML = question;

        pendingOrOpenQuestion.appendChild(image);
        pendingOrOpenQuestion.appendChild(span);
        pendingOrOpenQuestion.appendChild(p);
        pendingOrOpenQuestion.appendChild(actions);
    }
}