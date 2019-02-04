using LeagueSandbox.GameServer.API;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using GameServerCore.Enums;
using LeagueSandbox.GameServer.Scripting.CSharp;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;

namespace TaricPassive
{
    internal class TaricPassive : IBuffGameScript
    {       
        private IBuff _healBuff;
        private IAttackableUnit target;

        public void OnActivate(IObjAiBase unit, ISpell ownerSpell)
        {
            var damage = unit.Stats.Armor.Total * 0.2f;
            var a = _healBuff = AddBuffHudVisual("Gemcraft", 8.0f, 1, BuffType.COMBAT_ENCHANCER, unit);
            if (unit.IsAttacking == true)
            {
                RemoveBuffHudVisual(a);
                target.TakeDamage(unit, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
            }
            else
            {
                CreateTimer(8.0f, () =>
                {
                    RemoveBuffHudVisual(a);
                });
                return;
            };
        }

        public void OnHit(IObjAiBase unit)
        {

        }
        public void OnDeactivate(IObjAiBase unit)
        {
            
        }

        public void OnUpdate(double diff)
        {

        }
    }
}