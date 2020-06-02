using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject Death;
	public int maxHealth = 100;
	public int currentHealth;
	public Animator animator;
	private Rigidbody2D rb2d;
	public HealthBar healthBar;
	public float respawnDelay;	
	private Player player;
	public GameObject coins;
	public GameObject coinado;
	public GameObject healthBAR;
	Vector3 pushDirection;
	Rigidbody2D rb;


	// Start is called before the first frame update
	void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
		/*if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}*/
		if(currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		if(currentHealth <= 0) {
			currentHealth = 0;
			GameObject.Find("Player").GetComponent<CharacterController2D>().enabled = false;
			GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
			Die();
		}

    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		FindObjectOfType<Audiio>().Play("PlayerHurt");
		animator.SetTrigger("Hurt");
        if (currentHealth <=0)
        {
            Die();
        }

		healthBar.SetHealth(currentHealth);
	}
	void Die() {
		Death.SetActive(true);
		coins.SetActive(false);
		coinado.SetActive(false);
		healthBAR.SetActive(false);
		Time.timeScale = 0.5f;
		FindObjectOfType<Audiio>().Play("PlayerDeath");
        animator.SetBool("IsDead", true);
		Respawn();
		
	}
	public void Respawn(){
		Time.timeScale = 1f;
		StartCoroutine("RespawnCoroutine");
	}
	public IEnumerator RespawnCoroutine(){
		yield return new WaitForSeconds(respawnDelay);
		Application.LoadLevel(Application.loadedLevel);
	}
	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {
		float timer = 0;
		while (knockDur > timer) {
			timer +=Time.deltaTime;
			//rb2d.AddForce(new Vector3(knockbackDir.x *-2000, knockbackDir.y*knockbackPwr, transform.position.z));
		}
		yield return 0;
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			TakeDamage(30);
			StartCoroutine(player.Knockback(0.002f, 100, player.transform.position));

		}
		if(other.gameObject.tag == "AI Flight")
		{
			TakeDamage(30);
			StartCoroutine(player.Knockback(0.002f, 100, player.transform.position));

		}
	}
}