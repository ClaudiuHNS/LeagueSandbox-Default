using System;
using System.Numerics;
using System.Linq;
using GameServerCore;
using GameServerCore.Enums;
using LeagueSandbox.GameServer.API;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.Scripting.CSharp;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;

namespace Spells
{
    public class RocketJump : IGameScript
    {
        IChampion _championRef;
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
            var slowtime = 0.5f + spell.Level * 0.5f;
            var damage = 25f + spell.Level * 45f + owner.Stats.AbilityPower.Total * 0.8f;
            var trueCoords = this.getTrueCoords(owner, spell, target);
            IMinion m = AddMinion(owner, "TestCube", "TestCube", trueCoords.X, trueCoords.Y);
            var distanTime = owner.GetDistanceTo(m) * 0.0007f;
            //if (trueCoords.X - owner.X <= 900 && trueCoords.Y - owner.Y <= 900)
            //{
            //    distanTime = 0.65f;
            //    if (trueCoords.X - owner.X <= 600 && trueCoords.Y - owner.Y <= 600)
            //    {
            //        distanTime = 0.35f;
            //        if (trueCoords.X - owner.X <= 300 && trueCoords.Y - owner.Y <= 300)
            //        {
            //            distanTime = 0.135f;
            //        };
            //    };
            //};
                       
            DashToLocation(owner, trueCoords.X, trueCoords.Y, 1350, true, "Spell2", 80, 0, 0, 0);
            owner.Stats.MoveSpeed.FlatBonus += 1350;
            CreateTimer(distanTime, () => { owner.Stats.MoveSpeed.FlatBonus -= 1350; });
            
            
            
            var p1 = AddParticle(owner, "RocketJump_cas.troy", owner.X, owner.Y, 1); 
            var p2 = AddParticle(owner, "RocketJump_cas_sparks.troy", owner.X, owner.Y, 1);
            CancelDash(owner);
            
            CreateTimer(distanTime, () =>
            {
                var p3 = AddParticle(owner, "RocketJump_land.troy", trueCoords.X, trueCoords.Y, 1);
                foreach (var enemyTarget in GetUnitsInRange(m, 350, true)
                .Where(x => x.Team == CustomConvert.GetEnemyTeam(owner.Team)))
                {
                    if (enemyTarget is IChampion || enemyTarget is IMinion || enemyTarget is IMonster && enemyTarget.Team != owner.Team)
                    {
                        enemyTarget.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
                    }
                }
            });
            //if (target.Team != owner.Team && target != owner && target != null)
            //    {
            //        var p4 = AddParticleTarget(owner, "Global_Slow.troy", target, 1);
            //        ((ObjAiBase)target).AddBuffGameScript("TrisWSlow", "TrisWSlow", spell, slowtime, true);
            //        CreateTimer(slowtime, () =>
            //        {
            //            RemoveParticle(p4);
            //        });
            //    }
            //    else
            //    {
            //        return;
            //    }
            m.Die(m);

            //DashToUnit(owner, target, 2200, false, "Attack1");
        }

        private Vector2 getTrueCoords(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            var current = owner.GetPosition();
            var to = new Vector2(spell.X, spell.Y) - current;
            var trueCoords = new Vector2();

            if (to.Length() > 900)
            {
                to = Vector2.Normalize(to);
                var range = to * 900;
                trueCoords = new Vector2(current.X, current.Y) + range;
            }
            else
                trueCoords = new Vector2(spell.X, spell.Y);
            return trueCoords;
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {            
        }

        public void OnUpdate(double diff)
        {
        }
    }
}
