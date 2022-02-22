using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public string abilityname;
    public int cost;
    public bool targetself = false;
    public bool TryPerform(CombatStats user, CombatStats target)
    {
        if(user.mana >= cost)
        {
            user.mana -= cost;
            Perform(user, target);
            return true;
        }
        user.bm.AddBattleMessage("Not Enough Mana!");
        return false;
    }

    public virtual void Perform(CombatStats user, CombatStats target)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
