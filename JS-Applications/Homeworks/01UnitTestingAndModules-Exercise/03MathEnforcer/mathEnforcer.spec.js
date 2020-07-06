const expect = require('chai').expect;
const mathEnforcer = require('./mathEnforcer').mathEnforcer;

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('should return undefined with a non-number paramter', () => {
            const actual = mathEnforcer.addFive('invalid');
            expect(actual).to.be.undefined;
        });

        it('should return correct result with a number paramter', () => {
            const expected = 8;
            const actual = mathEnforcer.addFive(3);
            expect(actual).to.equal(expected);
        });

        it('should return correct result with a negative number', () => {
            const expected = 2;
            const actual = mathEnforcer.addFive(-3);
            expect(actual).to.equal(expected);
        });
    });

    describe('subtractTen', () => {
        it('should return undefined with a non-number paramter', () => {
            const actual = mathEnforcer.subtractTen({});
            expect(actual).to.be.undefined;
        });

        it('should return correct result with a number paramter', () => {
            const expected = 20;
            const actual = mathEnforcer.subtractTen(30);
            expect(actual).to.equal(expected);
        });

        it('should return correct result with a negative number', () => {
            const expected = -30;
            const actual = mathEnforcer.subtractTen(-20);
            expect(actual).to.equal(expected);
        });
    });

    describe('sum', () => {
        it('should return undefined with a non-number paramter', () => {
            const actual = mathEnforcer.sum([], {});
            expect(actual).to.be.undefined;
        });

        it('should return correct result with a number paramter', () => {
            const expected = 35.5;
            const actual = mathEnforcer.sum(5.5, 30);
            expect(actual).to.equal(expected);
        });

        it('should return correct result with a negative number', () => {
            const expected = -5.5;
            const actual = mathEnforcer.sum(-3.2, -2.3);
            expect(actual).to.equal(expected);
        });
    });
});