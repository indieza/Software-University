class BookStore {
    constructor(name) {
        this.name = name;
        this.books = [];
        this._workers = [];
    }

    get workers() {
        return this._workers;
    }

    stockBooks(newBooks) {
        newBooks.forEach((book) => {
            let [title, author] = book.split('-');
            this.books.push({ title, author });
        });

        return this.books;
    }

    hire(name, position) {
        let worker = this.workers.filter(w => w.name === name)[0];
        if (!worker) {
            worker = {
                name: name,
                position: position,
                booksSold: 0
            };
            this.workers.push(worker);
        } else {
            throw new Error('This person is our employee');
        }
        return `${name} started work at ${this.name} as ${position}`
    }

    fire(name) {
        let worker = this.workers.filter(w => w.name === name)[0];
        if (!worker) {
            throw new Error(`${name} doesn't work here`);
        }
        let index = this.workers.indexOf(worker);
        this.workers.splice(index, 1);
        return `${name} is fired`;
    }

    sellBook(title, workerName) {
        let book = this.books.filter(b => b.title === title)[0];
        if (!book) {
            throw new Error('This book is out of stock');
        }

        let worker = this.workers.filter((w) => w.name === workerName)[0];
        if(!worker){
            throw new Error(`${workerName} is not working here`)
        }

        this.books = this.books.filter(b => b.title !== title);
        this.workers.filter(w => w.name === workerName).map(w => w.booksSold++);
    }

    printWorkers() {
        let result = "";
        this.workers.forEach(w => {
            result += `Name:${w.name} Position:${w.position} BooksSold:${w.booksSold}\n`;
        })
        return result.trim();
    }
}