using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl : MonoBehaviour {

	public float moveSpeed = 2;
	public float maxDisRight;
	public float maxDisLeft;

	private float intPos;
	private Rigidbody2D rb;
	[HideInInspector]
	public int moveDir;
	private Collider2D coll;

	public Collider2D cameraColl;


	void Start () {
		intPos = transform.position.x;

		rb = GetComponent<Rigidbody2D> ();
		coll = GetComponent<Collider2D> ();

		moveDir = 1;

		Physics2D.IgnoreCollision (coll, cameraColl);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.transform.position.x <= intPos - maxDisLeft)							//max left
			moveDir = 1;
		if (rb.transform.position.x >= intPos + maxDisRight)						//max right
			moveDir = -1;
		rb.velocity = new Vector2 (moveDir * moveSpeed, rb.velocity.y);
	}
}
