"use strict"

function solve(points) {
    const x1 = +points[0];
    const y1 = +points[1];
    const x2 = +points[2];
    const y2 = +points[3];

    function calucateDistance(x1, y1, x2, y2) {
        const distX = x1 - x2;
        const distY = y1 - y2;
        return Math.sqrt(distX ** 2 + distY ** 2);
    }

    Number.isInteger(calucateDistance(x1, y1, 0, 0))
        ? console.log(`{${x1}, ${y1}} to {0, 0} is valid`)
        : console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    Number.isInteger(calucateDistance(x2, y2, 0, 0))
        ? console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
        : console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    Number.isInteger(calucateDistance(x1, y1, x2, y2))
        ? console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
        : console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
}