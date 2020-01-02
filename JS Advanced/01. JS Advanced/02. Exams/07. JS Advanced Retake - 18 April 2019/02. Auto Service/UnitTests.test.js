const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

const AutoService = require('./02. Auto Service_Ресурси.js');

describe('Tests', () => {
    let autoService;

    beforeEach(function () {
        autoService = new AutoService(2);
    });

    describe('Test constructor', () => {
        it('Test properties', () => {
            expect(autoService.garageCapacity).to.equal(2);
            expect(autoService.workInProgress).to.deep.equal([]);
            expect(autoService.backlogWork).to.deep.equal([]);
        });
    });

    describe('Test availableSpace()', () => {
        it('Test getter', () => {
            expect(autoService.availableSpace).to.equal(2);
        });
    });

    describe('Test repairCar()', () => {
        it('Test no clients', () => {
            const result = autoService.repairCar();

            expect(result).to.equal("No clients, we are just chilling...");
        });

        it('Test repair functionality', () => {
            autoService.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken',
                'wheels': 'broken',
                'tires': 'broken'
            });

            const result = autoService.repairCar();

            expect(result).to.equal("Your doors and wheels and tires were repaired.");
            expect(autoService.workInProgress.length).to.equal(0);
            expect(autoService.availableSpace).to.equal(2);
        });

        it('Test fine functionality', () => {
            autoService.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ'
            });

            const result = autoService.repairCar();

            expect(result).to.equal("Your car was fine, nothing was repaired.");
            expect(autoService.workInProgress.length).to.equal(0);
            expect(autoService.availableSpace).to.equal(2);
        });
    });

    describe('Test signUpForReview()', () => {
        it('Test functionality', () => {
            autoService.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ'
            });

            expect(autoService.workInProgress.length).to.equal(1);
            expect(autoService.availableSpace).to.equal(1);
            expect(autoService.workInProgress[0]).to.deep.equal({
                plateNumber: "CA1234CA",
                clientName: "Peter",
                carInfo: {
                    engine: "MFRGG23",
                    transmission: "FF4418ZZ"
                }
            })
        });
    });

    describe('Test carInfo()', () => {
        it('Test no car', () => {
            const result = autoService.carInfo("CA1234CA", "Pesho");
            expect(result).to.equal("There is no car with platenumber CA1234CA and owner Pesho.");
            expect(autoService.availableSpace).to.equal(2);
        });

        it('Test functionality', () => {
            autoService.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ'
            });

            const result = autoService.carInfo("CA1234CA", "Peter");

            expect(result).to.deep.equal({
                plateNumber: "CA1234CA",
                clientName: "Peter",
                carInfo: {
                    engine: "MFRGG23",
                    transmission: "FF4418ZZ"
                }
            });
            expect(autoService.availableSpace).to.equal(1);
        });
    });
});