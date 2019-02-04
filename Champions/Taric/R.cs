using System.Linq;
using GameServerCore;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using GameServerCore.Enums;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.Scripting.CSharp;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;

namespace Spells
{
    public class TaricHammerSmash : IGameScript
    {
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
            var p1 = AddParticleTarget(owner, "TaricHammerSmash_nova.troy", owner); 
            var p2 = AddParticleTarget(owner, "TaricHammerSmash_shatter.troy", owner);
            
            var hasbuff = owner.HasBuffGameScriptActive("Radiance", "Radiance");
            
            var ap = owner.Stats.AbilityPower.Total * 0.5f;            
            var damage = 50 + spell.Level * 100 + ap;
            foreach (var enemyTarget in GetUnitsInRange(owner, 375, true)
                .Where(x => x.Team == CustomConvert.GetEnemyTeam(owner.Team)))
            {
                if (!(enemyTarget is IBaseTurret) || !(enemyTarget is ILaneTurret))
                {
                    enemyTarget.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL,
                      false);
                }
                if (target.Team == owner.Team && target != owner && hasbuff == false)
                {
                    ((ObjAiBase)target).AddBuffGameScript("Radiance_ally", "Radiance_ally", spell, 10.0f, true);
                                     
                }
            }
            foreach (var allyTarget in GetUnitsInRange(owner, 1100, true)
                .Where(x => x.Team != CustomConvert.GetEnemyTeam(owner.Team)))
            {
                if (allyTarget.Team == owner.Team && allyTarget != owner && hasbuff == false && !(allyTarget is IObjBuilding))
                {
                    ((ObjAiBase)allyTarget).AddBuffGameScript("Radiance_ally", "Radiance_ally", spell, 10.0f, true);

                }
            }


            if (target == owner && hasbuff == false)
            {
                var p3 = AddParticleTarget(owner, "taricgemstorm.troy", owner);
                ((ObjAiBase)owner).AddBuffGameScript("Radiance", "Radiance", spell, 10.0f, true);
                CreateTimer(10.0f, () =>
                {
                    RemoveParticle(p3);
                });
            }
            
                if (hasbuff == true)
            {
                return;
            }
            CreateTimer(10.0f, () =>
            {
                RemoveParticle(p1);
                RemoveParticle(p2);
                
            }
            );
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {

        }

        public void OnUpdate(double diff)
        {
        }
    }
}
