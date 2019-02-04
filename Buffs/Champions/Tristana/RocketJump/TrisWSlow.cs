using GameServerCore.Enums;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace TrisWSlow
{
    internal class TrisWSlow : IBuffGameScript
    {
        private StatsModifier _statMod;
        private IBuff _visualBuff;
        private IChampion owner;

        public void OnActivate(IObjAiBase unit, ISpell ownerSpell)
        {
            var slowtime = 0.5f + owner.Spells[1].Level * 0.5f;
            _statMod = new StatsModifier();            
            _statMod.MoveSpeed.PercentBonus = _statMod.MoveSpeed.PercentBonus - (60f / 100f);
            unit.AddStatModifier(_statMod);
            _visualBuff = AddBuffHudVisual("Slow", slowtime, 1, BuffType.COMBAT_DEHANCER, unit);
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
