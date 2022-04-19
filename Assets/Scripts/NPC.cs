using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public string message = "Ooof, why you bump into me?";
    public void DisplayMessage()
    {
        Debug.Log(message);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerControl other;
        if (collision.gameObject
            .TryGetComponent<PlayerControl>(out other))
        {
            DisplayMessage();
        }
        SceneManager.LoadScene("BattleScene");
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
