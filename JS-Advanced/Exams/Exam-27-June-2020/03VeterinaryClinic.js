'use strict'

class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this._totalProfit = 0;
        this._currentWorkload = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        if (this.capacity === this.clients.length) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        const client = this.clients[ownerName];

        if (client === undefined) {
            this.clients.push(ownerName);
            this.clients[ownerName] = [];
        }

        const pet = this.clients[ownerName].find(p => p.name === petName);

        if (pet !== undefined) {
            const procedures = pet.procedures;

            if (procedures.length > 0) {
                throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${procedures.join(', ')}.`);
            }
        }

        this.clients[ownerName].push({
            name: petName,
            kind: kind.toLowerCase(),
            procedures: procedures
        });

        if (procedures.length > 0) {
            this._currentWorkload++;
        }

        return `Welcome ${petName}!`;
    }

    onLeaving(ownerName, petName) {
        const client = this.clients[ownerName];

        if (client === undefined) {
            throw new Error('Sorry, there is no such client!');
        }

        const pet = client.find(p => p.name === petName);

        if (pet === undefined) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        if (pet.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        this._totalProfit += 500 * pet.procedures.length;
        this._currentWorkload--;

        pet.procedures = [];

        return `Goodbye ${petName}. Stay safe!`;
    }

    toString() {
        let result = `${this.clinicName} is ${Math.floor(this._currentWorkload / this.capacity * 100)}% busy today!\n`;
        result += `Total profit: ${this._totalProfit.toFixed(2)}$\n`;

        const sortedClients = this.clients.sort((a, b) => a.localeCompare(b));

        for (const client of sortedClients) {
            result += `${client} with:\n`;

            const sortedPets = sortedClients[client].sort((a, b) => a.name.localeCompare(b.name));

            for (const pet of sortedPets) {
                result += `---${pet.name} - a ${pet.kind} that needs: ${pet.procedures.join(', ')}\n`;
            }
        }

        return result.trim();
    }
}