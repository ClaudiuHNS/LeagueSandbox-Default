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
    public class Shatter : IGameScript
    {
        private ISpell _spell;
        public void OnActivate(IChampion owner)
        {
            //if (owner.Spells[1].SpellData.Cooldown[1] <= 0.0f)
            //{
            //    foreach (var value in GetChampionsInRange(owner, 375, true))
            //    {
            //        if (value.Team == owner.Team)
            //        {
            //            var p1 = AddParticleTarget(owner, "ShatterReady_buf.troy", value, 1);
            //            value.AddBuffGameScript("WArmor", "WArmor", _spell, -1, true);
            //        }
            //    }
            //}          
        }
       
        public void OnDeactivate(IChampion owner)
        {
        }

        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            var hasbuff = owner.HasBuffGameScriptActive("TaricPassive", "TaricPassive");
            if (hasbuff == false)
            {
                owner.AddBuffGameScript("TaricPassive", "TaricPassive", spell, 8.0f, true);
            }
            if (hasbuff == true)
            {
                return;
            }
            //owner.Stats.AbilityPower.FlatBonus += 1.00f;
        }

        public void OnFinishCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            var armor = owner.Stats.Armor.Total;
            var damage = spell.Level * 40 + armor * 0.2f;
            var reduce = spell.Level * 5 + armor * 0.05f;
            var p1 = AddParticleTarget(owner, "Shatter_nova.troy", owner, 1);
            
            foreach (var enemys in GetUnitsInRange(owner, 375, true).Where(x => x.Team == CustomConvert.GetEnemyTeam(owner.Team)))
            {
                
                if (!(enemys is IBaseTurret) || !(enemys is ILaneTurret))
                {
                    enemys.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
                    enemys.Stats.Armor.FlatBonus -= reduce;
                    AddBuffHudVisual("Shatter", 4f, 1, BuffType.COMBAT_DEHANCER, (ObjAiBase)enemys, 4f);
                    var p2 = AddParticleTarget(owner, "Shatter_tar.troy", enemys, 1);
                    CreateTimer(4f, () =>
                     {
                         RemoveParticle(p2);
                         enemys.Stats.Armor.FlatBonus += reduce;
                     });
                    
                }
            }
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {
         
        }

        public void OnUpdate(double diff)
        {
            
        }
    }
}