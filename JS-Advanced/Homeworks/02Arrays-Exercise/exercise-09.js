'use strict'

function solve(arr) {
    const matrix = [];

    arr.map((item, index) => {
        matrix.push([]);
        item.split(' ').map(el => matrix[index].push(+el))
    });

    let mainDiagonalSum = 0;
    let secondDiagonalSum = 0;
    let secondDiagonalIndex = matrix.length - 1;

    for (let i = 0; i < matrix.length; i++) {
        mainDiagonalSum += matrix[i][i];
        secondDiagonalSum += matrix[secondDiagonalIndex--][i];
    }

    if (mainDiagonalSum === secondDiagonalSum) {
        changeValue();
    }

    print();

    function changeValue() {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (row === col || ((row + col) == (matrix[row].length - 1))) {
                    continue;
                }

                matrix[row][col] = mainDiagonalSum;
            }
        }
    }

    function print() {
        matrix.forEach(row => console.log(row.join(' ')));
    }
}