using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTravel : MonoBehaviour
{
    

    [SerializeField] GameObject TP01;
    [SerializeField] GameObject TP02;
    [SerializeField] GameObject TP03;

    Vector2 TPLocation1;
    Vector2 TPLocation2;
    Vector2 TPLocation3;

    // Start is called before the first frame update
    void Start()
    {
        
        TPLocation1 = TP01.transform.position;
        TPLocation2 = TP02.transform.position;
        TPLocation3 = TP03.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TeleportPlayer(TPLocation1);
        }
        
    }

    void TeleportPlayer(Vector2 tPLocation)
    {
        gameObject.transform.position = tPLocation;
    }
}
