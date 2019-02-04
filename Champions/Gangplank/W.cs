using System;
using GameServerCore.Enums;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
using LeagueSandbox.GameServer.GameObjects.Missiles;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.Scripting.CSharp;
using LeagueSandbox.GameServer.API;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;

namespace Spells
{
    public class RemoveScurvy : IGameScript
    {
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
            owner.ClearAllCrowdControl();
            var ap = owner.Stats.AbilityPower.Total;
            var healing = 10f + spell.Level * 70f + ap;
            AddParticleTarget(owner, "pirate_removeScurvy_citrus.troy", owner, 1);
            AddParticleTarget(owner, "pirate_removeScurvy_heal.troy", owner, 1);
            if (owner.Stats.CurrentHealth + healing > owner.Stats.HealthPoints.Total)
            {
                owner.Stats.CurrentHealth = owner.Stats.HealthPoints.Total;
            }
            else
            {
                owner.Stats.CurrentHealth += healing;
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
