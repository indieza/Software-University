class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: libraryName.length,
            special: libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        };
    }

    subscribe(name, type) {
        if (!this.subscriptionTypes[type]) {
            throw new Error(`The type ${type} is invalid`);
        }

        let subscriber = this.subscribers.find(s => s.name === name);

        if (!subscriber) {
            subscriber = {
                name: name,
                type: type,
                books: []
            };

            this.subscribers.push(subscriber);
        } else {
            subscriber.type = type;
        }

        return subscriber;
    }

    unsubscribe(name) {
        const index = this.subscribers.findIndex(s => s.name === name);

        if (index === -1) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        this.subscribers.splice(index, 1);
        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        let subscriber = this.subscribers.find(s => s.name === subscriberName);

        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }

        if (this.subscriptionTypes[subscriber.type] > subscriber.books.length) {
            let book = {
                title: bookTitle,
                author: bookAuthor
            };

            subscriber.books.push(book);
        } else {
            throw new Error(`You have reached your subscription limit ${this.subscriptionTypes[subscriber.type]}!`);
        }

        return subscriber;
    }

    showInfo() {
        if (this.subscribers.length === 0) {
            return `${this.libraryName} has no information about any subscribers`;
        }

        return this.subscribers
            .map(s =>
                `Subscriber: ${s.name}, Type: ${s.type}\nReceived books: ${s.books
                    .map(b =>
                        `${b.title} by ${b.author}`)
                    .join(", ")}`)
            .join("\n");
    }
}