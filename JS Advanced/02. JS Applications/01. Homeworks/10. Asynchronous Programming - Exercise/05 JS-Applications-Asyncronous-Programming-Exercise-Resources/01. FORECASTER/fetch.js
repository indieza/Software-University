const baseUrl = `https://judgetests.firebaseio.com/`;

export function fetchRequest() {
    return {
        locationInfo: () => fetch(`${baseUrl}locations.json`).then(resources => resources.json()),

        currentDay: (code) => fetch(`${baseUrl}forecast/today/${code}.json `).then(resources => resources.json()),

        upcomingDay: (code) => fetch(`${baseUrl}forecast/upcoming/${code}.json `).then(resources => resources.json())
    }
}