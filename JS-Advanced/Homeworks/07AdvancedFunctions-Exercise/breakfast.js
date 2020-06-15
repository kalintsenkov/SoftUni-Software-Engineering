'use strict'

function solution() {
    const ingredientsMap = {
        'protein': 0,
        'carbohydrate': 0,
        'fat': 0,
        'flavour': 0
    };

    return (input) => {
        const recipesMap = {
            'apple': (quantity) => {
                throwIfNotEnough('carbohydrate', 1 * quantity);
                throwIfNotEnough('flavour', 2 * quantity);
                decrease('carbohydrate', 1 * quantity);
                decrease('flavour', 2 * quantity);
            },
            'lemonade': (quantity) => {
                throwIfNotEnough('carbohydrate', 10 * quantity);
                throwIfNotEnough('flavour', 20 * quantity);
                decrease('carbohydrate', 10 * quantity);
                decrease('flavour', 20 * quantity);
            },
            'burger': (quantity) => {
                throwIfNotEnough('carbohydrate', 5 * quantity);
                throwIfNotEnough('fat', 7 * quantity);
                throwIfNotEnough('flavour', 3 * quantity);
                decrease('carbohydrate', 5 * quantity);
                decrease('fat', 7 * quantity);
                decrease('flavour', 3 * quantity);
            },
            'eggs': (quantity) => {
                throwIfNotEnough('protein', 5 * quantity);
                throwIfNotEnough('fat', 1 * quantity);
                throwIfNotEnough('flavour', 1 * quantity);
                decrease('protein', 5 * quantity);
                decrease('fat', 1 * quantity);
                decrease('flavour', 1 * quantity);
            },
            'turkey': (quantity) => {
                throwIfNotEnough('protein',10 * quantity);
                throwIfNotEnough('carbohydrate', 10 * quantity);
                throwIfNotEnough('fat', 10 * quantity);
                throwIfNotEnough('flavour', 10 * quantity);
                decrease('protein', 10 * quantity);
                decrease('carbohydrate', 10 * quantity);
                decrease('fat', 10 * quantity);
                decrease('flavour', 10 * quantity);
            }
        };

        function throwIfNotEnough(ingredient, quantity) {
            if (ingredientsMap[ingredient] - (quantity) < 0) {
                throw new Error(`Error: not enough ${ingredient} in stock`);
            }
        }

        function decrease(ingredient, quantity) {
            ingredientsMap[ingredient] -= quantity;
        }

        const [command, element, quantity] = input.split(' ');

        let result = '';

        if (command === 'restock') {
            ingredientsMap[element] += Number(quantity);
            result += 'Success\n';
        } else if (command === 'prepare') {
            try {
                recipesMap[element](quantity);
                result += 'Success\n';
            } catch (e) {
                result += `${e.message}\n`;
            }
        } else if (command === 'report') {
            for (const ingredient in ingredientsMap) {
                result += `${ingredient}=${ingredientsMap[ingredient]} `;
            }
        }

        return result.trim();
    };
}