'use strict'

function solve(input) {
    const rows = input[0];
    const cols = input[1];

    const starRow = input[2];
    const starCol = input[3];

    let counter = 1;

    const fillValue = 0;
    const matrix = new Array(rows).fill(fillValue).map(() => new Array(cols).fill(fillValue));
    matrix[starRow][starCol] = counter;

    let startRow = starRow - 1 < 0 ? starRow : starRow - 1;
    let startCol = starCol - 1 < 0 ? starCol : starCol - 1;
    let endRow = starRow + 1;
    let endCol = starCol + 1;

    while (counter !== rows && counter !== cols) {

        counter++;

        for (let row = startRow; row <= endRow; row++) {
            for (let col = startCol; col <= endCol; col++) {
                if (row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length) {
                    if (matrix[row][col] === fillValue) {
                        matrix[row][col] = counter;
                    }
                }
            }
        }

        startRow = startRow - 1 < 0 ? startRow : startRow - 1;
        startCol = startRow - 1 < 0 ? startRow : startRow - 1;

        endRow++;
        endCol++;
    }

    print();

    function print() {
        matrix.forEach(row => console.log(row.join(' ')));
    }
}