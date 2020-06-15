'use strict'

let solution = (function () {

    function add(vec1, vec2) {
        const [x1, y1] = vec1;
        const [x2, y2] = vec2;

        const x = x1 + x2;
        const y = y1 + y2;

        return [x, y];
    }

    function multiply(vec, scalar) {
        const [x1, y1] = vec;

        const x = x1 * scalar;
        const y = y1 * scalar;

        return [x, y];
    }

    function length(vec) {
        const [x1, y1] = vec;

        const x = x1 ** 2;
        const y = y1 ** 2;

        return Math.sqrt(x + y);
    }

    function dot(vec1, vec2) {
        const [x1, y1] = vec1;
        const [x2, y2] = vec2;

        const x1y1 = x1 * x2;
        const x2y2 = y1 * y2;

        return x1y1 + x2y2;
    }

    function cross(vec1, vec2) {
        const [x1, y1] = vec1;
        const [x2, y2] = vec2;

        const x = x1 * y2;
        const y = y1 * x2;

        return x - y;
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    };
})();

console.log(solution.add([1, 1], [1, 0]));    // [2, 1]
console.log(solution.multiply([3.5, -2], 2)); // [7, -4]
console.log(solution.length([3, -4]));        // 5
console.log(solution.dot([1, 0], [0, -1]));   // 0
console.log(solution.cross([3, 7], [1, 0]));  // -7