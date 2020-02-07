const StringBuilder = require('./StringBuilder.js');
const expect = require('chai').expect;
const assert = require('chai').assert;

describe("05.StringBuilder function", function () {
    describe('constructor', function () {
        it('Test withh string', function () {
            let myObj = new StringBuilder('str');
            expect(myObj).to.have.property('_stringArray').with.lengthOf(3);
        });

        it('Test with empty value', function () {
            let myObj = new StringBuilder();
            expect(myObj).to.have.property('_stringArray').with.lengthOf(0);
        });

        it('Test with wrong parameter', function () {
            expect(() => new StringBuilder(1)).to.Throw('Argument must be string');
        });
    });

    describe('append', function () {
        it('Test invalid param', function () {
            let myObj = new StringBuilder('str');
            expect(() => myObj.append(1)).to.Throw('Argument must be string');
        });

        it('Test new length', function () {
            let myObj = new StringBuilder('Str');
            myObj.append('T');
            expect(myObj).to.have.property('_stringArray').with.lengthOf(4);
        });

        it('Test if added at the end', function () {
            let myObj = new StringBuilder('Str');
            myObj.append('T');
            expect(myObj._stringArray[3]).to.equal('T');
        });
    });

    describe('prepend', function () {
        it('Test invalid param', function () {
            let myObj = new StringBuilder('str');
            expect(() => myObj.prepend(1)).to.Throw('Argument must be string');
        });

        it('Test new length', function () {
            let myObj = new StringBuilder('Str');
            myObj.prepend('a');
            expect(myObj).to.have.property('_stringArray').with.lengthOf(4);
        });

        it('Test if added at the beginning', function () {
            let myObj = new StringBuilder('Str');
            myObj.prepend('a');
            expect(myObj._stringArray[0]).to.equal('a');
        });
    });

    describe('insertAt', function () {
        it('Test invalid param', function () {
            let myObj = new StringBuilder('str');
            expect(() => myObj.insertAt(1, 1)).to.Throw('Argument must be string');
        });

        it('Test new length', function () {
            let myObj = new StringBuilder('ab');
            myObj.insertAt('TEST', 1);
            expect(myObj).to.have.property('_stringArray').with.lengthOf(6);
        });

        it('Test if the string is inserted at index', function () {
            let myObj = new StringBuilder('ab');
            myObj.insertAt('TEST', 1);
            expect(myObj._stringArray[1]).to.equal('T');
        });
    });

    describe('remove', function () {
        it('Test new length', function () {
            let myObj = new StringBuilder('abc');
            myObj.remove(1, 1);
            expect(myObj).to.have.property('_stringArray').with.lengthOf(2);
        });

        it('Test result', function () {
            let myObj = new StringBuilder('abc');
            myObj.remove(1, 1);
            expect(myObj._stringArray.join('')).to.equal('ac');
        });

        it('Test result', function () {
            let myObj = new StringBuilder('abc');
            myObj.remove(1, 2);
            expect(myObj._stringArray.join('')).to.equal('a');
        });
    });

    describe('toString', function () {
        it('Test if joined', function () {
            let result = new StringBuilder('test');
            expect(result.toString()).to.equal('test');
        });
    });

    describe('Type of StringBuilder', function () {
        it('StringBuilder exist', function () {
            expect(StringBuilder).to.exist
        });

        it('StringBuilder type', function () {
            expect(typeof StringBuilder).to.equal('function');
        });

        it('should have the correct function properties', function () {
            assert.isFunction(StringBuilder.prototype.append);
            assert.isFunction(StringBuilder.prototype.prepend);
            assert.isFunction(StringBuilder.prototype.insertAt);
            assert.isFunction(StringBuilder.prototype.remove);
            assert.isFunction(StringBuilder.prototype.toString);
        });

        it('full test', function () {
            let str = new StringBuilder('hello');
            str.append(', there');
            str.prepend('User, ');
            str.insertAt('woop', 5);
            str.remove(6, 3);
            expect(str.toString()).to.equal('User,w hello, there');
        });
    });
});