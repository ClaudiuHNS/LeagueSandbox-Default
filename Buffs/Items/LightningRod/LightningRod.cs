//Placeholder code for later:
//if (Type == TurretType.INHIBITOR_TURRET)
//{
//    for (var i = 0.0f; i < 1.25f; i += 0.25f)
//    {
//        CreateTimer(i, () =>
//        {
//            var p1 = AddParticleTarget(this, "SRU_Inhibitor_chaos_Tower_Beam_Lvl1.troy", target, 1, "root", "C_BUFFBONE_GLB_CHEST_LOC");
//            var p2 = AddParticleTarget(this, "SRU_Inhibitor_chaos_Tower_Beam_Lvl2.troy", target, 1, "root", "C_BUFFBONE_GLB_CHEST_LOC");
//            var p3 = AddParticleTarget(this, "SRU_Inhibitor_chaos_Tower_Beam_Lvl3.troy", target, 1, "root", "C_BUFFBONE_GLB_CHEST_LOC");
//            var p4 = AddParticleTarget(this, "SRU_Inhibitor_chaos_Tower_Beam_Lvl4.troy", target, 1, "root", "C_BUFFBONE_GLB_CHEST_LOC");
//            var p5 = AddParticleTarget(this, "SRU_Inhibitor_chaos_Tower_Beam_Lvl5.troy", target, 1, "root", "C_BUFFBONE_GLB_CHEST_LOC");
//            target.TakeDamage(this, Stats.AttackDamage.BaseValue, DamageType.DAMAGE_TYPE_PHYSICAL, DamageSource.DAMAGE_SOURCE_ATTACK, false);
//        });
//    }
//    var p6 = AddParticleTarget(this, "SRU_Inhibitor_Tower_Chaos_Beam_Lvl1_Audio.troy", target, 1, "C_BUFFBONE_GLB_CHEST_LOC");
//    var p7 = AddParticleTarget(this, "SRU_Inhibitor_Tower_Chaos_Beam_Lvl2_Audio.troy", target, 1, "C_BUFFBONE_GLB_CHEST_LOC");
//    var p8 = AddParticleTarget(this, "SRU_Inhibitor_Tower_Chaos_Beam_Lvl3_Audio.troy", target, 1, "C_BUFFBONE_GLB_CHEST_LOC");
//    var p9 = AddParticleTarget(this, "SRU_Inhibitor_Tower_Chaos_Beam_Lvl4_Audio.troy", target, 1, "C_BUFFBONE_GLB_CHEST_LOC");
//    var p10 = AddParticleTarget(this, "SRU_Inhibitor_Tower_Chaos_Beam_Lvl5_Audio.troy", target, 1, "C_BUFFBONE_GLB_CHEST_LOC");
//    CreateTimer(1.25f, () =>
//    {
//        RemoveParticle(p6);
//        RemoveParticle(p7);
//        RemoveParticle(p8);
//        RemoveParticle(p9);
//        RemoveParticle(p10);
//    });
//}