'use strict'

function solve(matrix) {
    const rowsEqual = areRowsEqual();
    const colsEqual = areColsEqual();

    if (!rowsEqual || !colsEqual) {
        return false;
    } else if (rowsEqual && colsEqual) {
        return true;
    }

    function areRowsEqual() {
        let firstRowSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            let rowSum = 0;
            for (let col = 0; col < matrix[row].length; col++) {
                const cell = matrix[row][col];

                if (row === 0) {
                    firstRowSum += cell;
                    continue;
                }

                rowSum += cell;
                if (rowSum !== firstRowSum &&
                    col === matrix[row].length - 1) {
                    return false;
                }
            }
        }

        return true;
    }

    function areColsEqual() {
        let firstColSum = 0;
        for (let col = 0; col < matrix[0].length; col++) {
            let colSum = 0;
            for (let row = 0; row < matrix.length; row++) {
                const cell = matrix[row][col];
                
                if (col === 0) {
                    firstColSum += cell;
                    continue;
                }

                colSum += cell;
                if (colSum !== firstColSum &&
                    row === matrix.length - 1) {
                    return false;
                }
            }
        }

        return true;
    }
}