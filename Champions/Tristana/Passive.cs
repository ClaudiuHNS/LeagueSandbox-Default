using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.API;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
using GameServerCore.Domain;
using GameServerCore.Enums;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace Spells
{
    public class Draw_a_Bead : IGameScript
    {
        private ISpell spell;
        IChampion _championRef;
        public void OnActivate(IChampion owner)
        {
            _championRef = owner;
            //ApiEventManager.OnHitUnit.AddListener(this, owner, AttackRange);
            owner.Stats.Range.FlatBonus += owner.Stats.Level * 10;
        }

        public void AttackRange(IChampion owner)
        {
        }

        private void ReduceCooldown(IAttackableUnit unit, bool isCrit)
        {
        //No Cooldown reduction on the other skills yet
        }

        public void OnDeactivate(IChampion owner)
        {
        }

        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {           
            //No increased durations on kills and assists yet
        }

        public void OnFinishCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {
        }

        public void OnUpdate(double diff)
        {
        }
    }
}
