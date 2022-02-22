using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CombatStats selectedEnemy;
    Dictionary<string, GameObject> managed;
    Dictionary<string, Vector3> managedPositions;
    Dictionary<string, Quaternion> managedRotations;
    Dictionary<string, Vector3> managedScales;
    public string sceneToLoad = "SampleScene";
    string returnScene;
    // Start is called before the first frame update
    void Start()
    {
        GameManager g = FindObjectOfType<GameManager>();
        if (g != null && g.gameObject != gameObject)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        managed = new Dictionary<string, GameObject>();
        managedPositions = new Dictionary<string, Vector3>();
        managedRotations = new Dictionary<string, Quaternion>();
        managedScales = new Dictionary<string, Vector3>();
        SceneManager.LoadScene(sceneToLoad);
    }

    public void BeginBattle(CombatStats enemy)
    {
        selectedEnemy = enemy;
        selectedEnemy.health = selectedEnemy.maxhealth;
        selectedEnemy.mana = selectedEnemy.maxmana;
        managedPositions.Clear();
        managedRotations.Clear();
        managedScales.Clear();
        foreach(KeyValuePair<string,GameObject> pair in managed)
        {
            managedPositions[pair.Key] = pair.Value.transform.position;
            managedRotations[pair.Key] = pair.Value.transform.rotation;
            managedScales[pair.Key] = pair.Value.transform.localScale;
        }
        managed.Clear();
        returnScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("BattleScene");
    }
    
    public void EndBattle(bool playerWins)
    {
        //Do any post-battle rewards here
        //Handle Game Over
        SceneManager.LoadScene(returnScene);
    }

    public void Manage(GameObject g)
    {
        managed.Add(g.name,g);
        if(managedPositions.ContainsKey(g.name))
            g.transform.position = managedPositions[g.name];
        if (managedRotations.ContainsKey(g.name))
            g.transform.rotation = managedRotations[g.name];
        if (managedScales.ContainsKey(g.name))
            g.transform.localScale = managedScales[g.name];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
