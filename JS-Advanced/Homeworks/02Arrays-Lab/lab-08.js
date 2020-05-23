'use strict'

function diagonalsSum(matrix) {
    let mainDiagonal = 0;
    let secondaryDiagonal = 0;
    let secondaryDiagonalIndex = matrix.length - 1;

    for (let i = 0; i < matrix.length; i++) {
        mainDiagonal += matrix[i][i];
        secondaryDiagonal += matrix[i][secondaryDiagonalIndex--];
    }

    return mainDiagonal + ' ' + secondaryDiagonal;
}