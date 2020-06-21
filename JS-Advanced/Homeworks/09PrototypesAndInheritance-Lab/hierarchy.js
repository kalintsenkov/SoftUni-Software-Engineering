'use strict'

function solution() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }
    
        changeUnits(newUnits) {
            this.units = newUnits;
        }
    
        transformMetric(value) {
            return this.units === 'm'
                ? value / 100
                : this.units === 'mm'
                    ? value * 10
                    : value;
        }
    
        toString() {
            return `Figures units: ${this.units} Area: ${this.area}`;
        }
    }
    
    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this.radius = radius;
        }
    
        get area() {
            const radius = this.transformMetric(this.radius);
            return Math.PI * radius * radius;
        }
    
        toString() {
            return `${super.toString()} - radius: ${this.transformMetric(this.radius)}`;
        }
    }
    
    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this.width = width;
            this.height = height;
        }
    
        get area() {
            const width = this.transformMetric(this.width);
            const height = this.transformMetric(this.height);
            return width * height;
        }
    
        toString() {
            return `${super.toString()} - width: ${this.transformMetric(this.width)}, height: ${this.transformMetric(this.height)}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    };
}

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
