const sum = require('./numbers').sum;
const expect = require('chai').expect;

describe('sum', () => {
    it('should return NaN when test with string', () => {
        const actual = sum('abc');
        expect(actual).to.be.NaN;
    });

    it('should return number when test with array of strings', () => {
        const expected = sum(['1', '2']);
        expect(expected).to.equal(3);
    });

    it('should return 6 when invoke sum([1, 2, 3])', () => {
        const expected = 6;
        const actual = sum([1, 2, 3]);
        expect(actual).to.equal(expected);
    });
});