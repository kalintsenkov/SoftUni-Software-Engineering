'use strict'

function solve() {
    function mage(name) {
        const state = {
            name,
            health: 100,
            mana: 100,
            cast: (spell) => {
                console.log(`${state.name} cast ${spell}`);
                state.mana--;
            }
        };

        return state;
    }

    function fighter(name) {
        const state = {
            name,
            health: 100,
            stamina: 100,
            fight: () => {
                console.log(`${state.name} slashes at the foe!`);
                state.stamina--;
            }
        };

        return state;
    }

    return { mage, fighter };
}

const create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);