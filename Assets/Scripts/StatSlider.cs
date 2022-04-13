using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSlider : MonoBehaviour
{
    public CombatStats stats;
    public string stat;
    // Start is called before the first frame update
    void Start()
    {

    }

    int getValue()
    {
        return (int)(stats.GetType().GetField(stat).GetValue(stats))*100
               / (int)(stats.GetType().GetField("max" + stat).GetValue(stats));
    }

    // Update is called once per frame
    void Update()
    {
        if (stats == null)
            stats = FindObjectOfType<PlayerStats>();
        GetComponent<UnityEngine.UI.Slider>().value = getValue();
    }
}
