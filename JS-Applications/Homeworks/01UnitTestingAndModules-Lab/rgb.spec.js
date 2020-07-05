const rgbToHexColor = require('./rgb').rgbToHexColor;
const expect = require('chai').expect;

describe('rgbToHexColor', () => {
    it('should return same color when parameters are valid', () => {
        const expected = '#1E90FF';
        const actual = rgbToHexColor(30, 144, 255);
        expect(actual).to.eql(expected);
    });

    it('should return undefined when one of parameters is not integers', () => {
        const actual = rgbToHexColor(1, 2, 'invalid3');
        expect(actual).to.be.undefined;
    });

    it('should return undefined when all parameters are not integers', () => {
        const actual = rgbToHexColor('invalid1', 'invalid2', 'invalid3');
        expect(actual).to.be.undefined;
    });

    it('should return undefined when one of parameters is not in range [0...255]', () => {
        const actual = rgbToHexColor(-1, 0, 10);
        expect(actual).to.be.undefined;
    });

    it('should return undefined when all parameters are not in range [0...255]', () => {
        const actual = rgbToHexColor(-1, 256, 300);
        expect(actual).to.be.undefined;
    });
});