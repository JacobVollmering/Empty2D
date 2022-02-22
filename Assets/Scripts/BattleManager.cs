using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    GameManager manager;
    PlayerStats player;
    CombatStats enemy;
    Dropdown abilityDropdown;
    Text battleText;
    StatSlider yourhealth, theirhealth, yourmana, theirmana;
    string currentBattleText;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        player = manager.GetComponent<PlayerStats>();
        player.RegisterBattleManager(this);
        enemy = manager.selectedEnemy;
        enemy.RegisterBattleManager(this);
        //Debug.Log(enemy);
        yourhealth = GameObject.Find("Your Health Slider").GetComponent<StatSlider>();
        yourhealth.stats = player;
        yourmana = GameObject.Find("Your Mana Slider").GetComponent<StatSlider>();
        yourmana.stats = player;
        theirhealth = GameObject.Find("Their Health Slider").GetComponent<StatSlider>();
        theirhealth.stats = enemy;
        theirmana = GameObject.Find("Their Mana Slider").GetComponent<StatSlider>();
        theirmana.stats = enemy;
        battleText = GameObject.Find("Battle Text").GetComponent<Text>();
        battleText.text += player.charname + " encounters a(n) " + enemy.charname + "!";
        abilityDropdown = FindObjectOfType<Dropdown>();
        List<string> abilitynames = new List<string>();
        for (int i = 0; i < player.abilities.Length; i++)
            abilitynames.Add(player.abilities[i].abilityname);
        abilityDropdown.AddOptions(abilitynames);
        GameObject.Find("Enemy Image").GetComponent<Image>().sprite = enemy.image;
    }
    public void AddBattleMessage(string text)
    {
        currentBattleText += text+"\n";
    }
    public void DoAction()
    {
        currentBattleText = "";
        bool targetself = player.abilities[abilityDropdown.value].targetself;
        player.abilities[abilityDropdown.value].TryPerform(player,targetself?player:enemy);
        if (player.health <= 0)
            manager.EndBattle(false);
        else if (enemy.health <= 0)
            manager.EndBattle(true);
        Ability enemymove = enemy.abilities[Random.Range(0, enemy.abilities.Length)];
        enemymove.TryPerform(enemy, enemymove.targetself?enemy:player);
        battleText.text = currentBattleText;
        if (player.health <= 0)
            manager.EndBattle(false);
        else if (enemy.health <= 0)
            manager.EndBattle(true);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemy);
    }
}
