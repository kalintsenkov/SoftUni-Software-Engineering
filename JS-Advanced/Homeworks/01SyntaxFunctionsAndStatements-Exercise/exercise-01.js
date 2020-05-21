"use strict"

function calculate(fruit, grams, pricePerKg) {
    let kg = grams / 1000;
    let totalPrice = (pricePerKg * kg).toFixed(2);

    return `I need $${totalPrice} to buy ${kg.toFixed(2)} kilograms ${fruit}.`;
}