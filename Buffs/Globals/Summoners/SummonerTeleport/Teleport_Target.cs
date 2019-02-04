using GameServerCore.Enums;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace Teleport_Target
{
    public class Teleport_Target : IBuffGameScript
    {
        private IBuff _visualBuff;

        public void OnActivate(IObjAiBase unit, ISpell ownerSpell)
        {
            _visualBuff = AddBuffHudVisual("Teleport_Target", 4.0f, 1, BuffType.COUNTER, unit);
        }

        public void OnDeactivate(IObjAiBase unit)
        {
            RemoveBuffHudVisual(_visualBuff);
        }

        public void OnUpdate(double diff)
        {

        }
    }
}