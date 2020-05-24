'use strict'

function play(coordinates) {
    const matrix = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let player = 'X';

    for (let i = 0; i < coordinates.length; i++) {
        const moves = coordinates[i].split(' ');
        const x = moves[0];
        const y = moves[1];

        if (matrix[x][y] !== false) {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        matrix[x][y] = player;

        const winner = checkIfSomeoneWin();
        if (winner !== null) {
            console.log(`Player ${winner} wins!`);
            break;
        }

        const finished = checkForFreeSpaces();
        if (!finished) {
            console.log('The game ended! Nobody wins :(');
            break;
        }

        player = player === 'X' ? 'O' : 'X';
    }

    matrix.forEach(row => { console.log(row.join('\t')); });

    function checkIfSomeoneWin() {
        if (matrix[0][0] === matrix[0][1] && matrix[0][1] === matrix[0][2] && matrix[0][2] === player) { return player; }
        if (matrix[1][0] === matrix[1][1] && matrix[1][1] === matrix[1][2] && matrix[1][2] === player) { return player; }
        if (matrix[2][0] === matrix[2][1] && matrix[2][1] === matrix[2][2] && matrix[2][2] === player) { return player; }

        if (matrix[0][0] === matrix[1][0] && matrix[1][0] === matrix[2][0] && matrix[2][0] === player) { return player; }
        if (matrix[0][1] === matrix[1][1] && matrix[1][1] === matrix[2][1] && matrix[2][1] === player) { return player; }
        if (matrix[0][2] === matrix[1][2] && matrix[1][2] === matrix[2][2] && matrix[2][2] === player) { return player; }
        
        if (matrix[0][0] === matrix[1][1] && matrix[1][1] === matrix[2][2] && matrix[2][2] === player) { return player; }
        if (matrix[0][2] === matrix[1][1] && matrix[1][1] === matrix[2][0] && matrix[2][0] === player) { return player; }

        return null;
    }

    function checkForFreeSpaces() {
        let finished = false;
        for (let row = 0; row < matrix.length; row++) {
            if (matrix[row].includes(false)) {
                finished = true;
            }
        }

        return finished;
    }
}