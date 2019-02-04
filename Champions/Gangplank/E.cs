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
    public class RaiseMorale : IGameScript
    {
        private ISpell spell;
        private IAttackableUnit target;
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
            var p1 = AddParticleTarget(owner, "pirate_raiseMorale_cas.troy", owner); 
            //spell.AddProjectileTarget("pirate_raiseMorale_mis.troy", target);
            var p2 = AddParticleTarget(owner, "pirate_raiseMorale_tar.troy", owner);
            var p3 = AddParticleTarget(owner, "pirate_raiseMorale_tar.troy", target);
            CreateTimer(7.0f, () =>
            {
                RemoveParticle(p1);
                RemoveParticle(p3);
            }
            );            
            foreach (var allyTarget in GetChampionsInRange(owner, 1300, true)
                .Where(x => x.Team != CustomConvert.GetEnemyTeam(owner.Team)))
            {
                if (allyTarget == owner)
                {
                    ((ObjAiBase)owner).AddBuffGameScript("GangEActSelf", "GangEActSelf", spell, 7.0f,true);
                }
                if (allyTarget != owner && allyTarget != null)
                {
                    ((ObjAiBase)allyTarget).AddBuffGameScript("GangEAct", "GangEAct", spell, 7.0f,true);
                }
            }
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {

        }

        public void GangPassive(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            if (spell.CurrentCooldown == 0)
            {
                owner.AddBuffGameScript("GangEPas", "GangEPas", spell);
            }
            else
            {
                return;
            }
        }

        public void OnUpdate(double diff)
        {
        }
    }
}
