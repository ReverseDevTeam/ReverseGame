using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl : MonoBehaviour {

	public float moveSpeed = 2;
	private Rigidbody2D rb;
	private int moveDir;
	private Collider2D coll;

	public Collider2D cameraColl;

	// Use this for initialization

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		coll = GetComponent<Collider2D> ();


		moveDir = 1;

		Physics2D.IgnoreCollision (coll, cameraColl);
		//Physics2D.IgnoreCollision (coll, cameraCollR);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.transform.position.x <= 3)
			moveDir = 1;
		if (rb.transform.position.x >= 7)
			moveDir = -1;
		rb.velocity = new Vector2 (moveDir * moveSpeed, rb.velocity.y);
	}
}
