namespace Tests
{
    using System;

    using FightingArena;

    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {  
        [Test]
        public void WarriorConstructorShouldWorksCorrectly()
        {
            var warrior = new Warrior("Pesho", 15, 100);

            var expectedName = "Pesho";
            var expectedDamage = 15;
            var expectedHp = 100;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void WarriorNameShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 25, 50));
        }

        [Test]
        public void WarriorNameShouldThrowExceptionIfIsWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("   ", 25, 50));
        }

        [Test]
        public void WarriorDamageShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", -10, 100));
        }

        [Test]
        public void WarriorDamageShouldThrowExceptionIfIsZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 0, 100));
        }

        [Test]
        public void WarriorHpShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 15, -10));
        }

        [Test]
        public void AttackMethodShouldWorksCorrectly()
        {
            var attacker = new Warrior("Pesho", 10, 100);
            var defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            var expectedAttackerHp = 95;
            var expectedDefenderHp = 80;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void WarriorShouldNotAttackIfHisHpIsEqualOrLessThan30()
        {
            var attacker = new Warrior("Pesho", 10, 25);
            var defender = new Warrior("Jivko", 5, 45);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void WarriorShouldNotAttackEnemyWith30HpOrLess()
        {
            var attacker = new Warrior("Pesho", 10, 45);
            var defender = new Warrior("Gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void WarriorShouldNotAttackEnemyWithBiggerDamageThanHisHealth()
        {
            var attacker = new Warrior("Pesho", 10, 35);
            var defender = new Warrior("Gosho", 45, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void EnemyHpShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHp()
        {
            var attacker = new Warrior("Pesho", 50, 100);
            var defender = new Warrior("Paul", 45, 40);

            attacker.Attack(defender);

            var expectedAttackerHp = 55;
            var expectedDefenderHp = 0;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
    }
}