const expect = require('chai').expect;
const isOddOrEven = require('./evenOrOdd').isOddOrEven;

describe('isOddOrEven', () => {
    it('should return undefined with a number parameter', () => {
        const actual = isOddOrEven(3);
        expect(actual).to.be.undefined;
    });

    it('should return undefined with a object parameter', () => {
        const actual = isOddOrEven({});
        expect(actual).to.be.undefined;
    });

    it('should return even when string length is even number', () => {
        const expected = 'even'
        const actual = isOddOrEven('valid test');
        expect(actual).to.equal(expected);
    });

    it('should return odd when string length is odd number', () => {
        const expected = 'odd'
        const actual = isOddOrEven('invalid');
        expect(actual).to.equal(expected);
    });
});