using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	public int state; 
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	private Rigidbody2D rb2d;
	
	
	public void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			state = 1;
			animator.SetBool("IsJumping", true);
			FindObjectOfType<Audiio>().Play("Jump");
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
			
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
	}
	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching) 
	{
		
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		
		jump = false;
		
	}

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.CompareTag("Coins")) 
		{
			Destroy(other.gameObject);
		}
	}
	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir){
 
                float timer = 0;
 
                while( knockDur > timer){
 
                        timer+=Time.deltaTime;
 
                        rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
 
                }
 
                yield return 0;
 
        }
	
	
}