using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaDamage : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Damaging")
        {
            FindObjectOfType<PlayerStats>().DoDamage(1);
            Debug.Log("Yeowch!");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Battle Scene");
        }
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
