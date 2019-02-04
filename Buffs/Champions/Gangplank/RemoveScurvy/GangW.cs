using LeagueSandbox.GameServer.API;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using GameServerCore.Enums;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace GangW
{
    internal class GangW : IBuffGameScript
    {
        private UnitCrowdControl _crowd01 = new UnitCrowdControl(CrowdControlType.AIRBORNE);
        private UnitCrowdControl _crowd02 = new UnitCrowdControl(CrowdControlType.BLIND);
        private UnitCrowdControl _crowd03 = new UnitCrowdControl(CrowdControlType.DISARM);
        private UnitCrowdControl _crowd04 = new UnitCrowdControl(CrowdControlType.GROUND);
        private UnitCrowdControl _crowd05 = new UnitCrowdControl(CrowdControlType.NEARSIGHT);
        private UnitCrowdControl _crowd06 = new UnitCrowdControl(CrowdControlType.ROOT);
        private UnitCrowdControl _crowd07 = new UnitCrowdControl(CrowdControlType.SILENCE);
        private UnitCrowdControl _crowd08 = new UnitCrowdControl(CrowdControlType.STUN);
        private UnitCrowdControl _crowd09 = new UnitCrowdControl(CrowdControlType.ROOT);
        private UnitCrowdControl _crowd10 = new UnitCrowdControl(CrowdControlType.SNARE);

        public void OnActivate(IObjAiBase unit, ISpell ownerSpell)
        {
            unit.RemoveCrowdControl(_crowd01);
            unit.RemoveCrowdControl(_crowd02);
            unit.RemoveCrowdControl(_crowd03);
            unit.RemoveCrowdControl(_crowd04);
            unit.RemoveCrowdControl(_crowd05);
            unit.RemoveCrowdControl(_crowd06);
            unit.RemoveCrowdControl(_crowd07);
            unit.RemoveCrowdControl(_crowd08);
            unit.RemoveCrowdControl(_crowd09);
            unit.RemoveCrowdControl(_crowd10);
        }

        public void OnDeactivate(IObjAiBase unit)
        {
            
        }

        public void OnUpdate(double diff)
        {

        }
    }
}

