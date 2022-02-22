using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Ability
{
    public override void Perform(CombatStats user, CombatStats target)
    {
        int damage = Random.Range(1, user.INT + 5);
        target.DoDamage(Random.Range(1, user.INT+5));
        user.bm.AddBattleMessage(user.charname + " casts " + abilityname + " on " + target.charname + " for " + damage + " damage!");
    }
}
