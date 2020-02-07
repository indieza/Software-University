const PaymentPackage = require('./PaymentPackage.js');
const expect = require('chai').expect;

describe("PaymentPackage", () => {
    describe("Test name", () => {
        it("1 => Error", () => {
            expect(() => new PaymentPackage(1, 1)).to.Throw('Name must be a non-empty string');
        });

        it("'' => Error", () => {
            expect(() => new PaymentPackage('', 1)).to.Throw('Name must be a non-empty string');
        })
        it("test => test", () => {
            let newObj = new PaymentPackage('test', 1);
            expect(newObj.name).to.equal('test');
        });

        it("newName => newName", () => {
            let newObj = new PaymentPackage('test', 1);
            expect(newObj.name = 'newName').to.equal('newName');
        });
    });
    describe("Test value", () => {
        it("a => Error", () => {
            expect(() => new PaymentPackage('a', 'a')).to.Throw('Value must be a non-negative number');
        });

        it("-1 => Error", () => {
            expect(() => new PaymentPackage('a', -1)).to.Throw('Value must be a non-negative number');
        });

        it("1 => 1", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(newObj.value).to.equal(1);
        });

        it("2 => 2", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(newObj.value = 2).to.equal(2);
        });
    });
    describe("Test VAT", () => {
        it("'' => 20", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(newObj.VAT).to.equal(20);
        });

        it("a => Error", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(() => newObj.VAT = 'a').to.Throw('VAT must be a non-negative number');
        })

        it("-1 => Error", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(() => newObj.VAT = -1).to.Throw('VAT must be a non-negative number');
        });

        it("1 => 1", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(newObj.VAT = 1).to.equal(1);
        });
    });
    describe("Test active", () => {
        it("'' => true", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(newObj.active).to.equal(true);
        });

        it("test => Error", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(() => newObj.active = 'test').to.Throw('Active status must be a boolean');
        });

        it("false => false", () => {
            let newObj = new PaymentPackage('a', 1);
            expect(newObj.active = false).to.equal(false);
        });
    });
    describe("Test toString", () => {
        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            expect(newObj.toString()).to.equal('Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800');
        });

        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            newObj.active = false;
            expect(newObj.toString()).to.equal('Package: HR Services (inactive)\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800');
        });

        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            newObj.VAT = 0;
            expect(newObj.toString()).to.equal('Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 0%): 1500');
        });

        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 0);
            newObj.VAT = 0;
            expect(newObj.toString()).to.equal('Package: HR Services\n- Value (excl. VAT): 0\n- Value (VAT 0%): 0');
        });
    });
});