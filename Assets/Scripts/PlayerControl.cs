using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour {
	
	private Rigidbody2D rb;

	public float moveSpeed = 2;
	public float jumpHeight = 4;
    private int doubleJumpsMade;

	public int health = 3;
	private float timeSinceLastDMG;

	[HideInInspector]
	public float checkpointX;
	private float checkpointY;

	public Transform groundCheck;
	public float groundCheckBox;
	public LayerMask ground;
	[HideInInspector]
	public bool grounded;

	public DiscordController dc;
	private string healthStr;
    public string discordApplicationId = "378417960659714048";

    private int totalJumps;

    private int totalCoins;
	private float timeSinceLastCoinPickup;

	private bool hardMode;

	[HideInInspector]
	public bool res;																	//allow other scripts to check for respawn
	[HideInInspector]
	public bool dead;																	//allow other scripts to check for death

    public audioControl audioCtrlScript;

    void Start () {
        audioCtrlScript = GetComponent<audioControl>();

		PlayerPrefs.SetInt ("health", 3);

	    if (PlayerPrefs.HasKey("coins"))
	    {
		    totalCoins = PlayerPrefs.GetInt("coins");
	    }
	    PlayerPrefs.SetInt ("coins", totalCoins);
		
		rb = GetComponent<Rigidbody2D> ();

		SetCheckpoint (false);

		res = false;
		dead = false;

	    dc = GetComponent<DiscordController>();
	    dc.updateDetails(String.Format("In Level {0} | ♥ {1}", SceneManager.GetActiveScene().name.Substring(3), health));
	    dc.updateStartTime();
    }
		
    void Update () {

		RunGame ();

		if (transform.position.y < -12)														//testing damage script
			TakeDamage ();

	    if (PlayerPrefs.GetInt("reversedOn") == 1)
		    hardMode = true;
	    else
	    {
		    hardMode = false;
	    }

	    if (health >= 1)
	    {
		    healthStr = health.ToString();
	    }
	    else
	    {
		    healthStr = 0.ToString();
	    }

    }

	public void RunGame ()
	{
		float moveH;

		switch (hardMode)
		{
				case true:
					moveH = -Input.GetAxis ("Horizontal");
					break;
				default:
					moveH = Input.GetAxis ("Horizontal");	
					break;
		}
		
		rb.velocity = new Vector2 (moveH * moveSpeed, rb.velocity.y);                       //x movement

		if (grounded)
			doubleJumpsMade = 0;
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckBox, ground);	//check for ground
		if (Input.GetKeyDown(KeyCode.Space)){												//y movement (jumping)
			if (!grounded && doubleJumpsMade != 1){
				rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
				doubleJumpsMade++;
                audioCtrlScript.playSound("m_Jump");
                totalJumps++;

            }

			else if(grounded){
				rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
                audioCtrlScript.playSound("m_Jump");
                totalJumps++;

            }

		}
		timeSinceLastCoinPickup += Time.deltaTime;
		timeSinceLastDMG += Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Enemy") {
			TakeDamage ();
		} else if (other.gameObject.tag == "Hazard") {
			TakeDamage ();
		}

//		Debug.Log (other.gameObject.name + "zucc2");
	}

	public void TakeDamage(){
		if (health >= 2 && timeSinceLastDMG >= 1f)
		{
			Respawn ();																		//need to change to knockback later
			health--;
			PlayerPrefs.SetInt ("health", health);
			Debug.Log ("damage");
			Debug.Log(timeSinceLastDMG);
		} else
		{
			health--;
			Death ();
		}
		timeSinceLastDMG = 0;
		dc.updateDetails(String.Format("In Level {0} | ♥ {1}", SceneManager.GetActiveScene().name.Substring(3), health));
	}

	public void SetCheckpoint(bool playSound){
		checkpointX = transform.position.x;
		checkpointY = transform.position.y;

        if(playSound)
            audioCtrlScript.playSound("Checkpoint");
	}

	public void Respawn(){
		transform.position = new Vector2 (checkpointX, checkpointY);
		res = true;
	}

	void OnTriggerEnter2D(Collider2D col){													//jumping on enemies
		if (col.gameObject.tag == "Enemy" && col.gameObject.transform.position.y < gameObject.transform.position.y) {
			Destroy (col.gameObject);
			rb.velocity = new Vector2 (rb.velocity.x, jumpHeight/2);
            audioCtrlScript.playSound("Hitting_Enemy");
		} 
		if (col.gameObject.tag == "Coin" && timeSinceLastCoinPickup >= .1f) {
			Destroy (col.gameObject);
			totalCoins++;
			PlayerPrefs.SetInt ("coins", totalCoins);
			audioCtrlScript.playSound ("coin_pick_up");
			timeSinceLastCoinPickup = 0f;
		} else if (col.gameObject.tag == "Hazard") {
			TakeDamage ();
		}
//		Debug.Log (col + "zucc");

	}
	
	public void Death(){
		dead = true;
	}
}