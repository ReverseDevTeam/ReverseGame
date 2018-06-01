using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class animationControllerNetwork : NetworkBehaviour {

	public Animator animator;
	public SpriteRenderer sr;

	[SyncVar(hook = "OnSetScale")]
	public Vector3 ls;
	
	private float scaleX;
	private float scaleY;

	private GameObject player;
	private PlayerControlNetwork ps;

	void Start () {
		animator = GetComponent<Animator>();

		
		
		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;

		player = this.gameObject;
		ps = player.GetComponent<PlayerControlNetwork> ();

		sr = GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
		if (!isLocalPlayer)
			return;
		
		CmdSetScale(new Vector3 (scaleX, scaleY, 1));
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			scaleX = Mathf.Abs (scaleX);
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			scaleX = -Mathf.Abs (scaleX);
		}
		
		animator.SetBool ("Right", Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D));
		animator.SetBool ("Left", Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A));

		if (!ps.grounded) {
			animator.SetBool ("Jump", true);
		} else {
			animator.SetBool ("Jump", false);
		}
		sr.color = Color.blue;
	}
	
	public override void OnStartLocalPlayer()
	{
		sr.color = Color.blue;
	}
	
	[Command]
	public void CmdSetScale(Vector3 vec)
	{
		this.ls = vec; // This is just to trigger the call to the OnSetScale while encapsulating.
	}
 
	private void OnSetScale(Vector3 vec){
		this.ls = vec;
		this.transform.localScale = vec;    
	}
}