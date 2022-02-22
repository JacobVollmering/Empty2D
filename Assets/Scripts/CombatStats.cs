using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStats : MonoBehaviour
{
    public int health = 100;
    public int mana = 100;
    public int maxhealth = 100;
    public int maxmana = 100;
    public int STR = 10;
    public int INT = 10;
    public string charname;
    public Ability[] abilities;
    public BattleManager bm;
    public Sprite image;
    // Start is called before the first frame update
    public void DoDamage(int amount)
    {
        health -= amount;
    }
    public void HealDamage(int amount)
    {
        health += amount;
    }
    public void RegisterBattleManager(BattleManager m)
    {
        bm = m;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
