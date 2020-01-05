let expect = require("chai").expect;

let sum = require("../Exercise/04. SumOfNumbers.js").sum;

describe("sum(arr) - sum array of numbers", function () {
    it("should return 3 for [1,2]", function () {
        expect(sum([1, 2])).to.be.equal(3);
    });
    it("should return 1 for [1]", function () {
        expect(sum([1])).to.be.equal(1);
    });
    it("should return 0 for empty array", function () {
        expect(sum([])).to.be.equal(0);
    });
    it("should return 3 for [1.5, 2.5, -1]", function () {
        expect(sum([1.5, 2.5, -1])).to.be.equal(3);
    });
    it("should return NaN for invalid data", function () {
        expect(sum("invalid data")).to.be.NaN;
    });
});

let isSymmetric = require("../Exercise/05. CheckForSymmetry.js").isSymmetric;

describe("isSymmetric(arr)", function () {
    it("should return true for [1,2,3,3,2,1]", function () {
        expect(isSymmetric([1, 2, 3, 3, 2, 1])).to.be.equal(true);
    });
    it("should return false for [1,2,3,4,2,1]", function () {
        expect(isSymmetric([1, 2, 3, 4, 2, 1])).to.be.equal(false);
    });
    it("should return true for [-1,2,-1]", function () {
        expect(isSymmetric([-1, 2, -1])).to.be.equal(true);
    });
    it("should return false for [-1,2,1]", function () {
        expect(isSymmetric([-1, 2, 1])).to.be.equal(false);
    });
    it("should return false for [1,2]", function () {
        expect(isSymmetric([1, 2])).to.be.equal(false);
    });
    it("should return true for [1]", function () {
        expect(isSymmetric([1])).to.be.equal(true);
    });
    it("should return true for [5,'hi',{a:5},new Date(),{a:5},'hi',5]", function () {
        expect(isSymmetric([5, 'hi', {
            a: 5
        }, new Date(), {
            a: 5
        }, 'hi', 5])).to.be.equal(true);
    });
    it("should return false for [5,'hi',{a:5},new Date(),{X:5},'hi',5]", function () {
        expect(isSymmetric([5, 'hi', {
            a: 5
        }, new Date(), {
            X: 5
        }, 'hi', 5])).to.be.equal(false);
    });
    it("should return false for 1,2,2,1", function () {
        expect(isSymmetric(1, 2, 2, 1)).to.be.equal(false);
    });
});

let rgbToHexColor = require("../Exercise/06. RGBToHex.js").rgbToHexColor;

describe("rgbToHexColor(red, green, blue)", function () {
    describe("Nominal cases(valid input)", function () {
        it("should return #FF9EAA for (255, 158, 170)", function () {
            expect(rgbToHexColor(255, 158, 170)).to.be.equal("#FF9EAA");
        });
        it("should return #0C0D0E for (12, 13, 14)", function () {
            expect(rgbToHexColor(12, 13, 14)).to.be.equal("#0C0D0E");
        });
        it("should return #000000 for (0, 0, 0)", function () {
            expect(rgbToHexColor(0, 0, 0)).to.be.equal("#000000");
        });
        it("should return #FFFFFF for (255, 255, 255)", function () {
            expect(rgbToHexColor(255, 255, 255)).to.be.equal("#FFFFFF");
        });
    });

    describe("Special cases(invalid input", function () {
        it("should return undefined for (-1,0,0)", function () {
            expect(rgbToHexColor(-1, 0, 0)).to.be.equal(undefined);
        });
        it("should return undefined for (0,-1,0)", function () {
            expect(rgbToHexColor(0, -1, 0)).to.be.equal(undefined);
        });
        it("should return undefined for (0,0,-1)", function () {
            expect(rgbToHexColor(0, 0, -1)).to.be.equal(undefined);
        });
        it("should return undefined for (256,0,0)", function () {
            expect(rgbToHexColor(256, 0, 0)).to.be.equal(undefined);
        });
        it("should return undefined for (0,256,0)", function () {
            expect(rgbToHexColor(0, 256, 0)).to.be.equal(undefined);
        });
        it("should return undefined for (0,0,256)", function () {
            expect(rgbToHexColor(0, 0, 256)).to.be.equal(undefined);
        });
        it("should return undefined for (3.14,0,0)", function () {
            expect(rgbToHexColor(3.14, 0, 0)).to.be.equal(undefined);
        });
        it("should return undefined for (0,3.14,0)", function () {
            expect(rgbToHexColor(0, 3.14, 0)).to.be.equal(undefined);
        });
        it("should return undefined for (0,0,3.14)", function () {
            expect(rgbToHexColor(0, 0, 3.14)).to.be.equal(undefined);
        });
        it('should return undefined for ("5", [3], {8:9})', function () {
            expect(rgbToHexColor("5", [3], {
                8: 9
            })).to.be.equal(undefined);
        });
        it("should return undefined for empty input", function () {
            expect(rgbToHexColor()).to.be.equal(undefined);
        });
    });
});

let createCalculator = require("../Exercise/07. AddSubtract.js").createCalculator;

describe("createCalculator()", function () {
    let calc;

    beforeEach(function () {
        calc = createCalculator();
    });

    it("should return 0 for get;", function () {
        let value = calc.get();
        expect(value).to.be.equal(0);
    });
    it("should return 5 after add(2); add(3);", function () {
        calc.add(2);
        calc.add(3);
        let value = calc.get();
        expect(value).to.be.equal(5);
    });
    it("shoul return -5 after subtract(3); subtract(2)", function () {
        calc.subtract(3);
        calc.subtract(2);
        let value = calc.get();
        expect(value).to.be.equal(-5);
    });
    it("should return 4.2 after add(5.3); subtract(1.1);", function () {
        calc.add(5.3);
        calc.subtract(1.1);
        let value = calc.get();
        expect(value).to.be.equal(5.3 - 1.1);
    });
    it("should return 2 after add(10); subtract('7'); add('-2'); subtract(-1)", function () {
        calc.add(10);
        calc.subtract('7');
        calc.add('-2');
        calc.subtract(-1);
        let value = calc.get();
        expect(value).to.be.equal(2);
    });
    it("should return NaN for add(string)", function () {
        calc.add('hello');
        let value = calc.get();
        expect(value).to.be.NaN;
    });
    it("should return NanN for subtarct(string)", function () {
        calc.subtract('hello');
        let value = calc.get();
        expect(value).to.be.NaN;
    });
});