'use strict'

function solve(matrix) {
    let equals = 0;

    const isInside = (row, col) => row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {

            if (isInside(row + 1, col)) {
                if (matrix[row][col] === matrix[row + 1][col]) {
                    equals++;
                }
            } if (isInside(row, col + 1)) {
                if (matrix[row][col] === matrix[row][col + 1]) {
                    equals++;
                }
            }
        }
    }

    return equals;
}