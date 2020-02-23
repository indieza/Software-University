const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

const Parser = require('./solution.js');

describe('Tests', () => {
    let parser;

    beforeEach(function () {
        parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
    });

    describe('Test Constructor', () => {
        it('Test properties', () => {
            expect(parser._data).to.deep.equal(JSON.parse('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]'));
            expect(parser._log).to.deep.equal([]);
        });

        it('Test getter', () => {
            const result = parser.data;

            expect(parser._log[0]).to.equal(`0: getData`);
            expect(parser._log.length).to.equal(1);
            expect(JSON.stringify(result)).to.equal(JSON.stringify([{
                    Nancy: "architect"
                },
                {
                    John: "developer"
                }, {
                    Kate: "HR"
                }
            ]));

            expect(result.length).to.equal(3);
        });
    });

    describe('Test addEntries()', () => {
        it('Test functionality', () => {
            const result = parser.addEntries("Steven:tech-support Edd:administrator");
            const data = JSON.stringify(parser._data)

            expect(result).to.equal("Entries added!");
            expect(parser._data.length).to.deep.equal(5);
            expect(parser._data[3]).to.deep.equal({
                Steven: "tech-support"
            });
            expect(parser._data[4]).to.deep.equal({
                Edd: "administrator"
            });
            expect(parser._log.length).to.deep.equal(1);
            expect(parser._log[0]).to.equal(`0: addEntries`);
            expect(data).to.deep.equal(JSON.stringify(parser._data));
        });
    });

    describe('Test removeEntries()', () => {
        it('Test error', () => {
            const result = () => parser.removeEntry("Error");

            expect(result).to.throw(Error, "There is no such entry!");
            expect(parser._log[0]).to.equal(undefined);
        });

        it('Test functionality', () => {
            const result = parser.removeEntry("Kate");

            expect(parser._log.length).to.deep.equal(1);
            expect(parser._log[0]).to.equal(`0: removeEntry`);
            expect(result).to.equal("Removed correctly!");
        });
    });

    describe('Test print()', () => {
        it('Test functionality none empty', () => {
            parser.addEntries("Steven:tech-support Edd:administrator");
            parser.removeEntry("Kate");
            const result = parser.print();

            expect(result).to.equal("id|name|position\n0|Nancy|architect\n1|John|developer\n2|Steven|tech-support\n3|Edd|administrator");
        });

        it('Test functionality empty', () => {
            const result = parser.print();

            expect(result).to.equal("id|name|position\n0|Nancy|architect\n1|John|developer\n2|Kate|HR");
        });
    });
});