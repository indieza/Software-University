class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }

    set clientId(value) {
        let pattern = /^[0-9]{6}$/gim;

        if (!pattern.test(value)) {
            throw new TypeError("Client ID must be a 6-digit number");
        }

        this._clientId = value;
    }

    get email() {
        return this._email;
    }

    set email(value) {
        let pattern = /^[a-zA-Z+_.]+@[a-zA-Z.]+$/gim;

        if (!pattern.test(value)) {
            throw new TypeError("Invalid e-mail");
        }

        this._email = value;
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        this.checkName(value, "First");
        this._firstName = value;
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        this.checkName(value, "Last");
        this._lastName = value;
    }

    checkName(value, item) {
        let pattern = /^[a-zA-Z]+$/gim;

        if (value.length < 3 || value.length > 20) {
            throw new TypeError(`${item} name must be between 3 and 20 characters long`);
        } else if (!pattern.test(value)) {
            throw new TypeError(`${item} name must contain only Latin characters`);
        }
    }
}

let acc = new CheckingAccount('1314', 'ivan@some.com', 'Ivan', 'Petrov');
let acc = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov');
let acc = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov');
let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov');