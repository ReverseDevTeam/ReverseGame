using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

	public GameObject player;
	public float y;
	private float x;

	void Start () {
		
	}

	void Update () {
		x = player.transform.position.x;
		transform.position = new Vector3(x, y, -5f);
	}
}
