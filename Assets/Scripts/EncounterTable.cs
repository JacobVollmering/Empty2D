using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterTable : MonoBehaviour
{
    public CombatStats[] enemies;
    public int[] frequencies;
    int total = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < frequencies.Length; i++)
            total += frequencies[i];
    }

    public CombatStats GetRandomEncounter()
    {
        int k = Random.Range(0, total);
        int m = 0;
        for (int i = 0; i < frequencies.Length; i++)
        {
            m += frequencies[i];
            if (k < m)
                return enemies[i];
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
