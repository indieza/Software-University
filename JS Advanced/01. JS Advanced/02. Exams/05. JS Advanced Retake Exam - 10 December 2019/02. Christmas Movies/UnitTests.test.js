const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

const ChristmasMovies = require('./02. Christmas Movies_Resources.js');

describe('Tests', () => {
    let christmasMovies;

    beforeEach(function () {
        christmasMovies = new ChristmasMovies();
    });

    describe('Test Constructor', () => {
        it('Test properties', () => {
            expect(christmasMovies.movieCollection).to.deep.equal([]);
            expect(christmasMovies.watched).to.deep.equal({});
            expect(christmasMovies.actors).to.deep.equal([]);
        });
    });

    describe('Test buyMovie()', () => {
        it('Test error message', () => {
            christmasMovies.buyMovie("Name1", ["Actor1"]);
            const result = () => christmasMovies.buyMovie("Name1", "Actor1");

            expect(result).to.throw(Error, "You already own Name1 in your collection!");
        });

        it('Test functionality', () => {
            const result = christmasMovies.buyMovie("Name1", ["Actor1", "Actor2", "Actor1"]);

            expect(christmasMovies.movieCollection[0]).to.deep.equal({
                name: "Name1",
                actors: ["Actor1", "Actor2"]
            });

            expect(christmasMovies.movieCollection.length).to.equal(1);
            expect(christmasMovies.movieCollection[0].actors).to.deep.equal(["Actor1", "Actor2"]);
            expect(christmasMovies.movieCollection[0].actors.length).to.equal(2);
            expect(result).to.equal("You just got Name1 to your collection in which Actor1, Actor2 are taking part!");
        });
    });

    describe('Test discardMovie()', () => {
        it('Test error message', () => {
            const result = () => christmasMovies.discardMovie("Name1");
            expect(result).to.throw(Error, "Name1 is not at your collection!");
        });

        it('Test not watched error message', () => {
            christmasMovies.buyMovie("Name1", ["Actor1", "Actor2", "Actor1"]);
            const result = () => christmasMovies.discardMovie("Name1");
            expect(result).to.throw(Error, "Name1 is not watched!");
        });

        it('Test functionality', () => {
            christmasMovies.buyMovie("Name1", ["Actor1", "Actor2", "Actor1"]);
            christmasMovies.watchMovie("Name1");

            const result = christmasMovies.discardMovie("Name1");
            expect(result).to.equal("You just threw away Name1!");
            expect(christmasMovies.movieCollection.length).to.equal(0);
            expect(christmasMovies.movieCollection[0]).not.deep.equal({
                name: "Name1",
                actors: ["Actor1", "Actor2"]
            });
        });
    });

    describe('Test watchMovie()', () => {
        it('Test error message', () => {
            const result = () => christmasMovies.watchMovie("Name1");

            expect(result).to.throw(Error, "No such movie in your collection!");
        });

        it('Test watch movie single time', () => {
            christmasMovies.buyMovie("Name1", ["Actor1", "Actor2", "Actor1"]);
            christmasMovies.watchMovie("Name1");

            expect(christmasMovies.watched["Name1"]).to.equal(1);
        });

        it('Test watch movie multiply times', () => {
            christmasMovies.buyMovie("Name1", ["Actor1", "Actor2", "Actor1"]);
            christmasMovies.watchMovie("Name1");
            christmasMovies.watchMovie("Name1");

            expect(christmasMovies.watched["Name1"]).to.equal(2);
        });
    });

    describe('Test favouriteMovie()', () => {
        it('Test error message', () => {
            const result = () => christmasMovies.favouriteMovie();

            expect(result).to.throw(Error, "You have not watched a movie yet this year!");
        });

        it('Test functionality', () => {
            christmasMovies.buyMovie("Name2", ["Actor1", "Actor2", "Actor1"]);
            christmasMovies.buyMovie("Name1", ["Actor1", "Actor2", "Actor1"]);
            christmasMovies.watchMovie("Name2");
            christmasMovies.watchMovie("Name1");
            christmasMovies.watchMovie("Name1");

            const result = christmasMovies.favouriteMovie();

            expect(result).to.equal("Your favourite movie is Name1 and you have watched it 2 times!");
        });
    });

    describe('Test mostStarredActor()', () => {
        it('Test error message', () => {
            const result = () => christmasMovies.mostStarredActor();


            expect(result).to.throw(Error, "You have not watched a movie yet this year!");
        });

        it('Test functionality', () => {
            christmasMovies.buyMovie("Name2", ["Actor1", "Actor2", "Actor1"]);
            christmasMovies.buyMovie("Name1", ["Actor3", "Actor3", "Actor3"]);
            christmasMovies.buyMovie("Name3", ["Actor1", "Actor1", "Actor1"]);

            const result = christmasMovies.mostStarredActor();

            expect(result).to.equal("The most starred actor is Actor1 and starred in 2 movies!");
            expect(christmasMovies.movieCollection[0]).to.deep.equal({
                name: "Name2",
                actors: ["Actor1", "Actor2"]
            });
        });
    });
});