const expect = require('chai').expect;
const PaymentPackage = require('./paymentPackage').PaymentPackage;

describe('PaymentPackage', () => {
    describe('constructor', () => {

    });

    describe('name', () => {
        it('get should return current name', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            const expected = 'Consultation';
            const actual = paymentPackage.name;
            expect(actual).to.be.eql(expected);
        });

        it('set should change name', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            paymentPackage.name = 'HR Services';

            const expected = 'HR Services';
            const actual = paymentPackage.name;

            expect(actual).to.be.eql(expected);
        });

        it('set should throw Error when newValue is not of type string', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            expect(() => paymentPackage.name = {}).to.throw(Error, 'Name must be a non-empty string');
        });

        it('set should throw Error when newValue is empty string', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            expect(() => paymentPackage.name = '').to.throw(Error, 'Name must be a non-empty string');
        });
    });

    describe('value', () => {
        it('get should return current value', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            const expected = 800;
            const actual = paymentPackage.value;
            expect(actual).to.be.eql(expected);
        });

        it('set should change value', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            paymentPackage.value = 500;

            const expected = 500;
            const actual = paymentPackage.value;

            expect(actual).to.be.eql(expected);
        });

        it('set should throw Error when newValue is not of type number', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            expect(() => paymentPackage.value = {}).to.throw(Error, 'Value must be a non-negative number');
        });

        it('set should throw Error when newValue is a negative number', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            expect(() => paymentPackage.value = -300).to.throw(Error, 'Value must be a non-negative number');
        });
    });

    describe('VAT', () => {
        it('get should return default value', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            const expected = 20;
            const actual = paymentPackage.VAT;
            expect(actual).to.be.eql(expected);
        });

        it('set should change value', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            paymentPackage.VAT = 30;

            const expected = 30;
            const actual = paymentPackage.VAT;

            expect(actual).to.be.eql(expected);
        });

        it('set should throw Error when newValue is not of type number', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            expect(() => paymentPackage.VAT = {}).to.throw(Error, 'VAT must be a non-negative number');
        });

        it('set should throw Error when newValue is a negative number', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            expect(() => paymentPackage.VAT = -300).to.throw(Error, 'VAT must be a non-negative number');
        });
    });

    describe('active', () => {
        it('get should return default value', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            const expected = true;
            const actual = paymentPackage.active;
            expect(actual).to.be.eql(expected);
        });

        it('set should change value', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            paymentPackage.active = false;

            const expected = false;
            const actual = paymentPackage.active;

            expect(actual).to.be.eql(expected);
        });

        it('set should throw Error when newValue is not of type boolean', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            expect(() => paymentPackage.active = {}).to.throw(Error, 'Active status must be a boolean');
        });
    });

    describe('toString', () => {
        it('should return correct output when active is true', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);

            const expected = [
                `Package: ${paymentPackage.name}`,
                `- Value (excl. VAT): ${paymentPackage.value}`,
                `- Value (VAT ${paymentPackage.VAT}%): ${paymentPackage.value * (1 + paymentPackage.VAT / 100)}`
            ].join('\n');

            const actual = paymentPackage.toString();

            expect(actual).to.be.eql(expected);
        });

        it('should return correct output when active is false', () => {
            const paymentPackage = new PaymentPackage('Consultation', 800);
            paymentPackage.active = false;

            const expected = [
                `Package: ${paymentPackage.name} (inactive)`,
                `- Value (excl. VAT): ${paymentPackage.value}`,
                `- Value (VAT ${paymentPackage.VAT}%): ${paymentPackage.value * (1 + paymentPackage.VAT / 100)}`
            ].join('\n');

            const actual = paymentPackage.toString();

            expect(actual).to.be.eql(expected);
        });
    });
});