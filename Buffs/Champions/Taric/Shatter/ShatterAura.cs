using GameServerCore.Enums;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace ShatterAura
{
    internal class ShatterAura : IBuffGameScript
    {
        private StatsModifier _statMod;
        private IBuff _visualBuff;
        private IObjAiBase unit;
        private ISpell ownerSpell;
        public void OnActivate(IObjAiBase unit,ISpell spell)
        {
            _statMod = new StatsModifier();
            _statMod.Armor.FlatBonus = _statMod.Armor.FlatBonus + (5f + ownerSpell.Level * 5);
            unit.AddStatModifier(_statMod);
            _visualBuff = AddBuffHudVisual("ShatterAuraSelf", -2, 1, BuffType.COMBAT_ENCHANCER, unit);
            //Immunity to slowness not added
        }

        public void OnDeactivate(IObjAiBase unit)
        {
            RemoveBuffHudVisual(_visualBuff);
            unit.RemoveStatModifier(_statMod);
        }

        private void OnAutoAttack(AttackableUnit target, bool isCrit)
        {
        }

        public void OnUpdate(double diff)
        {
            
        }
    }
}
