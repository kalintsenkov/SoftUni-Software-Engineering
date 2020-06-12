'use strict'

class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(username, salary, position, department) {
        this._throwIfNullOrEmpty(username);
        this._throwIfNullOrEmpty(salary);
        this._throwIfNullOrEmpty(position);
        this._throwIfNullOrEmpty(department);
        this._throwIfSalaryIsInvalid(salary);

        if (!(this.departments[department])) {
            this.departments[department] = [];
        }

        this.departments[department].push({ username, salary, position, department });

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let result = '';

        const [bestDepartment, avgSalary] = this._getBestDepartmentAndAvgSalary();

        result += `Best Department is: ${bestDepartment}\n`;
        result += `Average salary: ${avgSalary.toFixed(2)}\n`;

        const sortedEmployees = this.departments[bestDepartment].sort((a, b) => {
            if (b.salary < a.salary) { return -1; }
            if (b.salary > a.salary) { return 1; }
            if (b.salary === a.salary) { return a.username.localeCompare(b.username); }
        });

        for (const emp of sortedEmployees) {
            result += `${emp.username} ${emp.salary} ${emp.position}\n`;
        }

        return result.trim();
    }

    _throwIfNullOrEmpty(input) {
        if (input === null || input === undefined || input === "") {
            throw new Error("Invalid input!");
        }
    }

    _throwIfSalaryIsInvalid(salary) {
        if (salary < 0) {
            throw new Error("Invalid input!");
        }
    }

    _getBestDepartmentAndAvgSalary() {
        const allDepartments = {};

        for (const department in this.departments) {
            const employees = this.departments[department];

            for (const emp of employees) {

                if (!(department in allDepartments)) {
                    allDepartments[department] = emp.salary;
                } else {
                    allDepartments[department] += emp.salary;
                }
            }
        }

        const result = Object.keys(allDepartments)
            .map(d => ({ key: d, value: allDepartments[d] / this.departments[d].length }))
            .sort((a, b) => b.value.salary - a.value.salary);

        const bestDepartment = result[[...result.keys()].find(v => true)].key;
        const avgSalary = [...result.values()].find(v => true).value;

        return [bestDepartment, avgSalary];
    }
}