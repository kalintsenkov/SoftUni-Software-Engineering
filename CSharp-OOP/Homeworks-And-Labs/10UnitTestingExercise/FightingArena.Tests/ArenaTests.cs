namespace Tests
{
    using System;

    using FightingArena;

    using NUnit.Framework;

    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        public void ArenaEnrollShouldWorkCorrectly()
        {
            var warrior = new Warrior("Gosho", 5, 100);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void ArenaEnrollShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {
            var warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior));
        }

        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            var expectedResult = 1;

            var warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.AreEqual(expectedResult, this.arena.Count);
        }

        [Test]
        public void ArenaFightMethodShouldWorkCorrectly()
        {
            var attacker = new Warrior("Pesho", 10, 100);
            var defender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            var expectedAttackerHp = 95;
            var expectedDefenderHp = 40;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void ArenaFightMethodShouldThrowExceptionIfWarriorsAreNotFound()
        {
            var attacker = new Warrior("Pesho", 10, 100);
            var defender = new Warrior("Gosho", 5, 5);

            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker.Name, defender.Name));
        }
    }
}
