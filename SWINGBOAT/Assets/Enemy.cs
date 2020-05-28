using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;	
    public int coinValue = 10;
    public float speed;

    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update () 
    {
 
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
        ScoreManager.instance.ChangeScore(coinValue);
        this.enabled = false;
        //GetComponent<MovingMinotaur>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Destroy(gameObject, 1);
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			TakeDamage(30);
			StartCoroutine(player.Knockback(0.002f, 100, player.transform.position));

		}
	}
}
