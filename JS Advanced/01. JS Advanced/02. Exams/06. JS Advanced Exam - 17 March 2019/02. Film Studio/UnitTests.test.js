const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

const FilmStudio = require('./filmStudio.js');

describe('Tests', () => {
    let filmStudio;

    beforeEach(function () {
        filmStudio = new FilmStudio("Studio1");
    });

    describe('Test constructor', () => {
        it('Test properties', () => {
            expect(filmStudio.name).to.equal("Studio1");
            expect(filmStudio.films).to.deep.equal([]);
        });
    });

    describe('Test casting()', () => {
        it('Test error message', () => {
            const result = filmStudio.casting("Actor1", "Role1");
            expect(result).to.equal("There are no films yet in Studio1.");
        });

        it('Test functionality for existing role', () => {
            filmStudio.makeMovie("Name1", ["Role1", "Role2"]);
            const result = filmStudio.casting("Actor1", "Role1");

            expect(result).to.equal("You got the job! Mr. Actor1 you are next Role1 in the Name1. Congratz!");
            expect(filmStudio.films[0].filmRoles[0].actor).to.equal("Actor1");
            expect(filmStudio.films.length).to.equal(1);
        });

        it('Test functionality for not existing role', () => {
            filmStudio.makeMovie("Name1", ["Role1", "Role2"]);
            const result = filmStudio.casting("Actor1", "Role3");

            expect(result).to.equal("Actor1, we cannot find a Role3 role...");
            expect(filmStudio.films.length).to.equal(1);
        });
    });

    describe('Test makeMovie()', () => {
        it('Test error messages', () => {
            const result1 = () => filmStudio.makeMovie("Name1");
            expect(result1).to.throw('Invalid arguments count');

            const result2 = () => filmStudio.makeMovie("Name1", "Error");
            expect(result2).to.throw('Invalid arguments');
        });

        it('Test functionality for film added single time', () => {
            const result = filmStudio.makeMovie("Name1", ["Role1", "Role2"]);

            expect(result).to.deep.equal({
                filmName: "Name1",
                filmRoles: [{
                        "actor": false,
                        "role": "Role1"
                    },
                    {
                        "actor": false,
                        "role": "Role2"
                    }
                ]
            });
        });

        it('Test functionality for film added multiply times', () => {
            filmStudio.makeMovie("Name1", ["Role1", "Role2"]);
            const result = filmStudio.makeMovie("Name1", ["Role1", "Role2"]);

            expect(result).to.deep.equal({
                filmName: "Name1 2",
                filmRoles: [{
                        "actor": false,
                        "role": "Role1"
                    },
                    {
                        "actor": false,
                        "role": "Role2"
                    }
                ]
            });
        });
    });

    describe('Test lookForProducer()', () => {
        it('Test error message', () => {
            const result = () => filmStudio.lookForProducer("Name1");

            expect(result).to.throw(Error, "Name1 do not exist yet, but we need the money...");
        });

        it('Test functionality', () => {
            filmStudio.makeMovie("Name1", ["Role1", "Role2"]);
            const result = filmStudio.lookForProducer("Name1");

            expect(result).to.equal("Film name: Name1\nCast:\nfalse as Role1\nfalse as Role2\n");
        });
    });
});