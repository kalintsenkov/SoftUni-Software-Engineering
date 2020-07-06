const expect = require('chai').expect;
const StringBuilder = require('./stringBuilder').StringBuilder;

describe('StringBuilder', () => {
    describe('constructor', () => {
        it('should throw TypeErrorException when the parameter is not a string', () => {
            expect(() => new StringBuilder(5)).to.throw(TypeError, 'Argument must be string');
        });

        it('should not throw TypeErrorException when the parameter is a string', () => {
            expect(() => new StringBuilder('valid')).to.not.throw(TypeError);
        });

        it('should not throw TypeErrorException when instantiated without parameter', () => {
            expect(() => new StringBuilder()).to.not.throw(TypeError);
        });
    });

    describe('append', () => {
        it('should throw TypeErrorException when the parameter is not a string', () => {
            const sb = new StringBuilder();
            expect(() => sb.append(5)).to.throw(TypeError, 'Argument must be string');
        });

        it('should add string to the end of the storage', () => {
            const sb = new StringBuilder('testing');
            sb.append('test');

            const acutal = sb._stringArray;
            const expected = Array.from('testingtest');

            expect(acutal).to.be.eql(expected);
        });
    });

    describe('prepend', () => {
        it('should throw TypeErrorException when the parameter is not a string', () => {
            const sb = new StringBuilder();
            expect(() => sb.prepend([])).to.throw(TypeError, 'Argument must be string');
        });

        it('should add string to the beginning of the storage', () => {
            const sb = new StringBuilder('testing');
            sb.prepend('test');

            const acutal = sb._stringArray;
            const expected = Array.from('testtesting');

            expect(acutal).to.be.eql(expected);
        });
    });

    describe('insertAt', () => {
        it('should throw TypeErrorException when the parameter is not a string', () => {
            const sb = new StringBuilder();
            expect(() => sb.insertAt([], 0)).to.throw(TypeError, 'Argument must be string');
        });

        it('should add string at the given index', () => {
            const sb = new StringBuilder('test');
            sb.insertAt('ing', 4);

            const acutal = sb._stringArray;
            const expected = Array.from('testing');

            expect(acutal).to.be.eql(expected);
        });
    });

    describe('remove', () => {
        it('should removes elements from the storage', () => {
            const sb = new StringBuilder('test');
            sb.remove(0, 3);

            const acutal = sb._stringArray;
            const expected = ['t'];

            expect(acutal).to.be.eql(expected);
        });

        it('should removes elements from the storage', () => {
            const sb = new StringBuilder('test');
            sb.remove(0, 4);

            const acutal = sb._stringArray;
            const expected = [];

            expect(acutal).to.be.eql(expected);
        });
    });

    describe('toString', () => {
        it('should return a string with all elements joined by an empty string', () => {
            const sb = new StringBuilder('test');
            sb.append('ing. ');
            sb.append('unit testing is cool!');

            const acutal = sb.toString();
            const expected = 'testing. unit testing is cool!';

            expect(acutal).to.be.eql(expected);
        });
    });
});