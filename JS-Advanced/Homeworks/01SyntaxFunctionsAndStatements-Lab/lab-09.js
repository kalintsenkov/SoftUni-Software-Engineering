"use strict"

function uppercaseWords(input) {
    return input
        .split(/\.\s+|\.|,\s+|,|\/|!|\?|\s+|-|_|'|"/g)
        .filter(word => word)
        .join(', ')
        .toString()
        .toUpperCase();
}