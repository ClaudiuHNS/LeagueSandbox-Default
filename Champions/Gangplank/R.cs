using System;
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
    public class CannonBarrage : IGameScript
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
            var b = CustomConvert.GetEnemyTeam(owner.Team);
            var a = GetChampionsInRange(owner, 20000, true || false);
            a.Remove(owner);
            var p1 = AddParticleTarget(owner, "pirate_cannonBarrage_cas.troy", owner);
            //var p4 = AddParticleTarget(owner, " pirate_cannonBarrage_tar.troy", owner);
            //spell.AddProjectileTarget("pirate_raiseMorale_mis.troy", target);
            var p2 = AddParticle(owner, "pirate_cannonBarrage_glow.troy", spell.X,spell.Y,1);
            var p3 = AddParticle(owner, "pirate_cannonBarrage_point.troy", spell.X,spell.Y,1);
            var p4 = AddParticle(owner, "pirate_cannonBarrage_aoe_indicator_green.troy", spell.X, spell.Y, 1);
            //foreach (var value in a.Where(x => x.Team == CustomConvert.GetEnemyTeam(owner.Team)))
            //{
            //    if (value != owner)
            //    {
            //        var p4 = AddParticle(owner, "pirate_cannonBarrage_aoe_indicator_red.troy", spell.X, spell.Y, 1);
            //        p4.SetVisibleByTeam(owner.Team,false);
            //        CreateTimer(7.0f, () =>
            //        {
            //            RemoveParticle(p4);
            //        });
            //    }

            //    var p5 = AddParticle(owner, "pirate_cannonBarrage_aoe_indicator_green.troy", spell.X, spell.Y, 1);  
            //    
            //    p5.SetVisibleByTeam(value.Team,false);
            //    CreateTimer(7.0f, () => 
            //    {
            //        
            //        RemoveParticle(p5);
            //    });
            //}
            CreateTimer(0.8f, () => { RemoveParticle(p1); });
            for (var i = 0.0f; i <= 7.2f; i += 0.8f)
            {
                
                CreateTimer(i, () =>
                {
                    CannonBall(owner, spell, target);
                    
                }); 
            }
            CreateTimer(7.0f, () =>
            {
                
                RemoveParticle(p2);
                RemoveParticle(p3);
            }
            );            
            
            
            
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {

        }

        public void CannonBall(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            //var reduce = (25f / 100f);
            var ap = owner.Stats.AbilityPower.Total * 0.2f;
            var damage = 30f + spell.Level * 45 + ap;            
            //for (var i = 0.0f; i <= 2.0f; i += 0.5f)
            //{
                    ShotCannon(owner, spell);
            IMinion m = AddMinion(owner, "TestCube", "TestCube", spell.X, spell.Y);
                
            foreach (var enemys in GetUnitsInRange(m, 600, true)
            .Where(x => x.Team == CustomConvert.GetEnemyTeam(owner.Team)))
            {
                    if (!(enemys is IBaseTurret) || !(enemys is ILaneTurret))
                    {
                        enemys.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
                        //enemys.Stats.MoveSpeed.PercentBonus -= reduce;
                        //AddBuffHudVisual("CannonBarrageSlow", 0.1f, 1, BuffType.COMBAT_DEHANCER, (ObjAiBase)enemys, 0.1f);                        
                        //CreateTimer(0.1f, () =>
                        //{
                        //    enemys.Stats.Armor.PercentBonus += reduce;
                        //});

                    }
                }
                
            m.Die(m);
            //}
        }

        public void ShotCannon(IChampion owner, ISpell spell)
        {
            var random1 = new Random().Next(-300, 0);
            var random2 = new Random().Next(-180, 0);
            var random3 = new Random().Next(0, 245);
            var random4 = new Random().Next(0, 275);            
            AddParticle(owner, "pirate_cannonBarrage_tar.troy", spell.X + random1, spell.Y + random3, 1);
            AddParticle(owner, "pirate_cannonBarrage_tar.troy", spell.X + random2, spell.Y + random4, 1);
            AddParticle(owner, "pirate_cannonBarrage_tar.troy", spell.X + random1, spell.Y + random4, 1);
            AddParticle(owner, "pirate_cannonBarrage_tar.troy", spell.X + random2, spell.Y + random3, 1);
        }

        public void OnUpdate(double diff)
        {
        }
    }
}
