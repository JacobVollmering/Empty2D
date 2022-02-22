using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Ability
{
    public override void Perform(CombatStats user, CombatStats target)
    {
        int health = Random.Range(1, 5) + user.INT / 2;
        target.HealDamage(health);
        user.bm.AddBattleMessage(target.charname+" heals for "+health+" health!");
    }
}
