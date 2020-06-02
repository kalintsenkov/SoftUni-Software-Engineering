'use strict'

function solve(arr, sortCriteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    const tickets = [];

    for (const row of arr) {
        let [destination, price, status] = row.split('|');
        price = Number(price);

        tickets.push(new Ticket(destination, price, status));
    }

    if (sortCriteria === 'destination') {
        tickets.sort((a, b) => a.destination.localeCompare(b.destination));
    } else if (sortCriteria === 'price') {
        tickets.sort((a, b) => a.price - b.price);
    } else {
        tickets.sort((a, b) => a.status.localeCompare(b.status));
    }

    return tickets;
}