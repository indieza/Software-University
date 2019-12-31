function solution() {
    const addGiftButton = document.getElementsByTagName("button")[0];
    const listOfGifts = document.getElementsByClassName("card")[1];
    const listOfSendGifts = document.getElementsByClassName("card")[2];
    const listOfDiscardedGifts = document.getElementsByClassName("card")[3];

    addGiftButton.addEventListener("click", function (e) {
        e.preventDefault();

        const gift = document.getElementsByTagName("input")[0].value;
        const li = createGift(gift, true);

        if (listOfGifts.children[1].childElementCount === 0) {
            listOfGifts.children[1].appendChild(li);
        } else {
            for (let i = 0; i < listOfGifts.children[1].childElementCount; i++) {
                const currentGift = listOfGifts.children[1].getElementsByTagName("li")[i];

                if (li.innerHTML.localeCompare(currentGift.innerHTML) === -1) {
                    listOfGifts.children[1].insertBefore(li, currentGift);
                    break;
                }
            }
        }

        document.getElementsByTagName("input")[0].value = "";
    });

    function createGift(gift, hasButtons) {
        const li = document.createElement("li");
        li.classList.add("gift");
        li.innerHTML = gift;

        if (hasButtons) {
            const sendButton = document.createElement("button");
            sendButton.innerHTML = "Send";
            sendButton.id = "sendButton";

            sendButton.addEventListener("click", function (e) {
                e.preventDefault();

                this.parentNode.parentNode.removeChild(this.parentNode);
                const li = createGift(gift, false);
                listOfSendGifts.children[1].appendChild(li);
            });

            const discardButton = document.createElement("button");
            discardButton.innerHTML = "Discard";
            discardButton.id = "discardButton";

            discardButton.addEventListener("click", function (e) {
                e.preventDefault();

                this.parentNode.parentNode.removeChild(this.parentNode);
                const li = createGift(gift, false);
                listOfDiscardedGifts.children[1].appendChild(li);
            });

            li.appendChild(sendButton);
            li.appendChild(discardButton);
        }

        return li;
    }
}