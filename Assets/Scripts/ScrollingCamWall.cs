using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCamWall : MonoBehaviour {

	private Collider2D col;
	private GameObject enemy;
	private Collider2D enemycol;

	void Start () {
		col = GetComponent<BoxCollider2D> ();
		enemy = GameObject.FindWithTag ("Enemy");
		enemycol = enemy.GetComponent<BoxCollider2D> ();

		Physics2D.IgnoreCollision (col, enemycol);
	}
}