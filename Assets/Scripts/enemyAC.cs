using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAC : MonoBehaviour {

	private float scaleX;
	private float scaleY;

	private EnemyControl ps;

	void Start () {
		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;

		ps = GetComponent<EnemyControl> ();
	}

	void Update () {
		gameObject.transform.localScale = new Vector3 (scaleX, scaleY, 1);
		if (ps.moveDir > 0) {
			scaleX = -Mathf.Abs (scaleX);
		}
		if (ps.moveDir < 0) {
			scaleX = Mathf.Abs (scaleX);
		}
	}
}