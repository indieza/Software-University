function printDeckOfCards(cards) {
    function createCard(face, suit) {
        const faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        const suits = {
            "S": "\u2660",
            "H": "\u2665",
            "D": "\u2666",
            "C": "\u2663"
        };

        class Card {
            constructor(face, suit) {
                this.face = face;
                this.suit = suit;
            }

            get face() {
                if (!faces.includes(this._face)) {
                    throw Error("Error");
                }

                return this._face;
            }

            set face(face) {
                this._face = face;
            }

            get suit() {
                if (!Object.keys(suits).includes(this._suit)) {
                    throw Error("Error");
                }

                return this._suit;
            }

            set suit(suit) {
                this._suit = suit;
            }

            toString() {
                return `${this.face}${suits[this.suit]}`;
            }
        }

        let card = new Card(face, suit);
        return card.toString();
    }

    let result = [];

    for (const currentCard of cards) {
        let face;
        let suit;

        if (currentCard.length === 2) {
            face = currentCard.substring(0, 1);
            suit = currentCard.substring(currentCard.length - 1);
        } else {
            face = currentCard.substring(0, 2);
            suit = currentCard.substring(currentCard.length - 1);
        }
        try {
            let card = createCard(face, suit);
            result.push(card);
        } catch (error) {
            return `Invalid card: ${currentCard}`;
        }
    }

    return result.join(" ");
}

console.log(printDeckOfCards(['AS', '10D', 'KH', '2C']));
console.log(printDeckOfCards(['5S', '3D', 'QD', '1C']));