class Parser {
    constructor(data) {
        this._data = JSON.parse(data);
        this._log = [];
        this._addToLog = this._addToLogInitial();
    }

    get data() {
        this._addToLog("getData");
        return this._data.filter(x => !x.hasOwnProperty("deleted"));
    }

    print() {
        this._addToLog("print");
        return this._data
            .filter(x => !x.hasOwnProperty("deleted"))
            .reduce((acc, x, index) => {
                acc.push(`${index}|${Object.keys(x)[0]}|${Object.values(x)[0]}`);
                return acc;
            }, ["id|name|position"]).join("\n");
    }

    addEntries(entries) {
        this._data = this._data.concat(entries.split(" ").map(x => {
            const [a, b] = x.split(":");
            let res = {};
            res[a] = b;
            return res;
        }));
        this._addToLog("addEntries");

        return "Entries added!"
    }

    removeEntry(key) {
        let entry = this._data.find(x => x.hasOwnProperty(key) && !x.hasOwnProperty("deleted"));
        if (entry === undefined) {
            throw new Error("There is no such entry!")
        }
        entry["deleted"] = true;
        this._addToLog("removeEntry");

        return "Removed correctly!"
    }

    _addToLogInitial() {
        let counter = 0;
        return function (command) {
            this._log.push(`${counter++}: ${command}`)
            return "Added to log";
        }
    }
}

module.exports = Parser;


// let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
// console.log(parser.addEntries("Steven:tech-support Edd:administrator"));
// console.log(parser.data);
// console.log(parser.removeEntry("Kate"));
// console.log(parser.data);
// console.log("_".repeat(50));
// console.log();
// console.log(parser.print());