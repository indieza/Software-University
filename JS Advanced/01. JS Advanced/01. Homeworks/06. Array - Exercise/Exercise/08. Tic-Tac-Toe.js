function solve(input) {
    let array = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let player = 'X';

    for (let line of input) {
        [currRow, currCol] = line.split(' ').map(Number);

        if (array[currRow][currCol] !== false) {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        array[currRow][currCol] = player;

        for (let i = 0; i < 3; i++) {
            if (
                array[i][0] === player &&
                array[i][1] === player &&
                array[i][2] === player
            ) {
                console.log(`Player ${player} wins!`);
                printMatrix();
                return;
            } else if (
                array[0][i] === player &&
                array[1][i] === player &&
                array[2][i] === player
            ) {
                console.log(`Player ${player} wins!`);
                printMatrix();
                return;
            }
        }

        if (
            array[0][0] === player &&
            array[1][1] === player &&
            array[2][2] === player
        ) {
            console.log(`Player ${player} wins!`);
            printMatrix();
            return;
        } else if (
            array[0][2] === player &&
            array[1][1] === player &&
            array[2][0] === player
        ) {
            console.log(`Player ${player} wins!`);
            printMatrix();
            return;
        }

        let theresFalse = false;

        for (let row = 0; row < array.length; row++) {
            if (array[row].includes(false)) {
                theresFalse = true;
            }
        }

        if (!theresFalse) {
            console.log('The game ended! Nobody wins :(');
            printMatrix();
            return;
        }

        player = player === 'X' ? 'O' : 'X';
    }

    function printMatrix() {
        for (let row = 0; row < array.length; row++) {
            console.log(array[row].join('\t'));
        }
    }
}