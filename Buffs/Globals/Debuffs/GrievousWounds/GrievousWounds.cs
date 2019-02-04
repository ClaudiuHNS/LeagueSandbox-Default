using GameServerCore.Enums;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;
using LeagueSandbox.GameServer.GameObjects;

namespace GrievousWounds
{
    internal class GrievousWounds : IBuffGameScript
    {
        private IObjAiBase _owningUnit;
        private ISpell _owningSpell;
        private IParticle _grievousParticle;
        private IBuff _grievousBuff;

        public void OnActivate(IObjAiBase unit, ISpell ownerSpell)
        {
            _owningUnit = unit;
            _owningSpell = ownerSpell;
            if (unit is IChampion) // Add a visual buff if the effected unit is a Champion
            {
                _grievousParticle = AddParticleTarget((IChampion)unit, "global_grievousWound_tar.troy", unit);
            }
            _grievousBuff = AddBuffHudVisual("GrievousWound", -1, 1, BuffType.COMBAT_DEHANCER, unit, -1);
        }

        public void OnDeactivate(IObjAiBase unit)
        {
            if (_grievousParticle != null)
            {
                RemoveParticle((Particle)_grievousParticle);
            }
            RemoveBuffHudVisual(_grievousBuff);
        }

        public void OnUpdate(double diff)
        {

        }
    }
}
