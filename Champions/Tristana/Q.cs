using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
using GameServerCore.Domain;
using GameServerCore.Enums;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace Spells
{
    public class RapidFire : IGameScript
    {        
        public void OnActivate(IChampion owner)
        {
            //owner.Stats.Range.FlatBonus += owner.Stats.Level * 10;
        }

        private void ReduceCooldown(IAttackableUnit unit, bool isCrit)
        {
        //No Cooldown reduction on the other skills yet
        }

        public void OnDeactivate(IChampion owner)
        {
        }

        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            var p1 = AddParticleTarget(owner, "RapidFire_buf.troy", owner, 1);
            var p2 = AddParticleTarget(owner, "RapidFire_cas.troy", owner, 1);
            ((ObjAiBase) target).AddBuffGameScript("RapidFire", "RapidFire", spell, 5.0f, true);
            CreateTimer(1.0f, () =>
            {
                RemoveParticle(p2);
            });
            CreateTimer(5.0f, () =>
            {
                RemoveParticle(p1);
            });
            //No increased durations on kills and assists yet
        }

        public void OnFinishCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {
        }

        public void OnUpdate(double diff)
        {
        }
    }
}
