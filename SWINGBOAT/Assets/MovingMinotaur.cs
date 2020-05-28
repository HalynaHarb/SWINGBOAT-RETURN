using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMinotaur : MonoBehaviour
{
    public bool MoveRight;
    public float speed;
    void Update()
    {
        if(MoveRight) 
        {
            transform.Translate(2*Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (3,3);

        }
        else {
            transform.Translate(-2*Time.deltaTime*speed, 0,0);
            transform.localScale = new Vector2 (-3,3);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Turn"))
        {
            if(MoveRight){
                MoveRight = false;
            }
            else 
            {
                MoveRight = true;
            }
        }
    }
}
