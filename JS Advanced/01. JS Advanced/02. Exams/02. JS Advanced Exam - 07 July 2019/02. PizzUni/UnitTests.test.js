const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

const PizzUni = require('./02. PizzUni_Ресурси.js');

describe("Test", function () {
    let pizzUni;

    beforeEach(function () {
        pizzUni = new PizzUni();
    });

    describe('Test Constructor', () => {
        it('Test properties', () => {
            expect(pizzUni.registeredUsers).to.deep.equal([]);
            expect(pizzUni.orders).to.deep.equal([]);
            expect(pizzUni.availableProducts).to.deep.equal({
                pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],
                drinks: ['Coca-Cola', 'Fanta', 'Water']
            });
        });
    });

    describe('Test registerUser()', () => {
        it('Test error', () => {
            pizzUni.registerUser("email1");
            const result = () => pizzUni.registerUser("email1");

            expect(result).to.throw(Error, `This email address (email1) is already being used!`);
        });

        it('Test add user correctly', () => {
            const result = pizzUni.registerUser("email1");

            expect(result).to.deep.equal({
                email: "email1",
                orderHistory: []
            });

            expect(pizzUni.registeredUsers[0]).to.deep.equal({
                email: "email1",
                orderHistory: []
            });
        });
    });

    describe('Test makeAnOrder()', () => {
        it('Test invalid user error', () => {
            const result = () => pizzUni.makeAnOrder("email1", "Barbeque Classic", "Fanta");

            expect(result).to.throw(Error, 'You must be registered to make orders!');
        });

        it('Test invalid pizza error', () => {
            pizzUni.registerUser("email1");
            const result = () => pizzUni.makeAnOrder("email1", "Error", "Fanta");

            expect(result).to.throw(Error, 'You must order at least 1 Pizza to finish the order.');
        });

        it('Test make an order with correct drink', () => {
            pizzUni.registerUser("email1");
            const result = pizzUni.makeAnOrder("email1", "Barbeque Classic", "Fanta");

            expect(result).to.equal(0);
            expect(pizzUni.orders[0]).to.deep.equal({
                email: "email1",
                orderedDrink: "Fanta",
                orderedPizza: "Barbeque Classic",
                status: "pending"
            });
            expect(pizzUni.orders[0].orderedDrink).to.equal("Fanta");
            expect(pizzUni.registeredUsers[0].orderHistory).to.deep.equal([{
                orderedDrink: "Fanta",
                orderedPizza: "Barbeque Classic"
            }]);
        });

        it('Test make an order with incorrect drink', () => {
            pizzUni.registerUser("email1");
            const result = pizzUni.makeAnOrder("email1", "Barbeque Classic", "Error");

            expect(result).to.equal(0);
            expect(pizzUni.orders[0]).to.deep.equal({
                email: "email1",
                orderedPizza: "Barbeque Classic",
                status: "pending"
            });
            expect(pizzUni.orders[0].orderedDrink).to.equal(undefined);
            expect(pizzUni.registeredUsers[0].orderHistory).to.deep.equal([{
                orderedPizza: "Barbeque Classic"
            }]);
        });
    });

    describe('Test detailsAboutMyOrder()', () => {
        it('Test pending functionality', () => {
            pizzUni.registerUser("email1");
            pizzUni.makeAnOrder("email1", "Barbeque Classic", "Fanta");

            const result = pizzUni.detailsAboutMyOrder(0);

            expect(result).to.equal('Status of your order: pending')
        });

        it('Test completed functionality', () => {
            pizzUni.registerUser("email1");
            pizzUni.makeAnOrder("email1", "Barbeque Classic", "Fanta");
            pizzUni.completeOrder();

            const result = pizzUni.detailsAboutMyOrder(0);

            expect(result).to.equal('Status of your order: completed')
        });

        it('Test completed functionality', () => {
            const result = pizzUni.detailsAboutMyOrder(0);

            expect(result).to.equal(undefined);
        });
    });

    describe('Test doesTheUserExist()', () => {
        it('Test functionality with not existing user', () => {
            const result = pizzUni.doesTheUserExist("email1");

            expect(result).to.equal(undefined);
        });

        it('Test functionality with existing user', () => {
            pizzUni.registerUser("email1")
            const result = pizzUni.doesTheUserExist("email1");

            expect(result).to.equal(pizzUni.registeredUsers[0]);
        });
    });

    describe('Test completeOrder()', () => {
        it('Test functionality', () => {
            pizzUni.registerUser("email1");
            pizzUni.makeAnOrder("email1", "Barbeque Classic", "Fanta");

            const result = pizzUni.completeOrder();

            expect(result).to.deep.equal({
                email: "email1",
                orderedDrink: "Fanta",
                orderedPizza: "Barbeque Classic",
                status: "completed"
            });
        });
    });
});