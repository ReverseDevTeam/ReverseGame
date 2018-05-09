using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCamera : MonoBehaviour {

	public float speed;

	private float y;
	private float z;

	private GameObject player;
	private PlayerControl ps;

	void Start () {
		player = GameObject.FindWithTag ("Player");
		y = transform.position.y;
		z = transform.position.z;
		ps = player.GetComponent<PlayerControl> ();
	}

	void Update () {

		transform.Translate (speed * Time.deltaTime, 0, 0);

		if (ps.res == true) {
			transform.position = new Vector3 (ps.checkpointX, y, z);
			ps.res = false;
		}
	}
}