using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public bool MoveRight;
    public float speed;
    int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update () 
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
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
  
        if (currentHealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        this.enabled = false;
    }
}
