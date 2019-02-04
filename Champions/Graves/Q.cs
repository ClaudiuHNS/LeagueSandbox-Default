using System.Numerics;
using GameServerCore.Enums;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace Spells
{
    public class GravesClusterShot : IGameScript
    {

        public void OnActivate(IChampion owner)
        {

        }

        public void OnDeactivate(IChampion owner)
        {
        }

        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            spell.SpellAnimation("SPELL1", owner);
        }

        public void OnFinishCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            var current = new Vector2(owner.X, owner.Y);
            var to = Vector2.Normalize(new Vector2(spell.X, spell.Y) - current);
            Vector2 to2 = to.Rotate(15.32f);
            Vector2 to3 = to.Rotate(360 - 15.32f);

            var range = to * 950;
            var range2 = to2 * 950;
            var range3 = to3 * 950;
            var trueCoords1 = current + range;
            var trueCoords2 = current + range2;
            var trueCoords3 = current + range3;

            // Fire the three projectiles in a cone
            spell.AddProjectile("GravesClusterShotAttack", owner.X, owner.Y, trueCoords1.X, trueCoords1.Y);
            spell.AddProjectile("GravesClusterShotAttack", owner.X, owner.Y, trueCoords2.X, trueCoords2.Y);
            spell.AddProjectile("GravesClusterShotAttack", owner.X, owner.Y, trueCoords3.X, trueCoords3.Y);
            // Create the invisible 'projectile' for sound effects
            spell.AddProjectile("GravesClusterShotSoundMissile", owner.X, owner.Y, trueCoords1.X, trueCoords1.Y);
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {
            var bonusAD = owner.Stats.AttackDamage.Total - owner.Stats.AttackDamage.BaseValue;
            var ad = bonusAD * 0.150f;
            var damage = new[] { 60, 95, 130, 165, 200 }[spell.Level - 1] + ad;
            target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
        }

        public void OnUpdate(double diff)
        {
        }
    }
}
