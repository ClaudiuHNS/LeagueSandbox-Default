using GameServerCore.Enums;
using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace Spells
{
    public class SummonerTeleport : IGameScript
    {

        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            owner.AddBuffGameScript("SummonerTeleport", "SummonerTeleport", spell, 4.0f, true);
            ((IObjAiBase)target).AddBuffGameScript("SummonerTeleport", "SummonerTeleport", spell, 4.0f, true);
            var p1 = AddParticleTarget(owner, "Summoner_Teleport_purple.troy", owner);
            //var p102 = AddParticleTarget(owner, "teleport.troy", owner);
            var p3 = AddParticleTarget(owner, "Teleport_target.troy", target);
            //var p104 = AddParticleTarget(owner, "Scroll_Teleport.troy", target);

            owner.StopChampionMovement();

            CreateTimer(4.0f, () =>
            {
                RemoveParticle(p1);
                RemoveParticle(p3);
                var p201 = AddParticleTarget(owner, "Summoner_TeleportArrive_purple.troy", owner);
                var p202 = AddParticleTarget(owner, "teleportarrive.troy", owner);
                var p203 = AddParticleTarget(owner, "scroll_teleportarrive.troy", owner);
                owner.TeleportTo(target.X, target.Y);
            });
        }

        public void OnFinishCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            //if (owner is moving)
            //{
            //    spell.Deactivate();
            //    return;
            //}
            //else
            //{

            //}
            //if (owner.IsMovementUpdated() == true)
            //{ return; }
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {
        }

        public void OnUpdate(double diff)
        {
        }

        public void OnActivate(IChampion owner)
        {
        }

        public void OnDeactivate(IChampion owner)
        {
        }
    }
}

