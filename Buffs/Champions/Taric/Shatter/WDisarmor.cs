using GameServerCore.Enums;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace WDisarmor
{
    internal class WDisarmor : IBuffGameScript
    {
        private StatsModifier _statMod;
        private IBuff _visualBuff;
        private IObjAiBase unit;
        private ISpell ownerSpell;
        private IChampion owner;
        public void OnActivate(IObjAiBase unit,ISpell spell)
        {
            _statMod = new StatsModifier();
            _statMod.Armor.FlatBonus = _statMod.Armor.FlatBonus - ((spell.Level * 5) + (owner.Stats.Armor.Total * 0.05f));
            unit.AddStatModifier(_statMod);
            _visualBuff = AddBuffHudVisual("Shatter", 4, 1, BuffType.COMBAT_DEHANCER, unit);
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
