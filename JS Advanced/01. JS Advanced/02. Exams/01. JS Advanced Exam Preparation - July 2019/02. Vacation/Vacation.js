class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }

    get numberOfChildren() {
        let count = 0;

        for (const grade in this.kids) {
            count += this.kids[grade].length;
        }

        return count;
    }

    registerChild(name, grade, budget) {
        if (this.budget > budget) {
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }

        if (!this.kids.hasOwnProperty(grade)) {
            this.kids[grade] = [];
        }

        if (!this.kids[grade].findIndex(x => x.startsWith(name))) {
            return `${name} is already in the list for this ${this.destination} vacation.`;
        }

        this.kids[grade].push(`${name}-${budget}`);

        return this.kids[grade];
    }

    removeChild(name, grade) {
        if (!this.kids.hasOwnProperty(grade)) {
            return `We couldn't find ${name} in ${grade} grade.`;
        }

        let index = this.kids[grade].findIndex(x => x.startsWith(name));

        if (index === -1) {
            return `We couldn't find ${name} in ${grade} grade.`;
        }

        this.kids[grade].splice(index, 1);

        return this.kids[grade];
    }

    toString() {
        let result = "";

        if (this.numberOfChildren > 0 || this.kids === []) {

            for (const grade in this.kids) {
                result += `Grade: ${grade}\n`;
                let count = 1;

                for (const kid of this.kids[grade]) {
                    result += `${count}. ${kid}\n`;
                    count++;
                }
            }
        } else {
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
        }

        return result;
    }
}

let vacation1 = new Vacation('Mr Pesho', 'San diego', 2000);
console.log(vacation1.registerChild('Gosho', 5, 2000));
console.log(vacation1.registerChild('Lilly', 6, 2100));
console.log(vacation1.registerChild('Pesho', 6, 2400));
console.log(vacation1.registerChild('Gosho', 5, 2000));
console.log(vacation1.registerChild('Tanya', 5, 6000));
console.log(vacation1.registerChild('Mitko', 10, 1590));

console.log("------------------------------------------");

let vacation2 = new Vacation('Mr Pesho', 'San diego', 2000);
vacation2.registerChild('Gosho', 5, 2000);
vacation2.registerChild('Lilly', 6, 2100);

console.log(vacation2.removeChild('Gosho', 9));

vacation2.registerChild('Pesho', 6, 2400);
vacation2.registerChild('Gosho', 5, 2000);

console.log(vacation2.removeChild('Lilly', 6));
console.log(vacation2.registerChild('Tanya', 5, 6000));

console.log("------------------------------------------");

let vacation3 = new Vacation('Miss Elizabeth', 'Dubai', 2000);
vacation3.registerChild('Gosho', 5, 3000);
vacation3.registerChild('Lilly', 6, 1500);
vacation3.registerChild('Pesho', 7, 4000);
vacation3.registerChild('Tanya', 5, 5000);
vacation3.registerChild('Mitko', 10, 5500)
console.log(vacation3.toString());