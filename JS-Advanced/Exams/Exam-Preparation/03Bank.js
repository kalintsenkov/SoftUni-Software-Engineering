'use strict'

class Bank {
    #transactions = {};

    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        const isExisting = this.allCustomers
            .some(c => c.firstName === customer.firstName && c.lastName === customer.lastName);

        if (isExisting) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney(personalId, amount) {
        const customer = this.allCustomers.find(c => c.personalId === personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        if (personalId in this.#transactions) {
            this.#transactions[personalId].push(amount);
        } else {
            this.#transactions[personalId] = [];
            this.#transactions[personalId].push(amount);
        }

        if (customer.hasOwnProperty('totalMoney')) {
            customer['totalMoney'] += amount;
        } else {
            Object.defineProperty(customer, 'totalMoney', {
                value: amount,
                writable: true
            });
        }

        return customer['totalMoney'] + '$';
    }

    withdrawMoney(personalId, amount) {
        const customer = this.allCustomers.find(c => c.personalId === personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        if (customer['totalMoney'] - amount < 0) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`)
        }

        if (personalId in this.#transactions) {
            this.#transactions[personalId].push(-amount);
        } else {
            this.#transactions[personalId] = [];
            this.#transactions[personalId].push(-amount);
        }

        customer['totalMoney'] -= amount;

        return customer['totalMoney'] + '$';
    }

    customerInfo(personalId) {
        const customer = this.allCustomers.find(c => c.personalId == personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        const customerTransactions = this.#transactions[personalId];
        let result = `Bank name: ${this._bankName}\n`;
        result += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
        result += `Customer ID: ${customer.personalId}\n`;
        result += `Total Money: ${customer['totalMoney']}$\n`;
        result += 'Transactions:\n';

        for (let i = customerTransactions.length - 1; i >= 0; i--) {
            const amount = customerTransactions[i];

            result += amount > 0
                ? `${i + 1}. ${customer.firstName} ${customer.lastName} made deposit of ${amount}$!\n`
                : `${i + 1}. ${customer.firstName} ${customer.lastName} withdrew ${Math.abs(amount)}$!\n`;
        }

        return result.trim();
    }
}