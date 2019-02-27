using System.Numerics;
using GameServerCore.Enums;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.API;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace Spells
{
    public class Dazzle : IGameScript
    {
        private UnitCrowdControl _crowd = new UnitCrowdControl(CrowdControlType.STUN);
        public void OnActivate(IChampion owner)
        {
        }

        public void OnDeactivate(IChampion owner)
        {
        }

        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
        }

        public void OnFinishCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            spell.AddProjectileTarget("Dazzle", target, true);
            //var p101 = AddParticleTarget(owner, "Dazzle_cas.troy", owner, 1);

            //AddBuffHudVisual("Stun", time, 1, BuffType.STUN, (ObjAiBase)target, time);
            //var p1 = AddParticleTarget(owner, "Dazzle_beam.troy", target, 1);
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {
            var time = 1.1f + 0.1f * spell.Level;
            var ap = owner.Stats.AbilityPower.Total;
            var damage = 10 + spell.Level * 30 + ap * 0.2f;

            if (owner.GetDistanceTo(target) <= 550)
            {

                damage = 15 + spell.Level * 45 + ap * 0.3f;
                if (owner.GetDistanceTo(target) <= 425)
                {

                    damage = 20 + spell.Level * 60 + ap * 0.4f;
                }
            }

            target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            AddBuffHudVisual("Dazzle", time, 1, BuffType.COMBAT_DEHANCER, (ObjAiBase)target, time);
            ((ObjAiBase)target).AddBuffGameScript("Stun", "Stun", spell, time, true);
            var p102 = AddParticleTarget(owner, "Global_Stun.troy", target, 1.25f, "head");
            //var p103 = AddParticleTarget(owner, "Dazzle_cas.troy", target, 1);

            CreateTimer(time, () =>
            {
                RemoveParticle(p102);
                ((ObjAiBase)target).RemoveCrowdControl(_crowd);
            });
            projectile.SetToRemove();
        }
               
        public void OnUpdate(double diff)
        {
        }
    }
}
