const isSymmetric = require('./symmetry').isSymmetric;
const expect = require('chai').expect;

describe('isSymmetric', () => {
    it('should return true when array is symmetric', () => {
        const actual = isSymmetric([1, 2, 3, 2, 1]);
        expect(actual).to.be.true;
    });

    it('should return false when array is not symmetric', () => {
        const actual = isSymmetric([1, 2, 3, 2, 2]);
        expect(actual).to.be.false;
    });

    it('should return false when parameter is not an array', () => {
        const actual = isSymmetric('invalid');
        expect(actual).to.be.false;
    });
});