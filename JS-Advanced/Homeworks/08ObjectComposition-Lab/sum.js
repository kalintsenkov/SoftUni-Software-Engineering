'use strict'

function solution() {
    let first;
    let second;
    let result;

    function init(selector1, selector2, resultSelector) {
        first = document.querySelector(selector1);
        second = document.querySelector(selector2);
        result = document.querySelector(resultSelector);
    }
    
    function add() {
        result.value = Number(first.value) + Number(second.value);
    }

    function subtract() {
        result.value = Number(first.value) - Number(second.value);
    }

    return {
        init,
        add,
        subtract
    };
}