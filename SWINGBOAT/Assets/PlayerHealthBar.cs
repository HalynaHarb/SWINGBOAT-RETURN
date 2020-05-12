using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    //health bar part
	public int maxHealth = 4;
	public int currentHealth;
	
	public HealthBar healthBar;

    void Start()
	{
		currentHealth = maxHealth;
		//healthBar.SetMaxHealth(maxHealth);
	}
	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(1); 
		}

	}
    
    void TakeDamage(int damage)
	{
		currentHealth -= damage;
		//healthBar.SetHealth(currentHealth);
	}
}
