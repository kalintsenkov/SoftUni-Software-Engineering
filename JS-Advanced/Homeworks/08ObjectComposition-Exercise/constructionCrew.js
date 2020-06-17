'use strict'

function solve(worker) {

    if (worker.dizziness === true) {
        worker.levelOfHydrated += worker.weight * worker.experience * 0.1;
        worker.dizziness = false;
    }

    return worker;
}