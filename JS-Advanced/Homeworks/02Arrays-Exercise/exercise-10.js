'use strict'

function solve(input) {
    const rows = input[0];
    const cols = input[1];

    const starRow = input[2];
    const starCol = input[3];

    const fillValue = null;
    const matrix = new Array(rows).fill(fillValue).map(() => new Array(cols).fill(fillValue));
    matrix[starRow][starCol] = 1;

    let startRow = starRow - 1 < 0 ? starRow : starRow - 1;
    let startCol = starCol - 1 < 0 ? starCol : starCol - 1;
    let endRow = starRow + 1;
    let endCol = starCol + 1;

    for (let i = 2; i <= matrix.length; i++) {

        for (let row = startRow; row <= endRow; row++) {
            for (let col = startCol; col <= endCol; col++) {
                
                if (row < 0 || row >= matrix.length || col < 0 || col >= matrix[row].length) {
                    continue;
                }

                if (matrix[row][col] === fillValue) {
                    matrix[row][col] = i;
                }
            }
        }

        startRow = startRow - 1 < 0 ? startRow : startRow - 1;
        startCol = startCol - 1 < 0 ? startCol : startCol - 1;

        endRow++;
        endCol++;
    }

    print();

    function print() {
        matrix.forEach(row => console.log(row.join(' ')));
    }
}