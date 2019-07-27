namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;

    using Contracts;
    using Players;
    using Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += 40;
                attackPlayer.CardRepository.Cards.ToList().ForEach(x => x.DamagePoints += 30);
            }

            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += 40;
                enemyPlayer.CardRepository.Cards.ToList().ForEach(x => x.DamagePoints += 30);
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            while (true)
            {
                var attackPlayerDamage = attackPlayer
                    .CardRepository
                    .Cards
                    .Sum(x => x.DamagePoints);

                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyPlayerDamage = enemyPlayer
                    .CardRepository
                    .Cards
                    .Sum(x => x.DamagePoints);

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
