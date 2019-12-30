const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

const BookStore = require('./02. Book Store_Ресурси.js');

describe('Tests', () => {
    let bookStore;

    beforeEach(function () {
        bookStore = new BookStore("Test");
    });

    describe('Test Constructor', () => {
        it('Test Properties', () => {
            expect(bookStore.name).to.equal("Test");
            expect(bookStore.books).to.deep.equal([]);
            expect(bookStore.workers).to.deep.equal([]);
        });
    });

    describe('Test stockBooks()', () => {
        it('Test adding book', () => {
            const result = bookStore.stockBooks(['Inferno-Dan Braun']);

            expect(result).to.deep.equal([{
                title: "Inferno",
                author: "Dan Braun"
            }]);

            expect(bookStore.books.length).to.equal(1);

            expect(bookStore.books[0]).to.deep.equal({
                title: "Inferno",
                author: "Dan Braun"
            });
        });
    });

    describe('Test hire()', () => {
        it('Test error message', () => {
            bookStore.hire("Pesho", "Reader");
            const result = () => bookStore.hire("Pesho", "Reader");

            expect(result).to.throw(Error, 'This person is our employee');
        });

        it('Test valid work', () => {
            const result = bookStore.hire("Pesho", "Reader");

            expect(result).to.equal('Pesho started work at Test as Reader');
            expect(bookStore.workers.length).to.equal(1);
            expect(bookStore.workers[0]).to.deep.equal({
                name: "Pesho",
                position: "Reader",
                booksSold: 0
            });
        });
    });

    describe('Test fire()', () => {
        it('Test error', () => {
            const result = () => bookStore.fire("Pesho");

            expect(result).to.throw(Error, "Pesho doesn't work here");
        });

        it('Test work correctly', () => {
            bookStore.hire("Pesho", "Reader");
            const result = bookStore.fire("Pesho");

            expect(result).to.equal("Pesho is fired");
            expect(bookStore.workers.length).to.equal(0);
            expect(bookStore.workers[0]).not.deep.equal({
                name: "Pesho",
                position: "Reader",
                booksSold: 0
            });
        });
    });

    describe('Test sellBook()', () => {
        it('Test error for invalid book', () => {
            const result = () => bookStore.sellBook("Title", "Name");

            expect(result).to.throw(Error, "This book is out of stock");
        });

        it('Test error for invalid worker', () => {
            bookStore.stockBooks(["Sing For Song-Pesho"]);
            const result = () => bookStore.sellBook("Sing For Song", "Name");

            expect(result).to.throw(Error, "Name is not working here");
        });

        it('Work correctly', () => {
            bookStore.stockBooks(["Sing For Song-Pesho"]);
            bookStore.hire("Name", "Position");
            bookStore.sellBook("Sing For Song", "Name");

            expect(bookStore.books.length).to.equal(0);
            expect(bookStore.workers[0]).to.deep.equal({
                name: "Name",
                position: "Position",
                booksSold: 1
            });
        });
    });

    describe('Test printWorkers()', () => {
        it('Test functionality', () => {
            bookStore.hire("Name", "Position");

            const result = bookStore.printWorkers();

            expect(result).to.equal("Name:Name Position:Position BooksSold:0");
        });
    });
});