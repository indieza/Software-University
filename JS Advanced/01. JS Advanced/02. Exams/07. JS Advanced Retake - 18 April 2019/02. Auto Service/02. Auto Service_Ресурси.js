class AutoService {

    constructor(garageCapacity) {
        this.garageCapacity = garageCapacity;
        this.workInProgress = [];
        this.backlogWork = [];
    }

    get availableSpace() {
        return this.garageCapacity - this.workInProgress.length;
    }

    repairCar() {

        let workingPlace = this.workInProgress.length > 0 ? this.workInProgress : this.backlogWork;

        if (workingPlace.length > 0) {

            let keysForRepair = [];
            Object.keys(workingPlace[0].carInfo)
                .filter((k) => workingPlace[0].carInfo[k] === 'broken')
                .forEach((k) => keysForRepair.push(k));

            workingPlace.shift();
            if (keysForRepair.length > 0) {
                return `Your ${keysForRepair.join(' and ')} were repaired.`;
            } else {
                return 'Your car was fine, nothing was repaired.'
            }
        } else {
            return 'No clients, we are just chilling...'
        }
    }

    signUpForReview(clientName, plateNumber, carInfo) {

        let currentClient = {
            plateNumber,
            clientName,
            carInfo
        };

        if (this.availableSpace > 0) {
            this.workInProgress.push(currentClient);
        } else {
            this.backlogWork.push(currentClient);
        }
    }

    carInfo(plateNumber, clientName) {

        let checkCar =
            this.workInProgress.filter((carInfo) => carInfo.plateNumber === plateNumber && carInfo.clientName === clientName)[0] ||
            this.backlogWork.filter((carInfo) => carInfo.plateNumber === plateNumber && carInfo.clientName === clientName)[0];

        if (checkCar) {
            return checkCar;
        } else {

            return `There is no car with platenumber ${plateNumber} and owner ${clientName}.`;
        }
    }
}

module.exports = AutoService;