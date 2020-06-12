'use strict'

function getFibonator() {
    const fibonacci = [];

    return () => {
        let next = 1;
        if (fibonacci.length >= 2) {
            next = fibonacci[fibonacci.length - 1] + fibonacci[fibonacci.length - 2];
        } 

        fibonacci.push(next);
        return next;
    }
}