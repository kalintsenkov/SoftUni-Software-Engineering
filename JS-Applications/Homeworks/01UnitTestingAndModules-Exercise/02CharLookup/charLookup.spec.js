const expect = require('chai').expect;
const lookupChar = require('./charLookup').lookupChar;

describe('lookupChar', () => {
    it('should return undefined if first parameter is not a string', () => {
        const actual = lookupChar(5, 5);
        expect(actual).to.be.undefined;
    });

    it('should return undefined if second parameter is not a number', () => {
        const actual = lookupChar('invalid', 'test');
        expect(actual).to.be.undefined;
    });

    it('should return undefined when parameters are not in correct type', () => {
        const actual = lookupChar(5, 'invalid');
        expect(actual).to.be.undefined;
    });

    it(`should return 'Incorrect index' when the value of the index is bigger than the string length`, () => {
        const expected = 'Incorrect index';
        const actual = lookupChar('testing', 10);
        expect(actual).to.equal(expected);
    });

    it(`should return 'Incorrect index' when the value of the index is equal to the string length`, () => {
        const expected = 'Incorrect index';
        const actual = lookupChar('testing', 7);
        expect(actual).to.equal(expected);
    });

    it(`should return 'Incorrect index' when the value of the index is a negative number`, () => {
        const expected = 'Incorrect index';
        const actual = lookupChar('testing', -3);
        expect(actual).to.equal(expected);
    });

    it('should return character at the specified index when both parameters have correct types and values', () => {
        const expected = 't';
        const actual = lookupChar('testing', 3);
        expect(actual).to.equal(expected);
    });
});