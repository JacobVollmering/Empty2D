using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalOscillation : MonoBehaviour
{
    public int minX = -3, maxX = 3;
    public bool walkRight = true;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxX)
            walkRight = false;
        if (transform.position.x < minX)
            walkRight = true;
        transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime * (walkRight ? 1 : -1);
    }
}
