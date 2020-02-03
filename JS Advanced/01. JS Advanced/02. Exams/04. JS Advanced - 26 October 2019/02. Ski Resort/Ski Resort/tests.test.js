const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

let SkiResort = require('./solution');

describe('Tests', function () {
    let skiResort;

    beforeEach(function () {
        skiResort = new SkiResort("Name1");
    });

    describe('Test Constructor', () => {
        it('Test properties', () => {
            expect(skiResort.name).to.equal("Name1");
            expect(skiResort.voters).to.equal(0);
            expect(skiResort.hotels).to.deep.equal([]);
        });
    });

    describe('Test get bestHotel()', () => {
        it('Test no voters', () => {
            const result = skiResort.bestHotel;
            expect(result).to.equal("No votes yet");
        });

        it('Test functionality', () => {
            skiResort.build("Test1", 5);
            skiResort.build("Test1", 6);
            skiResort.leave("Test1", 5, 12);
            skiResort.leave("Test1", 5, 13);
            const result = skiResort.bestHotel;
            expect(result).to.equal("Best hotel is Test1 with grade 125. Available beds: 15");
        });
    });

    describe('Test build() method', () => {
        it('Test error', () => {
            const result = () => skiResort.build("", 0);
            expect(result).to.throw(Error, `Invalid input`);
        });

        it('Test functionality', () => {
            const result = skiResort.build("Test1", 5);

            expect(skiResort.hotels.length).to.equal(1);
            expect(skiResort.hotels[0]).to.deep.equal({
                name: "Test1",
                beds: 5,
                points: 0
            });
            expect(result).to.equal(`Successfully built new hotel - Test1`);
        });
    });

    describe('Test book() method', () => {
        it('Test error', () => {
            const result = () => skiResort.book("", 0);
            expect(result).to.throw(Error, `Invalid input`);
        });

        it('Test invalid hotel error', () => {
            const result = () => skiResort.book("Test1", 5);
            expect(result).to.throw(Error, "There is no such hotel");
        });

        it('Test invalid beds count error', () => {
            skiResort.build("Test1", 5);
            const result = () => skiResort.book("Test1", 6);
            expect(result).to.throw(Error, "There is no free space");
        });

        it('Test functionality', () => {
            skiResort.build("Test1", 5);
            const result = skiResort.book("Test1", 4);
            expect(skiResort.hotels[0].beds).to.equal(1);
            expect(result).to.equal("Successfully booked");
        });
    });

    describe('Test leave() method', () => {
        it('Test error', () => {
            const result = () => skiResort.leave("", 0, 12);
            expect(result).to.throw(Error, "Invalid input");
        });

        it('Test invalid hotel error', () => {
            const result = () => skiResort.leave("Test1", 5, 12);
            expect(result).to.throw(Error, "There is no such hotel");
        });

        it('Test functionality', () => {
            skiResort.build("Test1", 5);
            const result = skiResort.leave("Test1", 5, 12);

            expect(result).to.equal(`5 people left Test1 hotel`);
            expect(skiResort.voters).to.equal(5);
            expect(skiResort.hotels[0].beds).to.equal(10);
            expect(skiResort.hotels[0].points).to.equal(60);
        });
    });

    describe('Test averageGrade() method', () => {
        it('Test empty voters', () => {
            const result = skiResort.averageGrade();
            expect(result).to.equal("No votes yet");
        });

        it('Test functionality', () => {
            skiResort.build("Test1", 5);
            skiResort.leave("Test1", 5, 12);
            const result = skiResort.averageGrade();
            expect(result).to.equal("Average grade: 12.00");
        });
    });
});