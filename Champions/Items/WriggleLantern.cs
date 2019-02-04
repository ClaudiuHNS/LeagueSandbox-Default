using GameServerCore.Domain.GameObjects;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.Scripting.CSharp;
using System.Numerics;
using GameServerCore.Enums;

namespace Spells
{
    public class wrigglelantern : IGameScript
    {
        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            var castrange = spell.SpellData.CastRange[0];
            var ownerPos = new Vector2(spell.X, spell.Y);
            var spellPos = new Vector2(spell.X, spell.Y);
            if (owner.WithinRange(ownerPos, spellPos, castrange))
            {
                var ward = AddMinion(owner, "GhostWard", "GhostWard", spell.X, spell.Y);
                var wardBuff = AddBuffHudVisual("WriggleLanternWard", 180.0f, 1, BuffType.COMBAT_ENCHANCER, ward, owner, 1100);
                ward.PauseAi(true);
                CreateTimer(180.0f, () =>
                {
                    if (!ward.IsDead)
                    {
                        RemoveBuffHudVisual(wardBuff);
                        ward.Die(ward);
                    }
                });
            }
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

        public void OnActivate(IChampion owner)
        {
        }

        public void OnDeactivate(IChampion owner)
        {
        }
    }
}
