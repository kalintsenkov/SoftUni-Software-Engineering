'use strict'

class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(a, b) {
        const horizontal = Math.pow((a.x - b.x), 2);
        const vertical = Math.pow((a.y - b.y), 2);

        return Math.sqrt(horizontal + vertical);
    }
}