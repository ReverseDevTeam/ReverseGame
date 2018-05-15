using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
	private bool grounded;

    public string discordApplicationId = "378417960659714048";

    private int totalJumps;

    private int totalCoins;
	private float timeSinceLastCoinPickup;

	[HideInInspector]
	public bool res;																	//allow other scripts to check for respawn
	[HideInInspector]
	public bool dead;																	//allow other scripts to check for death

    public audioControl audioCtrlScript;

    public DiscordRpc.RichPresence presence;
    DiscordRpc.EventHandlers handlers;

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

        startDiscord();


		res = false;
		dead = false;
	}
		
    void Update () {

		RunGame ();

		if (transform.position.y < -12)														//testing damage script
			TakeDamage ();
		
	}

	public void RunGame (){

		float moveH = Input.GetAxis ("Horizontal");	
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

                presence.details = string.Format("Player Jumped {0} times", totalJumps);

                DiscordRpc.UpdatePresence(ref presence);
            }

			else if(grounded){
				rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
                audioCtrlScript.playSound("m_Jump");
                totalJumps++;

                presence.details = string.Format("Player Jumped {0} times", totalJumps);

                DiscordRpc.UpdatePresence(ref presence);
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
		} else {
			Death ();
		}
		timeSinceLastDMG = 0;
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
		if (col.gameObject.tag == "Enemy") {
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
		
    void startDiscord(){
        handlers = new DiscordRpc.EventHandlers();
        DiscordRpc.Initialize(discordApplicationId, ref handlers, true, "");
    }

    private void OnApplicationQuit(){
        DiscordRpc.Shutdown();
    }
	public void Death(){
		dead = true;
	}
}