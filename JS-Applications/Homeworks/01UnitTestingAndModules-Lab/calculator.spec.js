const createCalculator = require('./calculator').createCalculator;
const expect = require('chai').expect;

describe('calculator', () => {
    it ('should return value of the internal sum when get method is invoked', () => {
        const calculator = createCalculator();
        const expected = 0;
        const actual = calculator.get();
        expect(actual).to.be.eql(expected);
    });

    it ('should add number to current sum', () => {
        const calculator = createCalculator();
        calculator.add(2);
        const expected = 2;
        const actual = calculator.get();
        expect(actual).to.be.eql(expected);
    });

    it ('should parse and add number to current sum', () => {
        const calculator = createCalculator();
        calculator.add('2');
        const expected = 2;
        const actual = calculator.get();
        expect(actual).to.be.eql(expected);
    });

    it ('should subtract number to current sum', () => {
        const calculator = createCalculator();
        calculator.subtract(2);
        const expected = -2;
        const actual = calculator.get();
        expect(actual).to.be.eql(expected);
    });

    it ('should parse and subtract number to current sum', () => {
        const calculator = createCalculator();
        calculator.add('-2');
        const expected = -2;
        const actual = calculator.get();
        expect(actual).to.be.eql(expected);
    });

    it ('should return undefined when internal sum is modified', () => {
        const calculator = createCalculator();
        const actual = calculator.value;
        expect(actual).to.be.undefined;
    });
});