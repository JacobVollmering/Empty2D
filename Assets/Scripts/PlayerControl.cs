using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        oldpos = transform.position;   
    }

    Vector3 oldpos;
    float encdist = 0;
    float lastroll = -1;
    public float maxencdist = 80;
    public float minencdist = 5;
    void OnTriggerStay2D(Collider2D collision)
    {
        EncounterTable et;
        if(collision.gameObject.TryGetComponent(out et))
        {
            encdist += (transform.position - oldpos).magnitude;
            if (encdist - lastroll > 1)
            {
                lastroll = encdist;
                if (Random.value < (encdist - minencdist) / (maxencdist - minencdist))
                {
                    FindObjectOfType<GameManager>().BeginBattle(et.GetRandomEncounter());
                    encdist = 0;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = Vector3.ClampMagnitude(
               new Vector3(Input.GetAxis("Horizontal"),
               Input.GetAxis("Vertical")),
               1) * speed;
        /*  transform.position +=
               Vector3.ClampMagnitude(
                 new Vector3(Input.GetAxis("Horizontal"),
                 Input.GetAxis("Vertical")),
                 1)*Time.deltaTime*speed;*/
    }



    void LateUpdate()
    {
        oldpos = transform.position;
    }
}
