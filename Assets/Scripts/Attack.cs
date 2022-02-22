using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
    public override void Perform(CombatStats user, CombatStats target)
    {
        int damage = Random.Range(1, 5) + user.STR / 2;
        target.DoDamage(damage);
        user.bm.AddBattleMessage(user.charname + " attacks " + target.charname + " for "+damage+" damage!");
    }
}
