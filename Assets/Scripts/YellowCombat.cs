using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCombat : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<PlayerStats>().DoDamage(1);
            Debug.Log("Yeowch!");
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
