'use strict'

function solve(rows, cols) {
    const matrix = new Array(rows).fill(null).map(() => new Array(cols).fill(null));

    let counter = 1;
    let startRow = 0;
    let startCol = 0;
    let endRow = rows - 1;
    let endCol = cols - 1;

    while (startRow <= endRow && startCol <= endCol) {
        for (let i = startCol; i <= endCol; i++) {
            matrix[startRow][i] = counter;
            counter++;
        }
        startRow++;

        for (let i = startRow; i <= endRow; i++) {
            matrix[i][endCol] = counter;
            counter++;
        }
        endCol--;
        
        for (let i = endCol; i >= startCol; i--) {
            matrix[endRow][i] = counter;
            counter++;
        }
        endRow--;
        
        for (let i = endRow; i >= startRow; i--) {
            matrix[i][startCol] = counter;
            counter++;
        }
        startCol++;
    }

    print();

    function print() {
        matrix.forEach(row => console.log(row.join(' ')));
    }
}