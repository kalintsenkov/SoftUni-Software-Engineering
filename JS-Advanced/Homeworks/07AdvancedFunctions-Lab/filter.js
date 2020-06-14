'use strict'

function solve(data, criteria) {
    const parsed = JSON.parse(data);
    const [first, second] = criteria.split('-');

    let result = '';
    [...parsed].filter(d => d[first] === second).map((element, index) => {
        result += `${index}. ${element.first_name} ${element.last_name} - ${element.email}\n`;
    });

    return result.trim();
}

console.log(solve(
    `[
        {
            "id": "1",
            "first_name": "Kaylee",
            "last_name": "Johnson",
            "email": "k0@cnn.com",
            "gender": "Female"
        }, 
        {
            "id": "2",
            "first_name": "Kizzee",
            "last_name": "Johnson",
            "email": "kjost1@forbes.com",
            "gender": "Female"
        }, 
        {
            "id": "3",
            "first_name": "Evanne",
            "last_name": "Maldin",
            "email": "emaldin2@hostgator.com",
            "gender": "Male"
        }, 
        {
            "id": "4",
            "first_name": "Evanne",
            "last_name": "Johnson",
            "email": "ev2@hostgator.com",
            "gender": "Male"
        }
    ]`,
    'last_name-Johnson'
));